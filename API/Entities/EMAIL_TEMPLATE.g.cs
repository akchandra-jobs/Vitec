using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a email_template entity with essential details
    /// </summary>
    [Table("EMAIL_TEMPLATE", Schema = "dbo")]
    public class EMAIL_TEMPLATE
    {
        /// <summary>
        /// Initializes a new instance of the EMAIL_TEMPLATE class.
        /// </summary>
        public EMAIL_TEMPLATE()
        {
            ENTITY_TYPE = -1;
            IS_DEFAULT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the EMAIL_TEMPLATE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the EMAIL_TEMPLATE 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field IS_DEFAULT of the EMAIL_TEMPLATE 
        /// </summary>
        [Required]
        public bool IS_DEFAULT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the EMAIL_TEMPLATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EMAIL_TEMPLATE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the EMAIL_TEMPLATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EMAIL_TEMPLATE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TEMPLATE_BODY of the EMAIL_TEMPLATE 
        /// </summary>
        public string? TEMPLATE_BODY { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the EMAIL_TEMPLATE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the EMAIL_TEMPLATE 
        /// </summary>
        public string? ID { get; set; }
    }
}