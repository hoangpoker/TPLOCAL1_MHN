using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using Microsoft.Extensions.Options;


//This file is not to be modified
namespace TPLOCAL1_MHN.Models
{
    public class OpinionList
    {
        /// <summary>
        /// Function that alow to recover the opinions list inside an xml file
        /// </summary>
        /// <param name="file">file path</param>
        public List<Opinion> GetAvis(string file)
        {
            // instantiating empty list
            List<Opinion> opinionList = new List<Opinion>();

            // Creation of an XMLDocument object that alow to recover datas from the file
            XmlDocument xmlDoc = new XmlDocument();
            // Reading of the file thank to a StreamReader file
            StreamReader streamDoc = new StreamReader(file);
            string dataXml = streamDoc.ReadToEnd();
            // Loading data in the XmlDocument
            xmlDoc.LoadXml(dataXml);

            // Retrieve the nodes, convert them to the "Avis" object, and add them to the "OpinionList" list.
            // Loop through each XmlNode node with the path "root/row" (see xml file structure)
            // The SelectNodes method retrieves all nodes with the specified path.
            foreach (XmlNode node in xmlDoc.SelectNodes("root/row"))
            {
                // Retrieving data from child nodes.
                string Nom = node["Nom"].InnerText;
                string Prenom = node["Prenom"].InnerText;
                string Avis = node["Avis"].InnerText;

                // Creating the "Opinion" object to add to the results list.
                Opinion opinion = new Opinion
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    Avis = Avis
                };

                // Adding the object to the list.
                if (opinion.Nom != null && opinion.Prenom != null && opinion.Avis != null)
                {
                    opinionList.Add(opinion);
                }
            }

            // Returning the list formed by processing to the calling method.
            return opinionList;
        }
    }

    // .: Info :.
    // This class can be extracted to a new C# page, but for the sake of this exercise, it can be left in the same page.
    // It's best to avoid having multiple classes inside the same page as it can complicate code readability and maintenance in the long run.
    public class Opinion
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Avis { get; set; }
    }
}