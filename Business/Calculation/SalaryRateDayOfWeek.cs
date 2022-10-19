using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Calculation
{
    public class SalaryRateDayOfWeek: SalaryValueRate
    {
        public SalaryRateDayOfWeek(string strDay,DateTime dtFrom, DateTime dtTo) : base(strDay, dtFrom, dtTo)
        {
            this.StrDay = strDay;
            this.From = dtFrom;
            this.To = dtTo;


        }
        public override long GetRateValue()
        {

            bool result = (this.StrDay == "MO"
                                || this.StrDay == "TU"
                                || this.StrDay == "TU"
                                || this.StrDay == "WE"
                                || this.StrDay == "TH"
                                || this.StrDay == "FR");


            if (result)
            {
                if (this.From>= common.DateFrom1 && this.To<=common.DateTo1)
                {
                    this.RateValue = 25;
                }
                else if (this.From >= common.DateFrom2 && this.To <= common.DateTo2)
                {
                    this.RateValue = 15;
                }
                else if (this.From >= common.DateFrom3 && this.To <= common.DateTo3)
                {
                    this.RateValue = 20;
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
