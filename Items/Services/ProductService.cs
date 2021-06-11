using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{

    public class ProductService : IProductService
    {
        private readonly ItemFeedContext _context;

        public ProductService(ItemFeedContext context)
        {
            this._context = context;
        }

        public async Task<List<Item>> GetItems() => await this._context.Items.ToListAsync();

        public async Task<Item> GetItem(int id) => await this._context.Items.Where(m => m.Id == id).FirstOrDefaultAsync();

        public async Task<Item> CreateItem(Item item)
        {
            await this._context.Items.AddAsync(item);
            await this._context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteItem(Item item)
        {
            this._context.Items.Remove(item);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<Item>> SearchItems(string term)
        {
            var query = this._context.Items.AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                var cleanTerm = term.ToLowerInvariant().Trim();
                query = query.Where(m => m.Title.ToLowerInvariant().Contains(cleanTerm) || (m.Description != null && m.Description.ToLowerInvariant().Contains(cleanTerm)));
            }

            return await query.ToListAsync();
        }

        public async Task UpdateItem(Item item)
        {
            this._context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

