using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OidConfigurationController : Controller
    {

        public OidConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider) {
            this.clientRequestParametersProvider = clientRequestParametersProvider;
        }

        public IClientRequestParametersProvider clientRequestParametersProvider { get; set; }

        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientParameters([FromRoute]string clientId)
        {
            var parameters = clientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(parameters);
        }
    }
}
