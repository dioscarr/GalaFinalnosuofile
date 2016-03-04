using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
using Gala_MVC_Project.Areas.Admin.Models;

namespace Gala_MVC_Project.Models
{
    public class MemberModel
    {
        GalaDBEntities db = new GalaDBEntities();

        public Team Member { get; set; }
        public List<Team> Members { get; set; }
        public int FID { get; set; }
        public int CID { get; set; }
        public List<MemberList> MemberList { get; set; }
        public List<CMFRelation> CMF { get; set; }
      


        public MemberModel()
        {
            Member = null;
            Members = ManageTeam.GetAllTeam().ToList();
            FID = 0;
            CID = 0;
           
        }





        public void FilterTeam(string Name)
        {

            MemberList = db.CMFRelation.Where(c => c.isDeleted == false)
                .Where(c => c.Team.LName.Contains(Name) || c.Team.FName.Contains(Name))
                .Select(c => new MemberList
          {
              Country = c.Country.CountryName,
              Firm = c.Firm.FirmName,
              Name = c.Team.FName + " " + c.Team.MInitial + " " + c.Team.LName,
              FID = c.Firm.Id,
              MID = c.Team.Id,
              flag = c.Country.Flag,
              id = c.Id
          }).ToList();


        }     

      
        public void LoadMemberList()
        {
            

            MemberList = db.CMFRelation.Where(c => c.isDeleted == false).Select(c => new MemberList
            {
                Country = c.Country.CountryName,
                Firm = c.Firm.FirmName,
                Name = c.Team.FName + " " + c.Team.MInitial + " " + c.Team.LName,
                FID = c.Firm.Id,
                MID = c.Team.Id,
                flag = c.Country.Flag,
                id = c.Id
            }).ToList();
           

        }

        public void LoadMemberList(int? CID, int? FID, int? MID )
        {
            if (CID != null)
            {
                MemberList = db.CMFRelation.Where(c => c.isDeleted == false && c.CID == (int)CID).Select(c => new MemberList
                {
                    Country = c.Country.CountryName,
                    Firm = c.Firm.FirmName,
                    Name = c.Team.FName + " " + c.Team.MInitial + " " + c.Team.LName,
                    FID = c.Firm.Id,
                    MID = c.Team.Id,
                    flag = c.Country.Flag,
                    id = c.Id
                }).ToList();
            }
            else if (FID != null)
            {
                MemberList = db.CMFRelation.Where(c => c.isDeleted == false && c.FID == (int)FID).Select(c => new MemberList
                {
                    Country = c.Country.CountryName,
                    Firm = c.Firm.FirmName,
                    Name = c.Team.FName + " " + c.Team.MInitial + " " + c.Team.LName,
                    FID = c.Firm.Id,
                    MID = c.Team.Id,
                    flag = c.Country.Flag,
                    id = c.Id
                }).ToList();
            }
            else if(MID!=null) {
                MemberList = db.CMFRelation.Where(c => c.isDeleted == false && c.MID == (int)MID).Select(c => new MemberList
                {
                    Country = c.Country.CountryName,
                    Firm = c.Firm.FirmName,
                    Name = c.Team.FName + " " + c.Team.MInitial + " " + c.Team.LName,
                    FID = c.Firm.Id,
                    MID = c.Team.Id,
                    flag = c.Country.Flag,
                    id = c.Id
                }).ToList();
            }
            ;


        }
       


        public void loadMember(int id)
        {

            
            Member = db.Team.Where(c=>c.Id==id).FirstOrDefault();
        }


        public bool update(MemberModel model)
        {
            return ManageTeam.UpdateTeam(model.Member);
        }

        public bool Insert(MemberModel model)
        {
            return ManageTeam.AddTeam(model.Member);
        }
        public bool InsertRelations(int MID, int FID, int CID)
        {
            CMFRelation CM = new CMFRelation();
            CM.CID = CID;
            CM.FID = FID;
            CM.MID = MID;
            return ManageCMFRelation.AddCMFRelation(CM);
        }

        public bool DeleteRef(int id)
        {
            return ManageCMFRelation.DeleteCMFRelation(ManageCMFRelation.GetById(id));
        }
        public bool Delete(int id)
        {
            return ManageTeam.DeleteTeam(ManageTeam.GetById(id));
        }

    }
        public class MemberList
    {
        public int id { get; set; }
        public int FID { get; set; }
        public int MID { get; set; }
        public string Country { get; set; }
        public string Firm { get; set; }
        public string Name { get; set; }
        public string flag { get; set; }
    }


}