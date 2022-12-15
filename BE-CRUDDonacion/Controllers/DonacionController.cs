using BE_CRUDDonacion.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BE_CRUDDonacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public DonacionController(AplicationDbContext context) 
        {

            _context = context; //  para acceder al contexto y hacer peticiones a la base de datos

        }

        [HttpGet]
        [EnableCors]

        public async Task<IActionResult> Get() // trab con los distintos estados
        {
            try
            {
                var listDonaciones = await _context.donaciones.ToListAsync();
                return Ok(listDonaciones);
            }
            catch (Exception ex)

            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        [EnableCors]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var donacion = await _context.donaciones.FindAsync(id);

                if (donacion == null)
                {
                    return NotFound();
                }
                return Ok(donacion);
            }
            catch (Exception ex) {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [EnableCors]

        public async Task<IActionResult> Delete(int id)
        {
            
            try {

                var donacion = await _context.donaciones.FindAsync(id);
                if (donacion == null)
                {
                    return NoContent();
                }

                _context.donaciones.Remove(donacion);
                await _context.SaveChangesAsync();
                return NoContent();


            }
            catch (Exception ex) {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        

       public async Task<IActionResult> Post(Donacion donacion) 
       {

            try
            {
                donacion.fecha_creacion = DateTime.Now; //
                _context.Add(donacion);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = donacion.id }, donacion);
            }
            catch (Exception ex) 
            
            {
                return BadRequest(ex.Message);
            }
                

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Donacion donacion) 
        
        {
            try
            {
                if (id != donacion.id)
                {
                    return BadRequest();
                }
                var donacionItem = await _context.donaciones.FindAsync(id);

                if (donacionItem == null)
                {
                    return NotFound();
                }
                //Valida los datos eenviados vs existentes
                donacionItem.nombre = donacion.nombre;
                donacionItem.apellido = donacion.apellido;
                donacionItem.direccion = donacion.direccion;
                donacionItem.email = donacion.email;
                donacionItem.telefono = donacion.telefono;
                donacionItem.anonimo = donacion.anonimo;
                donacionItem.estado = donacion.estado;
                donacionItem.nombre_orden = donacion.nombre_orden;
                donacionItem.cantidad = donacion.cantidad;
                donacionItem.fecha_recojo = donacion.fecha_recojo;
                donacionItem.contacto = donacion.contacto;
                donacionItem.tipo = donacion.tipo;


                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        
        }


    }


}




