using McvCrudDepartamentosEFCore2022.Models;
using McvCrudDepartamentosEFCore2022.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McvCrudDepartamentosEFCore2022.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult EmpleadosSalario() 
        {
            //LA PRIMERA VEZ DEVOLVEMOS TODOS LOS EMPLEADOS
            List<Empleado> empleados = this.repo.GetEmpleados();
            //NECESITAMOS LOS OFICIOS PARA DIBUJARLOS DENTRO DEL DESPLEGABLE
            List<String> oficios = this.repo.GetOficios();
            //TENEMOS QUE ENVIAR DOS OBJETOS A LA MISMA VISTA
            //COMO RECORDAMOS, SOLAMENTE PODEMOS TENER UN MODEL
            //POR CADA VISTA
            //ENVIAREMOS LOS OFICIOS POR ViewData/ViewBag
            //ENVIAREMOS POR MODEL LOS EMPLEADOS
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }
        [HttpPost]
        public IActionResult EmpleadosSalario(string oficio, int incremento) 
        {
            this.repo.IncrementarSalarioOficio(oficio, incremento);
            //RECUPERAMOS LOS EMPLEADOS POR OFICIOS
            List<Empleado> empleados = this.repo.GetEmpleadosOficio(oficio);
            //QUEREMOS SEGUIR DIBUJANDO EL DESPLEGABLE A PESAR 
            //DE SER EL POST, ES DECIR, NECESITAMOS TAMBIEN LOS OFICIOS
            List<string> oficios = this.repo.GetOficios();
            ViewData["OFICIOS"] = oficios;
            return View(empleados);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmpleadosDepartamento(int id) 
        {
            List<Empleado> empleados = this.repo.GetEmpleadosDepartamento(id);
            return View(empleados);
        }

        public IActionResult EmpleadosResumen(int iddepartamento) 
        {
            ResumenEmpleados resumen = this.repo.GetResumenEmpleados(iddepartamento);
            //comprobamos que no sea null el resumen 
            if (resumen == null)
            {
                ViewBag.Mensaje = "No existen empleados en el departamento.";
                return View();
            }
            else
            {
                return View(resumen);
            }
        }
    }
}
