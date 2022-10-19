using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business
{
    public class FileValidator
    {
        public StreamReader Stream { get; set; }
        public Dictionary<string, List<string>> DicRecordEmployee { get; set; }
        public string MsgResult { get; set; }

        public FileValidator(StreamReader stream)
        {
            this.Stream = stream;
            this.MsgResult = "";
            this.DicRecordEmployee = new Dictionary<string, List<string>>();
        }
        public string Validate()
        {
            if (this.Stream == null)
            {
                this.MsgResult = "This file is null or empty";
            }
            else if (this.Stream.ToString().Length == 0)
            {
                this.MsgResult = "This file is null or empty";
            }
            else
            {
                this.ValidateRecords();
            }
           
            return this.MsgResult;
        }
        private void ValidateRecords()
        {
            int i = 1;
            string strLineConvert;

            while ((strLineConvert = this.Stream.ReadLine()) != null)
            {
                string[] arg = strLineConvert.Split("=");

                if (arg.Length != 2)
                {
                    this.MsgResult += "Invalid format line: " + i.ToString();
                }
                else
                {
                    this.ValidateRecordByComm(arg[1], i);
                    this.SetEmployeeDic(arg);

                }
                
                i++;
            }

        }

        private void ValidateRecordByComm(string record,int index)
        {
            string[] argComma = record.Split(",");

            if (argComma.Length == 0)
            {
                this.ValidateUnderScore(record, index);
            }
            else
            {
                this.ValidateUnderScore(argComma, index);
            }
        }

        private void ValidateUnderScore(string[] argComma, int index)
        {
            foreach (string str in argComma)
            {
                string[] argUnderScore = str.Split("-");
                if (argUnderScore.Length != 2)
                {
                    this.MsgResult += "Invalid format line: " + index.ToString();
                }
                else
                {
                    var result = new ValidateMask(argUnderScore[0], argUnderScore[1], this.Stream);
                }
            }
        }

        

        private void ValidateUnderScore(string record,int index)
        {
            string[] argUnderScore = record.Split("-");
            if (argUnderScore.Length != 2)
            {
                this.MsgResult += "Invalid format line: " + index.ToString();
            }
            else
            {
                var result = new ValidateMask(argUnderScore[0], argUnderScore[1],this.Stream);
            }
        }
        

        private void SetEmployeeDic(string []arg)
        {
            List<string> lstRecord = new List<string>();
            if (!this.DicRecordEmployee.ContainsKey(arg[0]))
            {
                lstRecord.Add(arg[1]);
                this.DicRecordEmployee.Add(arg[0], lstRecord);
            }
            else
            {
                lstRecord = (List<string>)this.DicRecordEmployee[arg[0]];
                lstRecord.Add(arg[1]);
                this.DicRecordEmployee[arg[0]] = lstRecord;
            }
        }

       
    }
}
