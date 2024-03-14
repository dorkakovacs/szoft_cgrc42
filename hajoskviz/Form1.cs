namespace hajoskviz
{
    public partial class Form1 : Form
    {
        List<Kerdes> ÖsszesKérdés;
        List<Kerdes> AktuálisKérdések;
        int MegjelenítettKérdésSzáma = 5;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ÖsszesKérdés = KérdésekBetöltése();
            AktuálisKérdések = new List<Kerdes>();

            for (int i = 0; i < 7; i++)
            {
                AktuálisKérdések.Add(ÖsszesKérdés[0]);
                ÖsszesKérdés.RemoveAt(0);
            }
            dataGridView1.DataSource = AktuálisKérdések;
            KérdésMegjelenítés(AktuálisKérdések[MegjelenítettKérdésSzáma]);
        }

        List<Kerdes> KérdésekBetöltése()
        {
            List<Kerdes> kérdések = new List<Kerdes>();
            StreamReader sr = new StreamReader("hajozasi_szabalyzat_kerdessor_BOM.txt", true);

            while (!sr.EndOfStream)
            {


                string sor = sr.ReadLine();
                string[] tömb = sor.Split("\t");

                Kerdes k = new Kerdes();
                k.KérdésSzöveg = tömb[1].ToUpper();
                k.Válasz1 = tömb[2].Trim('"');
                k.Válasz2 = tömb[3].Trim('"');
                k.Válasz3 = tömb[4].Trim('"');
                k.URL = tömb[5];

                int x = 0;
                int.TryParse(tömb[6], out x);
                k.HelyesVálasz = x;

                kérdések.Add(k);
            }
            sr.Close();

            return kérdések;
        }

        void KérdésMegjelenítés(Kerdes kérdés)
        {
            label1.Text = kérdés.KérdésSzöveg;
            textBox1.Text = kérdés.Válasz1;
            textBox2.Text = kérdés.Válasz2;
            textBox3.Text = kérdés.Válasz3;

            if (string.IsNullOrEmpty(kérdés.URL))
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Load("https://storage.altinum.hu/hajo/" + kérdés.URL);
            }
        }

        private void button1_Click(object Sender, EventArgs e)
        {
            MegjelenítettKérdésSzáma++;
            if (MegjelenítettKérdésSzáma == 7) MegjelenítettKérdésSzáma = 0;

            KérdésMegjelenítés(AktuálisKérdések[MegjelenítettKérdésSzáma]);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.Salmon;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.Salmon;
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.Salmon;
        }

        void Színezés()
        {
            int helyesVálasz= AktuálisKérdések[MegjelenítettKérdésSzáma].HelyesVálasz;
            if (helyesVálasz == 1) textBox1.BackColor = Color.LightGreen;
            if (helyesVálasz == 2) textBox1.BackColor = Color.LightGreen;
            if (helyesVálasz == 3) textBox1.BackColor = Color.LightGreen;
        }
            
    }
}