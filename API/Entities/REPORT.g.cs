using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a report entity with essential details
    /// </summary>
    [Table("REPORT", Schema = "dbo")]
    public class REPORT
    {
        /// <summary>
        /// Initializes a new instance of the REPORT class.
        /// </summary>
        public REPORT()
        {
            REPORT_TYPE = -1;
            ENTITY_TYPE = -1;
            IS_DEACTIVATED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the REPORT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field REPORT_TYPE of the REPORT 
        /// </summary>
        [Required]
        public int REPORT_TYPE { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the REPORT 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the REPORT 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// UPDATED_DATE of the REPORT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REPORT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the REPORT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REPORT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// BINARY_DATA of the REPORT 
        /// </summary>
        public byte[]? BINARY_DATA { get; set; }
        /// <summary>
        /// STORED_PROCEDURES of the REPORT 
        /// </summary>
        public string? STORED_PROCEDURES { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the REPORT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the REPORT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// NAME of the REPORT 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// DESCRIPTION of the REPORT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}