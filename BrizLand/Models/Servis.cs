using System.ComponentModel.DataAnnotations;

namespace BrizLand.Models
{
    public class Servis
    {
        public int Id { get; set; }
        [Required]
        public string IconName { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public string Title { get; set; } = null!;

    }
}
