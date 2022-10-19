using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Calculation
{
    public class WorkedDay
    {
        public DateTime HourFrom { get; set; }
        public DateTime HourTo { get; set; }
        public string StrDay { get; set; }

        public bool IsDayOfWeek
        {
            get
            {
                return (this.StrDay == "MO" || this.StrDay == "TU" || this.StrDay == "WE"
                        || this.StrDay == "TH" || this.StrDay == "FR");
            }
        }
        public bool IsWeekend
        {
            get
            {
                return (this.StrDay == "SA" || this.StrDay == "SU");
            }
        }

    }
}
