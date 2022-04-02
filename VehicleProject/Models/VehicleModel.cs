using System.ComponentModel.DataAnnotations;

namespace VehicleProject.Models
{
    public class VehicleModel
    {
        public int VehicleModelID { get; set; }
        [Required()]
        [StringLength(50)]
        public string? ModelName { get; set; }

        public int VehicleMakeID { get; set; }
        public virtual VehicleMake? VehicleMakes { get; set; }
    }
}
