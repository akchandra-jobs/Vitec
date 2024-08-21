using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_x_attribute entity with essential details
    /// </summary>
    [Table("ENTITY_X_ATTRIBUTE", Schema = "dbo")]
    public class ENTITY_X_ATTRIBUTE
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_X_ATTRIBUTE class.
        /// </summary>
        public ENTITY_X_ATTRIBUTE()
        {
            VALIDITY_RULE = 0;
            INDEX_POSITION = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field VALIDITY_RULE of the ENTITY_X_ATTRIBUTE 
        /// </summary>
        [Required]
        public int VALIDITY_RULE { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the ENTITY_X_ATTRIBUTE 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }

        /// <summary>
        /// Primary key for the ENTITY_X_ATTRIBUTE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENTITY_X_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_ATTRIBUTE to which the ENTITY_X_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_ENTITY_ATTRIBUTE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_ATTRIBUTE
        /// </summary>
        [ForeignKey("GUID_ENTITY_ATTRIBUTE")]
        public ENTITY_ATTRIBUTE? GUID_ENTITY_ATTRIBUTE_ENTITY_ATTRIBUTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_X_ATTRIBUTE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_X_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_X_ATTRIBUTE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_X_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_TASK to which the ENTITY_X_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_TASK
        /// </summary>
        [ForeignKey("GUID_CLEANING_TASK")]
        public CLEANING_TASK? GUID_CLEANING_TASK_CLEANING_TASK { get; set; }
    }
}