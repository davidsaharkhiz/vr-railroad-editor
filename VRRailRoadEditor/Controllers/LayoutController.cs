using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VRRailRoadEditor.Data;
using System.Linq;
using Newtonsoft.Json;
using VRRailRoadEditor.Models;
using System.Collections.ObjectModel;

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

			var testLayout = _context.Layouts.FirstOrDefault(l => l.ID == id);

			if(testLayout != null) {

				_context.Tiles.RemoveRange(_context.Tiles.Where(t => t.Layout.ID == testLayout.ID));

				//delete old one(todo: these are null?!?!
				//_context.Tiles.RemoveRange(testLayout.Tiles);
				_context.Layouts.Remove(testLayout);

				_context.SaveChanges();
			}

			testLayout = new Layout { Name = "test layout david", Width = 15, Height=1, Length = 30 };

			_context.Add(testLayout);

			_context.SaveChanges();

			id = testLayout.ID;


			testLayout.Tiles = new List<Tile>();
			for (int z = 0; z < testLayout.Height; z++)
			{
				for (int y = 0; y < testLayout.Length; y++)
				{
					for (int x = 0; x < testLayout.Length; x++)
					{
						var tile = new Tile { X = x, Y = y, Z = z, Layout = testLayout, PrimaryMaterial = new IMaterial { Name = "grass" } };
						_context.Add(tile);
						testLayout.Tiles.Add(tile);

						if(x > 0) {
							continue; //temporary debug code
						}

					}
				}
			}

			_context.Update(testLayout);
			_context.SaveChanges();

			var test = _context.Layouts.FirstOrDefault(l => l.ID == id);
			var converted = Json(test);

			return converted;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Layout value)
        {
			
			//var blah = JsonConvert.DeserializeObject<Layout>(value);

			


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
