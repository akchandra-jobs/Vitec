using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a activity_constraint entity with essential details
    /// </summary>
    [Table("ACTIVITY_CONSTRAINT", Schema = "dbo")]
    public class ACTIVITY_CONSTRAINT
    {
        /// <summary>
        /// Initializes a new instance of the ACTIVITY_CONSTRAINT class.
        /// </summary>
        public ACTIVITY_CONSTRAINT()
        {
            TYPE = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ACTIVITY_CONSTRAINT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field TYPE of the ACTIVITY_CONSTRAINT 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ACTIVITY_CONSTRAINT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ACTIVITY_CONSTRAINT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ACTIVITY_CONSTRAINT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ACTIVITY_CONSTRAINT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ACTIVITY_CONSTRAINT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the ACTIVITY_CONSTRAINT belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the ACTIVITY_CONSTRAINT belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK_MASTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK_MASTER")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_MASTER_PERIODIC_TASK { get; set; }
        /// <summary>
        /// ID of the ACTIVITY_CONSTRAINT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ACTIVITY_CONSTRAINT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}