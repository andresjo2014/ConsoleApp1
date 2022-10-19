using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business
{
    public class ValidateMask: FileValidator
    {
        public string StrFrom { get; set; }
        public string StrTo { get; set; }

        public ValidateMask(string strFrom,string strTo,StreamReader stream): base(stream)
        {
            this.StrFrom = strFrom;
            this.StrTo = strTo;
            this.Stream = stream;

            this.ValidateFormat();
        }

        private void ValidateFormat()
        {
            //MO10:00-12:00

            string strDay = this.StrFrom.Substring(0, 2);
            this.IsValidDay(strDay);

            string strHourFrom = this.StrFrom.Substring(2, 5);
            this.IsValidHour(strHourFrom);
        }

        private void IsValidHour(string strHourFrom)
        {
            if (string.IsNullOrEmpty(strHourFrom))
            {
                this.MsgResult += " Invalid Hour format";
            }

            string[] strHour = strHourFrom.Split(":");

            if (strHour.Length != 2)
            {
                this.MsgResult += " Invalid Hour format";
            }
            else
            {

                string strHH = strHour[0];
                if (IsNumber(strHH))
                {
                    int number = int.Parse(strHH);
                    if (number < 0 || number > 23)
                    {
                        this.MsgResult += " Invalid Hour format";
                    }
                }

                string strMM = strHour[1];
                if (IsNumber(strMM))
                {
                    int number = int.Parse(strMM);
                    if (number < 0 || number > 59)
                    {
                        this.MsgResult += " Invalid minute format";
                    }
                }

            }

        }

        private bool IsNumber(string strHH)
        {
            try
            {
                int n = int.Parse(strHH);
                return true;
            }
            catch { }

            return false;
        }

        private void IsValidDay(string strDay)
        {
            if (string.IsNullOrEmpty(strDay))
            {
                this.MsgResult += " Invalid Day format";
            }
            if (strDay != "MO" && strDay != "TU" && strDay != "TU"
                && strDay != "WE" && strDay != "TH" && strDay != "FR" 
                && strDay != "SA" && strDay != "SU")
            {
                this.MsgResult += " Invalid Day format";
            }

            
        }
    }
}
