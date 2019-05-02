using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

using WebApI.Models;

namespace WebApI.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {

        ApiHelper web = new ApiHelper();

        /// <summary>
        /// Returns the value closest to zero which is supplied via an array parameter.
        /// </summary>
        /// <returns>Number int closest to zero </returns>
        /// 
        [Route("ClosestToZero")]
        public int Post([FromBody] int[] intArray)
        {

            if (intArray == null)
            {
                throw new NullReferenceException("IntArray can't be null");
            }

            int nearest = 0;
            try
            {
                nearest = intArray.OrderBy(x => Math.Abs((long)x - 0)).First();
            }
            catch (Exception ex)
            {
                web.WriteLog(ex, MethodBase.GetCurrentMethod().Name);
                throw ex;
                //return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return nearest;
        }

        /// <summary>
        /// Returns sum of the numbers in a given list using a for- loop, a while-loop, and recursion..
        /// </summary>
        /// <returns>The sum for each loop</returns>

        [Route("SumOfNumbers")]
        public Dictionary<string, int> Post([FromBody] List<int> intArray)
        {

            int index = 0, sumUsingWhileLoop = 0;
            int TotalForLoop = 0;
            if (intArray == null)
            {
                throw new NullReferenceException("intArray can't be null");
            }
            var results = new Dictionary<string, int>();
            try
            {
                //sum for While Loop
                while (index < intArray.Count)
                {
                    sumUsingWhileLoop += intArray[index];
                    index = index + 1;
                }

                //sum for ForLoop
                foreach (var item in intArray)
                {
                    TotalForLoop = TotalForLoop + item;

                }
                //sum for recursion
                int recursion = web.SumRecurssion(intArray, 0, intArray.Count);


                results.Add("Sum for WhileLoop", sumUsingWhileLoop);
                results.Add("Sum for recursion", recursion);
                results.Add("Sum for ForLoop", TotalForLoop);
            }
            catch (Exception ex)
            {
                web.WriteLog(ex, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            return results;
            //Display results on a string
            //  return string.Format("Sum for WhileLoop {0} : Sum for recursion {1} : Sum for ForLoop {2}", sumUsingWhileLoop, recursion, TotalForLoop);
        }

        //A class for the 

        public class ListToCombine
        {
            public string[] list { get; set; }
        }

        /// <summary>
        ///  combines two lists
        /// </summary>
        /// <returns>The sum for each loop</returns>
        [Route("CombinesTwoList")]
        public List<string> Post([FromBody] ListToCombine data)
        {
            var ArrayResults = new List<string>();
            if (data == null)
            {
                throw new NullReferenceException("List of arrays can't be null");
            }
            if (data != null)
            {
                var FirstArray = data.list[0].ToList();
                var SecondArray = data.list[1].Split(',').ToList();
                try
                {
                    var newList = SecondArray.Join(FirstArray, s => SecondArray.IndexOf(s), i => FirstArray.IndexOf(i), (s, i) => new { First = s, Second = i }).ToList();

                    foreach (var item in newList)
                    {
                        ArrayResults.Add(item.First.ToString());
                        ArrayResults.Add(item.Second.ToString());
                    }
                }
                catch (Exception ex)
                {
                    web.WriteLog(ex, MethodBase.GetCurrentMethod().Name);
                    throw ex;
                }
            }
            return ArrayResults;
        }

        /// <summary>
        /// computes the list of the first 100 Fibonacci numbers.
        /// </summary>
        /// <returns> lIst of 100 Fibonacci numbers. </returns>

        [Route("ListOf100Fibonacci")]
        public List<int> Get()
        {
            var FibonacciList = new List<int>();
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    FibonacciList.Add(web.FibonacciSum(i));

                }
            }
            catch (Exception ex)
            {
                web.WriteLog(ex, MethodBase.GetCurrentMethod().Name);
                throw ex;
            }

            return FibonacciList;
        }

        ///<summary>
        /// find the lowest absolute sum of elements.
        /// </summary>
        /// <returns></returns>
        [Route("AddNumbersToAddTo100")]
        public List<int> Post()
        {
            int total = 0;
            int count = 0;
            Random random = new Random();
            var ListOfNumbersToAdd = new List<int>();

            int NUmbertoCalculate = 0;

            string numbers = "1,2,..,9";

            var listOfNumbers = numbers.Split(',');

            foreach (var item in listOfNumbers)
            {
                var num = int.TryParse(item, out NUmbertoCalculate);

                if (NUmbertoCalculate == 0)
                {

                    while (total < 100)
                    {
                        int randNum = random.Next(100);
                        total = total + 12 + randNum;
                        ListOfNumbersToAdd.Add(randNum);
                        if (total > 100)
                        {

                        }
                    }
                }
            }
            return ListOfNumbersToAdd;
        }
    }
}
