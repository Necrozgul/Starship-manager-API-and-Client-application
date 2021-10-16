﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZNJXL9_HFT_2021221.Data
{
    [Table("brands")]
    public class Brand
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
        // IEnumerable, ICollection, IList, IDictionary

        public Brand()
        {
            Starships = new HashSet<Starship>();
        }
    }
}
