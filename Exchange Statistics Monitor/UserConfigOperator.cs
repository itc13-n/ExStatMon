using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Exchange_Statistics_Monitor
{
    public static class UserConfigOperator
    {
        public static bool isInitialized = false;
        public static List<string> FieldNames
        {
            get => fieldNames;

            private set
            {
                fieldNames = value;
                isInitialized = true;
            }
        }
        public static List<bool> FieldNamesVisUnsorted
        { get => fieldNamesVisUnsorted; private set => fieldNamesVisUnsorted = value; }
        public static List<bool>[] FieldNamesVisBySector
        { get => fieldNamesVisBySector; private set => fieldNamesVisBySector = value; }
        private static List<string> fieldNames;
        private static List<bool> fieldNamesVisUnsorted;
        private static List<bool>[] fieldNamesVisBySector;

        public static void AddFieldsNames(ICollection<Company> companies)
        {
            List<List<string>> companyFields = new List<List<string>>();
            foreach (Company company in companies)
            {
                companyFields.Add(company.fieldsNames);
            }

            foreach (Company company1 in companies)
            {
                foreach (string field in company1.fieldsNames)
                {
                    if (fieldNames.Count > 0)
                    {
                        bool nameExist = false;
                        foreach (string existingName in fieldNames)
                        {
                            if (field == existingName)
                            {
                                nameExist = true;
                                break;
                            }
                        }
                        if (!(nameExist))
                        {
                            fieldNames.Add(field);
                        }
                    }
                    else
                    {
                        fieldNames.Add(field);
                    }
                }
            }
            fieldNamesVisUnsorted.Capacity = fieldNames.Count();
            for (int i = 0; i < fieldNamesVisBySector.Length; i++)
            {
                fieldNamesVisBySector[i] = new List<bool>();
                fieldNamesVisBySector[i].Capacity = fieldNames.Count();
            }
        }

        public static void InitializeFields(ICollection<Company> companies)
        {
            FieldNames = new List<string>();
            fieldNamesVisUnsorted = new List<bool>();
            fieldNamesVisBySector = new List<bool>[Sectors.Count];
            AddFieldsNames(companies);
            XmlDocument document = new XmlDocument();
            document.Load(ConfigurationManager.AppSettings["FieldsPath"]);
            //unsorted
            XmlNode unsorted = document.DocumentElement.ChildNodes[0];
            for (int i = 0; i < unsorted.ChildNodes.Count; i++)
            {
                if (unsorted.ChildNodes[i].Attributes["visible"].Value == "1") //121
                {
                    fieldNamesVisUnsorted.Add(true);
                }
                else
                {
                    fieldNamesVisUnsorted.Add(false);
                }
            }
            //bySector
            XmlNode bySector = document.DocumentElement.ChildNodes[1];
            for (int i = 0; i < fieldNamesVisBySector.Length; i++)
            {
                XmlNode currentSector = bySector.ChildNodes[i];
                for (int j = 0; j < currentSector.ChildNodes.Count; j++)
                {
                    if (currentSector.ChildNodes[j].Attributes["visible"].Value == "1")
                    {
                        fieldNamesVisBySector[i].Add(true);
                    }
                    else
                    {
                        fieldNamesVisBySector[i].Add(false);
                    }
                }
            }

        }

        public static List<string> GetVisible()
        {
            List<string> visibleFields = new List<string>();
            for (int i = 0; i < fieldNames.Count; i++)
            {
                if (fieldNamesVisUnsorted[i] == true)
                {
                    visibleFields.Add(fieldNames[i]);
                }
            }
            return visibleFields;
        }

        public static List<string> GetVisibleBySector(int index)
        {
            List<string> visibleFields = new List<string>();
            for (int i = 0; i < fieldNames.Count; i++)
            {
                if (fieldNamesVisBySector[index][i] == true)
                {
                    visibleFields.Add(fieldNames[i]);
                }
            }
            return visibleFields;
        }

        public static void SaveFieldsFile()
        {
            XmlDocument document = new XmlDocument();
            XmlNode rootNode = document.CreateElement("fields");
            document.AppendChild(rootNode);
            //unsorted
            XmlNode unsortedNode = document.CreateElement("unsorted");
            rootNode.AppendChild(unsortedNode);
            XmlNode fieldNode;
            XmlAttribute visible;
            XmlAttribute name;
            for (int i = 0; i < FieldNames.Count; i++)
            {
                string field = FieldNames[i];
                fieldNode = document.CreateElement("field");
                name = document.CreateAttribute("name");
                name.Value = field;
                visible = document.CreateAttribute("visible");
                if (fieldNamesVisUnsorted[i] == true)
                {
                    visible.Value = "1";
                }
                else
                {
                    visible.Value = "0";
                }
                fieldNode.Attributes.Append(name);
                fieldNode.Attributes.Append(visible);
                unsortedNode.AppendChild(fieldNode);
            }
            //bySector
            XmlNode bySectorNode = document.CreateElement("bySector");
            rootNode.AppendChild(bySectorNode);

            for (int j = 0; j < Sectors.GetAll().Length; j++)
            {
                XmlNode sectorNode = document.CreateElement(Sectors.GetAll()[j]);
                bySectorNode.AppendChild(sectorNode);
                
                XmlNode sectorFieldNode;
                XmlAttribute sectorVisible;
                XmlAttribute sectorName;
                for (int i = 0; i < FieldNames.Count; i++)
                {
                    string field = FieldNames[i];
                    sectorFieldNode = document.CreateElement("field");
                    sectorName = document.CreateAttribute("Name");
                    sectorName.Value = field;
                    sectorVisible = document.CreateAttribute("visible");
                    if (fieldNamesVisBySector[j][i] == true)
                    {
                        sectorVisible.Value = "1";
                    }
                    else
                    {
                        sectorVisible.Value = "0";
                    }
                    sectorFieldNode.Attributes.Append(sectorName);
                    sectorFieldNode.Attributes.Append(sectorVisible);
                    sectorNode.AppendChild(sectorFieldNode);
                }
            }

            document.Save(ConfigurationManager.AppSettings["FieldsPath"]);

        }
    }
}
