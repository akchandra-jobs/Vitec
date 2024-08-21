using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning_quality_control_x_area entity with essential details
    /// </summary>
    [Table("CLEANING_QUALITY_CONTROL_X_AREA", Schema = "dbo")]
    public class CLEANING_QUALITY_CONTROL_X_AREA
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING_QUALITY_CONTROL_X_AREA class.
        /// </summary>
        public CLEANING_QUALITY_CONTROL_X_AREA()
        {
            STATUS = 0;
            INVENTORY_WASTE_LT = 0;
            INVENTORY_WASTE_VT = 0;
            INVENTORY_DUST_LT = 0;
            INVENTORY_DUST_VT = 0;
            INVENTORY_STAIN_LT = 0;
            INVENTORY_STAIN_VT = 0;
            INVENTORY_SURFACE_LT = 0;
            INVENTORY_SURFACE_VT = 0;
            WALLS_WASTE_LT = 0;
            WALLS_WASTE_VT = 0;
            WALLS_DUST_LT = 0;
            WALLS_DUST_VT = 0;
            WALLS_STAIN_LT = 0;
            WALLS_STAIN_VT = 0;
            WALLS_SURFACE_LT = 0;
            WALLS_SURFACE_VT = 0;
            FLOOR_WASTE_LT = 0;
            FLOOR_WASTE_VT = 0;
            FLOOR_DUST_LT = 0;
            FLOOR_DUST_VT = 0;
            FLOOR_STAIN_LT = 0;
            FLOOR_STAIN_VT = 0;
            FLOOR_SURFACE_LT = 0;
            FLOOR_SURFACE_VT = 0;
            CEILING_WASTE_LT = 0;
            CEILING_WASTE_VT = 0;
            CEILING_DUST_LT = 0;
            CEILING_DUST_VT = 0;
            CEILING_STAIN_LT = 0;
            CEILING_STAIN_VT = 0;
            CEILING_SURFACE_LT = 0;
            CEILING_SURFACE_VT = 0;
            CLEANING_QUALITY_INVENTORY_WASTE_LT = 0;
            CLEANING_QUALITY_INVENTORY_WASTE_VT = 0;
            CLEANING_QUALITY_INVENTORY_SURFACE_LT = 0;
            CLEANING_QUALITY_INVENTORY_SURFACE_VT = 0;
            CLEANING_QUALITY_WALLS_WASTE_LT = 0;
            CLEANING_QUALITY_WALLS_WASTE_VT = 0;
            CLEANING_QUALITY_WALLS_SURFACE_LT = 0;
            CLEANING_QUALITY_WALLS_SURFACE_VT = 0;
            CLEANING_QUALITY_FLOOR_WASTE_LT = 0;
            CLEANING_QUALITY_FLOOR_WASTE_VT = 0;
            CLEANING_QUALITY_FLOOR_SURFACE_LT = 0;
            CLEANING_QUALITY_FLOOR_SURFACE_VT = 0;
            CLEANING_QUALITY_CEILING_WASTE_LT = 0;
            CLEANING_QUALITY_CEILING_WASTE_VT = 0;
            CLEANING_QUALITY_CEILING_SURFACE_LT = 0;
            CLEANING_QUALITY_CEILING_SURFACE_VT = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field STATUS of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field INVENTORY_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_WASTE_LT { get; set; }

        /// <summary>
        /// Required field INVENTORY_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_WASTE_VT { get; set; }

        /// <summary>
        /// Required field INVENTORY_DUST_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_DUST_LT { get; set; }

        /// <summary>
        /// Required field INVENTORY_DUST_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_DUST_VT { get; set; }

        /// <summary>
        /// Required field INVENTORY_STAIN_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_STAIN_LT { get; set; }

        /// <summary>
        /// Required field INVENTORY_STAIN_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_STAIN_VT { get; set; }

        /// <summary>
        /// Required field INVENTORY_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field INVENTORY_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_SURFACE_VT { get; set; }

        /// <summary>
        /// Required field WALLS_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_WASTE_LT { get; set; }

        /// <summary>
        /// Required field WALLS_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_WASTE_VT { get; set; }

        /// <summary>
        /// Required field WALLS_DUST_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_DUST_LT { get; set; }

        /// <summary>
        /// Required field WALLS_DUST_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_DUST_VT { get; set; }

        /// <summary>
        /// Required field WALLS_STAIN_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_STAIN_LT { get; set; }

        /// <summary>
        /// Required field WALLS_STAIN_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_STAIN_VT { get; set; }

        /// <summary>
        /// Required field WALLS_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field WALLS_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_SURFACE_VT { get; set; }

        /// <summary>
        /// Required field FLOOR_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_WASTE_LT { get; set; }

        /// <summary>
        /// Required field FLOOR_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_WASTE_VT { get; set; }

        /// <summary>
        /// Required field FLOOR_DUST_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_DUST_LT { get; set; }

        /// <summary>
        /// Required field FLOOR_DUST_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_DUST_VT { get; set; }

        /// <summary>
        /// Required field FLOOR_STAIN_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_STAIN_LT { get; set; }

        /// <summary>
        /// Required field FLOOR_STAIN_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_STAIN_VT { get; set; }

        /// <summary>
        /// Required field FLOOR_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field FLOOR_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_SURFACE_VT { get; set; }

        /// <summary>
        /// Required field CEILING_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_WASTE_LT { get; set; }

        /// <summary>
        /// Required field CEILING_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_WASTE_VT { get; set; }

        /// <summary>
        /// Required field CEILING_DUST_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_DUST_LT { get; set; }

        /// <summary>
        /// Required field CEILING_DUST_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_DUST_VT { get; set; }

        /// <summary>
        /// Required field CEILING_STAIN_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_STAIN_LT { get; set; }

        /// <summary>
        /// Required field CEILING_STAIN_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_STAIN_VT { get; set; }

        /// <summary>
        /// Required field CEILING_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field CEILING_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_SURFACE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_INVENTORY_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_INVENTORY_WASTE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_INVENTORY_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_INVENTORY_WASTE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_INVENTORY_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_INVENTORY_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_INVENTORY_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_INVENTORY_SURFACE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_WALLS_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_WALLS_WASTE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_WALLS_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_WALLS_WASTE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_WALLS_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_WALLS_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_WALLS_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_WALLS_SURFACE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_FLOOR_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_FLOOR_WASTE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_FLOOR_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_FLOOR_WASTE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_FLOOR_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_FLOOR_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_FLOOR_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_FLOOR_SURFACE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_CEILING_WASTE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_CEILING_WASTE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_CEILING_WASTE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_CEILING_WASTE_VT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_CEILING_SURFACE_LT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_CEILING_SURFACE_LT { get; set; }

        /// <summary>
        /// Required field CLEANING_QUALITY_CEILING_SURFACE_VT of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Required]
        public int CLEANING_QUALITY_CEILING_SURFACE_VT { get; set; }

        /// <summary>
        /// Primary key for the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CLEANING_QUALITY_CONTROL_X_AREA belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the CLEANING_QUALITY_CONTROL_X_AREA belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_QUALITY_CONTROL to which the CLEANING_QUALITY_CONTROL_X_AREA belongs 
        /// </summary>
        public Guid? GUID_CLEANING_QUALITY_CONTROL { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_QUALITY_CONTROL
        /// </summary>
        [ForeignKey("GUID_CLEANING_QUALITY_CONTROL")]
        public CLEANING_QUALITY_CONTROL? GUID_CLEANING_QUALITY_CONTROL_CLEANING_QUALITY_CONTROL { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_QUALITY_CONTROL_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING_QUALITY_CONTROL_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_QUALITY_CONTROL_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}