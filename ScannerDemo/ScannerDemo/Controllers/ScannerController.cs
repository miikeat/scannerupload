using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScannerDemo.Models;
using System.Collections;
using System.Diagnostics;

namespace ScannerDemo.Controllers
{
    public class ScannerController : ApiController
    {

        public static Upload Upl = null;
        
        // GET: api/Scanner
        public Upload Get()
        {
            return Upl;
        }

        // POST: api/Scanner
        public HttpResponseMessage Post([FromBody]Upload data)
        {
            if (data != null)
            {
                Upl = data;
                if (data.User.Username.Equals("TestUser") && data.User.Password.Equals("TestPassword"))
                {
                    if (data.Cart.Count() <= 0)
                       return new HttpResponseMessage(HttpStatusCode.BadRequest);
                    else
                       return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                Debug.WriteLine("no data");
                Upl = null;
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            
        }
    }

    

}
