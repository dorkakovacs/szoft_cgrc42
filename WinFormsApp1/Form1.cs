using harmaidkhet;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button b = new Button();
            Controls.Add(b);

            b.Left = ClientRectangle.Width / 2 - b.Width/2;
            b.Top = ClientRectangle.Height / 2 - b.Height / 2;

            int méret = 20;

            for (int sor = 0; sor < 20; sor++)
            {
                for (int oszlop = 0; oszlop < 20; oszlop++)
                {
                    szamologomb p = new szamologomb();
                    Controls.Add(p);
                    p.Height = méret;
                    p.Width = méret;
                    p.Left = méret * oszlop;
                    p.Top= méret * sor;
                    p.BackColor = Color.FromArgb(random.Next(0, 255), 0, 0);
                }
            }
        }
    }
}