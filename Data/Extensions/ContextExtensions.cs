using Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Extensions;

public static class ContextExtensions
{
    public static void ApplyCustomConfigurations(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ToysConfig());
        builder.ApplyConfiguration(new CompanyConfig());
    }
}
