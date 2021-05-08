using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJdr.Models
{
	public class Sequence
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		public int HierchicalLevel { get; set; }
		public string Title { get; set; }
		public string Paragraph { get; set; }
		public string ChildsId { get; set; }
	}
}
