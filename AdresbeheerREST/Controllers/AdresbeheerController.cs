using AdresbeheerREST.Model.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdresbeheerREST.Controllers
{
    [Route("api/[controller]/gemeente")]
    [ApiController]
    public class AdresbeheerController : ControllerBase
    {
        [HttpGet("{gemeenteId}")]
        public ActionResult<GemeenteRESToutputDTO> GetGemeente(int gemeenteId)
        {
            try
            {
                return Ok(); 
                //vraag gemeente aan BL
                //gemeente omzetten naar DTO
            }
            catch (Exception ex) { return NotFound(ex.Message); }
    }
}
