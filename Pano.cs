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
        private const int BOYUT = 9;
        public Hucre[,] Hucreler = new Hucre[BOYUT, BOYUT];
        private Random random = new();

        public Pano() 
        {
            HucreleriOlustur();
        }
        public void HucreleriOlustur()
        {
            for (int i = 0; i < BOYUT; i++)
            {
                for (int j = 0; j < BOYUT; j++)
                {
                    // 81 hücre oluştur.
                    Hucreler[i, j] = new Hucre() { X = i, Y = j, Kilitli = false };
                    Hucreler[i, j].Font = new Font(SystemFonts.DefaultFont.FontFamily, 18);
                    Hucreler[i, j].Size = new Size(50, 50);
                    Hucreler[i, j].ForeColor = SystemColors.ControlDarkDark;
                    Hucreler[i, j].Location = new Point(i * 50, j * 50);
                    Hucreler[i, j].BackColor = ((i / 3) + (j / 3)) % 2 == 0 ? SystemColors.Control : Color.LightGray;
                    Hucreler[i, j].FlatStyle = FlatStyle.Flat;
                    Hucreler[i, j].FlatAppearance.BorderColor = Color.Black;


                    // Her bir hücre için tanımla
                    Hucreler[i, j].KeyPress += Hucre_Isaretlendi;

                    this.Controls.Add(Hucreler[i, j]);
                }
            }
        }


        private void Hucre_Isaretlendi(object nesne, KeyPressEventArgs args)
        {
            var SeciliHucre = nesne as Hucre;

            //Hücre kilitli ise bir şey yapmadan çık
            if (SeciliHucre.Kilitli) return;

            int Sayi = 0;

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

        public void Ilk_Degerleri_Goster(int orneklem)
        {
            List<int>[] Sayilar = new List<int>[BOYUT]; //{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int toplam = 0;
            int X = 0;
            var RY = 0; // Random Y

            for (int k = 0; k < BOYUT; k++)
            {
                Sayilar[k] = new List<int> { 0,1, 2, 3, 4, 5, 6, 7, 8 };
            }

            while (toplam <= orneklem) {


                RY = Sayilar[X][random.Next(0, Sayilar[X].Count)];
                    int Deger = Hucreler[X, RY].Degeri;
                    Hucreler[X, RY].Text = Deger.ToString();
                    Hucreler[X, RY].ForeColor = Color.Black;
                    Hucreler[X, RY].Kilitli = true;
                Sayilar[X].Remove(RY);
                toplam++;
                X++;
                if (X == BOYUT) X = 0;
            }

        }

        public void YeniDegerlerYukle()
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

            if (++j >= BOYUT)
            {
                j = 0;
                //Satır bittiğinde çık
                if (++i >= BOYUT)
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

                // Listeden rasgele bir değer al
                Sayi = Sayilar[random.Next(0, Sayilar.Count)];
                Hucreler[i, j].Degeri = Sayi;

                // Alınan değeri listeden çıkar
                Sayilar.Remove(Sayi);
            }
            while (!Gecerlimi(Sayi, i, j) || !BirSonrakiDegerBul(i, j));

            return true;
        }

        private bool Gecerlimi(int sayi, int x, int y)
        {
            for (int i = 0; i < BOYUT; i++)
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
