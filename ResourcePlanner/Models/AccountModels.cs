using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;
using System.Web.Security;

namespace ResourcePlanner.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public System.Data.Entity.DbSet<ResourcePlanner.Models.BusinessUnit> BusinessUnits { get; set; }

        public System.Data.Entity.DbSet<ResourcePlanner.Models.Department> Departments { get; set; }
        public System.Data.Entity.DbSet<ResourcePlanner.Models.Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessUnit>()
                .HasKey(b => b.BusinessUnitId);

            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentId);

            modelBuilder.Entity<Department>()
             .HasRequired(b => b.BusinessUnit)
             .WithMany(d => d.Departments)
             .HasForeignKey(b => b.BusinessUnitID);

            modelBuilder.Entity<Person>()
            .HasRequired(d => d.Department)
            .WithMany(p => p.People)
            .HasForeignKey(d =>d.DepartmentID);

            modelBuilder.Entity<Project>()
            .HasRequired(p => p.Department)
            .WithMany(p => p.Projects)
            .HasForeignKey(p => p.DepartmentID)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasRequired(t => t.Project)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.ProjectID)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<ResourcePlanner.Models.Role> Roles { get; set; }

        public System.Data.Entity.DbSet<ResourcePlanner.Models.UserProjectRole> UserProjectRoles { get; set; }

        public System.Data.Entity.DbSet<ResourcePlanner.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<ResourcePlanner.Models.State> States { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
