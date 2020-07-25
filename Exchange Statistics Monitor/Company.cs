using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Exchange_Statistics_Monitor
{
    public class Company
    {
        public List<string> fieldsNames;
        public static string SectortsPath
        {
            get
            { return sectortsPath; }
            set
            {
                string path = value;
                System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                try
                {
                    document.Load(path);
                    System.Xml.XmlNode rootNode = document.DocumentElement;
                    sectorsList = new string[rootNode.ChildNodes.Count][];
                    for (int i = 0; i < sectorsList.Length; i++)
                    {
                        sectorsList[i] = new string[rootNode.ChildNodes[i].Attributes.Count];
                        for (int j = 0; j < rootNode.ChildNodes[i].Attributes.Count; j++)
                        {
                            sectorsList[i][j] = rootNode.ChildNodes[i].Attributes[j].Value;
                        }
                    }
                    sectorsInitialized = true;
                }
                catch (Exception)
                {
                    sectortsPath = null;
                    sectorsList = null;
                }
            }
        }
        public string Name
        { get; set; }
        public string Sector
        { get => sector;
            set 
            {
                sector = value;
                for (int i = 0; i < sectorsList.Length; i++)
                {
                    if (sectorsList[i][0] == this.Name)
                    {
                        sectorsList[i][1] = value;
                        break;
                    }
                }
            }
        }
        public string SecurityCode
        { get; set; }
        public Report[] MSFOY
        { get; set; }
        public Report[] RSBUY
        { get; set; }
        public Report[] MSFOQ
        { get; set; }
        public Report[] RSBUQ
        { get; set; }
        public static bool sectorsInitialized = false;
        private static int emptySecCodesCount = 0;
        private static string sectortsPath;
        private static string[][] sectorsList;
        private string sector;

        public Company(string companyLink, string name)
        {
            bool secCodeFound = false;
            Name = name;
            Sector = GetSector(name);
            fieldsNames = new List<string>();
            MSFOY = GetReports(companyLink, "MSFOY", ref secCodeFound);
            RSBUY = GetReports(companyLink, "RSBUY", ref secCodeFound);
            MSFOQ = GetReports(companyLink, "MSFOQ", ref secCodeFound);
            RSBUQ = GetReports(companyLink, "RSBUQ", ref secCodeFound);
            if (MSFOY is null
                && RSBUY is null
                && MSFOQ is null
                && RSBUQ is null)
            {
                throw new NullReferenceException("Company has no reports (constructor warning)!");
            }
        }

        public Report GetLastReport()
        {
            Report[][] reports = { MSFOY, RSBUY, MSFOQ, RSBUQ };

            for (int i = 0; i < reports.Length; i++)
            {
                if (!(reports[i] is null))
                {
                    return reports[i][reports[i].Length - 1];
                }
            }
            throw new NullReferenceException("Company has no reports!");

        }

        public static void SaveSectors()
        {
            XmlDocument document = new XmlDocument();
            XmlNode rootNode = document.CreateElement("sectorsInfo");
            document.AppendChild(rootNode);
            foreach (string[] pair in sectorsList)
            {
                XmlNode node;
                node = document.CreateElement("Company-Sector");
                XmlAttribute name = document.CreateAttribute("name");
                name.Value = pair[0];
                node.Attributes.Append(name);
                XmlAttribute sector = document.CreateAttribute("sector");
                sector.Value = pair[1];
                node.Attributes.Append(sector);
                rootNode.AppendChild(node);
            }
            document.Save(ConfigurationManager.AppSettings["SectorsListPath"]);
        }

        private Report[] GetReports(string companyLinkBase, string reportType, ref bool secCodeFound)
        {
            int id = 0;
            string link = GetLink(companyLinkBase, reportType);
            if (link != null)
            {
                string[] date = null;
                string securityCode = null;
                string[][] table = HTMLOperator.GetTable(link, ref date, ref securityCode);
                if (!secCodeFound)
                {
                    secCodeFound = true;
                    if (!string.IsNullOrWhiteSpace(securityCode) & !string.IsNullOrEmpty(securityCode) & !securityCode.Contains(":"))
                    {
                        this.SecurityCode = securityCode;
                    }
                    else if ((securityCode.Contains(":") | string.IsNullOrEmpty(securityCode) | string.IsNullOrWhiteSpace(securityCode)) & !companyLinkBase.Contains("%"))
                    {
                        this.SecurityCode = companyLinkBase;
                    }
                    else
                    {
                        emptySecCodesCount++;
                        this.SecurityCode = $"000{emptySecCodesCount}";
                    }
                }

                int coulumnCount = table[0].Length;
                int rowCount = table.Length;

                Report[] reports = new Report[coulumnCount - 1];

                for (int j = 1; j < coulumnCount; j++)
                {
                    id++;
                    string[] repDataVal = new string[rowCount];
                    string[] repDataName = new string[rowCount];

                    Array.Clear(repDataVal, 0, repDataVal.Length);
                    Array.Clear(repDataName, 0, repDataName.Length);

                    for (int i = 0; i < rowCount; i++)
                    {
                        repDataName[i] = table[i][0];
                        repDataVal[i] = table[i][j];

                        // fill fieldsNames
                        if (j == 1 && i > 0)
                        {
                            if (fieldsNames.Count > 0)
                            {
                                foreach (string existingName in fieldsNames)
                                {
                                    if (repDataName[i] == existingName)
                                    {
                                        goto skip;
                                    }
                                }
                                fieldsNames.Add(repDataName[i]);
                            }
                            else
                            {
                                fieldsNames.Add(repDataName[i]);
                            }
                        }
                    skip:;
                    }
                    Report report = new Report(ref date[j], repDataVal, repDataName, id, link);
                    reports[j - 1] = report;
                }
                return reports;
            }
            else
            {
                return null;
            }
        }

        private string GetLink(string companyLink, string ReportType)
        {
            string outString = string.Empty;
            if (ReportType == "MSFOY")
            {
                outString = $"https://smart-lab.ru/q/{companyLink}/f/y/MSFO/";
            }
            else if (ReportType == "RSBUY")
            {
                outString = $"https://smart-lab.ru/q/{companyLink}/f/y/RSBU/";
            }
            else if (ReportType == "MSFOQ")
            {
                outString = $"https://smart-lab.ru/q/{companyLink}/f/q/MSFO/";
            }
            else if (ReportType == "RSBUQ")
            {
                outString = $"https://smart-lab.ru/q/{companyLink}/f/q/RSBU/";
            }

            HtmlNodeCollection doc = HTMLOperator.GetHtmlDocument(outString).DocumentNode.SelectNodes("//table");
            //HtmlAgilityPack.HtmlNode doc = HTMLOperator.GetHtmlDocument(outString).DocumentNode.SelectSingleNode("//table");

            if (doc == null)
            {
                outString = null;
            }

            return outString;
        }

        private string GetSector(string name)
        {
            if (sectorsInitialized && !string.IsNullOrWhiteSpace(name))
            {
                try
                {
                    foreach (string[] item in sectorsList)
                    {
                        if (item[0] == name)
                        {
                            return item[1];
                        }
                    }
                    AppendCompany(name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading sectors\n" + ex.Message);
                }

            }
            return Sectors.Uknown;
        }

        private static void AppendCompany(string name)
        {
            Array.Resize(ref sectorsList, sectorsList.Length + 1);
            sectorsList[sectorsList.Length - 1] = new string[2];
            sectorsList[sectorsList.Length - 1][0] = name;
            sectorsList[sectorsList.Length - 1][1] = Sectors.Uknown;
        }

    }
}
