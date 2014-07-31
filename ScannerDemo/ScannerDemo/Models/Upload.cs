using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScannerDemo.Models
{
    public class Upload
    {
        public IEnumerable<Article> Cart { get; set; }
        public User User { get; set; }

        public Upload()
        {
            Cart = new List<Article>();
            User = new User(); 
        }


    }
}