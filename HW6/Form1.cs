using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор - Бурыгин Антон");
        }
        void WriteIntoBox(int[] c)
        {
            foreach (var item in c)
            {
                mainBox.Text += item;
            }
            mainBox.Text += Environment.NewLine;
        }
        void AlgL(int n, int t)
        {
            int[] c = new int[t+2];
            mainBox.Text = "";
            for (int j = 0; j < t; j++)
            {
                c[j] = j;
                c[t ] = n;
                c[t + 1] = 0;
                do
                {
                    WriteIntoBox(c);
                    j = 0;
                    while (c[j]+1 == c[j+1])
                    {
                        c[j] = j;
                        j++;
                    }
                    if (j > t-1)
                        return;
                    c[j] = c[j] + 1;
                } while (j<=t-1);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*int n =0, t =0;

            try
            {
                n = int.Parse(textBox1.Text);
                t = int.Parse(textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AlgL(n, t);*/
            try
            {
                List<int> c = new List<int>();
                int count_num = 0;
                int j = 0;
                int t = 0;
                if (int.TryParse(textBox1.Text, out count_num) && int.TryParse(textBox2.Text, out t))
                {
                    mainBox.Text += "Сочетания (" + t + " из " + count_num + "):" + Environment.NewLine + Environment.NewLine;
                    int temp_t = 0;
                    while (temp_t < t)
                    {
                        c.Add(0);
                        temp_t++;
                    }
                    c.Add(0);
                    c.Add(0);

                    for (int i = 0; i != c.Count; i++)
                    {
                        c[i] = i;
                    }

                    c[t] = count_num;
                    c[t + 1] = 0;

                    while (j <= t - 1)
                    {
                        for (int i = t - 1; i >= 0; i--)
                        {
                            mainBox.Text += c[i] + " ";
                        }

                        mainBox.Text += Environment.NewLine;

                        j = 0;

                        while ((c[j] + 1) == c[j + 1])
                        {
                            c[j] = j;
                            j++;
                        }

                        if (j > t - 1)
                        {
                            mainBox.Text += "Алгоритм завершен" + Environment.NewLine + "================================" + Environment.NewLine;
                            break;
                        }
                        else
                        {
                            c[j] = c[j] + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
