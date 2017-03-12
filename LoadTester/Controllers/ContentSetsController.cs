using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoadTester.Models;

namespace LoadTester.Controllers
{
	[Route("")]
	public class DefaultController : Controller
	{
		public string Get()
		{
			return "APP running current server time: " + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
		}

	}

	[Route("api/[controller]")]
	public class ContentSetsController : Controller
    {

		private readonly ContentSetContext _ContentSetContext;

		public ContentSetsController(ContentSetContext ContentSetContext)
		{
			_ContentSetContext = ContentSetContext;
		}

		// GET api/ContentSets
		[HttpGet]
        public IEnumerable<string> Get()
        {
			List<ContentSet> sets = _ContentSetContext.GetAllContentSets();
			List<String> result = new List<String>();
			sets.ForEach((item) => result.Add(item.name));

			return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
