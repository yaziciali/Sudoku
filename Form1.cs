using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pano1.YeniDegerlerYukle();
            Pano1.ilk_degerleri_goster(100);
            label1.Text = "Yeni Oyun Başladı.";
            timer1.Enabled = true;
        }

        private void TemizleTusu_Click(object sender, EventArgs e)
        {
            foreach (var hucre in Pano1.Hucreler)
            {
                // Clear the cell only if it is not locked
                if (hucre.Kilitli == false)
                    hucre.Temizle();
            }
        }

        private void KontrolTusu_Click(object sender, EventArgs e)
        {
            var HataliHucreler = new List<Hucre>();

            foreach (var hucre in Pano1.Hucreler)
            {
                int h = hucre.Degeri;
                if (!string.Equals(h.ToString(), hucre.Text))
                {
                    HataliHucreler.Add(hucre);
                }
            }

            // Check if the inputs are wrong or the player wins 
            if (HataliHucreler.Any())
            {
                // Highlight the wrong inputs 
                HataliHucreler.ForEach(x => x.ForeColor = Color.Red);
                label1.Text = "Hataları kontrol edin.";
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Kazandınız");
                label1.Text = "Kazandınız";
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "";
            timer1.Enabled = false;
        }

        private void YeniOyunTusu1_Click(object sender, EventArgs e)
        {
            Pano1.YeniDegerlerYukle();
            Pano1.ilk_degerleri_goster(80);
        }

        private void YeniOyunTusu2_Click(object sender, EventArgs e)
        {
            Pano1.YeniDegerlerYukle();
            Pano1.ilk_degerleri_goster(40);
        }
    }
}
