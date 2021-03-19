using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SocialEcommerce.Shared.Utilities
{
    public static class Utility
    {  
        public static string GetEmailTemplate(string directory, string fileName)
        {
            string path = Directory.GetCurrentDirectory();
            string header = "", footer = "", body = "";

            using (StreamReader reader = new StreamReader(path + "/EmailTemplates/_layoutTemplate/EmailHeader.html"))
            {
                header = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(path + "/EmailTemplates/" + directory   + "/" + fileName))
            {
                body = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader(path + "/EmailTemplates/_layoutTemplate/EmailFooter.html" ))
            {
                footer = reader.ReadToEnd();
            }
            return header + body + footer;
        }
    }
}
