﻿using AutoMapper;
using KhoaLuan.Data.EF;
using KhoaLuan.Data.Entities;
using KhoaLuan.Data.Enums;
using KhoaLuan.ViewModels.Bill;
using KhoaLuan.ViewModels.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhoaLuan.Service.BillService
{
    public class BillService : IBillService
    {
        private readonly EnterpriseDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public BillService(EnterpriseDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<GetByOrderPlanBills>> GetByOrderPlanBills(string key)
        {
            IQueryable<OrderPlan> order;
            if (!string.IsNullOrEmpty(key))
            {
                order = _context.OrderPlans
              .Include(x => x.Responsible)
              .Where(x => x.Censorship == true && x.Status == StatusOrderPlan.Unfinished
              && (x.Code.Contains(key) || x.Name.Contains(key)));
            }
            else
            {
                order = _context.OrderPlans
              .Include(x => x.Responsible)
             .Where(x => x.Censorship == true && x.Status == StatusOrderPlan.Unfinished);
            }

            var count = await order.CountAsync();
            var result = await order
                .Select(x => new GetByOrderPlanBills()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CodeResponsible = x.Responsible.Code,
                    CreatedDate = x.CreatedDate.ToString("dd-MM-yyyyy"),
                    Distance = (DateTime.Now - x.CreatedDate).Days,
                    Count = count
                }).ToListAsync();

            return new List<GetByOrderPlanBills>(result);
        }

        public async Task<List<GetByIdOrderPlanBills>> GetByIdOrderPlanBills(long id)
        {
            var order = _context.OrderDetails
                .Include(o => o.Material)
                .Where(x => x.IdOrderPlan == id);

            var count = await order.CountAsync();
            var result = await order.Select(x => new GetByIdOrderPlanBills()
            {
                IdMaterials = x.IdMaterials,
                Amount = x.Amount,
                Code = x.Material.Code,
                Name = x.Material.Name,
                Unit = x.Unit,
                EnterAmount = x.EnterAmount,
                IdOrderDetail = x.Id,
                Count = count
            }).ToListAsync();

            return new List<GetByIdOrderPlanBills>(result);
        }

        public async Task<List<GetAllSuppliersBill>> GetAllSuppliers(string key)
        {
            var suppliers = _context.Suppliers;

            var supp = suppliers.Where(x => x.Code.Contains(key) || x.Name.Contains(key));

            var result = await supp.Select(x => new GetAllSuppliersBill()
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Address = x.Address
            }).ToListAsync();

            return new List<GetAllSuppliersBill>(result);
        }

        public async Task<ApiResult<long>> Create(CreateBill bundle)
        {
            int i = 0;
            var billDetail = new List<BillDetail>();
            double total = 0;
            foreach (var item in bundle.IdMaterials)
            {
                if (bundle.EnterAmount[i] != 0)
                {
                    double resultPrice = (bundle.EnterAmount[i] * bundle.Price[i]);
                    double money = 0;
                    if (bundle.Discount[i] != 0)
                    {
                        int percentComplete = (int)Math.Round((double)(resultPrice * bundle.Discount[i]) / 100);

                        money = (resultPrice - percentComplete);
                        total += money;
                    }
                    else
                    {
                        total += resultPrice;
                        money = resultPrice;
                    }

                    billDetail.Add(new BillDetail()
                    {
                        IdMaterials = item,
                        Amount = bundle.EnterAmount[i],
                        Discount = bundle.Discount[i],
                        Price = (decimal)(bundle.Price[i]),
                        TotalPrice = (decimal)money,
                        Unit = bundle.Unit[i]
                    });

                    // cập nhật số lượng chi tiết đặt hàng
                    var orderDetail = await _context.OrderDetails.FindAsync(bundle.IdOrderDetail[i]);
                    var enterAmountNow = orderDetail.EnterAmount + bundle.EnterAmount[i];
                    if (enterAmountNow >= bundle.Amount[i])
                    {
                        orderDetail.Status = true;
                    }
                    orderDetail.EnterAmount = enterAmountNow;
                    _context.OrderDetails.Update(orderDetail);
                    await _context.SaveChangesAsync();
                }
                i++;
            }

            if (bundle.Tax != 0)
            {
                int tax = (int)Math.Round((double)(total * bundle.Tax) / 100);
                total += tax;
            }

            // chuyển số thành chữ
            var convert = "";
            if (total != 0)
            {
                convert = this.NumberToText(total);
            }

            var bill = new Bill()
            {
                AmountPaid = Decimal.Parse(bundle.AmountPaid),
                IdPlan = bundle.IdOrderPlan,
                IdSupplier = bundle.IdSupliers,
                PurchaseDate = bundle.PurchaseDate,
                CodeBill = bundle.CodeBill,
                Tax = bundle.Tax,
                CreatedDate = DateTime.Now,
                TotalMoney = (decimal)total,
                ConvertNumbers = convert,
                BillDetails = billDetail,
            };

            var amountPaid = Double.Parse(bundle.AmountPaid);
            if (amountPaid == 0)
            {
                bill.PaymentStatus = PaymentStatus.Unpaid;
            }

            if (amountPaid > 0 && amountPaid < total)
            {
                bill.PaymentStatus = PaymentStatus.PartialPayment;
            }

            if (amountPaid >= total)
            {
                bill.PaymentStatus = PaymentStatus.Paid;
            }

            // tạo code
            var user = await _userManager.FindByNameAsync(bundle.NameCreator);
            bill.IdCreator = user.Id;

            var code = await _context.ManageCodes.FirstOrDefaultAsync(x => x.Name == bundle.StorageCode);
            Location:
            var location = code.Location + 1;

            var str = code.Name + location;

            var checkCode = await _context.Bills.AnyAsync(x => x.StorageCode == str);
            if (checkCode)
            {
                goto Location;
            }

            code.Location = location;
            _context.ManageCodes.Update(code);
            await _context.SaveChangesAsync();

            bill.StorageCode = str;

            // cập nhật trạng thái kế hoạch đặt hàng
            var check = true;
            var orderPlan = await _context.OrderPlans.Include(x => x.OrderDetails)
                .Where(x => x.Id == bundle.IdOrderPlan).FirstOrDefaultAsync();

            foreach (var item in orderPlan.OrderDetails)
            {
                if (!item.Status)
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                orderPlan.Status = StatusOrderPlan.Accomplished;
                _context.OrderPlans.Update(orderPlan);
            }

            //tạo hóa đơn
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<long>(bill.Id);
        }

        public async Task<List<GetAllPaymentStautsBill>> GetAllUnpaidBill(string key)
        {
            IQueryable<Bill> bill;
            if (!string.IsNullOrEmpty(key))
            {
                bill = _context.Bills.Include(x => x.BillDetails)
                    .Where(b => (b.StorageCode.Contains(key) || b.CodeBill.Contains(key))
                    && (b.PaymentStatus == PaymentStatus.Unpaid || b.PaymentStatus == PaymentStatus.PartialPayment));
            }
            else
            {
                bill = _context.Bills.Include(x => x.BillDetails)
                   .Where(b => b.PaymentStatus == PaymentStatus.Unpaid || b.PaymentStatus == PaymentStatus.PartialPayment);
            }

            bill = bill.Include(x => x.OrderPlan);
            bill = bill.Include(x => x.Creator);
            var count = await bill.CountAsync();

            var result = await bill.OrderByDescending(x => x.Id)
            .Select(x => new GetAllPaymentStautsBill()
            {
                Id = x.Id,
                CodeBill = x.CodeBill,
                StorageCode = x.StorageCode,
                CreatedDate = x.CreatedDate.ToString("dd-MM-yyyy"),
                CodePlan = x.OrderPlan.Code,
                CodeCreator = x.Creator.Code,
                Count = count,
                PaymentMoeny = x.AmountPaid,
                TotalMoney = x.TotalMoney
            }).ToListAsync();

            return new List<GetAllPaymentStautsBill>(result);
        }

        public async Task<ApiResult<PagedResult<GetAllPaymentStautsBill>>> GetAllPaidBill(GetAllPaidBillPanning bundle)
        {
            IQueryable<Bill> bill;
            if (!string.IsNullOrEmpty(bundle.Keyword))
            {
                bill = _context.Bills.Include(x => x.BillDetails).Include(s => s.OrderPlan)
                    .Where(b => (b.StorageCode.Contains(bundle.Keyword) ||
                    b.CodeBill.Contains(bundle.Keyword) || b.OrderPlan.Code.Contains(bundle.Keyword))
                    && b.PaymentStatus == PaymentStatus.Paid &&
                                            b.OrderPlan.Status == StatusOrderPlan.Accomplished);
            }
            else
            {
                bill = _context.Bills.Include(x => x.BillDetails)
                                    .Where(b => b.PaymentStatus == PaymentStatus.Paid &&
                                            b.OrderPlan.Status == StatusOrderPlan.Accomplished);
            }

            bill = bill.Include(x => x.OrderPlan);
            bill = bill.Include(x => x.Creator);

            var result = await bill.OrderByDescending(x => x.Id).
                Skip((bundle.PageIndex - 1) * bundle.PageSize)
              .Take(bundle.PageSize)
            .Select(x => new GetAllPaymentStautsBill()
            {
                Id = x.Id,
                CodeBill = x.CodeBill,
                StorageCode = x.StorageCode,
                CreatedDate = x.CreatedDate.ToString("dd-MM-yyyy"),
                CodePlan = x.OrderPlan.Code,
                CodeCreator = x.Creator.Code
            }).ToListAsync();

            //3. Paging
            int totalRow = await bill.CountAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<GetAllPaymentStautsBill>()
            {
                TotalRecords = totalRow,
                PageIndex = bundle.PageIndex,
                PageSize = bundle.PageSize,
                Items = result
            };
            return new ApiSuccessResult<PagedResult<GetAllPaymentStautsBill>>(pagedResult);
        }

        public async Task<ApiResult<GetBillById>> GetBillById(long id)
        {
            var bill = _context.Bills;

            var resultBills = bill.Include(x => x.BillDetails)
                .ThenInclude(d => d.Material)
                .Where(x => x.Id == id);

            if (resultBills == null)
            {
                return new ApiErrorResult<GetBillById>("Hóa đơn không tồn tại");
            }

            var orderPlan = resultBills.Include(o => o.OrderPlan);
            var supplier = resultBills.Include(s => s.Supplier);
            var user = resultBills.Include(c => c.Creator);

            var result = await user.Select(x => new GetBillById()
            {
                Id = x.Id,
                CodeBill = x.CodeBill,
                StorageCode = x.StorageCode,
                PurchaseDate = x.PurchaseDate.ToString("dd-MM-yyyy"),
                PurchaseDateDefault = x.PurchaseDate.ToString("yyyy-MM-dd"),
                CreatedDate = x.CreatedDate.ToString("dd-MM-yyyy"),
                Tax = x.Tax,
                PaymentStatus = x.PaymentStatus == PaymentStatus.PartialPayment ? "Thanh toán một phần" :
                            x.PaymentStatus == PaymentStatus.Unpaid ? "Chưa thanh toán" : "Đã thanh toán",
                AmountPaid = x.AmountPaid,
                CodeSupplier = x.Supplier.Code,
                IdSupplier = x.Supplier.Id,
                CodePlan = x.OrderPlan.Code,
                IdPlan = x.IdPlan,
                CodeCreator = x.Creator.Code,
                TotalMoney = x.TotalMoney,
                ConvertNumbers = x.ConvertNumbers != null ? x.ConvertNumbers : "",
                ListBillDetails = x.BillDetails
                    .Select(d => new ListBillDetail()
                    {
                        IdBillDetail = d.Id,
                        Amount = d.Amount,
                        AmountOrder = x.OrderPlan.OrderDetails
                        .Where(a => a.IdMaterials == d.IdMaterials && a.Unit == d.Unit)
                        .Select(d => d.Amount).FirstOrDefault(),
                        EnterAmountOrder = x.OrderPlan.OrderDetails
                        .Where(a => a.IdMaterials == d.IdMaterials).Select(d => d.EnterAmount).FirstOrDefault(),
                        IdMaterials = d.IdMaterials,
                        Unit = d.Unit,
                        Price = d.Price,
                        Discount = d.Discount,
                        TotalPrice = d.TotalPrice,
                        CodeMaterials = d.Material.Code,
                        NameMaterials = d.Material.Name
                    }).ToList(),
            }).FirstOrDefaultAsync();

            var listNotIdBill = _context.OrderDetails.Include(x => x.Material)
                .Where(x => x.IdOrderPlan == result.IdPlan);

            var countBill = await listNotIdBill.CountAsync();
            if (countBill > 0)
            {
                foreach (var item in result.ListBillDetails)
                {
                    listNotIdBill = listNotIdBill.Where(x => x.IdMaterials != item.IdMaterials);
                }

                var listResult = await listNotIdBill.Select(x => new ListBillDetail()
                {
                    IdMaterials = x.IdMaterials,
                    AmountOrder = x.Amount,
                    EnterAmountOrder = x.EnterAmount,
                    CodeMaterials = x.Material.Code,
                    NameMaterials = x.Material.Name,
                    Unit = x.Unit
                }).ToListAsync();

                result.ListBillDetailNotIds = listResult;
            }

            return new ApiSuccessResult<GetBillById>(result);
        }

        private string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }

            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";

            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }

        public async Task<ApiResult<ReturnUpdate>> Update(UpdateBill bundle)
        {
            var bill = await _context.Bills.Include(x => x.BillDetails)
                .FirstOrDefaultAsync(x => x.Id == bundle.IdBill);
            if (bill == null)
            {
                return new ApiErrorResult<ReturnUpdate>("Không tồn tại hóa đơn");
            }

            var billDetails = new List<BillDetail>();
            var i = 0;
            double total = 0;
            foreach (var item in bundle.IdMaterials)
            {
                double resultPrice = (bundle.EnterAmount[i] * bundle.Price[i]);
                double money = 0;

                if (bundle.Discount[i] != 0)
                {
                    int percentComplete = (int)Math.Round((double)(resultPrice * bundle.Discount[i]) / 100);

                    money = (resultPrice - percentComplete);
                    total += money;
                }
                else
                {
                    total += resultPrice;
                    money = resultPrice;
                }

                // cập nhật số lượng: lấy số lượng nhập trừ số lượng hiện tại
                var bd = bill.BillDetails.FirstOrDefault(x => x.IdMaterials == item);
                var howAmount = bundle.EnterAmount[i] - bd.Amount;

                var orderD = await _context.OrderDetails.FirstOrDefaultAsync(x => x.IdOrderPlan == bill.IdPlan
                && x.IdMaterials == bundle.IdMaterials[i]);

                var amountNew = howAmount + orderD.EnterAmount;

                orderD.EnterAmount = amountNew;
                // cập nhật số lượng chi tiết đặt hàng
                if (amountNew >= orderD.Amount)
                {
                    orderD.Status = true;
                }
                else
                {
                    orderD.Status = false;
                }

                _context.OrderDetails.Update(orderD);
                await _context.SaveChangesAsync();

                bd.Price = (decimal)bundle.Price[i];
                bd.Discount = bundle.Discount[i];
                bd.Amount = bundle.EnterAmount[i];
                bd.TotalPrice = (decimal)money;

                i++;
            }

            // khởi tạo thêm nguyên vật liệu vào hóa đơn
            if (bundle.EnterAmountCreate != null)
            {
                int y = 0;
                foreach (var create in bundle.EnterAmountCreate)
                {
                    if (create != 0)
                    {
                        double resultPrice = (bundle.EnterAmountCreate[y] * bundle.PriceCreate[y]);
                        double money = 0;
                        if (bundle.Discount[i] != 0)
                        {
                            int percentComplete = (int)Math.Round((double)(resultPrice * bundle.DiscountCreate[y]) / 100);

                            money = (resultPrice - percentComplete);
                            total += money;
                        }
                        else
                        {
                            total += resultPrice;
                            money = resultPrice;
                        }

                        var billOr = new BillDetail()
                        {
                            IdBill = bundle.IdBill,
                            Amount = create,
                            Discount = bundle.DiscountCreate[y],
                            Unit = bundle.UnitCreate[y],
                            Price = (decimal)bundle.PriceCreate[y],
                            TotalPrice = (decimal)money,
                            IdMaterials = bundle.IdMaterialsCreate[y]
                        };
                        _context.BillDetails.Add(billOr);

                        // cập nhật số lượng chi tiết đặt hàng
                        var orderD = await _context.OrderDetails.FirstOrDefaultAsync(x => x.IdOrderPlan == bill.IdPlan);
                        var enterAmountNow = orderD.EnterAmount + bundle.EnterAmountCreate[y];
                        if (enterAmountNow >= orderD.Amount)
                        {
                            orderD.Status = true;
                        }
                        else
                        {
                            orderD.Status = false;
                        }
                        orderD.EnterAmount = enterAmountNow;
                        _context.OrderDetails.Update(orderD);
                        await _context.SaveChangesAsync();
                    }
                    y++;
                }
            }

            if (bundle.Tax != 0)
            {
                int tax = (int)Math.Round((double)(total * bundle.Tax) / 100);
                total += tax;
            }

            // chuyển số thành chữ
            var convert = "";

            if (total != 0)
            {
                convert = this.NumberToText(total);
            }

            bill.IdSupplier = bundle.IdSupliers;
            bill.PurchaseDate = bundle.PurchaseDate;
            bill.Tax = bundle.Tax;
            bill.AmountPaid = Decimal.Parse(bundle.AmountPaid);
            bill.CodeBill = bundle.CodeBill;
            bill.ConvertNumbers = convert;
            bill.TotalMoney = (decimal)total;
            // cập nhật trạng thái
            var amountPaid = Double.Parse(bundle.AmountPaid);
            if (amountPaid == 0)
            {
                bill.PaymentStatus = PaymentStatus.Unpaid;
            }

            if (amountPaid > 0 && amountPaid < total)
            {
                bill.PaymentStatus = PaymentStatus.PartialPayment;
            }

            if (amountPaid >= total)
            {
                bill.PaymentStatus = PaymentStatus.Paid;
            }

            // cập nhật trạng thái kế hoạch đặt hàng
            var check = true;
            var orderPlan = await _context.OrderPlans.Include(x => x.OrderDetails)
                .Where(x => x.Id == bill.IdPlan).FirstOrDefaultAsync();
            foreach (var item in orderPlan.OrderDetails)
            {
                if (!item.Status)
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                orderPlan.Status = StatusOrderPlan.Accomplished;
            }
            else
            {
                orderPlan.Status = StatusOrderPlan.Unfinished;
            }
            _context.OrderPlans.Update(orderPlan);

            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();

            var countBills = await _context.BillDetails.Where(x => x.IdBill == bill.Id).ToListAsync();
            var delete = false;
            if (countBills == null)
            {
                delete = true;
            }
            else
            {
                foreach (var item in countBills)
                {
                    if (item.Amount != 0)
                    {
                        delete = false;
                        break;
                    }
                    else
                    {
                        delete = true;
                    }
                }
            }

            var pay = true;
            if (bill.PaymentStatus == PaymentStatus.Paid)
            {
                pay = false;
            }
            var result = new ReturnUpdate()
            {
                StatusOrder = delete,
                PaymentStatus = pay,
                CodeBill = bill.CodeBill,
                Id = bill.Id
            };

            if (delete)
            {
                await this.Delete(result.Id);
            }
            return new ApiSuccessResult<ReturnUpdate>(result);
        }

        public async Task<ApiResult<bool>> Delete(long id)
        {
            var bill = await _context.Bills
                .Include(x => x.BillDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (bill == null)
            {
                return new ApiErrorResult<bool>("Không tồn tại hóa đơn");
            }

            if (bill.BillDetails != null)
            {
                foreach (var item in bill.BillDetails)
                {
                    // cập nhật số lượng:
                    var bd = bill.BillDetails.FirstOrDefault(x => x.IdMaterials == item.IdMaterials);

                    var orderD = await _context.OrderDetails.FirstOrDefaultAsync(x => x.IdOrderPlan == bill.IdPlan
                    && x.IdMaterials == item.IdMaterials);

                    var amountNew = orderD.EnterAmount - bd.Amount;

                    orderD.EnterAmount = amountNew;
                    orderD.Status = false;

                    _context.OrderDetails.Update(orderD);

                    var orderPlan = await _context.OrderPlans.Include(x => x.OrderDetails)
                                   .Where(x => x.Id == bill.IdPlan).FirstOrDefaultAsync();
                    orderPlan.Status = StatusOrderPlan.Unfinished;
                    _context.OrderPlans.Update(orderPlan);

                    await _context.SaveChangesAsync();
                }
            }

            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> UpdateUnpaid(UpdateUnpaid bundle)
        {
            var bill = await _context.Bills.FindAsync(bundle.Id);

            if (bill == null)
            {
                return new ApiErrorResult<bool>("Không tồn tại hóa đơn");
            }

            decimal amountPaid = Decimal.Parse(bundle.Money);

            bill.AmountPaid = amountPaid;
            if (amountPaid == 0)
            {
                bill.PaymentStatus = PaymentStatus.Unpaid;
            }

            if (amountPaid > 0 && amountPaid < bill.TotalMoney)
            {
                bill.PaymentStatus = PaymentStatus.PartialPayment;
            }

            if (amountPaid >= bill.TotalMoney)
            {
                bill.PaymentStatus = PaymentStatus.Paid;
            }

            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>();
        }
    }
}