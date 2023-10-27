using AdresbeheerBL.Model;
using AdresbeheerBL.Services;
using AdresbeheerREST.Mappers;
using AdresbeheerREST.Model.Input;
using AdresbeheerREST.Model.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdresbeheerREST.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase
    {
        private GemeenteService gemeenteService;
        private StraatService straatService;
        private string url = "http://localhost:5200/api/adresbeheer";

        public AdresbeheerController(GemeenteService gemeenteService, StraatService straatService)
        {
            this.gemeenteService = gemeenteService;
            this.straatService = straatService;
        }

        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            try
            {
                Gemeente g=gemeenteService.GeefGemeente(gemeenteId);

                return Ok(MapFromDomain.MapFromGemeenteDomain(url,g,straatService));
                //vraag gemeente aan BL
                //gemeente omzetten naar DTO
            }
            catch (Exception ex) { return NotFound(ex.Message); }
        }
        [HttpPost]
        public ActionResult<GemeenteRESToutputDTO> PostGemeente([FromBody] GemeenteRESTinputDTO restDTO)
        {
            try
            {
                //gemeente maken
                //gemeente wegschrijven
                Gemeente gemeente = gemeenteService.VoegGemeenteToe(MapToDomain.MapToGemeenteDomain(restDTO));
                return CreatedAtAction(nameof(GetGemeente), new { gemeenteID = gemeente.NIScode }, MapFromDomain.MapFromGemeenteDomain(url, gemeente,straatService));
            }
            catch(Exception ex) { return BadRequest(ex.Message);}
        }
        [HttpDelete]
    }
}
