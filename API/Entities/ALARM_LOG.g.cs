using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a alarm_log entity with essential details
    /// </summary>
    [Table("ALARM_LOG", Schema = "dbo")]
    public class ALARM_LOG
    {
        /// <summary>
        /// Initializes a new instance of the ALARM_LOG class.
        /// </summary>
        public ALARM_LOG()
        {
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ALARM_LOG 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the ALARM_LOG 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// SENT_DATE of the ALARM_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SENT_DATE { get; set; }

        /// <summary>
        /// RESET_DATE of the ALARM_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RESET_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ALARM_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ALARM_LOG belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ALARM_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ALARM_LOG belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// EMAIL_COPY_TO of the ALARM_LOG 
        /// </summary>
        public string? EMAIL_COPY_TO { get; set; }
        /// <summary>
        /// ATTACHMENTS of the ALARM_LOG 
        /// </summary>
        public string? ATTACHMENTS { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ALARM_LOG belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ALARM to which the ALARM_LOG belongs 
        /// </summary>
        public Guid? GUID_ALARM { get; set; }

        /// <summary>
        /// Navigation property representing the associated ALARM
        /// </summary>
        [ForeignKey("GUID_ALARM")]
        public ALARM? GUID_ALARM_ALARM { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_HISTORY to which the ALARM_LOG belongs 
        /// </summary>
        public Guid? GUID_ENTITY_HISTORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_HISTORY
        /// </summary>
        [ForeignKey("GUID_ENTITY_HISTORY")]
        public ENTITY_HISTORY? GUID_ENTITY_HISTORY_ENTITY_HISTORY { get; set; }
        /// <summary>
        /// GUID_ENTITY of the ALARM_LOG 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }
        /// <summary>
        /// EMAIL_FROM of the ALARM_LOG 
        /// </summary>
        public string? EMAIL_FROM { get; set; }
        /// <summary>
        /// EMAIL_TO of the ALARM_LOG 
        /// </summary>
        public string? EMAIL_TO { get; set; }
        /// <summary>
        /// EMAIL_SUBJECT of the ALARM_LOG 
        /// </summary>
        public string? EMAIL_SUBJECT { get; set; }
        /// <summary>
        /// EMAIL_BODY of the ALARM_LOG 
        /// </summary>
        public string? EMAIL_BODY { get; set; }
    }
}