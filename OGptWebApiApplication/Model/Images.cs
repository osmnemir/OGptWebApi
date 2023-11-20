using System.ComponentModel.DataAnnotations;

namespace OGptWebApiApplication.Model
{
    public class Images
    {
        [Required]
        public string Prompt { get; set; }
        public int Size { get; set; }
        public int Piece { get; set; }
    }
}
