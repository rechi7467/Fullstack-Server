using Fullstack.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [Required]
        public string Instructions { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public int PreparationTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

