using McvCrudDepartamentosEFCore2022.Data;
using McvCrudDepartamentosEFCore2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McvCrudDepartamentosEFCore2022.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context) 
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos() 
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int id) 
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == id
                           select datos;
            //esto solo devuelve cuando devuelve un valor o sino un null
            //SOLO SIRVE SI DEVUELVES UN OBJETO
            return consulta.FirstOrDefault();
        }
    }
}
