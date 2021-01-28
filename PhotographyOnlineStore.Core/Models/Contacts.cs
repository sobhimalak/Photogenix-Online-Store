using System.ComponentModel.DataAnnotations;

namespace PhotographyOnlineStore.Core.Models
{
    public class Contacts : BaseEntity
    {
        [Required, Display(Name = "Sender Name")]
        public string SenderName { get; set; }
        [Required, Display(Name = "Sender Email"), EmailAddress]
        public string SenderEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
