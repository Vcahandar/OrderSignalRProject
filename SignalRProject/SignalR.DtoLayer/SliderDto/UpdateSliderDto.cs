using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.SliderDto
{
	public class UpdateSliderDto
	{
		public int SliderId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
