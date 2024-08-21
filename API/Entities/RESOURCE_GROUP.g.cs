using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a resource_group entity with essential details
    /// </summary>
    [Table("RESOURCE_GROUP", Schema = "dbo")]
    public class RESOURCE_GROUP
    {
        /// <summary>
        /// Initializes a new instance of the RESOURCE_GROUP class.
        /// </summary>
        public RESOURCE_GROUP()
        {
            DOES_MAINTENANCE_TASKS = false;
            DOES_CLEANING_TASKS = false;
            IS_DEACTIVATED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field AVAILABLE_HOURS of the RESOURCE_GROUP 
        /// </summary>
        [Required]
        public double AVAILABLE_HOURS { get; set; }

        /// <summary>
        /// Required field USED_HOURS of the RESOURCE_GROUP 
        /// </summary>
        [Required]
        public double USED_HOURS { get; set; }

        /// <summary>
        /// Required field COST_PR_HOUR of the RESOURCE_GROUP 
        /// </summary>
        [Required]
        public double COST_PR_HOUR { get; set; }

        /// <summary>
        /// Required field RENT_COST_PR_HOUR of the RESOURCE_GROUP 
        /// </summary>
        [Required]
        public double RENT_COST_PR_HOUR { get; set; }

        /// <summary>
        /// Required field DOES_MAINTENANCE_TASKS of the RESOURCE_GROUP 
        /// </summary>
        [Required]
        public bool DOES_MAINTENANCE_TASKS { get; set; }

        /// <summary>
        /// Primary key for the RESOURCE_GROUP 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field DOES_CLEANING_TASKS of the RESOURCE_GROUP 
        /// </summary>
        [Required]
        public bool DOES_CLEANING_TASKS { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the RESOURCE_GROUP 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the RESOURCE_GROUP 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the RESOURCE_GROUP 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the RESOURCE_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the RESOURCE_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RESOURCE_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}