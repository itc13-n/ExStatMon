using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace Exchange_Statistics_Monitor
{
    public static class LayoutTemplates
    {
        public static XmlDocument fields;
        public static Company[] companies;

        public static ToolStripMenuItem[] GetSortMethodsList()
        {
            ToolStripMenuItem безСортировкиToolStripMenuItem;
            безСортировкиToolStripMenuItem = new ToolStripMenuItem
            {
                Name = "безСортировкиToolStripMenuItem",
                Size = new System.Drawing.Size(180, 22),
                Text = "без сортировки"
            };


            ToolStripMenuItem поСекторамToolStripMenuItem;
            поСекторамToolStripMenuItem = new ToolStripMenuItem
            {
                Name = "поСекторамToolStripMenuItem",
                Size = new System.Drawing.Size(180, 22),
                Text = "по секторам"
            };


            return new ToolStripMenuItem[] { безСортировкиToolStripMenuItem, поСекторамToolStripMenuItem };
        }

        public static TabPage GetTabPage(int index)
        {

            if (index == 0) // unsorted
            {
                DataGridView dataGridViewUnsorted = new DataGridView();
                ((System.ComponentModel.ISupportInitialize)(dataGridViewUnsorted)).BeginInit();
                dataGridViewUnsorted.Location = new System.Drawing.Point(0, 0);
                dataGridViewUnsorted.Name = "dataGridViewUnsorted";
                dataGridViewUnsorted.TabIndex = 0;
                ((System.ComponentModel.ISupportInitialize)(dataGridViewUnsorted)).EndInit();
                dataGridViewUnsorted.Dock = DockStyle.Fill;


                { // dataGridView populate and fill
                    List<string> visibleFields = UserConfigOperator.GetVisible();

                    dataGridViewUnsorted.TopLeftHeaderCell.Value = "Название";
                    
                    dataGridViewUnsorted.ColumnCount = visibleFields.Count;
                    dataGridViewUnsorted.RowCount = companies.Length;
                    dataGridViewUnsorted.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    for (int i = 0; i < companies.Length; i++)
                    {
                        dataGridViewUnsorted.Rows[i].HeaderCell.Value = companies[i].Name;
                        dataGridViewUnsorted.RowHeadersWidth = 100;
                        for (int j = 0; j < dataGridViewUnsorted.ColumnCount; j++)
                        {
                            dataGridViewUnsorted.Columns[j].HeaderText = visibleFields[j];
                            dataGridViewUnsorted[j, i].Value = companies[i].GetLastReport().GetFieldValue(visibleFields[j]);
                        }
                    }
                    dataGridViewUnsorted.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewUnsorted.Click += DataGridViewUnsorted_Click;
                }

                Panel tabPanel = new Panel();
                tabPanel.Controls.Add(dataGridViewUnsorted);
                tabPanel.SuspendLayout();
                tabPanel.Location = new System.Drawing.Point(3, 3);
                tabPanel.Name = "panel3";
                tabPanel.TabIndex = 0;
                tabPanel.Dock = DockStyle.Fill;
                tabPanel.ResumeLayout(false);

                TabPage tabPage = new TabPage();
                tabPage.Controls.Add(tabPanel);
                tabPage.Text = "Все компании";
                return tabPage;
            }

            else if (index == 1) // by sector
            {
                List<Company>[] companiesBySector = new List<Company>[Sectors.Count];
                for (int i = 0; i < companiesBySector.Length; i++)
                {
                    companiesBySector[i] = new List<Company>();
                }
                
                string[] listOfSectors = Sectors.GetAll();
                for (int i = 0; i < companies.Length; i++)
                {
                    for (int j = 0; j < listOfSectors.Length; j++)
                    {
                        if (companies[i].Sector == listOfSectors[j])
                        {
                            companiesBySector[j].Add(companies[i]);
                        }
                    }
                }

                Panel tabPanel = new Panel();
                tabPanel.SuspendLayout();
                tabPanel.Location = new System.Drawing.Point(3, 3);
                tabPanel.Name = "tabPanel";
                tabPanel.TabIndex = 0;
                tabPanel.Dock = DockStyle.Fill;
                tabPanel.AutoScroll = true;
                tabPanel.ResumeLayout(false);

                TabPage tabPage = new TabPage();
                tabPage.Text = "По секторам";
                tabPage.Controls.Add(tabPanel);

                string[] sectorsInfo = Sectors.GetInfo();
                DataGridView previousDGV = null;
                for (int i = 0; i < Sectors.Count; i++)
                {
                    Label sectorLabel = new Label();
                    sectorLabel.Text = sectorsInfo[i];
                    sectorLabel.AutoSize = true;
                    if (i == 0)
                    {
                        sectorLabel.Location = new System.Drawing.Point(80, 20);
                    }
                    else
                    {
                        sectorLabel.Location = new System.Drawing.Point(80, previousDGV.Location.Y + previousDGV.Size.Height + 10);
                    }
                    tabPanel.Controls.Add(sectorLabel);

                    DataGridView sectorDGV = new DataGridView();
                    ((System.ComponentModel.ISupportInitialize)(sectorDGV)).BeginInit();
                    sectorDGV.Location = new System.Drawing.Point(40, sectorLabel.Location.Y + sectorLabel.Size.Height + 2);
                    sectorDGV.Size = new System.Drawing.Size(tabPanel.Width - 80, 500);
                    sectorDGV.Name = "dataGridViewBySector" + listOfSectors[i];
                    sectorDGV.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    ((System.ComponentModel.ISupportInitialize)(sectorDGV)).EndInit();
                    FillDGV(sectorDGV, companiesBySector[i], i);

                    
                    tabPanel.Controls.Add(sectorDGV);
                    previousDGV = sectorDGV;

                }
                return tabPage;
            }
            else
            {
                throw new NullReferenceException("Sort index is invalid"); // if this appears check for conformity between
                                                                           // ToolStripMenyItems and mentioned index values
                                                                           // (prbably missing implementation)
            }

        }

        private static void DataGridViewUnsorted_Click(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            Form f = new FormSectorSet(companies[dgv.SelectedRows[0].Index]);
            f.ShowDialog();
            f.Dispose();
        }

        private static void FillDGV(DataGridView dGV, List<Company> companies)
        {
            if (companies.Count<1)
            {
                return;   
            }    
            List<string> visibleFields = UserConfigOperator.GetVisible();

            dGV.TopLeftHeaderCell.Value = "Название";

            dGV.ColumnCount = visibleFields.Count;
            dGV.RowCount = companies.Count;
            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for (int i = 0; i < companies.Count; i++)
            {
                dGV.Rows[i].HeaderCell.Value = companies[i].Name;
                dGV.RowHeadersWidth = 100;
                for (int j = 0; j < dGV.ColumnCount; j++)
                {
                    dGV.Columns[j].HeaderText = visibleFields[j];
                    dGV[j, i].Value = companies[i].GetLastReport().GetFieldValue(visibleFields[j]);
                    }
                }
        }

        private static void FillDGV(DataGridView dGV, List<Company> companies, int index)
        {
            if (companies.Count < 1)
            {
                return;
            }
            List<string> visibleFields = UserConfigOperator.GetVisibleBySector(index);

            dGV.TopLeftHeaderCell.Value = "Название";

            dGV.ColumnCount = visibleFields.Count;
            dGV.RowCount = companies.Count;
            dGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for (int i = 0; i < companies.Count; i++)
            {
                dGV.Rows[i].HeaderCell.Value = companies[i].Name;
                dGV.RowHeadersWidth = 100;
                for (int j = 0; j < dGV.ColumnCount; j++)
                {
                    dGV.Columns[j].HeaderText = visibleFields[j];
                    dGV[j, i].Value = companies[i].GetLastReport().GetFieldValue(visibleFields[j]);
                }
            }
        }
    }
}
