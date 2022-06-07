using Services.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class ToyService : IToyService
    {
        private readonly DataContext _context;
        public ToyService(DataContext context)
        {
            _context = context;
        }
       
        public async Task<ActionResult<IEnumerable<ToysModel>>> GetToys() =>
            await _context.Toys.ToListAsync();

        public async Task<ToysModel> GetToyById(int id) =>
         await _context.Toys.FindAsync(id);
            
            
        
        public async Task AddToy(ToysModel toy)
        {
            _context.Toys.Add(toy);
            await _context.SaveChangesAsync();

           
        }

        public async Task<bool> UpdateToy(ToysModel request)
        {
            var Toy = await _context.Toys.FindAsync(request.Id);
            if (Toy is null)
            {
                return false;
            }

            Toy.Name = request.Name;
            Toy.Description = request.Description;
            Toy.AgeRestriction = request.AgeRestriction;
            Toy.Company = request.Company;
            Toy.Price = request.Price;


            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteToy(int id)
        {
            var Toy = await _context.Toys.FindAsync(id);
            if (Toy is null)
            {
                return false;
            }
                

            _context.Remove(Toy);
            await _context.SaveChangesAsync();
            return true;
        }
    }

    }


