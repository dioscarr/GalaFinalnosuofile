using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace GalaLaw.Areas.Admin.Models
{
    public class MediaModel
    {
        public Events eventDetails { get; set; }
        public List<Events> events { get; set; }



    }
}