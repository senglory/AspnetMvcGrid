using System;
using System.ComponentModel.DataAnnotations;



namespace AspnetMvcGrid.Interfaces.DTO
{
    public class AssetDto
    {
        [Required]
        public string AssetID;
        [Display(Name = "FIO")]
        [Required]
        public string FIO;
        [Display(Name = "AssetDate")]
        [Required]
        public DateTime AssetDate;
        [Display(Name = "AssetNumber")]
        [Required]
        public string AssetNumber;
        [Display(Name = "Organization Name")]
        [Required]
        public string OrgName;
        [Display(Name = "Position")]
        [Required]
        public string Position;
        [Display(Name = "E-Mail")]
        [Required]
        public string EMail;
    }
}
