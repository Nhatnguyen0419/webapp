﻿
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using eShopSolution.Application.Commom;
using eShopSolution.ViewModels.Catalog.Common;
using eShopSolution.ViewModels.Catalog.Products.Manage;
namespace eShopSolution.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly EShopDbContext _context;
        private readonly IStorageService _storageService;

        public ManageProductService(EShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {

            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                    {
                        new ProductTranslation()
                        {
                            Name =  request.Name,
                            Description = request.Description,
                            Details = request.Details,
                            SeoDescription = request.SeoDescription,
                            SeoAlias = request.SeoAlias,
                            SeoTitle = request.SeoTitle,
                            LanguageId = request.LanguageId
                        }
                    }
            };
            //Save Image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product == null) throw new EShopException("Cannot find a product:{productId}");
            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }


        public async Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
        {
            //1.Selection join
            /*
             select * from Products p
             join ProductTranslations pt on p.Id = pt.ProductId 
             join ProductInCategories pic on p.id=pic.productid
             join Categories c on pic.CategoryId = c.Id
             where p.id = 1

            */
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            //2.filter

            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }

            //3.Paging
            int totalRow = await query.CountAsync();

            var data = await query
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)

                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.p.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount

                })
                .ToListAsync();
            //4. Select and projection
            var pagedResult = new PageResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;

        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
                                                                                                  && x.LanguageId == request.LanguageId);

            if (product == null || productTranslations == null) throw new EShopException($"Cannot find a product with id: {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            /*tim sp voi id...
            var product =await _context.Products.FindAsync(ProductId);
            if (product == null)
            {
                throw new EShopException($"Cannot find a product:{productId}");
            }
            // update sp
            product.Price = newPrice;
            // lưu
            await _context.SaveChangesAsync();
            return await Task.FromResult(true);
            */
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Cannot find a product with id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            //var product = await _context.Products.FindAsync(productId);
            //product.
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new EShopException($"Cannot find a product with id: {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

    }
}