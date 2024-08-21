using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_permission_profile entity with essential details
    /// </summary>
    [Table("ENTITY_PERMISSION_PROFILE", Schema = "dbo")]
    public class ENTITY_PERMISSION_PROFILE
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_PERMISSION_PROFILE class.
        /// </summary>
        public ENTITY_PERMISSION_PROFILE()
        {
            TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENTITY_PERMISSION_PROFILE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field TYPE of the ENTITY_PERMISSION_PROFILE 
        /// </summary>
        [Required]
        public int TYPE { get; set; }
        /// <summary>
        /// ID of the ENTITY_PERMISSION_PROFILE 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_PERMISSION_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENTITY_PERMISSION_PROFILE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_PERMISSION_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_PERMISSION_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_PERMISSION_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}