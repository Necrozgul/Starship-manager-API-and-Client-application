using System;
using System.Collections.Generic;
using System.Linq;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Logic
{
    public class StarshipLogic : IStarshipLogic
    {
        IStarshipRepository starshipRepository;

        public StarshipLogic(IStarshipRepository starshipRepository)
        {
            this.starshipRepository = starshipRepository;
        }

        //CRUD
        public Starship Read(int id)
        {
            return starshipRepository.Read(id);
        }
        public IEnumerable<Starship> ReadAll()
        {
            return starshipRepository.ReadAll();
        }
        public void Create(Starship starship)
        {
            if (starship.BasePrice < 0)
            {
                throw new ErrorException("Negative price is not allowed");
            }
            if (starship.Model.Trim().Length < 0)
            {
                throw new Exception("Starship name cant be empty!");
            }
            starshipRepository.Create(starship);
        }
        public void Update(Starship obj)
        {
            if (obj != null && obj.Model.Trim().Length >0)
            {
                starshipRepository.Update(obj);
            }
            else
            {
                throw new ErrorException("Some Data is not valid");
            }

        }
        public void Delete(int id)
        {
            if (starshipRepository.Read(id) != null)
            {
                starshipRepository.Delete(id);
            }
            else
            {
                throw new Exception("There is no Starship with thad id");
            }

        }
        public double AVGPrice()
        {
            return starshipRepository.ReadAll().Average(t => t.BasePrice) ?? 0;
        }


        //NON CRUD
        public Starship MostExpensiveStarship()
        {
            var elements = ReadAll();
            return elements.OrderByDescending(obj => obj.BasePrice).First();
        }
        public Starship CheapestStarship()
        {
            var elements = ReadAll();
            if (elements != null)
            {
                return elements.OrderByDescending(obj => obj.BasePrice).Last();
            }
            else
            {
                throw new Exception("Sajnos nincsen adat a rendszerben, szóval nem értelmezhető a számítás!");
            }
            
        }
        //Többtáblás lekérdezés
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrand()
        {
            if (starshipRepository.ReadAll() != null)
            {
                return from x in starshipRepository.ReadAll()
                       group x by x.Brand.Name into g
                       select new KeyValuePair<string, double>
                       (g.Key, g.Average((t => (double)t.BasePrice)));
            }
            else
            {
                throw new Exception("Nincsen adat szóval nem lehet elvégezni a műveletet!");
            }
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByWeapon()
        {
            if (starshipRepository.ReadAll() != null)
            {
                return from x in starshipRepository.ReadAll()
                       group x by x.Weapon.Name into g
                       select new KeyValuePair<string, double>
                       (g.Key, g.Average((t => (double)t.BasePrice)));
            }
            else
            {
                throw new Exception("Nincsen adat szóval nem lehet elvégezni a műveletet!");
            }
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByModels()
        {
            return from x in starshipRepository.ReadAll()
                   group x by x.Model into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice) ?? 0);
        }

        public IList<AveragesResult> GetModelAverages()
        {
            var q = from s in starshipRepository.ReadAll()
                    group s
                    by new { s.Id, s.Model }
                    into grp
                    select new AveragesResult()
                    {
                        ModelName = grp.Key.Model,
                        AveragePrice = grp.Average(x => x.BasePrice) ?? 0
                    };
            return q.ToList();
        }

    }
}
