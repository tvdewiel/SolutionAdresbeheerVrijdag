using AdresbeheerBL.Model;
using AdresbeheerBL.Services;
using AdresbeheerREST.Mappers;
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
        private string url = "http://localhost:5200/api/adresbeheer";

        public AdresbeheerController(GemeenteService gemeenteService)
        {
            this.gemeenteService = gemeenteService;
        }

        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            try
            {
                Gemeente g=gemeenteService.GeefGemeente(gemeenteId);

                return Ok(MapFromDomain.MapFromGemeenteDomain(g));
                //vraag gemeente aan BL
                //gemeente omzetten naar DTO
            }
            catch (Exception ex) { return NotFound(ex.Message); }
        }
    }
}
