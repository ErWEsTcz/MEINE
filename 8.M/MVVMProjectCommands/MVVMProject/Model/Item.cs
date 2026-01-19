using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMProject.Model
{
    internal class Item
    {
        public string Name { get; set; }    

        public DateOnly DeadLine { get; set; }
    }
}
