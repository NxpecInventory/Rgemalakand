using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RGECMS.Api
{
    public class Student2Controller : ApiController
    {
        // GET: api/Student2
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Student2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student2
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student2/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student2/5
        public void Delete(int id)
        {
        }
    }
}
