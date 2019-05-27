using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Bisekcja
{
    public partial class Bisekcja : Form
    {
        public Bisekcja()
        {
            InitializeComponent();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {

            string[] tab = textBoxPeriod.Text.Split(',');
            double periodStart = Convert.ToDouble(tab[0]);
            double periodEnd = Convert.ToDouble(tab[1]);
            double epsilon = Convert.ToDouble(textBoxEpsilon.Text);
            double pomoc;
            if (Licz_Funkc(periodStart)* Licz_Funkc(periodEnd)<0)
            {
                do
                {
                    pomoc = ((periodStart + periodEnd) / 2);
                    if (Licz_Funkc(periodStart) > 0 && Licz_Funkc(pomoc) < 0)
                    {
                        periodEnd = pomoc;
                    }
                    if (Licz_Funkc(periodEnd) > 0 && Licz_Funkc(pomoc) < 0)
                    {
                        periodStart = pomoc;
                    }
                    if (Licz_Funkc(periodStart) < 0 && Licz_Funkc(pomoc) > 0)
                    {
                        periodEnd = pomoc;
                    }
                    if (Licz_Funkc(periodEnd) < 0 && Licz_Funkc(pomoc) > 0)
                    {
                        periodStart = pomoc;
                    }
                    textBox1.Text = pomoc.ToString();
                } while (Math.Abs(Licz_Funkc(pomoc)) > epsilon);
                textBox1.Text = pomoc.ToString();
            }
            else
            {
                textBox1.Text = "błędny przedział";
            }
        }
        public double Licz_Funkc(double x)
        {
            double fourPower = Convert.ToDouble(textBoxPow4.Text);
            double thrrePower = Convert.ToDouble(textBoxPow3.Text);
            double twoPower = Convert.ToDouble(textBoxPow2.Text);
            double onePower = Convert.ToDouble(textBoxPow1.Text);
            double C = Convert.ToDouble(textBoxC.Text);
            double funkc = 0;
            funkc = fourPower * Math.Pow(x, 4) + thrrePower * Math.Pow(x, 3) + twoPower * Math.Pow(x, 2) + onePower * Math.Pow(x, 1) + C;
            return funkc;
        }
    }
}
