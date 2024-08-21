using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a list_highlight entity with essential details
    /// </summary>
    [Table("LIST_HIGHLIGHT", Schema = "dbo")]
    public class LIST_HIGHLIGHT
    {
        /// <summary>
        /// Initializes a new instance of the LIST_HIGHLIGHT class.
        /// </summary>
        public LIST_HIGHLIGHT()
        {
            ENTITY_TYPE = -1;
            TEXT_COLOR = 0;
            BACKGROUND_COLOR = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the LIST_HIGHLIGHT 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field TEXT_COLOR of the LIST_HIGHLIGHT 
        /// </summary>
        [Required]
        public int TEXT_COLOR { get; set; }

        /// <summary>
        /// Required field BACKGROUND_COLOR of the LIST_HIGHLIGHT 
        /// </summary>
        [Required]
        public int BACKGROUND_COLOR { get; set; }

        /// <summary>
        /// Primary key for the LIST_HIGHLIGHT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the LIST_HIGHLIGHT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the LIST_HIGHLIGHT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// FIELD_PATH of the LIST_HIGHLIGHT 
        /// </summary>
        public string? FIELD_PATH { get; set; }
        /// <summary>
        /// BINARY_DATA of the LIST_HIGHLIGHT 
        /// </summary>
        public byte[]? BINARY_DATA { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LIST_HIGHLIGHT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LIST_HIGHLIGHT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the LIST_HIGHLIGHT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LIST_HIGHLIGHT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}