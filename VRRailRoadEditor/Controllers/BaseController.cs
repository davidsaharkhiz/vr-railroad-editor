using VRRailRoadEditor.Data;
using Microsoft.AspNetCore.Mvc;

namespace VRRailRoadEditor.Controllers
{
	public class BaseController : Controller
    {
		protected  VRRailRoadEditorContext _context;

		// Inject our datacontext
		public BaseController(VRRailRoadEditorContext context)
		{
			_context = context;
		}
	}
}
