using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28.Models
{
    public class Kid
    {
        public string Hobby { get; set; }
        public User UserNavigation { get; set; }
    }
}
