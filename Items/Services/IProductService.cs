using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services
{
    public  interface IProductService
    {
        Task<Item> CreateItem(Item item);
        Task DeleteItem(Item item);
        Task<Item> GetItem(int id);
        Task<List<Item>> GetItems();
        Task<List<Item>> SearchItems(string term);
        Task UpdateItem(Item item);
    }
}
