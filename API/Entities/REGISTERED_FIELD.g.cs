using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a registered_field entity with essential details
    /// </summary>
    [Table("REGISTERED_FIELD", Schema = "dbo")]
    public class REGISTERED_FIELD
    {
        /// <summary>
        /// Initializes a new instance of the REGISTERED_FIELD class.
        /// </summary>
        public REGISTERED_FIELD()
        {
            ENTITY_TYPE = -1;
            VALIDITY_RULES = 0;
            OVERRIDDEN_VALIDITY_RULES = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the REGISTERED_FIELD 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field VALIDITY_RULES of the REGISTERED_FIELD 
        /// </summary>
        [Required]
        public int VALIDITY_RULES { get; set; }

        /// <summary>
        /// Required field OVERRIDDEN_VALIDITY_RULES of the REGISTERED_FIELD 
        /// </summary>
        [Required]
        public int OVERRIDDEN_VALIDITY_RULES { get; set; }

        /// <summary>
        /// Primary key for the REGISTERED_FIELD 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// FIELD_NAME of the REGISTERED_FIELD 
        /// </summary>
        public string? FIELD_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the REGISTERED_FIELD 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REGISTERED_FIELD belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the REGISTERED_FIELD 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REGISTERED_FIELD belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}