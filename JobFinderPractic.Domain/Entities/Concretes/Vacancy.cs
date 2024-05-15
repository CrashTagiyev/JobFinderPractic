using JobFinderPractic.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobFinderPractic.Domain.Entities.Concretes
{
	public class Vacancy:Entity
	{
		public string? Title { get; set; }
		public string? JobDescription { get; set; }
		public string? QebulProsesi { get; set; }
		public string? IsCedveli { get; set; }
		public string? Experience { get; set; } 
		public string? Gender { get; set; } 
		public string? JobNature { get; set; } 
		public double MinimumSalary { get; set; } = 600;
		public double MaximumSalary { get; set; }
		public short MinimumAge { get; set; } = 18;
		public short MaximumAge { get; set; } = 60;
		public bool AcceptsDisabledApplicants { get; set; } = false;
		public bool AcceptsIncompleteCV { get; set; } = false;
		public string? Region { get; set; }
		public string? Address { get; set; }
		public string? ContactPersonName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public DateTime? ApplicationDate { get; set; }




		//Foreign keys
		public string? UserId { get; set; }

		//Navigation properties
		public virtual AppUser User { get; set; }
	}
}
