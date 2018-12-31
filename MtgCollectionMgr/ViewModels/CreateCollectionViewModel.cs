using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MtgCollectionMgr.ViewModels
{
    public class CreateCollectionViewModel
    {
        [Required]
        [Display(Name = "Name this collection")]
        public string Name { get; set; }
    }
}
