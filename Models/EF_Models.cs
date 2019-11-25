using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace WebApplicationDataGov.Models
{
    public class EF_Models
    {

        public class Rootobject
        {
            public Metadata metadata { get; set; }
            public List<School> results { get; set; }
        }

        public class Metadata
        {
            public int total { get; set; }
            public int page { get; set; }
            public int per_page { get; set; }
        }

        public class School
        {
            [JsonProperty("school.name")]
            public string name { get; set; }
            [JsonProperty("2017.student.size")]
            public int size { get; set; }
            [Key]
            public int id { get; set; }
        }

    }
}
