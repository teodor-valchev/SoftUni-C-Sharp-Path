using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
           /* context.Database.EnsureDeleted();
            context.Database.EnsureCreated();*/

            string json = File.ReadAllText(@"../../../Datasets/cars.json");
          var res = ImportCars(context, json);
           Console.WriteLine(res);
        }



        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
           var supliyers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(supliyers);
            context.SaveChanges();

            return $"Successfully imported {supliyers.Length}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";

        }

    }
}