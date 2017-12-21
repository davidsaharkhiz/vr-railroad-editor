using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VRRailRoadEditor.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace VRRailRoadEditor.Models
{
	public class ILayout
	{
		public int ID { get; set; }

		public int Width { get; set; }

		public int Length { get; set; }

		public int Height { get; set; }

		[StringLength(60, MinimumLength = 2)]
		[Required]
		public string Name { get; set; }

		public List<Tile> Tiles { get; set; }

		//todo: one to many relationship from users
	}
}
