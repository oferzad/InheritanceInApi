using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28.Models
{
    public class Adult
    {
        public string Proffesion { get; set; }
        public User UserNavigation { get; set; }
    }
}
