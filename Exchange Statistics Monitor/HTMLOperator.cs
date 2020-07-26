using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Exchange_Statistics_Monitor
{
    static class HTMLOperator
    {
        public static HtmlAgilityPack.HtmlDocument GetHtmlDocument(string address)
        {
            HtmlWeb webGet = new HtmlWeb();
            try
            {
                HtmlAgilityPack.HtmlDocument document = webGet.Load(address);
                if (document.DocumentNode.InnerHtml.Contains("Too Many Requests"))
                {
                    //MessageBox.Show("Слишком много запросов!");
                }
                return document;
            }
            catch (Exception)// ex)
            {
               //MessageBox.Show("Ошибка закгрузки!\n" + ex.Message);
            }
            return null;
        }

        public static string[][] GetTable(string link, ref string[] date, ref string securityCode)
        {
            HtmlAgilityPack.HtmlDocument doc = GetHtmlDocument(link);
            string[][] table = GetTable(doc, ref date, ref securityCode);//-----------------------------------------------!!

            return table;
        }

        public static string[][] GetTable(HtmlAgilityPack.HtmlDocument document, ref string[] date, ref string securityCode)
        {
            HtmlNode htmlTable = document.DocumentNode.SelectSingleNode("//table");
            int rowCount = 0;
            int columnCount;
            int maxElements = -1;
            securityCode = GetSecurityCode(htmlTable.ChildNodes[1].InnerText);
            foreach (HtmlNode row in htmlTable.SelectNodes("tr"))
            {
                if (row.Attributes["class"]?.Value == "company_report_separator"   // skip specified row
                    | row.Attributes.Count < 1
                    | row.Attributes["field"]?.Value == "date"
                    | row.Attributes["field"]?.Value == "report_url"
                    | row.Attributes["field"]?.Value == "year_report_url"
                    | row.Attributes["field"]?.Value == "presentation_url")
                {
                    { continue; }
                }

                rowCount++;

                columnCount = 0;
                foreach (HtmlNode cell in row.SelectNodes("td|th"))
                {
                    if (cell.Attributes["class"]?.Value == "ltm_spc"       // skip specified column
                        | cell.Attributes["class"]?.Value == "chartrow")
                    {
                        continue;
                    }

                    columnCount++;
                }
                if (columnCount > maxElements)
                    maxElements = columnCount;
            }
            columnCount = maxElements;
            string[][] table = new string[rowCount][];
            Array.Resize(ref date, columnCount);
            HtmlNodeCollection rows = htmlTable.SelectNodes("tr");
                                                                /*     V     */
            int rowIt = 0;//different counter for rows in table (table[ ][ ])

            for (int i = 0; i < rows.Count; i++)
            {
                if (rows[i].Attributes["field"]?.Value == "date")//--------------------------------- date for report
                {                                                                                 //
                    HtmlNodeCollection dateRowCells = rows[i].SelectNodes("td|th");               //
                    for (int k = 1; k < date.Length + 1; k++)                                     //
                    {                                                                             //
                        date[k - 1] = Regex.Replace(dateRowCells[k].InnerText, @"\s+", "");       //
                    }                                                                             //
                }//---------------------------------------------------------------------------------

                if (rows[i].Attributes["class"]?.Value == "company_report_separator"    // skip specified row
                    | rows[i].Attributes.Count < 1
                    | rows[i].Attributes["field"]?.Value == "date"
                    | rows[i].Attributes["field"]?.Value == "report_url"
                    | rows[i].Attributes["field"]?.Value == "year_report_url"
                    | rows[i].Attributes["field"]?.Value == "presentation_url")
                { continue; }

                table[rowIt] = new string[columnCount];

                HtmlNode currentRow = rows[i];

                int j;
                j = 0; // table columns counter

                HtmlNodeCollection currentRowCells = currentRow.SelectNodes("td|th");
                for (int columnNum = 0; columnNum < currentRowCells.Count; columnNum++)
                {

                    if (currentRowCells[columnNum].Attributes["class"]?.Value == "ltm_spc"      // skip specified column
                        | currentRowCells[columnNum].Attributes["class"]?.Value == "chartrow")
                    {
                        continue;
                    }
                    //!!
                    if (currentRow.Attributes["class"]?.Value == "header_row")                                  // header row alignment (1->)      
                    {                                                                                           //                                 
                        table[rowIt][j] = Regex.Replace(currentRowCells[columnNum].InnerText, @"\s+", "");      //                                 
                        j++;                                                                                    // increment table columns counter
                    }
                    else
                    {                                                                                           //                                 
                        table[rowIt][j] = Regex.Replace(currentRowCells[columnNum].InnerText, @"\s+", "");      // common row's cell write to table      
                    j++;                                                                                        // increment table columns counter      
                    }
                }                                                                                                                                    
                rowIt++;
            }
            CleanTable(ref table, ref date);
            return table;
        }

        private static void CleanTable(ref string[][] table, ref string[] date)
        {
            bool[] wasteColumns = new bool[table[0].Length];
            for (int rowId = 0; rowId < table.Length; rowId++)
            {
                if (table[rowId][table[rowId].Length - 1] != null)
                {
                    if (table[rowId][table[rowId].Length - 1].Contains("LTM?"))
                    {
                        wasteColumns[table[rowId].Length - 1] = true;
                    }
                }
                for (int columnId = 0; columnId < table[rowId].Length; columnId++)
                {
                    if (!string.IsNullOrEmpty(table[rowId][columnId])
                        | !string.IsNullOrWhiteSpace(table[rowId][columnId]))
                    {
                        if (table[rowId][columnId] == "%"
                            | table[rowId][columnId] == "?")
                        {
                            wasteColumns[columnId] = true;
                        }
                    }
                }
            }
            RemoveColumns(wasteColumns, ref table, ref date);
        }

        private static void RemoveColumns(bool[] wasteColumns, ref string[][] table, ref string[] date)
        {
            bool allColumnsGood = true;
            int badColCount = 0;
            for (int wasteColNum = 0; wasteColNum < wasteColumns.Length; wasteColNum++)
            {
                if (wasteColumns[wasteColNum])
                {
                    allColumnsGood = false;
                    badColCount++;
                }
            }

            if (!allColumnsGood)
            {
                string[] newDateRow = new string[table[0].Length - badColCount]; // might cause unhandled exceptions

                bool dateCleared = false;

                for (int rowId = 0; rowId < table.Length; rowId++)
                {
                    string[] newRow = new string[table[rowId].Length - badColCount];
                    int newColumnId = 0;
                    for (int oldColumnId = 0; oldColumnId < table[rowId].Length; oldColumnId++)
                    {
                        if (!wasteColumns[oldColumnId])
                        {
                            if (!dateCleared)
                            {
                                newDateRow[newColumnId] = date[oldColumnId];
                            }
                            newRow[newColumnId] = table[rowId][oldColumnId];
                            newColumnId++;
                        }
                    }
                    table[rowId] = newRow;
                    dateCleared = true;
                }
                Array.Resize(ref date, newDateRow.Length);
                for (int m = 0; m < newDateRow.Length; m++)
                {
                    date[m] = newDateRow[m];
                }
            }

        }

        private static string GetSecurityCode(string nodeInnerText)
        {
            int indexOfBegin = nodeInnerText.IndexOf("(") + 1;
            int indexOfEnd = nodeInnerText.IndexOf(")");
            string _ = nodeInnerText.Substring(indexOfBegin, indexOfEnd - indexOfBegin);
            return _;
        }

        private static string GetCompanyName(HtmlNode tdNode)
        {
            string nodeText = tdNode.InnerText;
            if (string.IsNullOrWhiteSpace(nodeText))
            {
                throw new NullReferenceException($"nodeText was whitespace or null: {nodeText.Length}");
            }
            else
            {
                return nodeText;
            }
        }

        private static string GetCompanyLinkBase(HtmlNode tdNode)
        {
            string hrefVal = tdNode.Attributes["href"].Value.Trim();
            if (string.IsNullOrWhiteSpace(hrefVal))
            {
                throw new NullReferenceException("href was null");
            }
            else
            {
                string outString = hrefVal.Substring(hrefVal.LastIndexOf("/") + 1);
                return outString;
            }
        }

        public static List<string[]> GetCompanyParameters(string webAddressMain)
        {
            List<string[]> companiesParameters = new List<string[]>();
            HtmlAgilityPack.HtmlDocument document = GetHtmlDocument(webAddressMain);

            HtmlNodeCollection tables = document.DocumentNode.SelectNodes("//table");
            if (tables is null)
            {
                throw new NullReferenceException($"No tables was found. Address: {webAddressMain}");
            }
            else if (tables.Count < 2)
            {
                throw new IndexOutOfRangeException($"Found only {tables.Count} tables");
            }

            bool f = false;
            foreach (HtmlNode row in tables[0].SelectNodes("tr"))
            {
                if (f)
                {
                    string[] CPair = new string[2];
                    Array.Clear(CPair, 0, CPair.Length);
                    foreach (HtmlNode cell in row.SelectNodes("td|th"))
                    {
                        if (cell.FirstChild?.Attributes.Count == 1)
                        {
                            CPair[0] = GetCompanyLinkBase(cell.FirstChild);
                            CPair[1] = GetCompanyName(cell.FirstChild);
                        }
                    }
                    companiesParameters.Add(CPair);
                }
                f = true;
            }

            return companiesParameters;
        }
    }
}