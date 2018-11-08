using System.ComponentModel.DataAnnotations;

namespace MRT.Dtos
{
    public class PolicyTypeDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}