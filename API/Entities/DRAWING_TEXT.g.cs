using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a drawing_text entity with essential details
    /// </summary>
    [Table("DRAWING_TEXT", Schema = "dbo")]
    public class DRAWING_TEXT
    {
        /// <summary>
        /// Initializes a new instance of the DRAWING_TEXT class.
        /// </summary>
        public DRAWING_TEXT()
        {
            FONT_ANGLE = 0;
            FONT_SIZE = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DRAWING_TEXT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field POSITION_X of the DRAWING_TEXT 
        /// </summary>
        [Required]
        public double POSITION_X { get; set; }

        /// <summary>
        /// Required field POSITION_Y of the DRAWING_TEXT 
        /// </summary>
        [Required]
        public double POSITION_Y { get; set; }

        /// <summary>
        /// Required field FONT_ANGLE of the DRAWING_TEXT 
        /// </summary>
        [Required]
        public int FONT_ANGLE { get; set; }

        /// <summary>
        /// Required field FONT_SIZE of the DRAWING_TEXT 
        /// </summary>
        [Required]
        public int FONT_SIZE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DRAWING_TEXT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DRAWING_TEXT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DRAWING_TEXT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DRAWING_TEXT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// FONT_NAME of the DRAWING_TEXT 
        /// </summary>
        public string? FONT_NAME { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DRAWING_TEXT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DRAWING to which the DRAWING_TEXT belongs 
        /// </summary>
        public Guid? GUID_DRAWING { get; set; }

        /// <summary>
        /// Navigation property representing the associated DRAWING
        /// </summary>
        [ForeignKey("GUID_DRAWING")]
        public DRAWING? GUID_DRAWING_DRAWING { get; set; }
        /// <summary>
        /// TEXT of the DRAWING_TEXT 
        /// </summary>
        public string? TEXT { get; set; }
    }
}