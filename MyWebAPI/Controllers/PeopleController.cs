using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebAPI.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { Id = 1, FirstName = "Francis", LastName = "Khoury" });
            people.Add(new Person { Id = 2, FirstName = "Ted", LastName = "Fujita" });
            people.Add(new Person { Id = 3, FirstName = "Charles", LastName = "Lenz" });
        }

        [Route("api/People/GetFirstNames")]
        [HttpGet, HttpPost]
        public IEnumerable<string> GetFirstNames()
        {
            List<string> firstNames = new List<string>();
            foreach (Person p in people)
            {
                firstNames.Add(p.FirstName);
            }
            return firstNames;
        }

        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            try
            {
                return people.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                //do some logging
                throw ex;
            }
            
        }

        // POST: api/People
        public void Post([FromBody]Person value)
        {
            try
            {
                people.Add(value);
            }
            catch (Exception ex)
            {
                //do some logging
                throw ex;
            }
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
