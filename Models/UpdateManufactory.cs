using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PXU.ManuAPI.Models
{
    public class UpdateManufactory
    {
        [Display(Name = "Manufactory Name")]
        [Required(ErrorMessage = "Manufactory Name is required.")]
        public int ManufactoryId { get; set; }
        public string Name { get; set; }
    }
}
