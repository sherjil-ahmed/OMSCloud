using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMSCloud.Web.MVC.Net.Areas.Security.Models
{
    [Table("PERMISSIONS")]
    public class PERMISSION
    {
        [Key]
        public long PermissionId { get; set; }

        [Required]
        [StringLength(1000)]
        public string PermissionDescription { get; set; }

        public virtual List<ApplicationRole> ROLES { get; set; }
    }
}