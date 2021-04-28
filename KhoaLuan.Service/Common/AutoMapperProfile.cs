using AutoMapper;
using KhoaLuan.Data.Entities;
using KhoaLuan.ViewModels;
using KhoaLuan.ViewModels.Material;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
using KhoaLuan.ViewModels.Product;
using KhoaLuan.ViewModels.ProductType;
using KhoaLuan.ViewModels.ProductTypeGroup;
using KhoaLuan.ViewModels.Supplier;
using KhoaLuan.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhoaLuan.Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //User
            CreateMap<RegisterRequest, AppUser>();
            CreateMap<UserUpdateRequest, AppUser>();
            CreateMap<AppUser, UserVm>();
            CreateMap<AppUser, UserNameVm>();
            CreateMap<AppUser, GetByIdListUser>();

            //MaterialsType
            CreateMap<CreateMaterialsType, MaterialsType>();
            CreateMap<UpdateMaterialsType, MaterialsType>();

            //ProductTypeGroup
            CreateMap<CreateProductTypeGroup, ProductTypeGroup>();
            CreateMap<UpdateProductTypeGroup, ProductTypeGroup>();

            //ProductType
            CreateMap<CreateProductType, ProductType>();
            CreateMap<UpdateProductType, ProductType>();

            //Product
            CreateMap<ProductUpdate, Product>();

            //Product
            CreateMap<MaterialUpdate, Material>();

            //Supplier
            CreateMap<SupplierCreate, Supplier>();
            CreateMap<SupplierUpdate, Supplier>();
            CreateMap<Supplier, GetByIdListSupplier>();
        }
    }
}