using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZNJXL9_HFT_2021221.Data;

namespace ZNJXL9_HFT_2021221.Data
{
    [Table("weapon")]
    public class Weapon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Part 2
        //[Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        public virtual ICollection<Starship> Starships { get; set; }

        public Weapon()
        {
            Starships = new HashSet<Starship>();
        }



    }
}
