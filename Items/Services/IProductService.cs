using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public  interface IProductService
    {
        Task<Announcement> CreateItem(Announcement item);
        Task DeleteItem(Announcement item);
        Task<Announcement> GetItem(int id);
        Task<List<Announcement>> GetItems();
        Task<List<Announcement>> SearchItems(string term);
        Task UpdateItem(Announcement item);
    }
}
