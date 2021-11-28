using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZNJXL9_HFT_2021221.Models
{
    public class Weapon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Starship> Starships { get; set; }

        public Weapon()
        {
            Starships = new HashSet<Starship>();
        }
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}
