using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VRRailRoadEditor.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace VRRailRoadEditor.Models
{

    public class ITile
    {

		public int ID { get; set; }

		/// <summary>
		/// Position in the layout
		/// </summary>
		public int X { get; set; }
		/// <summary>
		/// Position in the layout
		/// </summary>
		public int Y { get; set; }

		/// <summary>
		/// vertical position in the layout
		/// </summary>
		public int Z { get; set; }

		/// <summary>
		/// What is my surface? You pass trains.
		/// </summary>
		public IMaterial PrimaryMaterial { get; set; }
		/// <summary>
		/// This surface is currently unsupported but could for example store an oil spill or gravel/no gravel
		/// </summary>
		public IMaterial SecondaryMaterial { get; set; }

		public ICollection<IScenery> Scenery { get; set; }

	}
}
