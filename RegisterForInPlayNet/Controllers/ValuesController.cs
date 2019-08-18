using RegisterForInPlayNet.Models.ProfileInfo;
using RegisterForInPlayNet.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RegisterForInPlayNet.Controllers
{
    public class ValuesController : ApiController
    {
        RepositoryClass r = new RepositoryClass();
   //    public IEnumerable<string> Get()
  //     {
        //    return new string[] { "value1", "value2" };

        //        }
 //       public IEnumerable<Profile> Get()
   //     {
       //    return r.Get();
  //      }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
