using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class Common
    {
        public DateTime DateFrom1 
        {
            get 
            {
                DateTime d = DateTime.Parse("2000/01/01");
                d = d.AddHours(0);
                d = d.AddMinutes(1);

                return d;
            }
        }
        public DateTime DateFrom2
        {
            get
            {
                DateTime d = DateTime.Parse("2000/01/01");
                d = d.AddHours(9);
                d = d.AddMinutes(1);

                return d;
            }
        }
        public DateTime DateFrom3
        {
            get
            {
                DateTime d = DateTime.Parse("2000/01/01");
                d = d.AddHours(18);
                d = d.AddMinutes(1);

                return d;
            }
        }


        public DateTime DateTo1
        {
            get
            {
                DateTime d = DateTime.Parse("2000/01/01");
                d = d.AddHours(9);
                d = d.AddMinutes(0);

                return d;
            }
        }
        public DateTime DateTo2
        {
            get
            {
                DateTime d = DateTime.Parse("2000/01/01");
                d = d.AddHours(18);
                d = d.AddMinutes(0);

                return d;
            }
        }
        public DateTime DateTo3
        {
            get
            {
                DateTime d = DateTime.Parse("2000/01/01");
                d = d.AddHours(23);
                d = d.AddMinutes(59);

                return d;
            }
        }
    }
}
