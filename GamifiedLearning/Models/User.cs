using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int TotalPoints { get; set; }
        public int Level { get; set; }

        public string Badges { get; set; }
    }
}