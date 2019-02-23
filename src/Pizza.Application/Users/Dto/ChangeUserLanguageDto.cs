using System.ComponentModel.DataAnnotations;

namespace Pizza.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}