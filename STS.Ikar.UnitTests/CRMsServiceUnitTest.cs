using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using STS.Ikar.Interfaces;
using STS.Ikar.DAL;
using System.Threading.Tasks;
using STS.Ikar.Models;
using System.Collections.Generic;

namespace STS.Ikar.UnitTests
{
    [TestClass]
    public class CRMsServiceUnitTest
    {
        ICMRsService cmrsService;

        [TestInitialize]
        public void Init()
        {
            cmrsService = new DbCMRsService();
        }

        [TestMethod]
        public async Task GetTest()
        {
            var cmrId = 1;

            await cmrsService.GetAsync(cmrId);
        }


        [TestMethod]
        public async Task AddTest()
        {
            var address = new Address
            {
                City = "Swarzędz",
                Postcode="62-020",
                Street = "Rabowicka 6",
            };

            var driver = new Driver
            {
                FirstName = "Marcin",
                LastName = "Sulecki",
                Birthday = DateTime.Today,
                Phone = "666-444-333"
            };

            var truck = new Truck
            {
                Plate = "WI 3091W",
                SideNumber = "54564",
            };

            var customer = new Customer
            {
                Name = "Sulmar",
                Address = address,
            };

            var vehicle = new Vehicle
            {
                Customer = customer,
                Mark = "VW",
                Model = "Golf",
                VIN = "56345643534HDD"
            };

            var cmr = new CMR
            {
                CreateDate = DateTime.Now,
                ArrivalAddress = address,
                DeliveryAddress = address,
                DeliveryDate = DateTime.Today.AddDays(4),
                Driver = driver,
                Number = "CMR 1",
                PickupDate = DateTime.Now,
                Truck = truck,
                WarehouseDocuments = new List<WarehouseDocument>
                {
                    new WarehouseDocument
                    {
                        DocumentType = DocumentType.WZ,
                        ConfirmDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        Number = "WZ 001/2017",
                        Vehicle = vehicle,
                    },

                    new WarehouseDocument
                    {
                        DocumentType = DocumentType.PZ,
                        ConfirmDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        Number = "PZ 001/2017",
                        Vehicle = vehicle,
                    },
                }
            };


            await cmrsService.AddAsync(cmr);
        }
    }
}
