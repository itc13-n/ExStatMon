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
    public partial class SetColumnsForm : Form
    {
        public SetColumnsForm()
        {
            InitializeComponent();
        }

        private void SetColumnsForm_Load(object sender, EventArgs e)
        {
            foreach (string field in UserConfigOperator.GetVisible())
            {
                listBoxVisible.Items.Add(field);
            }

            foreach (string field in UserConfigOperator.FieldNames)
            {
                listBoxAll.Items.Add(field);
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
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

        private void buttonHide_Click(object sender, EventArgs e)
        {
            listBoxVisible.Items.Remove(listBoxVisible.SelectedItem);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < UserConfigOperator.FieldNames.Count; i++)
            {
                UserConfigOperator.FieldNamesVisUnsorted[i] = false;

                foreach (string item in listBoxVisible.Items)
                {
                    if (item == UserConfigOperator.FieldNames[i])
                    {
                        UserConfigOperator.FieldNamesVisUnsorted[i] = true;
                    }
                }
            }

            UserConfigOperator.SaveFieldsFile();
            MessageBox.Show("Сохранено!");
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
