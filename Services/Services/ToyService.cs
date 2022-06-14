using Services.Contracts;
using Services.DTO;
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
using AutoMapper;
using System.Data.Entity;

namespace Services.Services
{
    public class ToyService : IToyService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ToyService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ToysViewModel>> GetToys()
        {
            return _context.Toys.ToList().Select(x => _mapper.Map<Toys, ToysViewModel>(x)).ToList();
        }

            //    List <ToysViewModel> toys = _context.Toys.ToListAsync();
            //    return _mapper.Map<ToysViewModel>(toys);
            //}
            //_context.Toys
            //.Select(x => new ToysViewModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    AgeRestriction = x.AgeRestriction,
            //    CompanyId = x.CompanyId,
            //    Price = x.Price
            //})
            //.ToListAsync();



        public async Task<ToysViewModel?> GetToyById(int? id)
        {
            var Toy = await _context.Toys.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ToysViewModel>(Toy);

        }


        //_context.Toys
        //  .Select(x => new ToysViewModel
        //  {
        //      Id = id,
        //      Name = x.Name,
        //      Description = x.Description,
        //      AgeRestriction = x.AgeRestriction,
        //      CompanyId = x.CompanyId,
        //      Price = x.Price
        //  })
        //  .FirstOrDefaultAsync(x => x.Id == id);



        public async Task AddToy(ToysDTO toy)
        {
            try
            {
                _context.Add(_mapper.Map<Toys>(toy));
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Toy could not been added {ex}");
            }

            //    try
            //    {
            //        var newToy = new Toys

            //        {
            //            Name = toy.Name,
            //            Description = toy.Description,
            //            AgeRestriction = toy.AgeRestriction,
            //            CompanyId = toy.CompanyId,
            //            Price = toy.Price
            //        };
            //        _context.Toys.Add(newToy);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (Exception)
            //    {

            //        throw new Exception("Toy could not been added");
            //    }
        }

        public async Task<bool> UpdateToy(ToysDTO request)
        {
            try
            {
                var Toy = await _context.Toys.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (Toy is null)
                {
                    return false;
                }
                _mapper.Map(Toy, request);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Toy could not been modified {ex}");
            }
            //try
            //{
            //    var Toy = await _context.Toys.FirstOrDefaultAsync(x => x.Id == request.Id);
            //    if (Toy is null)
            //    {
            //        return false;
            //    }

            //    //TODO: Try to use Automapper instead
            //    Toy.Name = request.Name;
            //    Toy.Description = request.Description;
            //    Toy.AgeRestriction = request.AgeRestriction;
            //    Toy.CompanyId = request.CompanyId;
            //    Toy.Price = request.Price;


            //    await _context.SaveChangesAsync();

            //    return true;
            //}
            //catch (Exception)
            //{

            //    throw new Exception("Toy could not been modified");
            //}
        }

        public async Task<bool> DeleteToy(int? id)
        {
            try
            {

                var Toy = await _context.Toys.FirstOrDefaultAsync(x => x.Id == id);
                if (Toy is null)
                {
                    return false;
                }


                _context.Remove(Toy);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception($"Toy could not been deleted {ex}");
            }
        }
    }

}


