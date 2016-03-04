using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
using Gala_MVC_Project.Areas.Admin.Models;

namespace Gala_MVC_Project.Areas.Admin.Models
{
    public class Basemodel
    {
              //  public Contact ContantInfo = ManageContact.GetSingleContact();

        public string Truncate(string text, int length=200, string ellipsis = "...", bool keepFullWordAtEnd = true)
        {
            string txtWNoHTML = System.Text.RegularExpressions.Regex.Replace(text, @"<[^>]+>", "").Trim();

            if (String.IsNullOrEmpty(txtWNoHTML))
            {
                return string.Empty;
            }

            if (txtWNoHTML.Length < length)
            {
                return txtWNoHTML;
            }

            txtWNoHTML = txtWNoHTML.Substring(0, length);

            if (keepFullWordAtEnd)
            {
                txtWNoHTML = txtWNoHTML.Substring(0, txtWNoHTML.LastIndexOf(' '));
            }

            return txtWNoHTML + ellipsis;
        }
    }
    }
