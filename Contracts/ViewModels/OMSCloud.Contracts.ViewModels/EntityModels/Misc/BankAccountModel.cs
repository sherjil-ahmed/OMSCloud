using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class BankAccountModel : BaseModel
    {
        public long BankId { get; set; }
        public long SupplierId { get; set; }
        [Display(Name = "Shop Name")]
        public string ShopName { get; set; }
        [Display(Name = "Bank Name")]
        [Required(ErrorMessage ="Bank Name can not be empty.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bank Address can not be empty.")]
        [Display(Name = "Bank Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bank Account Title can not be empty.")]
        [Display(Name = "Bank Account Title")]
        public string AccountTitle { get; set; }

        [Required(ErrorMessage = "Bank Number can not be empty.")]
        [Display(Name = "Conventional Bank Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name= "Transit/Routing Number, Sort Code, BSB Number, IBAN")]
        [Required(ErrorMessage = "Bank Name can not be empty.")]
        public string IBAN { get; set; }
        public int? AccountTypeId { get; set; } = -1;
        public string AccountType { get; set; } 
    }
}
