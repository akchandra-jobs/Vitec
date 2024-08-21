using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a image entity with essential details
    /// </summary>
    [Table("IMAGE", Schema = "dbo")]
    public class IMAGE
    {
        /// <summary>
        /// Initializes a new instance of the IMAGE class.
        /// </summary>
        public IMAGE()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the IMAGE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the IMAGE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the IMAGE_BINARY to which the IMAGE belongs 
        /// </summary>
        public Guid? GUID_IMAGE_BINARY { get; set; }

        /// <summary>
        /// Navigation property representing the associated IMAGE_BINARY
        /// </summary>
        [ForeignKey("GUID_IMAGE_BINARY")]
        public IMAGE_BINARY? GUID_IMAGE_BINARY_IMAGE_BINARY { get; set; }
        /// <summary>
        /// ID of the IMAGE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the IMAGE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// FILE_NAME of the IMAGE 
        /// </summary>
        public string? FILE_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the IMAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the IMAGE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the IMAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the IMAGE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the IMAGE_BINARY to which the IMAGE belongs 
        /// </summary>
        public Guid? GUID_ORIGINAL_IMAGE_BINARY { get; set; }

        /// <summary>
        /// Navigation property representing the associated IMAGE_BINARY
        /// </summary>
        [ForeignKey("GUID_ORIGINAL_IMAGE_BINARY")]
        public IMAGE_BINARY? GUID_ORIGINAL_IMAGE_BINARY_IMAGE_BINARY { get; set; }
    }
}