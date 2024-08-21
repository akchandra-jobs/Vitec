using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a api_request_log entity with essential details
    /// </summary>
    [Table("API_REQUEST_LOG", Schema = "dbo")]
    public class API_REQUEST_LOG
    {
        /// <summary>
        /// Initializes a new instance of the API_REQUEST_LOG class.
        /// </summary>
        public API_REQUEST_LOG()
        {
            INDEX_POSITION = 0;
            RESPONSE_STATUS = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the API_REQUEST_LOG 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the API_REQUEST_LOG 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }

        /// <summary>
        /// Required field RESPONSE_STATUS of the API_REQUEST_LOG 
        /// </summary>
        [Required]
        public int RESPONSE_STATUS { get; set; }

        /// <summary>
        /// UPDATED_DATE of the API_REQUEST_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the API_REQUEST_LOG belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the API_REQUEST_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the API_REQUEST_LOG belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// REQUEST of the API_REQUEST_LOG 
        /// </summary>
        public string? REQUEST { get; set; }
        /// <summary>
        /// RESPONSE of the API_REQUEST_LOG 
        /// </summary>
        public string? RESPONSE { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_TASK to which the API_REQUEST_LOG belongs 
        /// </summary>
        public Guid? GUID_ENTITY_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_TASK
        /// </summary>
        [ForeignKey("GUID_ENTITY_TASK")]
        public ENTITY_TASK? GUID_ENTITY_TASK_ENTITY_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the SCHEDULED_JOB to which the API_REQUEST_LOG belongs 
        /// </summary>
        public Guid? GUID_SCHEDULED_JOB { get; set; }

        /// <summary>
        /// Navigation property representing the associated SCHEDULED_JOB
        /// </summary>
        [ForeignKey("GUID_SCHEDULED_JOB")]
        public SCHEDULED_JOB? GUID_SCHEDULED_JOB_SCHEDULED_JOB { get; set; }
    }
}