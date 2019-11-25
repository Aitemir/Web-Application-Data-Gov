using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using WebApplicationDataGov.Models;

namespace WebApplicationDataGov.APIHandlerManager
{
    public class APIHandler
    {
        /*
        // Obtaining the API key is easy. The same key should be usable across the entire
        // data.gov developer network, i.e. all data sources on data.gov.
        // https://www.nps.gov/subjects/developer/get-started.htm

        static string BASE_URL = "https://api.data.gov/ed/collegescorecard/v1/";

        //static string API_KEY = "rdesCWBgxKPHVZyvaC4cwzT94Gtt3zc637y58Pcj"; //Add your API key here inside ""
        static string API_KEY = "Lrr804HNAPbzeOMHvQmx7k8M7hedpx8bJzR0hP9e";



        HttpClient httpClient;

        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>
        public APIHandler()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public Rootobject GetSchools()
        {
            string COLLEGE_SCORE_CARD_API_PATH = BASE_URL + "schools?school.degrees_awarded.predominant=2,3&fields=id,school.name,2013.student.size&"; //&api_key=rdesCWBgxKPHVZyvaC4cwzT94Gtt3zc637y58Pcj
            
            string NATIONAL_PARK_API_PATH = BASE_URL + "schools.json?school.degrees_awarded.predominant=2,3&fields=id,school.name,2013.student.size&";

            string rootobjectData = "";

            Rootobject rootobject = null;

            httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(COLLEGE_SCORE_CARD_API_PATH).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    rootobjectData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!rootobjectData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    rootobject = JsonConvert.DeserializeObject<Rootobject>(rootobjectData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return rootobject;
        }
        */
    }


}



