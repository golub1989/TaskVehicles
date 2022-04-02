using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Models
{
    public class VehicleMake
    {
        public int VehicleMakeID { get; set; }
        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required()]
        [StringLength(50, MinimumLength = 2)]
        public string? Abbreviation { get; set; }

        public virtual List<VehicleModel>? VehicleModels { get; set; }
    }
}
