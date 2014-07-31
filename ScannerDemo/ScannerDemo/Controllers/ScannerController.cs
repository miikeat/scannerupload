using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScannerDemo.Models;
using System.Collections;
using System.Diagnostics;
using ScannerDemo.Authentication;

namespace ScannerDemo.Controllers
{
    
    public class ScannerController : ApiController
    {

        public static Upload Upl = null;
        public static User usr;
        
        // GET: api/Scanner
        public Upload Get()
        {
            return Upl;
        }

        // POST: api/Scanner
        [BasicAuthenticator(realm: "ScannerUpload")]
        public HttpResponseMessage Post([FromBody]Upload data)
        {
            if (data != null && data.Cart != null && data.Cart.Count() > 0)
            {
                Upl = data;
                Upl.User = usr;
                return new HttpResponseMessage(HttpStatusCode.OK);
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
