using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.ViewModels.NotificationVM
{
    public class CreateNotificationVM
    {
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
