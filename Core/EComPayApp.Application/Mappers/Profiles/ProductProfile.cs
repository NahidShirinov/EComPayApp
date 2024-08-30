﻿using AutoMapper;
using EComPayApp.Application.DTOs.ProductDtos;
using EComPayApp.Application.Features.CQRS.Commands.Products.CreateProduct;
using EComPayApp.Application.Features.CQRS.Queries.Products.GetProduct;
using EComPayApp.Domain.Entities;


namespace EComPayApp.Application.Mappers.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, GetProductResponse>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
        }
    }

}
