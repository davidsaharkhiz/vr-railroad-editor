using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VRRailRoadEditor.Data;
using System.Linq;
using Newtonsoft.Json;
using VRRailRoadEditor.Models;

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
			var jsonResult = Json(_context.Layouts);
			return jsonResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
			return Json(_context.Layouts.FirstOrDefault(l => l.ID == id));
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Layout value)
        {
			
			//var blah = JsonConvert.DeserializeObject<Layout>(value);

			var testSerialize = new Layout();
			var testTiles = new List<Tile> {
				new Tile { ID = 4},
				new Tile { ID = 7},
			};
			testSerialize.Tiles = testTiles;

			var testSerialized = JsonConvert.SerializeObject(testSerialize);
			var blah2 = 3;
			var blah4 = JsonConvert.DeserializeObject<Layout>(testSerialized);

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
