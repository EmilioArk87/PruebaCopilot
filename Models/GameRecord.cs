using System.ComponentModel.DataAnnotations;

namespace SnakeGameApp.Models
{
    public class GameRecord
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nickname { get; set; } = string.Empty;
        
        [Required]
        public int PlayTimeSeconds { get; set; }
        
        [Required]
        public int Score { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}