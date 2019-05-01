using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApI.Models
{
    public class ApiHelper
    {
        //Calculate sum in an array using Recurssion
        public int SumRecurssion(List<int> Values, int start, int end)
        {
            if (start < end)
                return Values[start] + SumRecurssion(Values, start + 1, end);
            else return 0;
        }

        // Calculate the sum of first N numbers
        public int FibonacciSum(int n)
        {
            int FirstNumber = 0;
            int SecondNumber = 1;
            
            for (int i = 0; i < n; i++)
            {
                int temp = FirstNumber;
                FirstNumber = SecondNumber;
                SecondNumber = temp + SecondNumber;
            }
            return FirstNumber;
        }
        public  void WriteLog(Exception ex, string methodName)
        {
            //lock (lockObject)
            //{
            using (var sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\ErrorFile.txt", true))
            {
                sw.WriteLine("------------------------------------------------------");
                sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + " : ERROR :: " + ex.Source.ToString().Trim() + " - " + ex.Message);
                sw.WriteLine("Occured at : " + methodName);
                if (ex.InnerException != null)
                    sw.WriteLine("Inner Exception : " + ex.InnerException.Message);
                sw.WriteLine("Trace : " + ex.StackTrace);
                sw.WriteLine("------------------------------------------------------");
                sw.Flush();
            }
            // }
        }
    }
}