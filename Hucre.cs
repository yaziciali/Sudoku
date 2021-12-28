using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Hucre: Button
    {
        public int Degeri; // Hücre Değeri
        public bool Kilitli; // Hücre kilitli mi?
        public int X; // X koordinatı
        public int Y; // y koordinatı

        public void Temizle()
        {
            this.Text = "";
            this.Kilitli = false;
        }
         
    }
}
