using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZNJXL9_HFT_2021221.Models
{
    public class Starship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public int? BasePrice { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual Brand Brand { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Weapon Weapon { get; set; }

        [ForeignKey(nameof(Weapon))]
        public int WeaponId { get; set; }

        public override string ToString()
        {
            return $"Id={Id} [{Name}] Price:{BasePrice} BrandId:{BrandId}, WeaponId:{WeaponId}";
        }

        public string Print()
        {
            return $"Id={Id} [{Name}] Price:{BasePrice} BrandId:{BrandId}, WeaponId:{WeaponId}";
        }
    }
}
