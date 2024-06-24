﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.ViewModels.ContactVM
{
	public class CreateContactVM
    {
        
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterTitle { get; set; }
        public string FooterDesc { get; set; }
        public string OpenDays { get; set; }
        public string OpenDaysDesc { get; set; }
        public string OpenHours { get; set; }
    }
}
