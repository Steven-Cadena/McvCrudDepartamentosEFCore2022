using McvCrudDepartamentosEFCore2022.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McvCrudDepartamentosEFCore2022.Data
{
    public class DepartamentosContext: DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options) { }
        
        public DbSet<Departamento> Departamentos { get; set; }
    }
}
