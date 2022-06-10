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
       
        //TODO: Test with no toys
        public async Task<ActionResult<IEnumerable<ToysModel>>> GetToys() =>
            await _context.Toys.ToListAsync();

        //TODO: Find will throw an exception if the Id doesnt exist, you can use FirstOrDefault
        //https://arwsoftware.wordpress.com/2017/02/04/entity-framework-find-vs-firstordefault/
        public async Task<ToysModel> GetToyById(int? id) =>
         await _context.Toys.FindAsync(id);
         
        public async Task AddToy(ToysModel toy)
        {
            //TODO: Same, error not being validated
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

            //TODO: Try to use Automapper instead
            Toy.Name = request.Name;
            Toy.Description = request.Description;
            Toy.AgeRestriction = request.AgeRestriction;
            Toy.Company = request.Company;
            Toy.Price = request.Price;


            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteToy(int? id)
        {
            //TODO: Same here The find might cause exceptions if the ID is not found
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


