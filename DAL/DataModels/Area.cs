using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class Area
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset CreatedOn { get; set; }

        [Required]
        public int CreatedById { get; set; }

        public Nullable<DateTimeOffset> UpdatedOn { get; set; }

        public Nullable<int> UpdatedById { get; set; }
    }
}
