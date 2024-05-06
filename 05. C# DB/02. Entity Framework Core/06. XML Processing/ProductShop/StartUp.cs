using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            /*context.Database.EnsureDeleted();
            context.Database.EnsureCreated();*/

            string xmlPath = File.ReadAllText("../../../Datasets/users.xml");
            var result = ImportUsers(context, xmlPath);
            Console.WriteLine(result);


        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDtos = Deserialize<ImportUsersDto[]>(inputXml, "Users");

            User[] users = usersDtos.
                Select(dto => new User()
                {
                  FirstName = dto.FirstName,
                  LastName = dto.LastName,
                  Age =  dto.Age
                }).ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
           
        }

         public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            
        }



        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
             T dtos = (T)xmlSerializer
                .Deserialize(reader);

            return dtos;
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}