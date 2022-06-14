using Services.Contracts;
using Services.DTO;
using Models;
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

        public async Task<ToysViewModel?> GetToyById(int? id)
        {
            var Toy = await _context.Toys.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ToysViewModel>(Toy);

        }

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


