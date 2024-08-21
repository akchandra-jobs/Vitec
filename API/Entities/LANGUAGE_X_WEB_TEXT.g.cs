using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a language_x_web_text entity with essential details
    /// </summary>
    [Table("LANGUAGE_X_WEB_TEXT", Schema = "dbo")]
    public class LANGUAGE_X_WEB_TEXT
    {
        /// <summary>
        /// Initializes a new instance of the LANGUAGE_X_WEB_TEXT class.
        /// </summary>
        public LANGUAGE_X_WEB_TEXT()
        {
            CREATION_DATE = DateTime.UtcNow;
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the LANGUAGE_X_WEB_TEXT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the LANGUAGE to which the LANGUAGE_X_WEB_TEXT belongs 
        /// </summary>
        public Guid? GUID_LANGUAGE { get; set; }

        /// <summary>
        /// Navigation property representing the associated LANGUAGE
        /// </summary>
        [ForeignKey("GUID_LANGUAGE")]
        public LANGUAGE? GUID_LANGUAGE_LANGUAGE { get; set; }
        /// <summary>
        /// Foreign key referencing the WEB_TEXT to which the LANGUAGE_X_WEB_TEXT belongs 
        /// </summary>
        public Guid? GUID_WEB_TEXT { get; set; }

        /// <summary>
        /// Navigation property representing the associated WEB_TEXT
        /// </summary>
        [ForeignKey("GUID_WEB_TEXT")]
        public WEB_TEXT? GUID_WEB_TEXT_WEB_TEXT { get; set; }
        /// <summary>
        /// TRANSLATED_VALUE of the LANGUAGE_X_WEB_TEXT 
        /// </summary>
        public string? TRANSLATED_VALUE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE_X_WEB_TEXT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the LANGUAGE_X_WEB_TEXT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE_X_WEB_TEXT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LANGUAGE_X_WEB_TEXT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// DEFAULT_TRANSLATED_VALUE of the LANGUAGE_X_WEB_TEXT 
        /// </summary>
        public string? DEFAULT_TRANSLATED_VALUE { get; set; }
        /// <summary>
        /// TRANSLATED_HELPTEXT of the LANGUAGE_X_WEB_TEXT 
        /// </summary>
        public string? TRANSLATED_HELPTEXT { get; set; }
        /// <summary>
        /// DEFAULT_TRANSLATED_HELPTEXT of the LANGUAGE_X_WEB_TEXT 
        /// </summary>
        public string? DEFAULT_TRANSLATED_HELPTEXT { get; set; }
    }
}