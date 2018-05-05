using System.ComponentModel.DataAnnotations;

namespace SimpleMVC_VIPInvitation.Models
{
    public class VipRsvpModel
    {
        [Required(ErrorMessage = "Proszę podać imię i nazwisko.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać adres E-mail.")]
        [RegularExpression(".+\\@.+\\..+",
            ErrorMessage = "Proszę podać prawidłowy adres E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę określić rolę")]
        public bool? IsPhotographer { get; set; }

        public string Application { get; set; }
    }
}