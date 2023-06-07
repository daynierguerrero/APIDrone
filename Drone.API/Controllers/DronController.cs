using AutoMapper;
using Drone.API.Utilidad;
using Drone.BLL.Servicios;
using Drone.BLL.Servicios.Contrato;
using Drone.DAL.Repositorios.Contrato;
using Drone.DTO;
using Drone.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Drone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronController : ControllerBase
    {
        private readonly IDronService _dronService;
       

        public DronController(IDronService dronService)
        {
            _dronService = dronService;
           

        }


        [HttpPost]
        [Route("RegistrarDron")]
        public async Task<IActionResult> RegistrarDron([FromBody] DronDTO dron)
        {
            var response = new Response<DronDTO>();
            try
            {
                response.Status = true;
                response.Value = await _dronService.RegistrarDron(dron);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPost]
        [Route("CargarDron")]
        public async Task<IActionResult> CargarDron(int idMedicamento, int idDron)
        {
            var response = new Response<bool>();
            try
            {
                response.Status = true;
                response.Value = await _dronService.CargarDron(idMedicamento, idDron);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpGet]
        [Route("DronesDisponibles")]
        public async Task<IActionResult> DronesDisponibles()
        {
            var response = new Response<List<DronDTO>>();
            try
            {
                response.Status = true;
                response.Value = await _dronService.ObtenerDronesDisponibles();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpGet]
        [Route("BateriaDeUnDron")]
        public async Task<IActionResult> BateriaDeUnDron(int idDron)
        {
            var response = new Response<int>();
            try
            {
                response.Status = true;
                response.Value = await _dronService.BateriaDeUnDron(idDron);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpGet]
        [Route("PesoMedicamentoDron")]
        public async Task<IActionResult> PesoMedicamentoDron(int idDron)
        {
            var response = new Response<int>();
            try
            {
                response.Status = true;
                response.Value = await _dronService.PesoMedicamentoDron(idDron);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }


    }
}
