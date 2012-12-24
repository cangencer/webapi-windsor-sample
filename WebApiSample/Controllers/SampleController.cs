namespace WebApiSample.Controllers
{
    using System.Web.Http;

    using WebApiSample.Services;

    public class SampleController : ApiController
    {
        private readonly InjectedService service;

        public SampleController(InjectedService service)
        {
            this.service = service;
        }

        // GET api/sample        
        public string Get()
        {
            return this.service.Get();            
        }
    }
}