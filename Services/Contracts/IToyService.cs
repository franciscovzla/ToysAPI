using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.DTO;
namespace Services.Contracts
{
   public interface IToyService
    {
        Task<List<ToysViewModel>> GetToys();
        Task<ToysViewModel?>GetToyById(int? id);
        Task AddToy(ToysDTO toy);
        Task<bool> UpdateToy(ToysDTO toy);
        Task<bool> DeleteToy(int? id);
    }
}
