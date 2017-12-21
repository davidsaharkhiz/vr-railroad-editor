using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VRRailRoadEditor.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace VRRailRoadEditor.Models
{

	

    public class ITile
    {
		
		/// <summary>
		/// Position in the layout
		/// </summary>
		public int X { get; set; }
		/// <summary>
		/// Position in the layout
		/// </summary>
		public int Y { get; set; }

		public int ID { get; set; }

		public ICollection<IScenery> Scenery { get; set; }

	}
}
