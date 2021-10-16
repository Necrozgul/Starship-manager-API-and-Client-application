using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNJXL9_HFT_2021221.Data
{
    [Table("starships")]
    public class Starship
    {

        public Starship() {}

        public Starship(string modelName, int id, int price)
        {
            Model = modelName;
            BrandId = id;
            BasePrice = price;
            WeaponId = id;
        }

        public Starship(string modelName, int id)
        {
            Model = modelName;
            BrandId = id;
            WeaponId = id;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Part 1
        [Column("starship_id", TypeName = "int")]
        // Part 2 auto key increment
        //[Column("car_id", TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Model { get; set; }

        //[MaxLength(100)]
        //[Required]
        //public string Weapon { get; set; }

        public int? BasePrice { get; set; }

        // Proxy class
        // Lazy loading
        [NotMapped]
        public virtual Brand Brand { get; set; }

        [NotMapped]
        public virtual Weapon Weapon { get; set; }


        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        [ForeignKey(nameof(Weapon))]
        public int WeaponId { get; set; }
    }
}
