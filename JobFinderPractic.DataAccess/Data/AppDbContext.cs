using Azure;
using JobFinderPractic.Domain.Entities.Abstracts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobFinderPractic.DataAccess.Data
{
	public class AppDbContext:IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> option)
			: base(option)
		{
		}



		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

	}
}
