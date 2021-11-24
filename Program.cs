using IES_Assignment3.Models;
using System;
using System.Configuration;
using System.Text;

namespace IES_Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Convert.ToBase64String(Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()));
            Console.WriteLine("Key = {0}\n\n", key);

            Header header = new Header(); //Generate Header with Defaults
            PayLoad payLoad = new PayLoad(); //Generate Payload with Defaults

            string uniqueId = Guid.NewGuid().ToString(); //Just for demonstration

            payLoad.issuer = ConfigurationManager.AppSettings["Issuer"];
            payLoad.audience = ConfigurationManager.AppSettings["Audience"];
            payLoad.unique_name = ConfigurationManager.AppSettings["UniqueName"];
            payLoad.email = ConfigurationManager.AppSettings["Username"];
            payLoad.uniqueId = uniqueId;  //Usually generated during record creation in the User database
            payLoad.birthdate = "11-26-1992";
            payLoad.role = new[] { "Student" };

            Signature signature = new Signature(header, payLoad, ConfigurationManager.AppSettings["SecurityKey"]);

            var jwt = signature.GenerateToken();
            Console.WriteLine("Token = {0}", jwt);
        }
    }
}
