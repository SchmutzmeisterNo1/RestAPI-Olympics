using Microsoft.EntityFrameworkCore;
using Olympics.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Service
{
	public class DataContext : DbContext
	{
		private User _user;

		public User User
		{
			get { return _user; }
			set { _user = value; }
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Privilege> Privileges { get; set; }
		public DbSet<RolePrivilege> Roleprivileges { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<RolePrivilege>().HasKey(x => new { x.PrivilegeId, x.RoleId });
			builder.Entity<RolePrivilege>().HasOne(x => x.Role).WithMany(x => x.Privileges).HasForeignKey(x => x.RoleId);
			builder.Entity<RolePrivilege>().HasOne(x => x.Privilege).WithMany(x => x.Roles).HasForeignKey(x => x.PrivilegeId);
		}
	}
}
