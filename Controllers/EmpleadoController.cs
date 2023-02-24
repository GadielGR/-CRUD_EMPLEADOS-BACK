using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empleados.Dominio;
using Empleados.Application.Services;
using Empleados.Infrastructure.Data.context;
using Empleados.Infrastructure.Data.repositories;

namespace Empleados.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        EmpleadoService CreateService()
        {
            EmpleadoContext db = new EmpleadoContext();
            EmpleadoRepository repo = new EmpleadoRepository(db);
            EmpleadoService service = new EmpleadoService(repo);
            return service;
        }

        [HttpGet]
        public ActionResult<List<Empleado>> Get()
        {
            var service = CreateService();
            return Ok(service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult<Empleado> Get(int id)
        {
            var service = CreateService();
            return Ok(service.ObtenerPorId(id));
        }
        [HttpPost]
        public ActionResult<Empleado> Post([FromBody] Empleado empleado)
        {
            var service = CreateService();
            return Ok(service.Agregar(empleado));
        }
        [HttpPut("{id}")]
        public ActionResult<Empleado> Put(int id, [FromBody] Empleado empleado)
        {
            var service = CreateService();
            empleado.id = id;
            return Ok(service.Editar(empleado));
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            var service = CreateService();
            service.Eliminar(id);

            return Ok("Eliminado");
        }
    }
}