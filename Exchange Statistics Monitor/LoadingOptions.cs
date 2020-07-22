using System;
using System.Windows.Forms;

namespace Exchange_Statistics_Monitor
{
    public partial class LoadingOptions : Form
    {
        public LoadingOptions()
        {
            InitializeComponent();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            int delay;
            try
            {
                delay = Convert.ToInt32(textBoxDelay.Text);
                if (delay < 0)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Недопустимые символы или неверное число (задержка)");
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Вы ввели слишком большое или слишком маленькое число (задержка)");
                return;
            }
            MainForm.delay = delay;

            int counter;
            try
            {
                counter = Convert.ToInt32(textBoxCounter.Text);
                if (counter < 1)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Недопустимые символы или неверное число (количество компаний)");
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Вы ввели слишком большое или слишком маленькое число (количество компаний)");
                return;
            }
            MainForm.loadCounter = counter - 1;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
