using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a area_x_cleaning_task_attribute_value entity with essential details
    /// </summary>
    [Table("AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE", Schema = "dbo")]
    public class AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE
    {
        /// <summary>
        /// Initializes a new instance of the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE class.
        /// </summary>
        public AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE()
        {
            BIT_VALUE = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field BIT_VALUE of the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE 
        /// </summary>
        [Required]
        public bool BIT_VALUE { get; set; }

        /// <summary>
        /// Required field NUMERIC_VALUE of the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE 
        /// </summary>
        [Required]
        public double NUMERIC_VALUE { get; set; }

        /// <summary>
        /// DATE_VALUE of the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE_VALUE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_X_ATTRIBUTE to which the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE belongs 
        /// </summary>
        public Guid? GUID_ENTITY_X_ATTRIBUTE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_X_ATTRIBUTE
        /// </summary>
        [ForeignKey("GUID_ENTITY_X_ATTRIBUTE")]
        public ENTITY_X_ATTRIBUTE? GUID_ENTITY_X_ATTRIBUTE_ENTITY_X_ATTRIBUTE { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_X_CLEANING_TASK to which the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE belongs 
        /// </summary>
        public Guid? GUID_AREA_X_CLEANING_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_X_CLEANING_TASK
        /// </summary>
        [ForeignKey("GUID_AREA_X_CLEANING_TASK")]
        public AREA_X_CLEANING_TASK? GUID_AREA_X_CLEANING_TASK_AREA_X_CLEANING_TASK { get; set; }
        /// <summary>
        /// TEXT_VALUE of the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE 
        /// </summary>
        public string? TEXT_VALUE { get; set; }
    }
}