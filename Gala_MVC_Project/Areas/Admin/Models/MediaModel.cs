using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace Gala_MVC_Project.Areas.Admin.Models
{
    public class MediaModel
    {
        public Events eventDetails { get; set; }
        public List<Events> events { get; set; }



    }
}