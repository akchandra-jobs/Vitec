using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a building_x_contract entity with essential details
    /// </summary>
    [Table("BUILDING_X_CONTRACT", Schema = "dbo")]
    public class BUILDING_X_CONTRACT
    {
        /// <summary>
        /// Initializes a new instance of the BUILDING_X_CONTRACT class.
        /// </summary>
        public BUILDING_X_CONTRACT()
        {
            IS_ACTIVE = false;
            IS_DEACTIVATED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the BUILDING_X_CONTRACT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_ACTIVE of the BUILDING_X_CONTRACT 
        /// </summary>
        [Required]
        public bool IS_ACTIVE { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the BUILDING_X_CONTRACT 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// UPDATED_DATE of the BUILDING_X_CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING_X_CONTRACT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the BUILDING_X_CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING_X_CONTRACT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the BUILDING_X_CONTRACT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the BUILDING_X_CONTRACT belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the BUILDING_X_CONTRACT belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
        /// <summary>
        /// Foreign key referencing the PRICE_SHEET to which the BUILDING_X_CONTRACT belongs 
        /// </summary>
        public Guid? GUID_PRICE_SHEET { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRICE_SHEET
        /// </summary>
        [ForeignKey("GUID_PRICE_SHEET")]
        public PRICE_SHEET? GUID_PRICE_SHEET_PRICE_SHEET { get; set; }
    }
}