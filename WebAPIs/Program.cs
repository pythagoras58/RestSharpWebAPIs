using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace WebAPIs
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            var Authtoken = " 463227032b0367550695cf350481eb81d9df46af";
            var AccToken = "4cf4569fb1";

            using (var client = new RestClient("https://secure.fleetio.com/api/v1/inventory_journal_entries")) { 
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("Authorization", "Token "+ Authtoken);
            request.AddHeader("Account-Token", AccToken);
            request.Method = Method.Post;
                // IRestResponse response = client.Execute(request);

            var payload = new JObject();

            // parameters 
            var adjustment_quantity = 3;
            var inventory_adjustment_reason_id = 544414;
            //var current_quantity = 1;
            var part_id = 1695453;
            var part_location_detail_id = 17332424;


            payload.Add("adjustment_quantity", adjustment_quantity);
            payload.Add("inventory_adjustment_reason_id", inventory_adjustment_reason_id);

            payload.Add("part_id", part_id);

            payload.Add("part_location_detail_id", part_location_detail_id);

            request.AddStringBody(payload.ToString(), DataFormat.Json);

            var results = client.PostAsync(request).Result;

                Console.WriteLine(results);
                Console.ReadLine(); 
            
            }
        }

    }
}
