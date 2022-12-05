using AQMS.Controllers;
using AQMS.Data;
using AQMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Air_sesnor_tests
{
    public class AirsensorTest
    {
        private static DbContextOptions<AirsensorDbContext> DbContextOptions = new DbContextOptionsBuilder<AirsensorDbContext>()
            .UseInMemoryDatabase(databaseName: "AQMSDbTest")
            .Options;

        AirsensorDbContext context;
        AirsensorController AirsensorController;
        

        [OneTimeSetUp]

        public void setup()
        {
            context = new AirsensorDbContext(DbContextOptions);
            context.Database.EnsureCreated();

            SeedDatabase();
            AirsensorController= new AirsensorController(context);
            
        }

        [Test, Order(1)]
        public void HttpGET_GetAllAirsensors()
        {
            var result = AirsensorController.Get();
            Assert.That(result.First().ID, Is.EqualTo(1));
            Assert.That(result.Count, Is.EqualTo(6));

        }

        [Test, Order(2)]

        public void HttpPUT_GetAllAirsensors_byID()
        {
            var result1 = AirsensorController.Get(1);
            Assert.That(result1.ID, Is.EqualTo(1));
        }

        [Test, Order(3)]

        public void HttpGET_GetAllAirsensorsByID()
        {
            var result2 = AirsensorController.Get(1);
            Assert.That(result2.ID, Is.EqualTo(1)); 
        }

        [Test, Order(4)]

        public void HttpDelete_DeleteAirsensorsByID()
        {
            int ID = 1; 
            IActionResult actionResult= AirsensorController.Delete(ID);
            Assert.That(actionResult,Is.TypeOf<OkObjectResult>());

        }

        [Test, Order(5)]

        public void HttpPost_AddAirsensorData()
        {
            var Airsensor = new Airsensor()
            {
                SensorId = 102,
                FloorNo = 2,
                O2 = 12,
                CO2 = 13,
                SO2 = 14,
                CO = 15,
                C = 16
               
            };
            IActionResult actionResult = AirsensorController.Post(Airsensor);
            Assert.That(actionResult, Is.TypeOf<StatusCodeResult>());
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        public void SeedDatabase()
        {
            var Airsensor = new List<Airsensor>
            {
                new Airsensor()
                {
                    ID = 1,
                    SensorId = 101,
                    FloorNo = 1,
                    O2 = 22,
                    CO2 = 33,
                    SO2 = 44,
                    CO = 55,
                    C = 66
                     
                },

              new Airsensor()
                {
                    ID = 2,
                    SensorId = 102,
                    FloorNo = 2,
                    O2 = 12,
                    CO2 = 13,
                    SO2 = 14,
                    CO = 15,
                    C = 16
                    

                },

              new Airsensor()
                {
                    ID = 3,
                    SensorId = 103,
                    FloorNo = 3,
                    O2 = 33,
                    CO2 = 44,
                    SO2 = 55,
                    CO = 66,
                    C = 77
                    

                },

               new Airsensor()
                {
                    ID = 4,
                    SensorId = 104,
                    FloorNo = 1,
                    O2 = 10,
                    CO2 = 20,
                    SO2 = 30,
                    CO = 40,
                    C = 50
                   

                },

                new Airsensor()
                {
                    ID = 5,
                    SensorId = 105,
                    FloorNo = 2,
                    O2 = 60,
                    CO2 = 50,
                    SO2 = 40,
                    CO = 30,
                    C = 20
                    

                },

                new Airsensor()
                {
                    ID = 6,
                    SensorId = 106,
                    FloorNo = 3,
                    O2 = 5,
                    CO2 = 15,
                    SO2 = 25,
                    CO = 35,
                    C = 45
                    

                },


            };
            context.Airsensors.AddRange(Airsensor);

            context.SaveChanges();
            
        }
     
    }
}