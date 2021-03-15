using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Property.Core.Models;
using Property.Core.IServices;

namespace Property.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CitysController : ControllerBase
    {
        
        private readonly ICityService _musicService;
        public CitysController(ICityService musicService)
        {
         this._musicService = musicService;
}       

        //retorna lista de objetos do tipo City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetAllCities()
        {
            var musics = await _musicService.GetAllCities();
            return Ok(musics);
        }

       [HttpGet ("{id}")]
        public async Task<ActionResult<IEnumerable<City>>> GetCityById(int id)
        {
            var music = await _musicService.GetCityById(id);
            return Ok(music);
        }

        // //insere um objeto do tipo City
        // [HttpPost]
        // public IActionResult Add([FromBody] City City)
        // {
        //     try
        //     {  
        //        if (iRep.Add(City))
        //        {
        //           return Ok("Adicionado com sucesso");
        //        }
        //        else{
        //           return BadRequest("Não foi possivel adicionar o objeto");
        //        }
               
        //     }
        //     catch(Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }
 
        // //atualiza um objeto do tipo City pelo id
        // [HttpPut("{id}")]
        // public IActionResult UpdateByID(int id, [FromBody] City City)
        // {
        //     try
        //     {  
        //        if (iRep.Update(id,City))
        //        {
        //           return Ok("Atualizado com sucesso");
        //        }
        //        else{
        //           return BadRequest("Não foi possível atualizar objeto");
        //        }
               
        //     }
        //     catch(Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        // //deleta um objeto do tipo City pelo id
        // [HttpDelete("{id}")]
        // public IActionResult DeleteByID(int id)
        // {
        //     try
        //     {  
        //        if (iRep.Delete(id))
        //        {
        //           return Ok("Removido com sucesso");
        //        }
        //        else{
        //           return BadRequest("Não foi possível remover objeto");
        //        }
               
        //     }
        //     catch(Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        
    }
}