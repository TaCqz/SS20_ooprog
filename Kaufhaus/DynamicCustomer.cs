using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Xml.Linq;

/********************************************** 
 * *    Name: Jan-Oliver Lehnen             * * 
 * *    Mat. Nr.: 70467507                  * * 
 **********************************************/
 // DIESE KLASSE IST ZUM GRÖßTEN TEIL ÜBERNOMMEN!
namespace Kaufhaus
{
    public class DynamicCustomer
    {
        public static Kunde Dynamic()
        {
            //Create a new WebClient
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            //Download data as string
            string xml = wc.DownloadString("https://randomuser.me/api/?inc=name,location,dob&nat=de&format=xml&noinfo");

            //Parse XML
            XDocument xdoc = XDocument.Parse(xml);

            //Get values
            string firstName = xdoc.Root.Element("results").Element("name").Element("first").Value;
            string lastName = xdoc.Root.Element("results").Element("name").Element("last").Value;
            string street = xdoc.Root.Element("results").Element("location").Element("street").Value;
            string city = xdoc.Root.Element("results").Element("location").Element("city").Value;
            string birthdate = xdoc.Root.Element("results").Element("dob").Element("date").Value.Split('T')[0];

            //Gibt Kundenobjekte zurrück

            return new Kunde($"{firstName} {lastName}", $"{street}, {city}", birthdate);

        }
    }
    }
