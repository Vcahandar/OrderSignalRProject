using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
	public class MenuTable
	{
        public int MenuTableId { get; set; }
        public string TableName { get; set; }
        public bool Status { get; set; }
    }
}
