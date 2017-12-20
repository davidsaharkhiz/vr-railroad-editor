using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VRRailRoadEditor.Data;
using System.Linq;

namespace VRRailRoadEditor.Controllers
{

    [Route("api/layout")]
    public class LayoutController : BaseController
    {

		//todo: swagger

		// ex: http://localhost:58811/api/layout/5
		public LayoutController(VRRailRoadEditorContext context) : base(context) {
			_context = context;
		}

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
			return Json(_context.Layouts);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
			return Json(_context.Layouts.FirstOrDefault(l => l.ID == id));
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
