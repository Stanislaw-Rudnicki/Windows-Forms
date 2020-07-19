using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wf03_1_t01
{
    class Student
    {
        public String PIB { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{PIB}";
        }
    }
}
