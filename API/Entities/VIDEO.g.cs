using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a video entity with essential details
    /// </summary>
    [Table("VIDEO", Schema = "dbo")]
    public class VIDEO
    {
        /// <summary>
        /// Initializes a new instance of the VIDEO class.
        /// </summary>
        public VIDEO()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the VIDEO 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the VIDEO belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the VIDEO_BINARY to which the VIDEO belongs 
        /// </summary>
        public Guid? GUID_VIDEO_BINARY { get; set; }

        /// <summary>
        /// Navigation property representing the associated VIDEO_BINARY
        /// </summary>
        [ForeignKey("GUID_VIDEO_BINARY")]
        public VIDEO_BINARY? GUID_VIDEO_BINARY_VIDEO_BINARY { get; set; }
        /// <summary>
        /// ID of the VIDEO 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the VIDEO 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// FILE_NAME of the VIDEO 
        /// </summary>
        public string? FILE_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the VIDEO 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the VIDEO belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the VIDEO 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the VIDEO belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}