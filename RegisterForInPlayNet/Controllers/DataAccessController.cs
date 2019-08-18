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
    public class DataAccessController : ApiController
    {
        RepositoryClass rep = new RepositoryClass();

        [HttpGet]
        public List<Profile> Get()
        {
            return rep.Get();
        }

        [HttpPost]
        public void Post(Profile profile)
        {
            rep.Add(profile);
        }

        [HttpPut]
        public void Put(Profile profile) {
            rep.Change(profile);
        }

    }
}