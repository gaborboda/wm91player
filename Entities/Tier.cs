using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sm91.Play.Entities
{
    public enum Tier
    {
        [Display(Name = "Lite")]
        Lite,

        [Display(Name = "HD")]
        HD,

        [Display(Name = "4K")]
        FourK
    }
}
