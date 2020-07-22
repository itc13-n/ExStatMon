using System;

namespace Exchange_Statistics_Monitor
{
    public class Report
    {
        public DateTime? Date
        { get; set; }
        public ReportData[] ReportData
        { get; set; }
        public string Source
        { get; set; }
        public int ID
        { get; set; }

        public Report(ref string date, string[] repDataVal, string[] repDataName, int id, string source = "unknown")
        {
            this.ID = id;
            Source = source;
            this.Date = GetDateHTML(date);
            this.ReportData = new ReportData[repDataVal.Length - 1];
            for (int i = 1; i <= ReportData.Length; i++)
            {
                float? repDataField;
                if (!string.IsNullOrWhiteSpace(repDataVal[i]))
                {
                    try
                    {
                        if (repDataVal[i].Contains("."))
                        {
                            int dotPos = repDataVal[i].LastIndexOf(".");
                            if (repDataVal[i].Length > dotPos + 5)
                            {
                                if (repDataVal[i].Contains("%"))
                                {
                                    repDataField = Convert.ToSingle(repDataVal[i].Replace("%", "").Substring(0, dotPos + 5));
                                }
                                else
                                {
                                    repDataField = Convert.ToSingle(repDataVal[i].Substring(0, dotPos + 5));
                                }
                            }
                            else
                            {
                                if (repDataVal[i].Contains("%"))
                                {
                                    repDataField = Convert.ToSingle(repDataVal[i].Replace("%", ""));
                                }
                                else
                                {
                                    repDataField = Convert.ToSingle(repDataVal[i]);
                                }
                            }
                        }
                        else
                        {
                            if (repDataVal[i].Contains("%"))
                            {
                                repDataField = Convert.ToSingle(repDataVal[i].Replace("%", ""));
                            }
                            else
                            {
                                repDataField = Convert.ToSingle(repDataVal[i]);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        repDataField = -1;
                    }
                }
                else
                {
                    repDataField = null;
                }
                ReportData[i - 1] = new ReportData(repDataName[i], repDataField);
            }
        }

        public float? GetFieldValue(string fieldName)
        {
            float? fieldVal = null;
            if (string.IsNullOrWhiteSpace(fieldName))
            {
                return null;
            }

            foreach (ReportData pair in ReportData)
            {
                if (pair.fieldName.ToLower().Contains(fieldName.ToLower()) | fieldName.ToLower().Contains(pair.fieldName.ToLower()))
                {
                    fieldVal = pair.fieldData;
                    break;
                }
            }

            return fieldVal;
        }

        private DateTime? GetDateHTML(string date)
        {
            if (!string.IsNullOrEmpty(date) && !string.IsNullOrWhiteSpace(date))
            {
                string[] s = date.Split('\u002E');
                try
                {
                    DateTime? outDate = new DateTime(Convert.ToInt32(s[2]), Convert.ToInt32(s[1]), Convert.ToInt32(s[0]));
                    return outDate;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else { return null; }
        }
    }

}
