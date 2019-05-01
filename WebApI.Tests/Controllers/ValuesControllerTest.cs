using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApI;
using WebApI.Controllers;

namespace WebApI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void ClosestToZero()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            int[] arr = {1,2,6};
            int result = controller.Post(arr);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
          
        }

        [TestMethod]
        public void SumOfNumbers()
        {
            // Arrange
            ValuesController controller = new ValuesController();
            var arr = new List<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Add(6);
          
            // Act
            var result = controller.Post(arr);

            var testData = new Dictionary<string, int>();
            testData.Add("Sum for WhileLoop", 9);
            testData.Add("Sum for recursion", 9);
            testData.Add("Sum for ForLoop", 9);

            // Assert
            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(testData, result);
           
        }

        ValuesController.ListToCombine Data = new ValuesController.ListToCombine();

        [TestMethod]
        public void ListToCombine()
        {

            // Arrange
            ValuesController controller = new ValuesController();
            // data.list{"list": [  "1,2,3",  "a,b,c" ]  };
            // var list = string.Format(@"{"list": [  "1, 2, 3",  "a, b, c" ]  }");
            // Data.list. = new { "1,2,3","a,b,c"}";



            // Act
           List<string> result =  controller.Post(Data);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result);
            // Assert
        }
        /// <summary>
        /// /Returns The list of 100 fibo Numbers
        /// </summary>
        [TestMethod]
        public void ListOf100Fibonacci()
        {
            // Arrange
            ValuesController controller = new ValuesController();

            // Act
            List<int> result = controller.Get();

            // Assert
           
            string rawData = " 0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,196418,317811,514229,832040,1346269,2178309,3524578,5702887,9227465,14930352,24157817,39088169,63245986,102334155,165580141,267914296,433494437,701408733,1134903170,1836311903,-1323752223,512559680,-811192543,-298632863,-1109825406,-1408458269,1776683621,368225352,2144908973,-1781832971,363076002,-1418756969,-1055680967,1820529360,764848393,-1709589543,-944741150,1640636603,695895453,-1958435240,-1262539787,1073992269,-188547518,885444751,696897233,1582341984,-2015728079,-433386095,1845853122,1412467027,-1036647147,375819880,-660827267,-285007387,-945834654,-1230842041,2118290601,887448560,-1289228135,-401779575,-1691007710,-2092787285,511172301,-1581614984,-1070442683,1642909629,572466946,-2079590721,-1507123775,708252800,-798870975,-90618175,-889489150";
            var testData = rawData.Split(',').ToList();
            List<int> intList = testData.ConvertAll(int.Parse);     
            CollectionAssert.AreEqual(intList, result);
        }

        //[TestMethod]
        //public void Delete()
        //{
        //    // Arrange
        //    ValuesController controller = new ValuesController();

        //    // Act
        //    controller.Delete(5);

        //    // Assert
        //}
    }
}
