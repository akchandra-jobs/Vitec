using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_text entity with essential details
    /// </summary>
    [Table("WEB_TEXT", Schema = "dbo")]
    public class WEB_TEXT
    {
        /// <summary>
        /// Initializes a new instance of the WEB_TEXT class.
        /// </summary>
        public WEB_TEXT()
        {
            CREATION_DATE = DateTime.UtcNow;
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the WEB_TEXT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// SYSTEM_NAME of the WEB_TEXT 
        /// </summary>
        public string? SYSTEM_NAME { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_TEXT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_TEXT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_TEXT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_TEXT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// DESCRIPTION of the WEB_TEXT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}