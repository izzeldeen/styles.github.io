using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace style.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class UserInfo
    {
        //add new methods
       

            
        //[Compare("UserPassowrd", ErrorMessage ="The Password is not match")]
        [Display(Name = "Confirm passowrd")]
        public string ConfPassowrd { get; set; }

      
        
        //[Compare("UserEmail", ErrorMessage ="The Email is not match")]
        [Display(Name ="Confirm Email")]
        public string ConfEmail { get; set; }
    }

    public class UserMetaData
    {
        //Edit on current methods
        [Display(Name = "User ID")]
        [Required]
        public int UserID { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="User Email")]
        public string UserEmail { get; set; }
        [Required]
        
        [DataType(DataType.Password)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W]).{8,64})", ErrorMessage ="the passowrd should be strong")]
        [Display(Name ="User Passowrd ")]
        public string UserPassowrd { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string UserAddress { get; set; }
        [Required]
        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        
        public Nullable<double> UserBalance { get; set; }
        [Display(Name = "Type")]
        [Required]
        public string UserType { get; set; }


    }

}