using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace YazilimYapimiOyun
{
    public class KutuTablosu
    {

        Size buyukluk;
        public List<Kutu> kutular;
        public KutuTablosu(Size buyukluk)
        {
            kutular = new List<Kutu>();
            this.buyukluk = buyukluk;
            for (int x = 0; x < buyukluk.Width;x= x+40)
            {
                for (int y = 0; y <buyukluk.Height ; y=y+40)
                {
                    Kutu k = new Kutu(new Point(x, y));
                    KutuEkle(k);

                }

            }
        }
        public Size buyuklugu
        {
            get
            {
                return buyukluk;
            }
        }
        public void KutuEkle(Kutu o)
        {
            kutular.Add(o);
        }
        public Kutu kutu_al_loc(Point loc)
        {
            foreach (Kutu item in kutular)
            {
                if (item.konum_al==loc)
                {
                    return item;

                }
                
            }
            return null;

        }
        public List<Kutu> GetAllKutu
        {
            get
            {
                return kutular;
            }
        }
    }
}
