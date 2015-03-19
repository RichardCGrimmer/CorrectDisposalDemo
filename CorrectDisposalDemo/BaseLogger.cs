namespace CorrectDisposalDemo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class BaseLogger
    {
        protected TextWriter tw = new StreamWriter(@"C:\Temp\Log.log");

        public void Log (string logMessage)
        {
            this.tw.WriteLine(logMessage);
        }
    }
}
