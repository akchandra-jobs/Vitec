using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a log entity with essential details
    /// </summary>
    [Table("LOG", Schema = "dbo")]
    public class LOG
    {
        /// <summary>
        /// Initializes a new instance of the LOG class.
        /// </summary>
        public LOG()
        {
            CATEGORY = 0;
            SEVERITY = -1;
            PROCESS_ID = 0;
            INDEX = 0;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field CATEGORY of the LOG 
        /// </summary>
        [Required]
        public int CATEGORY { get; set; }

        /// <summary>
        /// Required field SEVERITY of the LOG 
        /// </summary>
        [Required]
        public int SEVERITY { get; set; }

        /// <summary>
        /// Primary key for the LOG 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field PROCESS_ID of the LOG 
        /// </summary>
        [Required]
        public int PROCESS_ID { get; set; }

        /// <summary>
        /// Required field INDEX of the LOG 
        /// </summary>
        [Required]
        public int INDEX { get; set; }

        /// <summary>
        /// SENT_TO_HOME of the LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SENT_TO_HOME { get; set; }
        /// <summary>
        /// MESSAGE_TEMPLATE of the LOG 
        /// </summary>
        public string? MESSAGE_TEMPLATE { get; set; }
        /// <summary>
        /// EXCEPTION of the LOG 
        /// </summary>
        public string? EXCEPTION { get; set; }
        /// <summary>
        /// LOG_EVENT of the LOG 
        /// </summary>
        public string? LOG_EVENT { get; set; }
        /// <summary>
        /// Foreign key referencing the LOG to which the LOG belongs 
        /// </summary>
        public Guid? GUID_PARENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated LOG
        /// </summary>
        [ForeignKey("GUID_PARENT")]
        public LOG? GUID_PARENT_LOG { get; set; }
        /// <summary>
        /// Foreign key referencing the USER_SESSION to which the LOG belongs 
        /// </summary>
        public Guid? GUID_USER_SESSION { get; set; }

        /// <summary>
        /// Navigation property representing the associated USER_SESSION
        /// </summary>
        [ForeignKey("GUID_USER_SESSION")]
        public USER_SESSION? GUID_USER_SESSION_USER_SESSION { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LOG belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// GUID_ENTITY of the LOG 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }
        /// <summary>
        /// MESSAGE of the LOG 
        /// </summary>
        public string? MESSAGE { get; set; }

        /// <summary>
        /// CREATION_DATE of the LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// WEB_BROWSER of the LOG 
        /// </summary>
        public string? WEB_BROWSER { get; set; }
        /// <summary>
        /// URL of the LOG 
        /// </summary>
        public string? URL { get; set; }
        /// <summary>
        /// ACTION_TYPE of the LOG 
        /// </summary>
        public string? ACTION_TYPE { get; set; }
        /// <summary>
        /// WEB_VERSION of the LOG 
        /// </summary>
        public string? WEB_VERSION { get; set; }
    }
}