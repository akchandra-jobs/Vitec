using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning_x_cleaning_task entity with essential details
    /// </summary>
    [Table("CLEANING_X_CLEANING_TASK", Schema = "dbo")]
    public class CLEANING_X_CLEANING_TASK
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING_X_CLEANING_TASK class.
        /// </summary>
        public CLEANING_X_CLEANING_TASK()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CLEANING_X_CLEANING_TASK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CLEANING_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING to which the CLEANING_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_CLEANING { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING
        /// </summary>
        [ForeignKey("GUID_CLEANING")]
        public CLEANING? GUID_CLEANING_CLEANING { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_TASK to which the CLEANING_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_TASK
        /// </summary>
        [ForeignKey("GUID_CLEANING_TASK")]
        public CLEANING_TASK? GUID_CLEANING_TASK_CLEANING_TASK { get; set; }
        /// <summary>
        /// RECURRENCE of the CLEANING_X_CLEANING_TASK 
        /// </summary>
        public string? RECURRENCE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}