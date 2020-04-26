using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IEXTrading.Infrastructure.RecDataHandler;
using IEXTrading.Models;

using IEXTrading.DataAccess;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace MVCTemplate.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;
        private readonly AppSettings _appSettings;
        public const string SessionKeyName = "Recreational_Activities";
        //List<Company> companies = new List<Company>();
        public HomeController(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            dbContext = context;
            _appSettings = appSettings.Value;
        }

       public IActionResult About()
        {
            ViewBag.Hello = _appSettings.Hello;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Read_rec_data()
        {
            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            RecDataHandler webHandler = new RecDataHandler();
            List<Rec> rec_centers = webHandler.Getrecdata();

            String recdata = JsonConvert.SerializeObject(rec_centers);
            //int size =  System.Text.ASCIIEncoding.ASCII.GetByteCount(companiesData);

            HttpContext.Session.SetString(SessionKeyName, recdata);

           
            return View(rec_centers);
        }

               public IActionResult Savedata()
        {
            string recdata = HttpContext.Session.GetString(SessionKeyName);
            List<Rec> rec_center_list = null;
            if (recdata != "")
            {
                rec_center_list = JsonConvert.DeserializeObject<List<Rec>>(recdata);
            }
            
            foreach (Rec r in rec_center_list)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //So add company only if it doesnt exist, check existence using symbol (PK)
                //if (dbContext.Companies.Where(c => c.activity.Equals(company.activity)).Count() == 0)
                //{
                    dbContext.Rec_centers.Add(r);
                //}
            }
            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Read_rec_data", rec_center_list);
        }


        public IActionResult savedrecdatacshtml()
        {
            string recdata = HttpContext.Session.GetString(SessionKeyName);
            List<Rec> rec_center_list = null;
            if (recdata != "")
            {
                rec_center_list = JsonConvert.DeserializeObject<List<Rec>>(recdata);
            }

            
            return View("savedrecdatacshtml", rec_center_list);
        }

        public IActionResult Refresh(string tableToDel)
         {
             ClearTables(tableToDel);
             Dictionary<string, int> tableCount = new Dictionary<string, int>();
             tableCount.Add("Delete all Records", dbContext.Rec_centers.Count());
             tableCount.Add("Delete records for activity Basketball", dbContext.Rec_centers.Where(c => c.activity == "Basketball").Count());
             tableCount.Add("Delete records for activity Badminton", dbContext.Rec_centers.Where(c => c.activity == "Badminton").Count());
             tableCount.Add("Delete records for activity Pickleball", dbContext.Rec_centers.Where(c => c.activity == "Pickleball").Count());
            tableCount.Add("Delete records for activity Volleyball", dbContext.Rec_centers.Where(c => c.activity == "Volleyball").Count());
            tableCount.Add("Delete records for activity Tiny Tots", dbContext.Rec_centers.Where(c => c.activity == "Tiny Tots").Count());
            tableCount.Add("Delete records for activity Table Tennis", dbContext.Rec_centers.Where(c => c.activity == "Table Tennis").Count());
            //tableCount.Add("Charts", dbContext.Equities.Count());

            return View(tableCount);
         }

        /****
 * Deletes the records from tables.
****/
        public void ClearTables(string tableToDel)
        {
            if ("Delete all Records".Equals(tableToDel))
            {
               
                dbContext.Rec_centers.RemoveRange(dbContext.Rec_centers);
            }
            else if ("Delete records for activity Basketball".Equals(tableToDel))
            {
               
                dbContext.Rec_centers.RemoveRange(dbContext.Rec_centers
                                                         .Where(c => c.activity == "Basketball")
                                                                      );
            }
            else if ("Delete records for activity Badminton".Equals(tableToDel))
            {
                dbContext.Rec_centers.RemoveRange(dbContext.Rec_centers
                                                         .Where(c => c.activity == "Badminton")
                                                                      );
            }
            else if ("Delete records for activity Pickleball".Equals(tableToDel))
            {
                dbContext.Rec_centers.RemoveRange(dbContext.Rec_centers
                                                         .Where(c => c.activity == "Pickleball")
                                                                      );
            }
            else if ("Delete records for activity Volleyball".Equals(tableToDel))
            {
                dbContext.Rec_centers.RemoveRange(dbContext.Rec_centers
                                                         .Where(c => c.activity == "Volleyball")
                                                                      );
            }
            else if ("Delete records for activity Tiny Tots".Equals(tableToDel))
            {
                dbContext.Rec_centers.RemoveRange(dbContext.Rec_centers
                                                         .Where(c => c.activity == "Tiny Tots")
                                                                      );
            }
            else if ("Delete records for activity Table Tennis".Equals(tableToDel))
            {
                dbContext.Rec_centers.RemoveRange(dbContext.Rec_centers
                                                         .Where(c => c.activity == "Table Tennis")
                                                                      );
            }
            dbContext.SaveChanges();
        }




    }
}
