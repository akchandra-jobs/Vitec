using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a integration_data entity with essential details
    /// </summary>
    [Table("INTEGRATION_DATA", Schema = "dbo")]
    public class INTEGRATION_DATA
    {
        /// <summary>
        /// Initializes a new instance of the INTEGRATION_DATA class.
        /// </summary>
        public INTEGRATION_DATA()
        {
            JOB_ID = -1;
            STATUS = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the INTEGRATION_DATA 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field JOB_ID of the INTEGRATION_DATA 
        /// </summary>
        [Required]
        public int JOB_ID { get; set; }

        /// <summary>
        /// Required field STATUS of the INTEGRATION_DATA 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field COUNTER of the INTEGRATION_DATA 
        /// </summary>
        [Required]
        public int COUNTER { get; set; }
        /// <summary>
        /// BINARY_DATA of the INTEGRATION_DATA 
        /// </summary>
        public byte[]? BINARY_DATA { get; set; }

        /// <summary>
        /// UPDATED_DATE of the INTEGRATION_DATA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the INTEGRATION_DATA belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the INTEGRATION_DATA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the INTEGRATION_DATA belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TEXT_DATA of the INTEGRATION_DATA 
        /// </summary>
        public string? TEXT_DATA { get; set; }
        /// <summary>
        /// FILE_NAME of the INTEGRATION_DATA 
        /// </summary>
        public string? FILE_NAME { get; set; }
        /// <summary>
        /// MESSAGE of the INTEGRATION_DATA 
        /// </summary>
        public string? MESSAGE { get; set; }

        /// <summary>
        /// PROCESSED_DATE of the INTEGRATION_DATA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PROCESSED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOM_FUNCTION to which the INTEGRATION_DATA belongs 
        /// </summary>
        public Guid? GUID_CUSTOM_FUNCTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOM_FUNCTION
        /// </summary>
        [ForeignKey("GUID_CUSTOM_FUNCTION")]
        public CUSTOM_FUNCTION? GUID_CUSTOM_FUNCTION_CUSTOM_FUNCTION { get; set; }
        /// <summary>
        /// Foreign key referencing the SCHEDULED_JOB to which the INTEGRATION_DATA belongs 
        /// </summary>
        public Guid? GUID_SCHEDULED_JOB { get; set; }

        /// <summary>
        /// Navigation property representing the associated SCHEDULED_JOB
        /// </summary>
        [ForeignKey("GUID_SCHEDULED_JOB")]
        public SCHEDULED_JOB? GUID_SCHEDULED_JOB_SCHEDULED_JOB { get; set; }
        /// <summary>
        /// ID of the INTEGRATION_DATA 
        /// </summary>
        public string? ID { get; set; }
    }
}