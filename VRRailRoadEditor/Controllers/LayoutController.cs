using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VRRailRoadEditor.Data;
using System.Linq;
using Newtonsoft.Json;
using VRRailRoadEditor.Models;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
			return Json(_context.Layouts.Include(l => l.Tiles).FirstOrDefault(l => l.ID == 16));
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public JsonResult Get(int id)
        {

			var testLayout = _context.Layouts.FirstOrDefault(l => l.ID == id);

			if(testLayout != null) {


				//delete old one(todo: these are null?!?!
				//_context.Tiles.RemoveRange(testLayout.Tiles);
				_context.Layouts.Remove(testLayout);

				_context.SaveChanges();
			}

			testLayout = new Layout { Name = "test layout david", Width = 6, Height=1, Length = 6 };

			_context.Attach(testLayout);

			testLayout.Tiles = new List<Tile>();
			for (int z = 0; z < testLayout.Height; z++)
			{
				for (int y = 0; y < testLayout.Length; y++)
				{
					for (int x = 0; x < testLayout.Length; x++)
					{

						var tile = new Tile { X = x, Y = y, Z = z,  PrimaryMaterial = new IMaterial { Name = "grass" } };
						testLayout.Tiles.Add(tile);

						
						

					}
				}
			}

			_context.SaveChanges();

			id = testLayout.ID;

			var test = _context.Layouts.Include(l => l.Tiles).FirstOrDefault(l => l.ID == 1);
			test.Tiles = (List<Tile>)test.Tiles.OrderBy(t => t.X).ThenBy(t => t.Y).ThenBy(t => t.Z).ToList();

			return new JsonResult(test); 


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
