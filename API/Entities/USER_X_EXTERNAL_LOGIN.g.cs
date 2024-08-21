using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user_x_external_login entity with essential details
    /// </summary>
    [Table("USER_X_EXTERNAL_LOGIN", Schema = "dbo")]
    public class USER_X_EXTERNAL_LOGIN
    {
        /// <summary>
        /// Initializes a new instance of the USER_X_EXTERNAL_LOGIN class.
        /// </summary>
        public USER_X_EXTERNAL_LOGIN()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USER_X_EXTERNAL_LOGIN 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_EXTERNAL_LOGIN belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the EXTERNAL_LOGIN_PROVIDER to which the USER_X_EXTERNAL_LOGIN belongs 
        /// </summary>
        public Guid? GUID_EXTERNAL_LOGIN_PROVIDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated EXTERNAL_LOGIN_PROVIDER
        /// </summary>
        [ForeignKey("GUID_EXTERNAL_LOGIN_PROVIDER")]
        public EXTERNAL_LOGIN_PROVIDER? GUID_EXTERNAL_LOGIN_PROVIDER_EXTERNAL_LOGIN_PROVIDER { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the USER_X_EXTERNAL_LOGIN 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USER_X_EXTERNAL_LOGIN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_EXTERNAL_LOGIN belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USER_X_EXTERNAL_LOGIN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_EXTERNAL_LOGIN belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}