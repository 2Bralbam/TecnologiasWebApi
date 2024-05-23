using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecnologiasWebApi.Models.DTOS;
using TecnologiasWebApi.Models.Entities;
using TecnologiasWebApi.Repositorios;

namespace TecnologiasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly UsuariosRepositorio _usersRepositorio;
        private readonly ChismesRepositorio _chismesRepositorio;
        public DataController(UsuariosRepositorio uR,ChismesRepositorio cR)
        {
            _usersRepositorio = uR;
            _chismesRepositorio = cR;
        }
        [HttpGet]
        public IActionResult TraerChisme(int Id)
        {

            return Ok(_chismesRepositorio.GetChismeById(Id));
        }
        [HttpGet]
        public IActionResult TraerChismes()
        {
            return Ok(_chismesRepositorio.GetChismes().OrderByDescending(x=>x.Id).ToList());
        }
        [HttpPost]
        public IActionResult GuardarChisme(Chisme chisme)
        {
            if(chisme != null)
            {
                chisme.IdUsuario = 0;
                bool SeGuardo = _chismesRepositorio.GuardarChisme(chisme);
                if (SeGuardo)
                {
                    return Ok();

                }
                else
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult EditarChisme(ChismeDTO chisme)
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult BorrarChisme(int Id)
        {
            return Ok();
        }
    }
}
