using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Pano : Panel
    {
        public Hucre[,] Hucreler = new Hucre[9, 9];
        private Random random = new();

        public Pano() 
        {
            HucreleriOlustur();
        }
        public void HucreleriOlustur()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // 81 hücre oluştur.
                    Hucreler[i, j] = new Hucre();
                    Hucreler[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 18);
                    Hucreler[i, j].Size = new Size(50, 50);
                    Hucreler[i, j].ForeColor = SystemColors.ControlDarkDark;
                    Hucreler[i, j].Location = new Point(i * 50, j * 50);
                    Hucreler[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    Hucreler[i, j].FlatStyle = FlatStyle.Flat;
                    Hucreler[i, j].FlatAppearance.BorderColor = Color.Black;
                    Hucreler[i, j].X = i;
                    Hucreler[i, j].Y = j;

                    // Her bir hücre için tanımla
                    Hucreler[i, j].KeyPress += hucre_isaretlendi;

                    this.Controls.Add(Hucreler[i, j]);
                }
            }
        }


        private void hucre_isaretlendi(object nesne, KeyPressEventArgs args)
        {
            var SeciliHucre = nesne as Hucre;

            //Hücre kilitli ise bir şey yapmadan çık
            if (SeciliHucre.Kilitli) return;

            int Sayi;

            // Yazılan sadece sayı olmalı
            if(int.TryParse(args.KeyChar.ToString(), out Sayi))
            {
                if (Sayi == 0)
                    SeciliHucre.Temizle();
                else
                    SeciliHucre.Text = Sayi.ToString();

                SeciliHucre.ForeColor = SystemColors.ControlDarkDark;
            }

        }

        public void ilk_degerleri_goster(int orneklem)
        {
            for (int i = 0; i < orneklem; i++)
            {
                var RX = random.Next(9);
                var RY = random.Next(9);
                int Deger = Hucreler[RX, RY].Degeri;
                Hucreler[RX, RY].Text = Deger.ToString();
                Hucreler[RX, RY].ForeColor = Color.Black;
                Hucreler[RX, RY].Kilitli = true;
            }
        }

        public void DegerleriYukle()
        {
            foreach (var h in Hucreler)
            {
                h.Degeri = 0;
                h.Temizle();
            }

            BirSonrakiDegerBul(0, -1);
        }

        private bool BirSonrakiDegerBul(int i, int j)
        {

            if (++j > 8)
            {
                j = 0;
                //Satır bittiğinde çık
                if (++i > 8)
                    return true;
            }

            int Sayi = 0;
            var Sayilar = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


            do
            {

                if (Sayilar.Count < 1)
                {
                    Hucreler[i, j].Degeri = 0;
                    return false;
                }

                // Take a random number from the numbers left in the list
                Sayi = Sayilar[random.Next(0, Sayilar.Count)];
                Hucreler[i, j].Degeri = Sayi;

                // Remove the allocated value from the list
                Sayilar.Remove(Sayi);
            }
            while (!Gecerlimi(Sayi, i, j) || !BirSonrakiDegerBul(i, j));

            return true;
        }

        private bool Gecerlimi(int sayi, int x, int y)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != y && Hucreler[x, i].Degeri == sayi)
                    return false;

                if (i != x && Hucreler[i, y].Degeri == sayi)
                    return false;
            }

            for (int i = x - (x % 3); i < x - (x % 3) + 3; i++)
            {
                for (int j = y - (y % 3); j < y - (y % 3) + 3; j++)
                {
                    if (i != x && j != y && Hucreler[i, j].Degeri == sayi)
                        return false;
                }
            }

            return true;
        }

    }
}
