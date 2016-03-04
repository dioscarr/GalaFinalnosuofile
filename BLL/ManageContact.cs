using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageContact 
    {
        #region Select Methods -- GetAllContact, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Contact> GetAllContact()
        {
            return Manage<Contact, ContactRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Contact GetById(int id)
        {
            return Manage<Contact, ContactRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Contact GetById(string id)
        {
            return Manage<Contact, ContactRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddContact
        public static bool AddContact(Contact n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Contact, ContactRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateContact
        public static bool UpdateContact(Contact n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Contact, ContactRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteContact
        public static bool DeleteContact(Contact n)
        {
            n.isDeleted = true;

            return UpdateContact(n);
        }
        #endregion
    }
}
