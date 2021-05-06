using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("HelplineCategory")]
    public partial class HelplineCategory
    {
        public HelplineCategory()
        {
            Helplines = new HashSet<Helpline>();
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string HelplineCategoryName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [InverseProperty(nameof(Helpline.HelplineCategory))]
        public virtual ICollection<Helpline> Helplines { get; set; }
    }
}
