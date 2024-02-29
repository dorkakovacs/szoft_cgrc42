using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace harmaidkhet
{
    internal class villogogomb : Button
    {
        public villogogomb() 
        {
            MouseEnter += Villogogomb_MouseEnter;
            MouseLeave += Villogogomb_MouseLeave;
        }

        private void Villogogomb_MouseLeave(object? sender, EventArgs e)
        {
            BackColor = Color.White;
        }

        private void Villogogomb_MouseEnter(object? sender, EventArgs e)
        {
            BackColor = Color.Fuchsia;
        }

    }
}
