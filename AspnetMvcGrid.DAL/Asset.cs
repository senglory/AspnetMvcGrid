using System;
using System.ComponentModel.DataAnnotations;



namespace AspnetMvcGrid.DAL
{
    public class Asset
    {
        [Key]
        public System.Guid AssetID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime AssetDate { get; set; }

        [Required]
        public string AssetNumber { get; set; }

        [Required]
        public string OrgName { get; set; }

        public string Position { get; set; }

        public string EMail { get; set; }

        public DateTime? ApprovalDate { get; set; }
    }
}
