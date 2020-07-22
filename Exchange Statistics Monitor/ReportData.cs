using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Statistics_Monitor
{
    public class ReportData
    {
        public string fieldName
        { get; set; }
        public float? fieldData
        { get; set; }

        public ReportData(string fieldName, float? fieldData)
        {
            if (!(fieldData is null))
            {
                this.fieldData = fieldData.Value;
            }
            else
            {
                this.fieldData = null;
            }
            this.fieldName = !(fieldName is null) ? fieldName : "no field name";

        }
    }
}
