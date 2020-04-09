using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace style.Models
{


    [MetadataType(typeof(ItemMetaData))]
    public partial class Item
    {
        // Add new mehtods and properties


    }

    public class ItemMetaData
    {
        // for edit on current methods and properties

        public int Code { get; set; }
        [Required]
        [Display(Name ="Item Name")]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Descriiption")]
        public string ItemDescription { get; set; }
        [Required]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString ="{0:c}",ApplyFormatInEditMode =false)]

        public Nullable<double> ItemPrice { get; set; }
        [Required]
        public string Department { get; set; }
        public string logo { get; set; }


    }
}