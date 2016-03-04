using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageTeam 
    {
        #region Select Methods -- GetAllTeam, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Team> GetAllTeam()
        {
            return Manage<Team, TeamRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Team GetById(int id)
        {
            return Manage<Team, TeamRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Team GetById(string id)
        {
            return Manage<Team, TeamRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddTeam
        public static bool AddTeam(Team n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Team, TeamRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateTeam
        public static bool UpdateTeam(Team n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Team, TeamRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteTeam
        public static bool DeleteTeam(Team n)
        {
            n.isDeleted = true;

            return UpdateTeam(n);
        }
        #endregion
    }
}
