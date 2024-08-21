using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a nons_reference entity with essential details
    /// </summary>
    [Table("NONS_REFERENCE", Schema = "dbo")]
    public class NONS_REFERENCE
    {
        /// <summary>
        /// Initializes a new instance of the NONS_REFERENCE class.
        /// </summary>
        public NONS_REFERENCE()
        {
            ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the NONS_REFERENCE 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Primary key for the NONS_REFERENCE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the NONS_REFERENCE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// GUID_ENTITY of the NONS_REFERENCE 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }
        /// <summary>
        /// RefPriSysLoc of the NONS_REFERENCE 
        /// </summary>
        public string? RefPriSysLoc { get; set; }
        /// <summary>
        /// RefPriSysOcc of the NONS_REFERENCE 
        /// </summary>
        public string? RefPriSysOcc { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysComp of the NONS_REFERENCE 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysComp { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysClass of the NONS_REFERENCE 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysClass { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysNo1 of the NONS_REFERENCE 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysNo1 { get; set; }
        /// <summary>
        /// RefPriSysOcc_RefPriSysNo2 of the NONS_REFERENCE 
        /// </summary>
        public string? RefPriSysOcc_RefPriSysNo2 { get; set; }
        /// <summary>
        /// RefCompOcc of the NONS_REFERENCE 
        /// </summary>
        public string? RefCompOcc { get; set; }
        /// <summary>
        /// RefCompClass of the NONS_REFERENCE 
        /// </summary>
        public string? RefCompClass { get; set; }
        /// <summary>
        /// RefCompOcc_RefCompOccNo of the NONS_REFERENCE 
        /// </summary>
        public string? RefCompOcc_RefCompOccNo { get; set; }
        /// <summary>
        /// RefCompType of the NONS_REFERENCE 
        /// </summary>
        public string? RefCompType { get; set; }
        /// <summary>
        /// RefCompType_RefCompTypeNo1 of the NONS_REFERENCE 
        /// </summary>
        public string? RefCompType_RefCompTypeNo1 { get; set; }
        /// <summary>
        /// RefCompType_RefCompTypeNo2 of the NONS_REFERENCE 
        /// </summary>
        public string? RefCompType_RefCompTypeNo2 { get; set; }
        /// <summary>
        /// RefString of the NONS_REFERENCE 
        /// </summary>
        public string? RefString { get; set; }

        /// <summary>
        /// UPDATED_DATE of the NONS_REFERENCE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the NONS_REFERENCE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the NONS_REFERENCE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the NONS_REFERENCE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}