using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace VizeSinavi
{
    public partial class Form1 : Form
    {
        int kisisayisi;
        string basaridurumu;
        double[] ortalamalar;

        string[] sira, ogrencino, ad, soyad, BBN;
        int[] vize, final, but;
        
        int i = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kisisayisi= int.Parse(Interaction.InputBox("Kişi Sayısı", "Kişi sayısını giriniz"));
            basaridurumu = Interaction.InputBox("100'Lük sistem mi yoksa bağıl sistem mi(100 veya bagil) yazınız.", "Hangi Sistem");
            ortalamalar = new double[kisisayisi];
            sira = new string[kisisayisi];
            ogrencino = new string[kisisayisi];
            ad = new string[kisisayisi];
            soyad = new string[kisisayisi];
            BBN = new string[kisisayisi];
            vize = new int[kisisayisi];
            final = new int[kisisayisi];
            but = new int[kisisayisi];
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")
            {
                sira[i] = textBox1.Text;
                ogrencino[i] = textBox2.Text;
                ad[i] = textBox3.Text;
                soyad[i] = textBox4.Text;
                vize[i] = int.Parse(textBox5.Text);
                final[i] = int.Parse(textBox6.Text);
                but[i] = int.Parse(textBox7.Text);
                MessageBox.Show("Tamamlandı");
                i++;
                label9.Text = "Kalan kişi sayısı = " + (kisisayisi - i).ToString();
            }
            if (label9.Text == "0")
                MessageBox.Show("Öğrenci Girişleri tamamlandı.");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double sinifortalamasi = 0;
            foreach (double a in ortalamalar)
                sinifortalamasi += a;

            sinifortalamasi /= kisisayisi;

            for (int i = 0; i < kisisayisi; i++)
            {
                ortalamalar[i] = vize[i] * 0.4 + final[i] * 0.6;
                ortalamalar[i] = (ortalamalar[i] + but[i]) / 2;

                if (basaridurumu == "100")
                {
                    ortalamalar[i] = ortalamalar[i];
                    BBN[i] = "";

                }
                else if (basaridurumu == "bagil")
                {

                    if (ortalamalar[i] <= 100 && ortalamalar[i] >= 70) BBN[i] = "AA";
                    else if (ortalamalar[i] <= 70 && ortalamalar[i] > 60) BBN[i] = "BA";
                    else if (ortalamalar[i] <= 60 && ortalamalar[i] > 50) BBN[i] = "BB";
                    else if (ortalamalar[i] <= 50 && ortalamalar[i] > 45) BBN[i] = "CB";
                    else if (ortalamalar[i] <= 45 && ortalamalar[i] >40) BBN[i] = "CC";
                    else if (ortalamalar[i] <= 40 && ortalamalar[i] >30) BBN[i] = "DC";
                    else if (ortalamalar[i] <= 30 && ortalamalar[i] > 20) BBN[i] = "DD";
                    else if (ortalamalar[i] <= 20) BBN[i] = "FF";

                    else MessageBox.Show("Yanlış bir girdi oluştu.");

                }
                else MessageBox.Show("Yanlış giriş yaptınız tekrar giriniz.");
            }
            int h = 0;
            while (h < kisisayisi)
            {
                listBox1.Items.Add("Öğrenci no = " + ogrencino[h]);
                listBox1.Items.Add("Ad = " + ad[h]);
                listBox1.Items.Add("Soyad = " + soyad[h]);
                listBox1.Items.Add("Vize = " + vize[h]);
                listBox1.Items.Add("Final = " + final[h]);
                listBox1.Items.Add("Bütünleme = " + but[h]);
                listBox1.Items.Add("BBN = " + BBN[h]);
                h++;
            }
            MessageBox.Show("Tamamlandı");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string hangi = Interaction.InputBox("Aramak istediğiniz öğrencinin okul no giriniz", "Hangi öğrenci");

            int index = Array.IndexOf(ogrencino, hangi);
            
            textBox1.Text = sira[index];
            textBox2.Text = ogrencino[index];
            textBox3.Text = ad[index];
            textBox4.Text = soyad[index];
            textBox5.Text = vize[index].ToString();
            textBox6.Text = final[index].ToString();
            textBox7.Text = but[index].ToString();
            textBox8.Text = BBN[index];
        }
    }
}
