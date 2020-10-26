using DataAccess.Context;
using Entities.Modules.Lookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Seeder
{
    public class DataSeeder
    {
        public List<Make> GenerateCarMakes()
        {
            List<Make> makes = new List<Make>();

            Make audi = new Make()
            {
                Id = 1,
                TitleAr = string.Format("أودي"),
                TitleEn = string.Format("Audi"),
                CreatedOn = DateTime.Now,
            };
            makes.Add(audi);

            Make bentley = new Make()
            {
                Id = 2,
                TitleAr = string.Format("بنتلي"),
                TitleEn = string.Format("Bentley"),
                CreatedOn = DateTime.Now,
            };
            makes.Add(bentley);

            Make mclaren = new Make()
            {
                Id = 3,
                TitleAr = string.Format("مكلارين"),
                TitleEn = string.Format("McLaren"),
                CreatedOn = DateTime.Now,
            };
            makes.Add(mclaren);

            Make dodge = new Make()
            {
                Id = 4,
                TitleAr = string.Format("دودج"),
                TitleEn = string.Format("Dodge"),
                CreatedOn = DateTime.Now,
            };
            makes.Add(dodge);

            Make ferrari = new Make()
            {
                Id = 5,
                TitleAr = string.Format("فيراري"),
                TitleEn = string.Format("Ferrari"),
                CreatedOn = DateTime.Now,
            };
            makes.Add(ferrari);

            return makes;
        }
        public List<Model> GenerateCarModels()
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
            return models;
        }
        public List<Trim> GenerateCarTrims()
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
            return trims;
        }
        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}