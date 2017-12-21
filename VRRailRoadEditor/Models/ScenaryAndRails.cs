using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VRRailRoadEditor.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace VRRailRoadEditor.Models
{
  

	public class IMaterial
	{
		public int ID { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string Name { get; set; }

		public ICollection<Tile> Tiles { get; set; }
	}

	public class Material : IMaterial {

	}

	public class IRail
	{
		public int ID { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string Name { get; set; }
	}

	public class StandardRail : IRail {

	}

	public class IScenery
	{

		public int ID { get; set; }

		/// <summary>
		/// Subposition in the tile
		/// </summary>
		public int X { get; set; }
		/// <summary>
		/// Subposition in the tile
		/// </summary>
		public int Y { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string Name { get; set; }



		public IRail Rail { get; set; }

	}

	public class Scenery : IScenery {


	}

	
}
