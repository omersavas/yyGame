using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimYapimiOyun
{
    public partial class Form1 : Form
    {
        
        public KutuTablosu kutuTablo;
        public Form1()
        {
            

            InitializeComponent();
        }
        
        List<Button> butonlar = new List<Button>();
        int tiklamaSayi = 1;
        int bosKutuSayi=0;
        int tiklanaBilirKutuSayisi;
        Size TabloBoyut;
        private void Form1_Load(object sender, EventArgs e)
        {
                                              

        }
        public void Kutu_Ekle()
        {
            for (int x = 0; x < panel1.Width; x = x + 40)
            {
                for (int y = 0; y < panel1.Height; y = y + 40)
                {
                    ButtonEkle(new Point(x, y));

                }

            }
        }
        public void ButtonEkle(Point loc)
        {
            Button btn = new Button();
            
            btn.Name = "Kutu" + ";" + loc.X + ";" + loc.Y;
            btn.Size = new Size(40, 40);
            btn.Location = loc;
            btn.BackColor = Color.Aqua;
            btn.Text = null;
            
            panel1.Controls.Add(btn);
            butonlar.Add(btn);

            btn.Click += new EventHandler(btn_Click);


        }
        void btn_Click(object sender,EventArgs e)
        {
            
            Button btn = (sender as Button);           
            Kutu k = kutuTablo.kutu_al_loc(btn.Location);

            foreach (Kutu item in kutuTablo.kutular)
            {
                if (item.tiklandimi==false)
                {
                    bosKutuSayi++;
                }
            }
            if (bosKutuSayi==0)
            {
                MessageBox.Show("Tebrikler Kazandınız");
            }
            else { 

               if (k.tiklandimi!=true&&btn.BackColor==Color.Aqua)
               {
           
               foreach (Button item in butonlar)
               {
                  Kutu tempK= kutuTablo.kutu_al_loc(item.Location);
                   if (tempK.tiklandimi==false)
                   {
                    item.BackColor = Color.White;

                   }                                                                    
               }
                       
               btn.Text = tiklamaSayi.ToString();
               tiklamaSayi++;
               btn.BackColor = Color.Tomato;         
               k.tiklandimi = true;
                               
                 foreach (Button tempBtn in butonlar)
              {
                  if (k.konum_al.X-80==tempBtn.Location.X&&k.konum_al.Y+40==tempBtn.Location.Y)
                  {
                        if (tempBtn.BackColor!=Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }
                  
                  }
                if (k.konum_al.X - 40 == tempBtn.Location.X && k.konum_al.Y + 80 == tempBtn.Location.Y)
                {
                        if (tempBtn.BackColor != Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }

                    }
                if (k.konum_al.X +40 == tempBtn.Location.X && k.konum_al.Y + 80 == tempBtn.Location.Y)
                  {

                        if (tempBtn.BackColor != Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }

                    }
                  if (k.konum_al.X +80 == tempBtn.Location.X && k.konum_al.Y + 40 == tempBtn.Location.Y)
                  {

                        if (tempBtn.BackColor != Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }


                    }
                  if (k.konum_al.X + 80 == tempBtn.Location.X && k.konum_al.Y - 40 == tempBtn.Location.Y)
                  {

                        if (tempBtn.BackColor != Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }


                    }
                  if (k.konum_al.X +40 == tempBtn.Location.X && k.konum_al.Y -80 == tempBtn.Location.Y)
                  {

                        if (tempBtn.BackColor != Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }


                    }
                  if (k.konum_al.X -40 == tempBtn.Location.X && k.konum_al.Y - 80 == tempBtn.Location.Y)
                  {

                        if (tempBtn.BackColor != Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }


                    }
                  if (k.konum_al.X - 80 == tempBtn.Location.X && k.konum_al.Y - 40 == tempBtn.Location.Y)
                  {

                        if (tempBtn.BackColor != Color.Tomato)
                        {
                            tempBtn.BackColor = Color.Aqua;
                        }


                    }
              }

             }
             else
                MessageBox.Show("Sadece Mavi Olanlara ve Daha Önce Tıklamadığınız Karelere Tıklanabilir");

                foreach (Button item in butonlar)
                {
                    if (item.BackColor==Color.Aqua)
                    {
                        tiklanaBilirKutuSayisi++;

                    }

                }
                label1.Text ="Oynanabilecek Hamle :" +tiklanaBilirKutuSayisi.ToString();
                

                if (bosKutuSayi!=0&&tiklanaBilirKutuSayisi==0)
                {
                    MessageBox.Show("Hamleniz Kalmadı Oyunu Kaybettiniz");
                }
                tiklanaBilirKutuSayisi = 0;

            }
        }
        public Size sizeDondur()
        {
            Size sz = new Size();

            if (radioButton1.Checked == true)
            {
                sz = (new Size(200, 200));
            }
            else if (radioButton2.Checked == true)
            {
                sz = (new Size(240, 240));
            }
            else if (radioButton3.Checked == true)
            {
                sz = (new Size(280, 280));
            }
            else if (radioButton4.Checked == true)
            {
                sz = (new Size(320, 320));
            }
            else if (radioButton5.Checked == true)
            {
                sz = (new Size(360, 360));
            }

            return sz;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabloBoyut = sizeDondur();
            kutuTablo = new KutuTablosu(TabloBoyut);
            panel1.Size = kutuTablo.buyuklugu;
            Kutu_Ekle();

            panel2.Hide();
        }
    }
}
