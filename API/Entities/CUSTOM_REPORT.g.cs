using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a custom_report entity with essential details
    /// </summary>
    [Table("CUSTOM_REPORT", Schema = "dbo")]
    public class CUSTOM_REPORT
    {
        /// <summary>
        /// Initializes a new instance of the CUSTOM_REPORT class.
        /// </summary>
        public CUSTOM_REPORT()
        {
            ENTITY_TYPE = -1;
            COUNTER = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the CUSTOM_REPORT 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Primary key for the CUSTOM_REPORT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field COUNTER of the CUSTOM_REPORT 
        /// </summary>
        [Required]
        public int COUNTER { get; set; }

        /// <summary>
        /// LAST_PRINT_DATE of the CUSTOM_REPORT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_PRINT_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CUSTOM_REPORT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the CUSTOM_REPORT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// FILE_PATH of the CUSTOM_REPORT 
        /// </summary>
        public string? FILE_PATH { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CUSTOM_REPORT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOM_REPORT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CUSTOM_REPORT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOM_REPORT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}