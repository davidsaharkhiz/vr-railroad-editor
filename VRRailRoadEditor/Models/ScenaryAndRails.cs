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

	public class IRail
	{
		public int ID { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string Name { get; set; }
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

		/// <summary>
		/// What is my surface? You pass trains.
		/// </summary>
		public IMaterial PrimaryMaterial { get; set; }
		/// <summary>
		/// This surface is currently unsupported but could for example store an oil spill or gravel/no gravel
		/// </summary>
		public IMaterial SecondaryMaterial { get; set; }

		public IRail Rail { get; set; }

	}
}
