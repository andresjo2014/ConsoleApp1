using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Calculation
{
    public class SalaryRateDayWeekend: SalaryValueRate
    {
        public SalaryRateDayWeekend(string strDay, DateTime dtFrom, DateTime dtTo) : base(strDay, dtFrom, dtTo)
        {
            this.StrDay = strDay;
            this.From = dtFrom;
            this.To = dtTo;

        }

        public override long GetRateValue()
        {

            bool result = (this.StrDay == "SA"
                               || this.StrDay == "SU");

            if (result)
            {
                if (this.From >= common.DateFrom1 && this.To <= common.DateTo1)
                {
                    this.RateValue = 30;
                }
                else if (this.From >= common.DateFrom2 && this.To <= common.DateTo2)
                {
                    this.RateValue = 20;
                }
                else if (this.From >= common.DateFrom3 && this.To <= common.DateTo3)
                {
                    this.RateValue = 25;
                }
                else
                {
                    //throw new Exception("Iterval period not founded");
                    //not defined
                }

            }


           

            return this.RateValue;
        }
    }
}
