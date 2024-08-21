using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a external_login_provider entity with essential details
    /// </summary>
    [Table("EXTERNAL_LOGIN_PROVIDER", Schema = "dbo")]
    public class EXTERNAL_LOGIN_PROVIDER
    {
        /// <summary>
        /// Initializes a new instance of the EXTERNAL_LOGIN_PROVIDER class.
        /// </summary>
        public EXTERNAL_LOGIN_PROVIDER()
        {
            IS_ACTIVE = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field IS_ACTIVE of the EXTERNAL_LOGIN_PROVIDER 
        /// </summary>
        [Required]
        public bool IS_ACTIVE { get; set; }

        /// <summary>
        /// Primary key for the EXTERNAL_LOGIN_PROVIDER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// NAME of the EXTERNAL_LOGIN_PROVIDER 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// CONFIG of the EXTERNAL_LOGIN_PROVIDER 
        /// </summary>
        public string? CONFIG { get; set; }
        /// <summary>
        /// CLAIMS_MAPPING of the EXTERNAL_LOGIN_PROVIDER 
        /// </summary>
        public string? CLAIMS_MAPPING { get; set; }

        /// <summary>
        /// UPDATED_DATE of the EXTERNAL_LOGIN_PROVIDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EXTERNAL_LOGIN_PROVIDER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the EXTERNAL_LOGIN_PROVIDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EXTERNAL_LOGIN_PROVIDER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}