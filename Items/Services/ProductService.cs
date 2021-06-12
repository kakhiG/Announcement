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
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            this._context = context;
        }

        public async Task<List<Announcement>> GetItems() => await this._context.Announcements.ToListAsync();

        public async Task<Announcement> GetItem(int id) => await this._context.Announcements.Where(m => m.Id == id).FirstOrDefaultAsync();

        public async Task<Announcement> CreateItem(Announcement item)
        {
            await this._context.Announcements.AddAsync(item);
            await this._context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteItem(Announcement item)
        {
            this._context.Announcements.Remove(item);
            await this._context.SaveChangesAsync();
        }

        public async Task<List<Announcement>> SearchItems(string term)
        {
            var query = this._context.Announcements.AsQueryable();

            if (!string.IsNullOrEmpty(term))
            {
                var cleanTerm = term.ToLowerInvariant().Trim();
                query = query.Where(m => m.Title.ToLower().Contains(cleanTerm) || (m.Description != null && m.Description.ToLower().Contains(cleanTerm)));
            }

            return await query.ToListAsync();
        }

        public async Task UpdateItem(Announcement item)
        {
            this._context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

