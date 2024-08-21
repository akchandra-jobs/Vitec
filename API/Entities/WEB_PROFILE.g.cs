using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_profile entity with essential details
    /// </summary>
    [Table("WEB_PROFILE", Schema = "dbo")]
    public class WEB_PROFILE
    {
        /// <summary>
        /// Initializes a new instance of the WEB_PROFILE class.
        /// </summary>
        public WEB_PROFILE()
        {
            IS_READ_ONLY = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field IS_READ_ONLY of the WEB_PROFILE 
        /// </summary>
        [Required]
        public bool IS_READ_ONLY { get; set; }

        /// <summary>
        /// Primary key for the WEB_PROFILE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// ID of the WEB_PROFILE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the WEB_PROFILE 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// ICON of the WEB_PROFILE 
        /// </summary>
        public string? ICON { get; set; }
    }
}