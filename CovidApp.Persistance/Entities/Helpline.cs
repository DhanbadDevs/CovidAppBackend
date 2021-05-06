using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CovidApp.Persistance.Entities
{
    [Table("Helpline")]
    public partial class Helpline
    {
        [Key]
        public long Id { get; set; }
        public long HelplineCategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string HelplineName { get; set; }
        [StringLength(50)]
        public string Timing { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        public int? Votes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(HelplineCategoryId))]
        [InverseProperty("Helplines")]
        public virtual HelplineCategory HelplineCategory { get; set; }
    }
}
