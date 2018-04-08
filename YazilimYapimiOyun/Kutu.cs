using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace YazilimYapimiOyun
{
    public class Kutu
    {
        Point loc;
        bool tiklandi;
        

        public Kutu(Point loca)
        {
            tiklandi = false;
            
            loc = loca;
        }

        public Point konum_al
        {
            get { return loc; }
        }
        public bool tiklandimi
        {
            get
            {
                return tiklandi;
            }
            set
            {
                tiklandi = value;
            }
        }
       
    }
}
