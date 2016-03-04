using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using Gala_MVC_Project.Models;
using DAL.Models;
using BLL;


namespace Gala_MVC_Project.Areas.Admin.Models
{
  
    public class Usermanagement
    {
        ApplicationDbContext context = new ApplicationDbContext();
        GalaDBEntities db = new GalaDBEntities();

        public List<IdentityRole> Roles { get; set; }
        public string EmailAddress { get; set; }
        public bool AutoGeneratePassword { get; set; }
        public bool SendEmailNotification { get; set; }
        public List<Team> Members { get; set; }
        public string RoleName { get; set; }
        public string  newPassword { get; set; }


        public Usermanagement() {
            Roles = context.Roles.ToList();
            Members = db.Team.Where(c => c.Type == "Member").ToList();            
        }



       
        

       





    }
}