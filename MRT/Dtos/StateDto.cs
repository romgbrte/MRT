using System.ComponentModel.DataAnnotations;

namespace MRT.Dtos
{
    public class StateDto
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(2)]
        public string Abbreviation { get; set; }
    }
}