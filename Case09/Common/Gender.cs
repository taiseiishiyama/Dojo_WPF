using System.ComponentModel.DataAnnotations;

namespace Case09.Common
{
    internal enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Famale,
    }
}