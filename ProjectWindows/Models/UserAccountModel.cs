﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindows.Models
{
    public class UserAccountModel
    {
        public string UserName { get; set; }
        public string DisplayName {  get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
