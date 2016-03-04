using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace GalaLaw.Areas.Admin.Models
{
    public class PublicationModel
    {
        public Publication publication { get; set; }
        public List<publicationBooks> publicationbooks { get; set; }
        public publicationBooks publicationbook { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public bool isNewPicture { get; set; }

        public PublicationModel()
        {
            publicationbook = null;
            publicationbooks = ManagepublicationBooks.GetAllpublicationBooks().ToList();
            publication = ManagePublication.GetAllPublication().FirstOrDefault();

        }

        public bool update(PublicationModel model)
        {
            return ManagePublication.UpdatePublication(model.publication);
        }

        internal void loadPBook(int id)
        {
            publicationbook =  ManagepublicationBooks.GetById(id);
        }

        internal void updateBook(PublicationModel model)
        {
            ManagepublicationBooks.UpdatepublicationBooks(model.publicationbook);
        }

        internal void insert(PublicationModel model)
        {
            ManagepublicationBooks.AddpublicationBooks(model.publicationbook);
        }

        internal void Delete(int id)
        {
            ManagepublicationBooks.DeletepublicationBooks(ManagepublicationBooks.GetById(id));
        }
    }
}