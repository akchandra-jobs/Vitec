using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a nonsreferences entity with essential details
    /// </summary>
    [Table("NonsReferences", Schema = "Bim")]
    public class NonsReferences
    {
        /// <summary>
        /// Primary key for the NonsReferences 
        /// </summary>
        [Key]
        [Required]
        public Int64 Id { get; set; }

        /// <summary>
        /// Navigation property representing the associated Products
        /// </summary>
        [ForeignKey("Id")]
        public Products? Id_Products { get; set; }
        /// <summary>
        /// RefPriSysLoc of the NonsReferences 
        /// </summary>
        public string? RefPriSysLoc { get; set; }
        /// <summary>
        /// RefPriSysOcc of the NonsReferences 
        /// </summary>
        public string? RefPriSysOcc { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysComp of the NonsReferences 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysComp { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysClass of the NonsReferences 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysClass { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysNo1 of the NonsReferences 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysNo1 { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysNo2 of the NonsReferences 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysNo2 { get; set; }
        /// <summary>
        /// RefCompOcc of the NonsReferences 
        /// </summary>
        public string? RefCompOcc { get; set; }
        /// <summary>
        /// RefCompClass of the NonsReferences 
        /// </summary>
        public string? RefCompClass { get; set; }
        /// <summary>
        /// RefCompOcc_RefCompOccNo of the NonsReferences 
        /// </summary>
        public string? RefCompOcc_RefCompOccNo { get; set; }
        /// <summary>
        /// RefCompType of the NonsReferences 
        /// </summary>
        public string? RefCompType { get; set; }
        /// <summary>
        /// RefCompType_RefCompTypeNo1 of the NonsReferences 
        /// </summary>
        public string? RefCompType_RefCompTypeNo1 { get; set; }
        /// <summary>
        /// RefCompType_RefCompTypeNo2 of the NonsReferences 
        /// </summary>
        public string? RefCompType_RefCompTypeNo2 { get; set; }
        /// <summary>
        /// RefString of the NonsReferences 
        /// </summary>
        public string? RefString { get; set; }
    }
}