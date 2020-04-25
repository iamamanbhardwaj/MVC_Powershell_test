using MVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            try
            {
                using (var shell = PowerShell.Create())
                {

                    shell.Commands.Clear();
                    shell.AddCommand(@"D:\script1");
                    var result = shell.Invoke();
                    var output = new List<string>();
                     
                    foreach (var item in result)
                    {
                        output.Add(item.BaseObject.ToString());
                    }

                    output.ForEach(a => Console.WriteLine(a));
                }
            }catch(Exception e) { 

            }
                ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Post_1(UserModel model)
        {
            ViewBag.Message = "Post 1 done" + model.UserName;
            return View("About");

        }

        [HttpPost]
        public ActionResult Post_2(UserModel model)
        {
            ViewBag.Message = "Post 2 done" + model.UserName;
            return View("About");

        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

    
}