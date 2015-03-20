using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathHouse.Domain.Entities
{
	public class MessageImportance
	{
		public int MessageImprotanceId { get; set; }
		public string Name { get; set; }
		public int? Stars { get; set; }
	}
}