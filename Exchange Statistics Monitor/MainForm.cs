using Exchange_Statistics_Monitor.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Exchange_Statistics_Monitor
{
    public partial class MainForm : Form
    {
        public const string webAddressMain = "https://smart-lab.ru/q/shares_fundamental/";
        public static int delay = 1000;
        public static int loadCounter = 10;
        public static int SortIndex = 1;
        public static Form loadScreen;

        public MainForm()
        {
            InitializeComponent();
        }

        private async Task<Company> GetCompany(string parPair1, string parPair2)
        {
            Company company = await Task.Run(() => new Company(parPair1, parPair2));
            return company;
        }

        private async Task<Company[]> GetCompanies()
        {
            List<string[]> comPar = HTMLOperator.GetCompanyParameters(webAddressMain);
            List<Task<Company>> tasks = new List<Task<Company>>();
            int counter = 0;
            foreach (string[] pair in comPar)
            {
                if (counter == 10)
                {
                    await Task.Delay(delay);
                    counter = 0;
                }
                tasks.Add(GetCompany(pair[0], pair[1]));

                counter++;
            }

            Company[] companies = await Task.WhenAll(tasks);
            return companies;
        }

        private void СортироватьToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem Clickeditem = e.ClickedItem as ToolStripMenuItem;
            if (sender is ToolStripMenuItem item)
            {
                int index = (item).DropDownItems.IndexOf(Clickeditem);
                SortIndex = index;
                TabPage tabPage = LayoutTemplates.GetTabPage(index);
                tabControl1.TabPages.Clear();
                tabControl1.Controls.Add(tabPage);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void ВыбратьСтолбцыToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (SortIndex == 0)
            {
                Form f = new SetColumnsForm();
                f.ShowDialog();
            }
            else if (SortIndex == 1)
            {
                Form f = new SetColumnsFormBySector();
                f.ShowDialog();
            }
        }

        private void ToolStripButtonRefresh_Click(object sender, System.EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.TabPages[0]);
            tabControl1.TabPages.Add(LayoutTemplates.GetTabPage(SortIndex));
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {

            Form l = new LoadingOptions();
            l.ShowDialog();
            loadScreen = new LoadingScreen();
            loadScreen.Show();
            Company.SectortsPath = ConfigurationManager.AppSettings["SectorsListPath"];
            Company[] c = await GetCompanies();
            UserConfigOperator.InitializeFields(c);
            LayoutTemplates.companies = c;
            this.сортироватьToolStripMenuItem.DropDownItems.AddRange(LayoutTemplates.GetSortMethodsList());
            TabPage tabPage = LayoutTemplates.GetTabPage(SortIndex);
            tabControl1.Controls.Add(tabPage);
            this.Enabled = true;
            loadScreen.Close();
            loadScreen.Dispose();
        }

    }
}
