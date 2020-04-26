using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using IEXTrading.Models;
using Newtonsoft.Json;

namespace IEXTrading.Infrastructure.RecDataHandler
{
    public class RecDataHandler
    {
        static string BASE_URL = "https://data.montgomerycountymd.gov/resource/ijwf-vj4h.json"; //This is the base URL, method specific URL is appended to this.
        HttpClient httpClient;

        public RecDataHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

      
        public List<Rec> Getrecdata()
        {
            string Rec_API_PATH = BASE_URL + "?$query=select distinct activity,recreation_center, phone_number, address, age_requirements, days_of_week, times";
            string companyList = "";

            List<Rec> companies = null;
                        
            httpClient.BaseAddress = new Uri(Rec_API_PATH);
            HttpResponseMessage response = httpClient.GetAsync(Rec_API_PATH).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            if (!companyList.Equals(""))
            {
                companies = JsonConvert.DeserializeObject<List<Rec>>(companyList);
                
                companies = companies.GetRange(20, 40);
                
            }
            return companies;
        }

      
    
    }
}
