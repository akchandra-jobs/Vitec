using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a language_field_entry entity with essential details
    /// </summary>
    [Table("LANGUAGE_FIELD_ENTRY", Schema = "dbo")]
    public class LANGUAGE_FIELD_ENTRY
    {
        /// <summary>
        /// Initializes a new instance of the LANGUAGE_FIELD_ENTRY class.
        /// </summary>
        public LANGUAGE_FIELD_ENTRY()
        {
            LANGUAGE_ID = 0;
            IS_TO_DELETE = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field LANGUAGE_ID of the LANGUAGE_FIELD_ENTRY 
        /// </summary>
        [Required]
        public int LANGUAGE_ID { get; set; }

        /// <summary>
        /// Required field IS_TO_DELETE of the LANGUAGE_FIELD_ENTRY 
        /// </summary>
        [Required]
        public bool IS_TO_DELETE { get; set; }

        /// <summary>
        /// Primary key for the LANGUAGE_FIELD_ENTRY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// TABLE_NAME of the LANGUAGE_FIELD_ENTRY 
        /// </summary>
        public string? TABLE_NAME { get; set; }
        /// <summary>
        /// FIELD_NAME of the LANGUAGE_FIELD_ENTRY 
        /// </summary>
        public string? FIELD_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LANGUAGE_FIELD_ENTRY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE_FIELD_ENTRY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the LANGUAGE_FIELD_ENTRY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE_FIELD_ENTRY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}