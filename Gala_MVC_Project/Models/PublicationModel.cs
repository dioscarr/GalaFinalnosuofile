using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace Gala_MVC_Project.Models
{
    public class PublicationModel : Basemodel
    {
        GalaDBEntities db = new GalaDBEntities();
        public Publication publication { get; set; }
        public List<publicationBooks> publicationbooks { get; set; }
        public publicationBooks SinglepublicationBooks { get; set; }
        public Gazette GazetteArticle { get; set; }
        public List<Gazette> GazetteArticles { get; set; }
        public GazetteVolumes LastGazetteVolume { get; set; }
        public List<Gazette> Volumes { get; set; }
        public List<gazettelist> mylistofGazette { get; set; }
        public List<VolumesModel> mymodel { get; set; }
        public PublicationModel()
        {
            publication = db.Publication.FirstOrDefault();
            publicationbooks = ManagepublicationBooks.GetAllpublicationBooks().ToList();
            GazetteArticle = null;
            GazetteArticles = db.Gazette.ToList();
            LastGazetteVolume = ManageGazetteVolumes.GetAllGazetteVolumes().OrderByDescending(c => c.PublishedDate).FirstOrDefault();
            //=====================================================================================
            mymodel = db.GazetteVolumes
                .Select(c => new VolumesModel
                                            {
                                            id = c.Id,
                                            name = c.GazetteVolume,
                                            PublishedDate = c.PublishedDate.ToString(),
                                                countries = c.Gazette
                                                                    .Where(x=>x.GazetteVolumeID == c.Id)
                                                                    .Select(x=> new Countries{
                                                                                            cname = x.Firm.Country,
                                                                                            Content = x.Content,
                                                                                                Header = x.header,
                                                                                            id = x.Id })
                                                                    .ToList() })
                 .ToList();

            //=====================================================================================
        }

        public void publicationFirm(int? FirmID) {
            mymodel = db.GazetteVolumes
                .Select(c => new VolumesModel
                {
                    id = c.Id,
                    name = c.GazetteVolume,
                    countries = c.Gazette
                .Where(x => x.FirmID == (int)FirmID)
                .Select(x => new Countries
                {
                    cname = x.Firm.Country,
                    Content = x.Content,
                    Header = x.header,
                    id = x.Id
                })
                .ToList()
                })
                 .ToList();
        }
        internal void loadGazettebyVolume(int? id, int?FirmID)
        {
            if (FirmID != null)
            {
                Volumes = db.Gazette.Where(c=>c.FirmID==(int)FirmID).ToList();
            }
            else {
                Volumes = db.Gazette.Where(c => c.GazetteVolumeID == (int)id).ToList();
            }
           
        }
        public void loadPublication(int id)
        {
            SinglepublicationBooks = db.publicationBooks.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool update(PublicationModel model)
        {
            return ManagePublication.UpdatePublication(model.publication);
        }
        public bool Insert(PublicationModel model)
        {
            return ManagePublication.AddPublication(model.publication);
        }
        public bool Delete(int id)
        {
            return ManagepublicationBooks.DeletepublicationBooks(ManagepublicationBooks.GetById(id));
        }
    }

    public class gazettelist
    {
        public string cname { get; set; }
        public int id { get; set; }
        public string Content { get; set; }

    }


}