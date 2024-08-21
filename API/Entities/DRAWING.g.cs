using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a drawing entity with essential details
    /// </summary>
    [Table("DRAWING", Schema = "dbo")]
    public class DRAWING
    {
        /// <summary>
        /// Initializes a new instance of the DRAWING class.
        /// </summary>
        public DRAWING()
        {
            FONT_SIZE = 0;
            FONT_ANGLE = 0;
            SCALING_FACTOR = 0;
            LEGEND_FONT_SIZE = 0;
            IS_DEACTIVATED = false;
            DWG_CRC = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DRAWING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field FONT_SIZE of the DRAWING 
        /// </summary>
        [Required]
        public int FONT_SIZE { get; set; }

        /// <summary>
        /// Required field FONT_ANGLE of the DRAWING 
        /// </summary>
        [Required]
        public int FONT_ANGLE { get; set; }

        /// <summary>
        /// Required field REGISTERED_NET_AREA of the DRAWING 
        /// </summary>
        [Required]
        public double REGISTERED_NET_AREA { get; set; }

        /// <summary>
        /// Required field REGISTERED_GROSS_AREA of the DRAWING 
        /// </summary>
        [Required]
        public double REGISTERED_GROSS_AREA { get; set; }

        /// <summary>
        /// Required field COMPUTED_NET_AREA of the DRAWING 
        /// </summary>
        [Required]
        public double COMPUTED_NET_AREA { get; set; }

        /// <summary>
        /// Required field COMPUTED_GROSS_AREA of the DRAWING 
        /// </summary>
        [Required]
        public double COMPUTED_GROSS_AREA { get; set; }

        /// <summary>
        /// Required field COMMON_AREA of the DRAWING 
        /// </summary>
        [Required]
        public double COMMON_AREA { get; set; }

        /// <summary>
        /// Required field NON_COMMON_AREA of the DRAWING 
        /// </summary>
        [Required]
        public double NON_COMMON_AREA { get; set; }

        /// <summary>
        /// Required field COMMON_AREA_FACTOR of the DRAWING 
        /// </summary>
        [Required]
        public double COMMON_AREA_FACTOR { get; set; }

        /// <summary>
        /// Required field SCALING_FACTOR of the DRAWING 
        /// </summary>
        [Required]
        public int SCALING_FACTOR { get; set; }

        /// <summary>
        /// Required field LEGEND_FONT_SIZE of the DRAWING 
        /// </summary>
        [Required]
        public int LEGEND_FONT_SIZE { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the DRAWING 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field DWG_CRC of the DRAWING 
        /// </summary>
        [Required]
        public int DWG_CRC { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DRAWING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DRAWING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DRAWING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DRAWING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// DWG_DATA of the DRAWING 
        /// </summary>
        public byte[]? DWG_DATA { get; set; }
        /// <summary>
        /// BINARY_DATA of the DRAWING 
        /// </summary>
        public byte[]? BINARY_DATA { get; set; }
        /// <summary>
        /// FONT_NAME of the DRAWING 
        /// </summary>
        public string? FONT_NAME { get; set; }

        /// <summary>
        /// CAF_COMPUTATION_DATE of the DRAWING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CAF_COMPUTATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DRAWING belongs 
        /// </summary>
        public Guid? GUID_USER_CAF_COMPUTED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CAF_COMPUTED_BY")]
        public USR? GUID_USER_CAF_COMPUTED_BY_USR { get; set; }
        /// <summary>
        /// LEGEND_FONT_NAME of the DRAWING 
        /// </summary>
        public string? LEGEND_FONT_NAME { get; set; }
        /// <summary>
        /// FILE_PATH of the DRAWING 
        /// </summary>
        public string? FILE_PATH { get; set; }
        /// <summary>
        /// TYPE of the DRAWING 
        /// </summary>
        public string? TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DRAWING belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the DRAWING belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the LAYER_GROUP_SET to which the DRAWING belongs 
        /// </summary>
        public Guid? GUID_LAYER_GROUP_SET { get; set; }

        /// <summary>
        /// Navigation property representing the associated LAYER_GROUP_SET
        /// </summary>
        [ForeignKey("GUID_LAYER_GROUP_SET")]
        public LAYER_GROUP_SET? GUID_LAYER_GROUP_SET_LAYER_GROUP_SET { get; set; }
        /// <summary>
        /// GUID_IFC of the DRAWING 
        /// </summary>
        public string? GUID_IFC { get; set; }
        /// <summary>
        /// ID of the DRAWING 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DRAWING 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}