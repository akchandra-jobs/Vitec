using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a equipment_operating_hours entity with essential details
    /// </summary>
    [Table("EQUIPMENT_OPERATING_HOURS", Schema = "dbo")]
    public class EQUIPMENT_OPERATING_HOURS
    {
        /// <summary>
        /// Initializes a new instance of the EQUIPMENT_OPERATING_HOURS class.
        /// </summary>
        public EQUIPMENT_OPERATING_HOURS()
        {
            VALUE_INT = 0;
            VALUE_BOOL = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field COUNTER of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Required]
        public double COUNTER { get; set; }

        /// <summary>
        /// Required field VALUE of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Required]
        public double VALUE { get; set; }

        /// <summary>
        /// Primary key for the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field VALUE_INT of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Required]
        public int VALUE_INT { get; set; }

        /// <summary>
        /// Required field VALUE_BOOL of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Required]
        public bool VALUE_BOOL { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }

        /// <summary>
        /// VALUE_DATE of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VALUE_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the EQUIPMENT_OPERATING_HOURS belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the EQUIPMENT_OPERATING_HOURS belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }

        /// <summary>
        /// READ_DATE of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? READ_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EQUIPMENT_OPERATING_HOURS belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EQUIPMENT_OPERATING_HOURS belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT_OPERATING_HOUR_TYPE to which the EQUIPMENT_OPERATING_HOURS belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT_OPERATING_HOUR_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT_OPERATING_HOUR_TYPE
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT_OPERATING_HOUR_TYPE")]
        public EQUIPMENT_OPERATING_HOUR_TYPE? GUID_EQUIPMENT_OPERATING_HOUR_TYPE_EQUIPMENT_OPERATING_HOUR_TYPE { get; set; }
        /// <summary>
        /// VALUE_STRING of the EQUIPMENT_OPERATING_HOURS 
        /// </summary>
        public string? VALUE_STRING { get; set; }
    }
}