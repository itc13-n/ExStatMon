using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Statistics_Monitor
{
    public partial class SetColumnsFormBySector : Form
    {
        public SetColumnsFormBySector()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(Sectors.GetInfo());
            comboBox1.SelectedIndex = 0;
            FillLBVis(comboBox1.SelectedIndex);
            FillLBAll();
        }

        private void FillLBVis(int index)
        {
            foreach (string item in UserConfigOperator.GetVisibleBySector(index))
            {
                listBoxVisible.Items.Add(item);
            }
        }

        private void FillLBAll()
        {
            foreach (string field in UserConfigOperator.FieldNames)
            {
                listBoxAll.Items.Add(field);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxVisible.Items.Clear();
            FillLBVis(comboBox1.SelectedIndex);
        }

        private void ButtonShow_Click(object sender, EventArgs e)
        {
            foreach (string item in listBoxVisible.Items)
            {
                if (item == listBoxAll.SelectedItem.ToString())
                {
                    MessageBox.Show("Выбранный столбец уже отображается");
                    return;
                }
            }
            listBoxVisible.Items.Add(listBoxAll.SelectedItem);
        }

        private void ButtonHide_Click(object sender, EventArgs e)
        {
            listBoxVisible.Items.Remove(listBoxVisible.SelectedItem);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (listBoxVisible.Items.Count < 1)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы один столбец для отображения!");
                return;
            }
            for (int i = 0; i < UserConfigOperator.FieldNames.Count; i++)
            {
                UserConfigOperator.FieldNamesVisBySector[comboBox1.SelectedIndex][i] = false;

                foreach (string item in listBoxVisible.Items)
                {
                    if (item == UserConfigOperator.FieldNames[i])
                    {
                        UserConfigOperator.FieldNamesVisBySector[comboBox1.SelectedIndex][i] = true;
                    }
                }
            }

            UserConfigOperator.SaveFieldsFile();
            MessageBox.Show("Сохранено!");
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
//Нефть и газ
//Энергетика
//IT технологии, связь и СМИ
//Добыча и переаботка руды и металлов
//Финансы и инвестиции
//Потребительский сектор
//Химическая промышленность и фармацевтика
//Логистика и транспорт
//Другое