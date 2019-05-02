using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApI.Controllers
{
    public class CalculateController : ApiController
    {

        /// <summary>
        /// find the lowest absolute sum of elements.
        /// </summary>
        /// <returns></returns>
        [Route("lowestabsolutesumofelements")]
        public int Post(int[] Array)
        {
            var min = Array.Select(x => Math.Abs(x)).Min();
            return min;
        }



     
    }
}
