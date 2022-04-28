using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZNJXL9_HFT_2021221.Models
{
    public class Weapon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [NotMapped]
        [JsonIgnore]          
        public virtual IList<Starship> Starships { get; set; }
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}
