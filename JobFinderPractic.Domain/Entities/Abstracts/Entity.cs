using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinderPractic.Domain.Entities.Abstracts
{
	public class Entity
	{
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
    }

}
