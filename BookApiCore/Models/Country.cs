using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Country Name cannot be more than 50 characters")]
        public string Name { get; set; }
        // Adding 'virtual' enables lazy loading.
        public virtual ICollection<Author> Authors { get; set; }
    }
}
