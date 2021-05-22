using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CovidApp.Persistance.Entities
{
    [Table("FeedBack")]
    public partial class FeedBack
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public long CityId { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [Column("Comment")]
        [StringLength(500)]
        public string Comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("FeedBacks")]
        public virtual City City { get; set; }
    }
}
