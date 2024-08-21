using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a resource_group_x_cause entity with essential details
    /// </summary>
    [Table("RESOURCE_GROUP_X_CAUSE", Schema = "dbo")]
    public class RESOURCE_GROUP_X_CAUSE
    {
        /// <summary>
        /// Initializes a new instance of the RESOURCE_GROUP_X_CAUSE class.
        /// </summary>
        public RESOURCE_GROUP_X_CAUSE()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the RESOURCE_GROUP_X_CAUSE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the RESOURCE_GROUP_X_CAUSE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the RESOURCE_GROUP_X_CAUSE belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the CAUSE to which the RESOURCE_GROUP_X_CAUSE belongs 
        /// </summary>
        public Guid? GUID_CAUSE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CAUSE
        /// </summary>
        [ForeignKey("GUID_CAUSE")]
        public CAUSE? GUID_CAUSE_CAUSE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the RESOURCE_GROUP_X_CAUSE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RESOURCE_GROUP_X_CAUSE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the RESOURCE_GROUP_X_CAUSE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RESOURCE_GROUP_X_CAUSE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}