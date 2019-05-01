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
        [Route("ClosestToZero")]
        public int Post([FromBody] int[] intArray)
        {
            int nearest = 0;
            try
            {
                nearest = intArray.OrderBy(x => Math.Abs((long)x - 0)).First();
            }
            catch (Exception ex)
            {
                web.WriteLog(ex, MethodBase.GetCurrentMethod().Name);
                //return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
            return nearest;
        }

        // Post api/SumOfNumbers
        [Route("SumOfNumbers")]
        public Dictionary<string, int> Post([FromBody] List<int> intArray)
        {

            int index = 0, sumUsingWhileLoop = 0;
            int TotalForLoop = 0;

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

            var results = new Dictionary<string, int>();
            results.Add("Sum for WhileLoop", sumUsingWhileLoop);
            results.Add("Sum for recursion", recursion);
            results.Add("Sum for ForLoop", TotalForLoop);
            return results;
            //Display results on a string
            //  return string.Format("Sum for WhileLoop {0} : Sum for recursion {1} : Sum for ForLoop {2}", sumUsingWhileLoop, recursion, TotalForLoop);
        }

        //A class for the 
        public class ListToCombine
        {
            public string[] list { get; set; }
        }

        // POST api/CombinesTwoList/{"list": [ "1,2,3","a,b,c"] }

        [Route("CombinesTwoList")]
        public List<string> Post([FromBody] ListToCombine data)
        {
            var ArrayResults = new List<string>();

            var FirstArray = data.list[0].ToList();
            var SecondArray = data.list[1].Split(',').ToList();
            var newList = SecondArray.Join(FirstArray, s => SecondArray.IndexOf(s), i => FirstArray.IndexOf(i), (s, i) => new { First = s, Second = i }).ToList();

            foreach (var item in newList)
            {
                ArrayResults.Add(item.First.ToString());
                ArrayResults.Add(item.Second.ToString());
            }

            return ArrayResults;
        }


        // Post api/ListOf100Fibonacci
        [Route("ListOf100Fibonacci")]
        public List<int> Get()
        {
            var FibonacciList = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                FibonacciList.Add(web.FibonacciSum(i));

            }

            return FibonacciList;
        }
        [Route("lowestabsolutesumofelements")]
        public int Post()
        {
            int[] Array = {5,6,9,10 };

            return Array.Max();

        }
}
}
