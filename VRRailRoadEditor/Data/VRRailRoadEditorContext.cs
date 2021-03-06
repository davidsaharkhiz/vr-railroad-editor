﻿using Microsoft.EntityFrameworkCore;
using VRRailRoadEditor.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using VRRailRoadEditor.Helpers;

namespace VRRailRoadEditor.Data
{
	public class VRRailRoadEditorContext : DbContext
	{
		public VRRailRoadEditorContext(DbContextOptions<VRRailRoadEditorContext> options) : base(options)
		{
		}

		//old stuff todo: remove
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Dependent> Dependents { get; set; }
		public DbSet<Discount> Discounts { get; set; }

		//layout stuff:
		public DbSet<Tile> Tiles { get; set; }
		public DbSet<Layout> Layouts { get; set; }
		public DbSet<Material> Materials { get; set; }
		public DbSet<StandardRail> Rails { get; set; }

		// many to many
		public DbSet<EmployeeDependent> EmployeeDependents { get; set; }

		/// <summary>
		/// Retrieves discounts with properly populated delegates
		/// </summary>
		public List<Discount> DiscountsWithCalculations { 
			get
			{
				return Discount.MapDelegatesToDiscounts(Discounts);
			}
		}

		/// <summary>
		/// Convenience method to automatically fetch all associated records and apply all discounts
		/// </summary>
		public IQueryable<Employee> EmployeesWithAllData { 
			get {
				var employees = Employees.Include(e => e.EmployeeDependents).ThenInclude(e => e.Dependent);
				var discountsWithCalculations = DiscountsWithCalculations;
				foreach (var employee in employees) {
					employee.ApplyDiscounts(new DiscountHelper(discountsWithCalculations));
				}
				return employees;
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Define composite key for our join table
			modelBuilder.Entity<EmployeeDependent>()
				.HasKey(t => new { t.EmployeeId, t.DependentId });
		}

	}
}