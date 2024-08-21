using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning_quality_control entity with essential details
    /// </summary>
    [Table("CLEANING_QUALITY_CONTROL", Schema = "dbo")]
    public class CLEANING_QUALITY_CONTROL
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING_QUALITY_CONTROL class.
        /// </summary>
        public CLEANING_QUALITY_CONTROL()
        {
            NUMBER_OF_MINUTES_SINCE_CLEANING = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CLEANING_QUALITY_CONTROL 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field NUMBER_OF_MINUTES_SINCE_CLEANING of the CLEANING_QUALITY_CONTROL 
        /// </summary>
        [Required]
        public int NUMBER_OF_MINUTES_SINCE_CLEANING { get; set; }

        /// <summary>
        /// Required field QUALITY_LEVEL of the CLEANING_QUALITY_CONTROL 
        /// </summary>
        [Required]
        public double QUALITY_LEVEL { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CLEANING_QUALITY_CONTROL 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING_QUALITY_CONTROL 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_QUALITY_CONTROL belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING_QUALITY_CONTROL 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_QUALITY_CONTROL belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CLEANING_QUALITY_CONTROL belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DRAWING to which the CLEANING_QUALITY_CONTROL belongs 
        /// </summary>
        public Guid? GUID_DRAWING { get; set; }

        /// <summary>
        /// Navigation property representing the associated DRAWING
        /// </summary>
        [ForeignKey("GUID_DRAWING")]
        public DRAWING? GUID_DRAWING_DRAWING { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the CLEANING_QUALITY_CONTROL belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// ID of the CLEANING_QUALITY_CONTROL 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the CLEANING_QUALITY_CONTROL 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}