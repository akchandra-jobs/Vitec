using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a periodic_task_x_resource_group entity with essential details
    /// </summary>
    [Table("PERIODIC_TASK_X_RESOURCE_GROUP", Schema = "dbo")]
    public class PERIODIC_TASK_X_RESOURCE_GROUP
    {
        /// <summary>
        /// Initializes a new instance of the PERIODIC_TASK_X_RESOURCE_GROUP class.
        /// </summary>
        public PERIODIC_TASK_X_RESOURCE_GROUP()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PERIODIC_TASK_X_RESOURCE_GROUP 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the PERIODIC_TASK_X_RESOURCE_GROUP 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the PERIODIC_TASK_X_RESOURCE_GROUP 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PERIODIC_TASK_X_RESOURCE_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERIODIC_TASK_X_RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PERIODIC_TASK_X_RESOURCE_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERIODIC_TASK_X_RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the HOUR_TYPE to which the PERIODIC_TASK_X_RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_HOUR_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated HOUR_TYPE
        /// </summary>
        [ForeignKey("GUID_HOUR_TYPE")]
        public HOUR_TYPE? GUID_HOUR_TYPE_HOUR_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PERIODIC_TASK_X_RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the PERIODIC_TASK_X_RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the PERIODIC_TASK_X_RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the PERIODIC_TASK_X_RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
    }
}