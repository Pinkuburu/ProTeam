using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStatz.Models
{
    public class AccountInfo
    {
        public int Id { get; set; }
        public DateTime LastActiveTime { get; set; }
        public string Avatar { get; set; }
        public string Name { get; set; }
    }
}
