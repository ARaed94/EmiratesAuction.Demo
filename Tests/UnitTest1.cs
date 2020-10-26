using DataAccess.Models;
using DataAccess.Seeder;
using Entities.Modules.Lookups;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Application_Should_Read_Connection_String()
        {
            using (StreamReader reader = new StreamReader("appsettings.json"))
            {
                string json = reader.ReadToEnd();
                ApplicationSettingsModel settings = JsonConvert.DeserializeObject<ApplicationSettingsModel>(json);
                Assert.IsNotNull(settings.ApplicationSettings.ConnectionString);
            }
        }

        [TestMethod]
        public void Application_Should_Generate_Lorem_Ipsum_In_Arabic()
        {
            string loremImsum = LoremIpsumGenerator.Generate(10, 50, 2, 4, 2, Language.Arabic);
            Assert.IsNotNull(loremImsum);
        }

        [TestMethod]
        public void Application_Should_Generate_Lorem_Ipsum_In_English()
        {
            string loremImsum = LoremIpsumGenerator.Generate(10, 50, 2, 4, 2, Language.English);
            Assert.IsNotNull(loremImsum);
        }

        [TestMethod]
        public void Application_Should_Seed_Car_Models()
        {
            List<Make> makes = new List<Make>() {
                new Make()
                {
                    Id = 1,
                    TitleAr = "أودي",
                    TitleEn = "Audi",
                    CreatedOn = DateTime.Now
                },
                new Make()
                {
                    Id = 2,
                    TitleAr = "أوبل",
                    TitleEn = "Opel",
                    CreatedOn = DateTime.Now
                },
                new Make()
                {
                    Id = 3,
                    TitleAr = "بورشه",
                    TitleEn = "Porsche",
                    CreatedOn = DateTime.Now
                },
                new Make()
                {
                    Id = 4,
                    TitleAr = "رينو",
                    TitleEn = "Renault",
                    CreatedOn = DateTime.Now
                },
                new Make()
                {
                    Id = 5,
                    TitleAr = "لاند روفر",
                    TitleEn = "Land Rover",
                    CreatedOn = DateTime.Now
                }
            };
        }

        [TestMethod]
        public void Application_Should_Generate_Fake_Car_Models()
        {
            List<Model> models = new List<Model>();
            for (int i = 0; i < 5; i++)
            {
                Model model = new Model()
                {
                    Id = i + 1,
                    TitleAr = string.Format($"موديل {i + 1}"),
                    TitleEn = string.Format($"Model {i + 1}"),
                    CreatedOn = DateTime.Now,
                    MakeId = i + 1
                };
                models.Add(model);
            }
        }

        [TestMethod]
        public void Application_Should_Generate_Fake_Car_Trims()
        {
            List<Trim> trims = new List<Trim>();
            for (int i = 0; i < 5; i++)
            {
                Trim trim = new Trim()
                {
                    Id = i + 1,
                    TitleAr = string.Format($"نوع {i + 1}"),
                    TitleEn = string.Format($"Trim {i + 1}"),
                    CreatedOn = DateTime.Now,
                    MakeId = i + 1
                };
                trims.Add(trim);
            }
        }
    }
}

