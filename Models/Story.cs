using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebJdr.Models
{
    public class Story
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int StartSequenceId { get; set; }
	}
}