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


        private void Button3_Click(object sender, EventArgs e)
        {
            if (MainForm.isParallelEnabled)
            {
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
            }

            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RadioButtonsStateCheck()
        {
            if (radioButtonParallel.Checked)
            {
                panel3.Enabled = true;
                panel5.Enabled = true;
                MainForm.isParallelEnabled = true;
            }
            else
            {
                panel3.Enabled = false;
                panel5.Enabled = false;
                MainForm.isParallelEnabled = false;
            }
        }


        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonsStateCheck();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonsStateCheck();
        }

        private void LoadingOptions_Load(object sender, EventArgs e)
        {
            toolTip1.AutoPopDelay = 10000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.radioButtonParallel, "Значительно быстрее, чем последовательная, рекомендуется использовать не чаще 1го раза в 2 часа" +
                                                           "\nМожет спровоцировать блокировку запросов сервером");
            toolTip1.SetToolTip(this.radioButtonSuccessive, "Значительно медленее, чем параллельная," +
                                                            "\nно со сниженной вероятностью блокировки запросов");
            toolTip1.SetToolTip(this.textBoxCounter, "Число компаний загружаемых параллельно" +
                                                     "\n(1 - ∞)");
            toolTip1.SetToolTip(this.textBoxDelay, "Искуственно встроенная задержка между стопками компаний в миллисекундах" +
                                                   "\n для предотвращения блокировки запросов сервером " +
                                                   "\n(1 - ∞)");
            toolTip1.SetToolTip(this.labelCounter, "Число компаний загружаемых параллельно" +
                                                     "\n(1 - ∞)");
            toolTip1.SetToolTip(this.labelDelay, "Искуственно встроенная задержка между стопками компаний в миллисекундах" +
                                                   "\n для предотвращения блокировки запросов сервером " +
                                                   "\n(1 - ∞)");

            radioButtonSuccessive.Checked = true;
            RadioButtonsStateCheck();
        }
    }
}
