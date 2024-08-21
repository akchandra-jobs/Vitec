using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a video_x_entity entity with essential details
    /// </summary>
    [Table("VIDEO_X_ENTITY", Schema = "dbo")]
    public class VIDEO_X_ENTITY
    {
        /// <summary>
        /// Initializes a new instance of the VIDEO_X_ENTITY class.
        /// </summary>
        public VIDEO_X_ENTITY()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the VIDEO_X_ENTITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the VIDEO_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the VIDEO to which the VIDEO_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_VIDEO { get; set; }

        /// <summary>
        /// Navigation property representing the associated VIDEO
        /// </summary>
        [ForeignKey("GUID_VIDEO")]
        public VIDEO? GUID_VIDEO_VIDEO { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_TASK to which the VIDEO_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_TASK
        /// </summary>
        [ForeignKey("GUID_CLEANING_TASK")]
        public CLEANING_TASK? GUID_CLEANING_TASK_CLEANING_TASK { get; set; }

        /// <summary>
        /// UPDATED_DATE of the VIDEO_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the VIDEO_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the VIDEO_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the VIDEO_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}