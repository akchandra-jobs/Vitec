using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a scheduled_job entity with essential details
    /// </summary>
    [Table("SCHEDULED_JOB", Schema = "dbo")]
    public class SCHEDULED_JOB
    {
        /// <summary>
        /// Initializes a new instance of the SCHEDULED_JOB class.
        /// </summary>
        public SCHEDULED_JOB()
        {
            TYPE = -1;
            RUN_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field TYPE of the SCHEDULED_JOB 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Primary key for the SCHEDULED_JOB 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field RUN_TYPE of the SCHEDULED_JOB 
        /// </summary>
        [Required]
        public int RUN_TYPE { get; set; }
        /// <summary>
        /// ID of the SCHEDULED_JOB 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the SCHEDULED_JOB 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// PARAMETERS of the SCHEDULED_JOB 
        /// </summary>
        public string? PARAMETERS { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SCHEDULED_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SCHEDULED_JOB belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SCHEDULED_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SCHEDULED_JOB belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}