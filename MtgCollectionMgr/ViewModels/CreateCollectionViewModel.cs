using System.ComponentModel.DataAnnotations;

namespace MtgCollectionMgr.ViewModels
{
    public class CreateCollectionViewModel
    {
        [Required]
        [Display(Name = "Name this collection")]
        public string Name { get; set; }
    }
}
