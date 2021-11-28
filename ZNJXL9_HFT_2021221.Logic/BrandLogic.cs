using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository brandRepository;

        public BrandLogic(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public IEnumerable<Brand> ReadAll()
        {
            return brandRepository.ReadAll().ToList();
        }

        public Brand Read(int id)
        {
            return brandRepository.Read(id);
        }

        public void Create(Brand obj)
        {
            if (obj.Name == "null")
            {
                throw new ErrorException("Name cant be empty");
            }
            brandRepository.Create(obj);
        }

        public void Delete(int id)
        {
            if (brandRepository.Read(id) != null)
            {
                brandRepository.Delete(id);
            }
            else
            {
                throw new ErrorException("There is no Brand with thad id");
            }
        }

        public Brand MostUsedBrand()
        {
            var query = (from l in ReadAll()
                         group l by l into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            return query;
        }

        public void Update(Brand obj)
        {
            if (obj != null && obj.Name != "")
            {
                brandRepository.Update(obj);
            }
            else
            {
                throw new ErrorException("Some Data is not valid");
            }
        }
    }
}
