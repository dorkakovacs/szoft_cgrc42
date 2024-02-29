using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmaidkhet
{
    internal class szamologomb : villogogomb
    {
        int szám = 1;
        public szamologomb()
        {
            Width = 20;
            Height = 20;
            MouseClick += Szamologomb_MouseClick;
            int szám = 1;
            Text = szám.ToString();
        }

        private void Szamologomb_MouseClick(object? sender, MouseEventArgs e)
        {
            szám++;
            if (szám == 6) 
            {
                szám = 1;
            }
            Text = szám.ToString();
        }
    }
}
