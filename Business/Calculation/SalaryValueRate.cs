using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Calculation
{
    public class SalaryValueRate
    {
        public string StrDay { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Common common = new Common();

        public SalaryValueRate(string strDay, DateTime dtFrom, DateTime dtTo)
        {
            this.StrDay = strDay;
            this.From = dtFrom;
            this.To = dtTo;
        }
        protected long RateValue { get; set; }
        public virtual long GetRateValue()
        {
            return 0;
        }
       
    }
}
