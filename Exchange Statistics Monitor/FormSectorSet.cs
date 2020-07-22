using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exchange_Statistics_Monitor
{
    public partial class FormSectorSet : Form
    {
        Company company;
        public FormSectorSet(Company company)
        {
            InitializeComponent();
            this.company = company;
        }

        private void FormSectorSet_Load(object sender, EventArgs e)
        {
            string sector = company.Sector;

            checkedListBox1.Items.AddRange(new string[]
            { Sectors.Oil, Sectors.Electricity,
              Sectors.Media, Sectors.MetalMinning,
              Sectors.Financial,Sectors.Transport,
              Sectors.Consumer, Sectors.Chemicals,
              Sectors.Uknown
            });
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemText(checkedListBox1.Items[i]) == sector)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 1)
            {
                MessageBox.Show("Укажите не более одного сектора");
                return;
            }
            else if (checkedListBox1.CheckedItems.Count < 1)
            {
                MessageBox.Show("Укажите хотя бы один сектор");
                return;
            }
            company.Sector = checkedListBox1.CheckedItems[0].ToString();
            this.Close();
        }
    }
}
