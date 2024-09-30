using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Model.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaapiController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
           return VillaStore.villaList;
        }

        [HttpGet("id:int",Name ="GetVilla")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVillas(int id)
        {
            if (id == 0) { 
            return BadRequest();  
            }
            var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);

            if (villa == null) { 
            return NotFound();
            }
           return Ok(villa);
        }


        [HttpPost]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villadto)
        {
            if (villadto == null)
            {
                return BadRequest(villadto);
            }
            if (villadto.Id <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villadto.Id = VillaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.villaList.Add(villadto);
            return CreatedAtRoute("GetVilla", new {id=villadto.Id },villadto);
        }
    }
}
