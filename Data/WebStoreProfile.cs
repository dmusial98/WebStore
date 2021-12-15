using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebStore.Data.Entities;
using WebStore.Models;

namespace WebStore.Data
{
    public class WebStoreProfile : Profile
    {
        public WebStoreProfile()
        {
            this.CreateMap<Product, ProductModel>()
                .ReverseMap();

            this.CreateMap<ProductInCart, ProductInCartModel>()
                .ReverseMap();

            this.CreateMap<User, UserModel>()
                .ReverseMap();

            this.CreateMap<Opinion, OpinionModel>()
                .ReverseMap();

            this.CreateMap<Store, StoreModel>()
                .ReverseMap();

            this.CreateMap<StoreDescription, StoreDescriptionModel>()
                .ReverseMap();

            this.CreateMap<StoreHours, StoreHoursModel>()
                .ReverseMap();

            this.CreateMap<StoreTelephoneNumber, StoreTelephoneNumberModel>()
                .ReverseMap();

            this.CreateMap<StoreEMail, StoreEMailModel>()
                .ReverseMap();

        }
    }
}
