using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Annoying
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            int newX, newY;
            Random rnd = new Random();

            newX = rnd.Next(0, this.Width - 75);
            newY = rnd.Next(0, this.Height - 23);

            button1.Location = new Point(newX, newY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 newForm1 = new Form1();
            newForm1.Show();
        }

        private async void Form1_Shown(object sender, EventArgs e)
        {
            await TaskDelay(10000);
            button2.Show();
        }

        async Task TaskDelay(int time)
        {
            await Task.Delay(time);
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                for (int i = 0; i < 11; i++)
                {
                    Form2 form2 = new Form2();
                    Screen myScreen = Screen.FromControl(form2);
                    Rectangle area = myScreen.WorkingArea;
                    Random rnd = new Random();
                    int newX, newY;

                    newX = rnd.Next(0, area.Width - (area.Width/10));
                    newY = rnd.Next(0, area.Height - (area.Height/10));

                    form2.Location = new Point(newX, newY);
                    form2.Show();
                    await TaskDelay(100);
                }
            }
        }
    }
}
