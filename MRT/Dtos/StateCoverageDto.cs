using System.ComponentModel.DataAnnotations;

namespace MRT.Dtos
{
    public class StateCoverageDto
    {
        public int Id { get; set; }

        [Required]
        public int CarrierId { get; set; }

        [Required]
        public int StateId { get; set; }

        public StateDto State { get; set; }
    }
}