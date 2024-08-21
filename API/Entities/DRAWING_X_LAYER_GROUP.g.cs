using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a drawing_x_layer_group entity with essential details
    /// </summary>
    [Table("DRAWING_X_LAYER_GROUP", Schema = "dbo")]
    public class DRAWING_X_LAYER_GROUP
    {
        /// <summary>
        /// Initializes a new instance of the DRAWING_X_LAYER_GROUP class.
        /// </summary>
        public DRAWING_X_LAYER_GROUP()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DRAWING_X_LAYER_GROUP 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DRAWING_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the LAYER_GROUP to which the DRAWING_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_LAYER_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated LAYER_GROUP
        /// </summary>
        [ForeignKey("GUID_LAYER_GROUP")]
        public LAYER_GROUP? GUID_LAYER_GROUP_LAYER_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the DRAWING to which the DRAWING_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_DRAWING { get; set; }

        /// <summary>
        /// Navigation property representing the associated DRAWING
        /// </summary>
        [ForeignKey("GUID_DRAWING")]
        public DRAWING? GUID_DRAWING_DRAWING { get; set; }
        /// <summary>
        /// DWG_LAYER_NAME of the DRAWING_X_LAYER_GROUP 
        /// </summary>
        public string? DWG_LAYER_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DRAWING_X_LAYER_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DRAWING_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DRAWING_X_LAYER_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DRAWING_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}