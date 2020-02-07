using System;
using System.ComponentModel.DataAnnotations;

namespace HomeAreaManagement.ViewModels
{
    public class AreaViewModel
    {
		public int Id { get; set; }

		[Required]
		[MaxLength(200)]
		public string Name { get; set; }
		public string CreatedOn { get; set; }
		public string CreatedById { get; set; }
		public string UpdatedOn { get; set; }
		public string UpdatedById { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
    }
}
