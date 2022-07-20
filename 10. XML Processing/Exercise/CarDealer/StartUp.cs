using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DataTransferObjects.Cars;
using CarDealer.DataTransferObjects.Customers;
using CarDealer.DataTransferObjects.Parts;
using CarDealer.DataTransferObjects.Sales;
using CarDealer.DataTransferObjects.Suppliers;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;
        public static void Main(string[] args)
        {
            mapper = new Mapper(new MapperConfiguration(config =>
            {
                config.AddProfile<CarDealerProfile>();
            }));

            using CarDealerContext dbContext = new CarDealerContext();

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();


            // P01:
            /* string inputXml = ReadXmlFile("suppliers");
            Console.WriteLine(ImportSuppliers(dbContext, inputXml)); */

            /* string inputXml = ReadXmlFile("parts");
            Console.WriteLine(ImportParts(dbContext, inputXml)); */

            /* string inputXml = ReadXmlFile("cars");
            Console.WriteLine(ImportCars(dbContext, inputXml)); */
            
            /* string inputXml = ReadXmlFile("customers");
            Console.WriteLine(ImportCustomers(dbContext, inputXml)); */
            
            /* string inputXml = ReadXmlFile("sales");
            Console.WriteLine(ImportSales(dbContext, inputXml)); */


            dbContext.Dispose();
        }

        private static string ReadXmlFile(string fileName)
        {
            return File.ReadAllText(@$"..\..\..\Datasets\{fileName}.xml");
        }

        // Problem 02: Import Data
        
        // Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader streamReader = new StringReader(inputXml);

            ICollection<ImportSupplierDto> supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(streamReader);

            ICollection<Supplier> suppliers = new List<Supplier>();
            foreach (var supplierDto in supplierDtos)
            {
                Supplier supplier = mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }

        // Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), xmlRoot);
            using StringReader stringReader = new StringReader(inputXml);

            ICollection<ImportPartDto> partDtos = (ImportPartDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Part> parts = new List<Part>();
            foreach (var partDto in partDtos)
            {
                parts.Add(mapper.Map<Part>(partDto));
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        // Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto), xmlRoot);
            using StringReader stringReader = new StringReader(inputXml);

            ImportCarDto[] carDtos = (ImportCarDto[])xmlSerializer.Deserialize(stringReader);
            ICollection<Car> cars = new List<Car>();
            foreach (var carDto in carDtos)
            {
                cars.Add(mapper.Map<Car>(carDto));
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCustomersDto), xmlRoot);
            using StringReader stringReader = new StringReader(inputXml);

            ImportCustomersDto[] customersDtos = (ImportCustomersDto[])serializer.Deserialize(stringReader);

            ICollection<Customer> customers = new List<Customer>();
            foreach (var customerDto in customersDtos)
            {
                customers.Add(mapper.Map<Customer>(customerDto));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        // Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSaleDto), xmlRoot);
            using StringReader stringReader = new StringReader(inputXml);
            ImportSaleDto[] saleDtos = (ImportSaleDto[])serializer.Deserialize(stringReader);

            ICollection<Sale> sales = new List<Sale>();
            foreach (ImportSaleDto saleDto in saleDtos)
            {
                sales.Add(mapper.Map<Sale>(saleDto));
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
    }
}