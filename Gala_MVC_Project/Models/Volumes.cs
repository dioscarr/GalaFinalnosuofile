using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gala_MVC_Project.Models
{
    public class VolumesModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Countries> countries { get; set; }
        public string PublishedDate { get; set; }
        //public List<VolumesModel> VolumesList { get; set; }
    }

    public class Countries
    {
        public int id { get; set; }
        public string Header { get; set; }
        public string cname { get; set; }
        public string Content { get; set; }
    }
}