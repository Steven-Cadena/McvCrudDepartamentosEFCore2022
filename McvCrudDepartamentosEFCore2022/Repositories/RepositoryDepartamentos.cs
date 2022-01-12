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
        //METODO PARA OBTENER EL ID MAXIMO DE DEPARTAMENTO
        private int GetMaxIdDepartamento() 
        {
            //SI LA TABLA NO TUVIERA REGISTRO ESTO NOS DA EXCEPCION PORQUE NO PUEDE RECUPERAR DE NULL

            //NECESITAMOS UN LAMBDA PARA RECUPERAR EL MAXIMO
            //DE LA COLECCION DbSet DE DEPARTAMENTOS
            int maximo = this.context.Departamentos.Max(x => x.IdDepartamento) + 1;
            return maximo;
        }

        public void InsertarDepartamento(string nombre,string localidad) 
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = this.GetMaxIdDepartamento();
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            //agregamos la dbset de departamentos
            this.context.Departamentos.Add(departamento);
            //guardamos los cambios
            this.context.SaveChanges();
        }
        public void DeleteDepartamento(int id) 
        {
            //BUSCAMOS ELOBJETO/OBJETOS A ELIMINAR
            Departamento departamento = this.FindDepartamento(id);
            //hacemos la accion 
            this.context.Departamentos.Remove(departamento);
            //y guardamos los cambios para almacenarlos en la BBDD 
            this.context.SaveChanges();
        }

        public void UpdateDepartamento(int id, string nombre, string localidad) 
        {
            //buscamos el departamento
            Departamento departamento = this.FindDepartamento(id);
            //modificamos los datos 
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            //guardamos los cambios
            this.context.SaveChanges();
        }
    }
}
