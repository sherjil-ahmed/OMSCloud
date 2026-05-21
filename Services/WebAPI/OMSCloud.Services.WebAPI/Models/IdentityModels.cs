using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OMSCloud.Services.WebAPIs.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<long> { }
    public class ApplicationUserClaim : IdentityUserClaim<long> { }

    public class ApplicationUserRole : IdentityUserRole<long>
    {
        public ApplicationUserRole()
            : base()
        { }

        public ApplicationRole Role { get; set; }

        public bool IsPermissionInRole(string _permission)
        {
            bool _retVal = false;
            try
            {
                _retVal = this.Role.IsPermissionInRole(_permission);
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public bool IsSysAdmin { get { return (this.Role == null ? false : this.Role.IsSysAdmin); } }
    }

    public class ApplicationUser : IdentityUser<long, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {        
        public DateTime LastModified { get; set; }

        public bool Inactive { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ApplicationUser()
        {
            LastModified = DateTime.Now;
            Inactive = false;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, long> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }


        //public virtual List<ApplicationRole> UserRoles { get; set; }


        public bool IsPermissionInUserRoles(string _permission)
        {
            bool _retVal = false;
            try
            {
                _retVal = (from r in this.Roles select r).Any(i => i.IsSysAdmin || i.IsPermissionInRole(_permission));
                //foreach (ApplicationUserRole _role in this.Roles)
                //{
                //    if (_role.IsSysAdmin || _role.IsPermissionInRole(_permission))
                //    {
                //        _retVal = true;
                //        break;
                //    }
                //}
            }
            catch (Exception)
            {
            }
            return _retVal;
        }

        public bool IsSysAdmin()
        {
            bool _retVal = false;
            try
            {
                _retVal = (from r in this.Roles select r).Any(i => i.IsSysAdmin);
                //foreach (ApplicationUserRole _role in this.Roles)
                //{
                //    if (_role.IsSysAdmin)
                //    {
                //        _retVal = true;
                //        break;
                //    }
                //}
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
    }

    public class ApplicationRole : IdentityRole<long, ApplicationUserRole>
    {
        public ApplicationRole()
        {
            //this.Id = Guid.NewGuid().ToString();
        }
        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationRole(string name, string description)
            : this(name)
        {
            this.RoleDescription = description;
        }

        public DateTime LastModified { get; set; }
        public bool IsSysAdmin { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<PERMISSION> PERMISSIONS { get; set; }

        public bool IsPermissionInRole(string _permission)
        {
            bool _retVal = false;
            try
            {
                _retVal = (from p in this.PERMISSIONS select p).Any(i => i.PermissionDescription.ToLower() == _permission.ToLower());
                //foreach (PERMISSION _perm in this.PERMISSIONS)
                //{
                //    if (_perm.PermissionDescription.ToLower() == _permission.ToLower())
                //    {
                //        _retVal = true;
                //        break;
                //    }
                //}
            }
            catch (Exception)
            {
            }
            return _retVal;
        }
    }

    public class SecurityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public DbSet<PERMISSION> PERMISSIONS { get; set; }

        public SecurityDbContext() : base("DefaultSecurityConnection")
        {
            Database.SetInitializer<SecurityDbContext>(new SecurityDBInitializer());

        }

        public SecurityDbContext(string connectionString)
            : base(connectionString)
        {

        }

        public static SecurityDbContext Create()
        {
            return new SecurityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("USERS").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationRole>().ToTable("ROLES").Property(p => p.Id).HasColumnName("RoleId");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("LNK_USER_ROLE");

            modelBuilder.Entity<ApplicationRole>().
            HasMany(c => c.PERMISSIONS).
            WithMany(p => p.ROLES).
            Map(
                m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("PermissionId");
                    m.ToTable("LNK_ROLE_PERMISSION");
                });
        }


        public static string _localConnectionString = string.Empty;
        private static string LocalConnectionString
        {
            get
            {
                if (_localConnectionString == string.Empty)
                {
                    _localConnectionString = GetConnectionString();

                    //if (_localConnectionString == string.Empty )
                    //  Utility.Logger.Info("using the default connection string");
                    //else
                    //  Utility.Logger.Info("using the local connection string used (name in config): \"{0}\"", System.Environment.MachineName);
                }

                return _localConnectionString;
            }
        }

        private static string GetConnectionString()
        {
            try
            {
                var str = System.Configuration.ConfigurationManager.ConnectionStrings[System.Environment.MachineName];//?.ConnectionString;

                return str == null ? string.Empty : System.Environment.MachineName;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static SecurityDbContext CreateInstance()
        {

            //DbInterception.Add(new SqlInterceptor());
            SecurityDbContext context = null;
            if (LocalConnectionString == string.Empty)
            {
                try
                {
                    context = new SecurityDbContext();
                }
                catch (Exception ex)
                {
                    var Message = System.Configuration.ConfigurationManager.ConnectionStrings["OMSContext"].ConnectionString;
                    var e = new Exception(ex.Message + Environment.NewLine + Message, ex);

                    throw e;
                }

            }
            else
            {
                try
                {
                    context = new SecurityDbContext(LocalConnectionString);
                }
                catch (Exception ex)
                {
                    var Message = LocalConnectionString;
                    var e = new Exception(ex.Message + Environment.NewLine + Message, ex);

                    throw e;
                }

            }
            //context.Configuration.AutoDetectChangesEnabled = false;
            return context;

        }
    }
}