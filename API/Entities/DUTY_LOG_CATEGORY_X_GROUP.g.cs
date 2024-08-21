using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a duty_log_category_x_group entity with essential details
    /// </summary>
    [Table("DUTY_LOG_CATEGORY_X_GROUP", Schema = "dbo")]
    public class DUTY_LOG_CATEGORY_X_GROUP
    {
        /// <summary>
        /// Initializes a new instance of the DUTY_LOG_CATEGORY_X_GROUP class.
        /// </summary>
        public DUTY_LOG_CATEGORY_X_GROUP()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DUTY_LOG_CATEGORY_X_GROUP 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DUTY_LOG_CATEGORY_X_GROUP belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DUTY_LOG_CATEGORY to which the DUTY_LOG_CATEGORY_X_GROUP belongs 
        /// </summary>
        public Guid? GUID_DUTY_LOG_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DUTY_LOG_CATEGORY
        /// </summary>
        [ForeignKey("GUID_DUTY_LOG_CATEGORY")]
        public DUTY_LOG_CATEGORY? GUID_DUTY_LOG_CATEGORY_DUTY_LOG_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the DUTY_LOG_GROUP to which the DUTY_LOG_CATEGORY_X_GROUP belongs 
        /// </summary>
        public Guid? GUID_DUTY_LOG_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated DUTY_LOG_GROUP
        /// </summary>
        [ForeignKey("GUID_DUTY_LOG_GROUP")]
        public DUTY_LOG_GROUP? GUID_DUTY_LOG_GROUP_DUTY_LOG_GROUP { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DUTY_LOG_CATEGORY_X_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DUTY_LOG_CATEGORY_X_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DUTY_LOG_CATEGORY_X_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DUTY_LOG_CATEGORY_X_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}