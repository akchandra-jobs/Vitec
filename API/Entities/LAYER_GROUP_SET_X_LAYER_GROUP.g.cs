using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a layer_group_set_x_layer_group entity with essential details
    /// </summary>
    [Table("LAYER_GROUP_SET_X_LAYER_GROUP", Schema = "dbo")]
    public class LAYER_GROUP_SET_X_LAYER_GROUP
    {
        /// <summary>
        /// Initializes a new instance of the LAYER_GROUP_SET_X_LAYER_GROUP class.
        /// </summary>
        public LAYER_GROUP_SET_X_LAYER_GROUP()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the LAYER_GROUP_SET_X_LAYER_GROUP 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the LAYER_GROUP_SET_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the LAYER_GROUP_SET to which the LAYER_GROUP_SET_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_LAYER_GROUP_SET { get; set; }

        /// <summary>
        /// Navigation property representing the associated LAYER_GROUP_SET
        /// </summary>
        [ForeignKey("GUID_LAYER_GROUP_SET")]
        public LAYER_GROUP_SET? GUID_LAYER_GROUP_SET_LAYER_GROUP_SET { get; set; }
        /// <summary>
        /// Foreign key referencing the LAYER_GROUP to which the LAYER_GROUP_SET_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_LAYER_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated LAYER_GROUP
        /// </summary>
        [ForeignKey("GUID_LAYER_GROUP")]
        public LAYER_GROUP? GUID_LAYER_GROUP_LAYER_GROUP { get; set; }
        /// <summary>
        /// DWG_LAYER_NAME of the LAYER_GROUP_SET_X_LAYER_GROUP 
        /// </summary>
        public string? DWG_LAYER_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LAYER_GROUP_SET_X_LAYER_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LAYER_GROUP_SET_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the LAYER_GROUP_SET_X_LAYER_GROUP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LAYER_GROUP_SET_X_LAYER_GROUP belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}