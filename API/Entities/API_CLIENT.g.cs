using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a api_client entity with essential details
    /// </summary>
    [Table("API_CLIENT", Schema = "dbo")]
    public class API_CLIENT
    {
        /// <summary>
        /// Initializes a new instance of the API_CLIENT class.
        /// </summary>
        public API_CLIENT()
        {
            IS_DEACTIVATED = false;
            REFRESH_TOKEN_LIFETIME = 6000;
            ACCESS_TOKEN_LIFETIME = 65;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the API_CLIENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the API_CLIENT 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field REFRESH_TOKEN_LIFETIME of the API_CLIENT 
        /// </summary>
        [Required]
        public int REFRESH_TOKEN_LIFETIME { get; set; }

        /// <summary>
        /// Required field ACCESS_TOKEN_LIFETIME of the API_CLIENT 
        /// </summary>
        [Required]
        public int ACCESS_TOKEN_LIFETIME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the API_CLIENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the API_CLIENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the API_CLIENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the API_CLIENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// ID of the API_CLIENT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// SECRET of the API_CLIENT 
        /// </summary>
        public string? SECRET { get; set; }
        /// <summary>
        /// DESCRIPTION of the API_CLIENT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}