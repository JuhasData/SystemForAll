using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SystemForAll.Global;
using SystemForAll.Session;

namespace SystemForAll.Location.Controllers
{
    [Authorize]
    public class GlobalController : ApiController
    {

        private readonly IGlobalServices _globalServices;

        public GlobalController(IGlobalServices globalServices)
        {
            _globalServices = globalServices;
        }

        //Get api/Globals
        public HttpResponseMessage Get()
        {
            var globals = _globalServices.GetAllGlobals();
            var globalEntities = globals as List<GlobalEntity> ?? globals.ToList();
            if (globalEntities.Any())
            
                return Request.CreateResponse(HttpStatusCode.OK, globalEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Globals Found");

        }

        //Get api/product/id
        public HttpResponseMessage Get(int id)
        {
            var global = _globalServices.GetGlobalById(id);
            if (global != null)
                return Request.CreateResponse(HttpStatusCode.OK, global);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Global found for this ID");
        }


        // POST: api/Global
        public long Post([FromBody] GlobalEntity globalEntity)
        {
            return _globalServices.CreateGlobal(globalEntity);
        }

        // PUT: api/Global/5
        public bool Put(int id, [FromBody]GlobalEntity globalEntity)
        {
            if (id > 0)
            {
                return _globalServices.UpdateGlobal(id, globalEntity);
            }
            return false;
        }

        // DELETE: api/Global/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _globalServices.DeleteGlobal(id);
            return false;
        }
    }
}
