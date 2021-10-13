using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AbstractFactory
{
    public class Logger : ILogger
    {

        private string FILE_LOG_PATH = String.Empty;
        public Logger()
        {
            string FILE_NAME_LOG = "logs.txt";
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = Path.Combine(sCurrentDirectory, (@"..\..\..\Data\" + FILE_NAME_LOG));
            FILE_LOG_PATH = Path.GetFullPath(sFile);
        }
        public void WriteToLogFile(IProduct selected_product)
        {
            var time = DateTime.Now.ToString("dd/MM/yyyy h:m:s tt");

            if (!File.Exists(FILE_LOG_PATH)) File.Create(FILE_LOG_PATH);
            using (StreamWriter sw = File.AppendText(FILE_LOG_PATH))
            {
                sw.WriteLine($"{time};{selected_product?.GetName()};{selected_product?.GetDiscount()}%;{selected_product.GetShopName()}");
            }
        }
        public void WriteToConsole(IProduct selected_product)
        {
            Console.WriteLine($"{selected_product.ToString()} \n ---------------------");
        }

        public void WriteToConsole(string text)
        {
            Console.WriteLine(text);
        }

    }
}
