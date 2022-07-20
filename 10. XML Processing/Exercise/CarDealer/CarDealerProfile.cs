using AutoMapper;
using CarDealer.Data;

using CarDealer.Models;
using CarDealer.DataTransferObjects.Cars;
using CarDealer.DataTransferObjects.Parts;
using CarDealer.DataTransferObjects.Suppliers;
using CarDealer.DataTransferObjects.Customers;
using CarDealer.DataTransferObjects.Sales;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>()
                .ForMember(d => d.IsImporter, mo => mo.MapFrom(s => s.IsImporter));

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCarDto, Car>();

            this.CreateMap<ImportCustomersDto, Customer>();

            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}