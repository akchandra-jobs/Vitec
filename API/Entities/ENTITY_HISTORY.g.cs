using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_history entity with essential details
    /// </summary>
    [Table("ENTITY_HISTORY", Schema = "dbo")]
    public class ENTITY_HISTORY
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_HISTORY class.
        /// </summary>
        public ENTITY_HISTORY()
        {
            ENTITY_TYPE = -1;
            VALUE_INT = 0;
            VALUE_INT64 = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the ENTITY_HISTORY 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field VALUE_INT of the ENTITY_HISTORY 
        /// </summary>
        [Required]
        public int VALUE_INT { get; set; }

        /// <summary>
        /// Required field VALUE_DOUBLE of the ENTITY_HISTORY 
        /// </summary>
        [Required]
        public double VALUE_DOUBLE { get; set; }

        /// <summary>
        /// Primary key for the ENTITY_HISTORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field VALUE_INT64 of the ENTITY_HISTORY 
        /// </summary>
        [Required]
        public Int64 VALUE_INT64 { get; set; }
        /// <summary>
        /// PREVIOUS_VALUE_GUID of the ENTITY_HISTORY 
        /// </summary>
        public Guid? PREVIOUS_VALUE_GUID { get; set; }
        /// <summary>
        /// GUID_ENTITY of the ENTITY_HISTORY 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_HISTORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_HISTORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// VALUE_GUID of the ENTITY_HISTORY 
        /// </summary>
        public Guid? VALUE_GUID { get; set; }
        /// <summary>
        /// FIELD_NAME of the ENTITY_HISTORY 
        /// </summary>
        public string? FIELD_NAME { get; set; }
        /// <summary>
        /// ENTITY_CAPTION of the ENTITY_HISTORY 
        /// </summary>
        public string? ENTITY_CAPTION { get; set; }
        /// <summary>
        /// PREVIOUS_VALUE of the ENTITY_HISTORY 
        /// </summary>
        public string? PREVIOUS_VALUE { get; set; }
        /// <summary>
        /// VALUE of the ENTITY_HISTORY 
        /// </summary>
        public string? VALUE { get; set; }
        /// <summary>
        /// VALUE_STRING of the ENTITY_HISTORY 
        /// </summary>
        public string? VALUE_STRING { get; set; }

        /// <summary>
        /// VALUE_DATE of the ENTITY_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VALUE_DATE { get; set; }
    }
}