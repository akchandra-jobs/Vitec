using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_user_token entity with essential details
    /// </summary>
    [Table("WEB_USER_TOKEN", Schema = "dbo")]
    public class WEB_USER_TOKEN
    {
        /// <summary>
        /// Initializes a new instance of the WEB_USER_TOKEN class.
        /// </summary>
        public WEB_USER_TOKEN()
        {
            LOGOUT_REASON = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the WEB_USER_TOKEN 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field LOGOUT_REASON of the WEB_USER_TOKEN 
        /// </summary>
        [Required]
        public int LOGOUT_REASON { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_USER_TOKEN belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the API_CLIENT to which the WEB_USER_TOKEN belongs 
        /// </summary>
        public Guid? GUID_API_CLIENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated API_CLIENT
        /// </summary>
        [ForeignKey("GUID_API_CLIENT")]
        public API_CLIENT? GUID_API_CLIENT_API_CLIENT { get; set; }
        /// <summary>
        /// ACCESS_TOKEN of the WEB_USER_TOKEN 
        /// </summary>
        public Guid? ACCESS_TOKEN { get; set; }
        /// <summary>
        /// REFRESH_TOKEN of the WEB_USER_TOKEN 
        /// </summary>
        public Guid? REFRESH_TOKEN { get; set; }
        /// <summary>
        /// TICKET of the WEB_USER_TOKEN 
        /// </summary>
        public string? TICKET { get; set; }

        /// <summary>
        /// ACCESS_TOKEN_EXPIRATION_DATE of the WEB_USER_TOKEN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ACCESS_TOKEN_EXPIRATION_DATE { get; set; }

        /// <summary>
        /// REFRESH_TOKEN_EXPIRATION_DATE of the WEB_USER_TOKEN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REFRESH_TOKEN_EXPIRATION_DATE { get; set; }
        /// <summary>
        /// FINGERPRINT of the WEB_USER_TOKEN 
        /// </summary>
        public string? FINGERPRINT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_USER_TOKEN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_USER_TOKEN belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_USER_TOKEN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_USER_TOKEN belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}