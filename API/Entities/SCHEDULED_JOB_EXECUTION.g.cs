using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a scheduled_job_execution entity with essential details
    /// </summary>
    [Table("SCHEDULED_JOB_EXECUTION", Schema = "dbo")]
    public class SCHEDULED_JOB_EXECUTION
    {
        /// <summary>
        /// Initializes a new instance of the SCHEDULED_JOB_EXECUTION class.
        /// </summary>
        public SCHEDULED_JOB_EXECUTION()
        {
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field STATUS of the SCHEDULED_JOB_EXECUTION 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Primary key for the SCHEDULED_JOB_EXECUTION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the SCHEDULED_JOB to which the SCHEDULED_JOB_EXECUTION belongs 
        /// </summary>
        public Guid? GUID_SCHEDULED_JOB { get; set; }

        /// <summary>
        /// Navigation property representing the associated SCHEDULED_JOB
        /// </summary>
        [ForeignKey("GUID_SCHEDULED_JOB")]
        public SCHEDULED_JOB? GUID_SCHEDULED_JOB_SCHEDULED_JOB { get; set; }
        /// <summary>
        /// JOB_ID of the SCHEDULED_JOB_EXECUTION 
        /// </summary>
        public string? JOB_ID { get; set; }
        /// <summary>
        /// PARAMETERS of the SCHEDULED_JOB_EXECUTION 
        /// </summary>
        public string? PARAMETERS { get; set; }
        /// <summary>
        /// LOG_OUTPUT of the SCHEDULED_JOB_EXECUTION 
        /// </summary>
        public string? LOG_OUTPUT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SCHEDULED_JOB_EXECUTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SCHEDULED_JOB_EXECUTION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SCHEDULED_JOB_EXECUTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SCHEDULED_JOB_EXECUTION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}