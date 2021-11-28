using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Models;
using ZNJXL9_HFT_2021221.Repository;

namespace ZNJXL9_HFT_2021221.Logic
{
    public class WeaponLogic : IWeaponLogic
    {
        IWeaponRepository weaponRepository;

        public WeaponLogic(IWeaponRepository weaponRepository)
        {
            this.weaponRepository = weaponRepository;
        }
        public void Create(Weapon obj)
        {
            if (obj.Name == "")
            {
                throw new ErrorException("Must be a weapon name");
            }
            weaponRepository.Create(obj);
        }

        public void Delete(int id)
        {
            if (weaponRepository.Read(id) != null)
            {
                weaponRepository.Delete(id);
            }
            else
            {
                throw new ErrorException("There is no Starship with thad id");
            }
        }

        public IEnumerable<Weapon> ReadAll()
        {
            return weaponRepository.ReadAll().ToList();
        }

        public Weapon Read(int id)
        {
            return weaponRepository.Read(id);
        }

        public Weapon MostUsedWeapon()
        {
            var query = (from l in ReadAll()
                         group l by l into gr
                         orderby gr.Count() descending
                         select gr.Key).First();
            return query;
        }

        public void Update(Weapon obj)
        {
            if (obj.Name != "")
            {
                weaponRepository.Update(obj);
            }
            else
            {
                throw new ErrorException("Some Data is not valid");
            }
        }
    }
}
