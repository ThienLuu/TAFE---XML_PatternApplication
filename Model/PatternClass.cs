using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PatternClass
    {
        //fields
        //2 dimensional array
        //www.dotnetperls.com/2d
        private bool[][] pattern = new bool[5][];

        //props
        public bool[][] Pattern
        {
            get
            {
                return pattern;
            }

            set
            {
                pattern = value;
            }
        }

        //constructor
        public PatternClass()
        {
            pattern[0] = new bool[5];
            pattern[1] = new bool[5];
            pattern[2] = new bool[5];
            pattern[3] = new bool[5];
            pattern[4] = new bool[5];
        }
        
    }
}
