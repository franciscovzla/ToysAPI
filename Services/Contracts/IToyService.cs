using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace Services.Contracts
{
   public interface IToyService
    {
        Task <ActionResult<IEnumerable<ToysModel>>> GetToys();
        Task<ToysModel>GetToyById(int? id);
        Task AddToy(ToysModel toy);
        Task<bool> UpdateToy(ToysModel toy);
        Task<bool> DeleteToy(int? id);
    }
}
