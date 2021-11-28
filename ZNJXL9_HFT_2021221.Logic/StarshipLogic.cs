using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;
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
            starshipRepository.Create(starship);
        }
        public void Update(Starship obj)
        {
            if (obj != null && obj.Model != "")
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
                throw new ErrorException("There is no Starship with thad id");
            }

        }
        public double AVGPrice()
        {
            return starshipRepository.ReadAll().Average(t => t.BasePrice) ?? 0;
        }


        //NON CRUD
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

        public Starship MostExpensiveStarship()
        {
            var elements = ReadAll();
            return elements.OrderByDescending(obj => obj.BasePrice).First();
        }
        public Starship CheapestStarship()
        {
            var elements = ReadAll();
            return elements.OrderByDescending(obj => obj.BasePrice).Last();
        }
    }
}
