using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a work_order_x_area entity with essential details
    /// </summary>
    [Table("WORK_ORDER_X_AREA", Schema = "dbo")]
    public class WORK_ORDER_X_AREA
    {
        /// <summary>
        /// Initializes a new instance of the WORK_ORDER_X_AREA class.
        /// </summary>
        public WORK_ORDER_X_AREA()
        {
            INVENTORY_LT = 0;
            INVENTORY_VT = 0;
            INVENTORY_LT_PR = 0;
            INVENTORY_VT_PR = 0;
            INVENTORY_LT_KONTR = 0;
            INVENTORY_VT_KONTR = 0;
            INVENTORY_LT_PR_KONTR = 0;
            INVENTORY_VT_PR_KONTR = 0;
            WALLS_LT = 0;
            WALLS_VT = 0;
            WALLS_LT_PR = 0;
            WALLS_VT_PR = 0;
            WALLS_LT_KONTR = 0;
            WALLS_VT_KONTR = 0;
            WALLS_LT_PR_KONTR = 0;
            WALLS_VT_PR_KONTR = 0;
            FLOOR_LT = 0;
            FLOOR_VT = 0;
            FLOOR_LT_PR = 0;
            FLOOR_VT_PR = 0;
            FLOOR_LT_KONTR = 0;
            FLOOR_VT_KONTR = 0;
            FLOOR_LT_PR_KONTR = 0;
            FLOOR_VT_PR_KONTR = 0;
            CEILING_LT = 0;
            CEILING_VT = 0;
            CEILING_LT_PR = 0;
            CEILING_VT_PR = 0;
            CEILING_LT_KONTR = 0;
            CEILING_VT_KONTR = 0;
            CEILING_LT_PR_KONTR = 0;
            CEILING_VT_PR_KONTR = 0;
            TYPE = -1;
            YEAR = 0;
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field INVENTORY_LT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_LT { get; set; }

        /// <summary>
        /// Required field INVENTORY_VT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_VT { get; set; }

        /// <summary>
        /// Required field INVENTORY_LT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_LT_PR { get; set; }

        /// <summary>
        /// Required field INVENTORY_VT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_VT_PR { get; set; }

        /// <summary>
        /// Required field INVENTORY_LT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_LT_KONTR { get; set; }

        /// <summary>
        /// Required field INVENTORY_VT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_VT_KONTR { get; set; }

        /// <summary>
        /// Required field INVENTORY_LT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_LT_PR_KONTR { get; set; }

        /// <summary>
        /// Required field INVENTORY_VT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int INVENTORY_VT_PR_KONTR { get; set; }

        /// <summary>
        /// Required field WALLS_LT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_LT { get; set; }

        /// <summary>
        /// Required field WALLS_VT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_VT { get; set; }

        /// <summary>
        /// Required field WALLS_LT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_LT_PR { get; set; }

        /// <summary>
        /// Required field WALLS_VT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_VT_PR { get; set; }

        /// <summary>
        /// Required field WALLS_LT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_LT_KONTR { get; set; }

        /// <summary>
        /// Required field WALLS_VT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_VT_KONTR { get; set; }

        /// <summary>
        /// Required field WALLS_LT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_LT_PR_KONTR { get; set; }

        /// <summary>
        /// Required field WALLS_VT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int WALLS_VT_PR_KONTR { get; set; }

        /// <summary>
        /// Required field FLOOR_LT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_LT { get; set; }

        /// <summary>
        /// Required field FLOOR_VT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_VT { get; set; }

        /// <summary>
        /// Required field FLOOR_LT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_LT_PR { get; set; }

        /// <summary>
        /// Required field FLOOR_VT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_VT_PR { get; set; }

        /// <summary>
        /// Required field FLOOR_LT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_LT_KONTR { get; set; }

        /// <summary>
        /// Required field FLOOR_VT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_VT_KONTR { get; set; }

        /// <summary>
        /// Required field FLOOR_LT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_LT_PR_KONTR { get; set; }

        /// <summary>
        /// Required field FLOOR_VT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int FLOOR_VT_PR_KONTR { get; set; }

        /// <summary>
        /// Required field CEILING_LT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_LT { get; set; }

        /// <summary>
        /// Required field CEILING_VT of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_VT { get; set; }

        /// <summary>
        /// Required field CEILING_LT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_LT_PR { get; set; }

        /// <summary>
        /// Required field CEILING_VT_PR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_VT_PR { get; set; }

        /// <summary>
        /// Required field CEILING_LT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_LT_KONTR { get; set; }

        /// <summary>
        /// Required field CEILING_VT_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_VT_KONTR { get; set; }

        /// <summary>
        /// Required field CEILING_LT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_LT_PR_KONTR { get; set; }

        /// <summary>
        /// Required field CEILING_VT_PR_KONTR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int CEILING_VT_PR_KONTR { get; set; }

        /// <summary>
        /// Primary key for the WORK_ORDER_X_AREA 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field TYPE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field ESTIMATE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public double ESTIMATE { get; set; }

        /// <summary>
        /// Required field YEAR of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int YEAR { get; set; }

        /// <summary>
        /// Required field STATUS of the WORK_ORDER_X_AREA 
        /// </summary>
        [Required]
        public int STATUS { get; set; }
        /// <summary>
        /// ACTION_COMMENT of the WORK_ORDER_X_AREA 
        /// </summary>
        public string? ACTION_COMMENT { get; set; }

        /// <summary>
        /// START_DATE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// DEADLINE_DATE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DEADLINE_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT
        /// </summary>
        [ForeignKey("GUID_DOCUMENT")]
        public DOCUMENT? GUID_DOCUMENT_DOCUMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONSEQUENCE to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_CONSEQUENCE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONSEQUENCE
        /// </summary>
        [ForeignKey("GUID_CONSEQUENCE")]
        public CONSEQUENCE? GUID_CONSEQUENCE_CONSEQUENCE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONSEQUENCE_TYPE to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_CONSEQUENCE_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONSEQUENCE_TYPE
        /// </summary>
        [ForeignKey("GUID_CONSEQUENCE_TYPE")]
        public CONSEQUENCE_TYPE? GUID_CONSEQUENCE_TYPE_CONSEQUENCE_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION_TYPE to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_CONDITION_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION_TYPE
        /// </summary>
        [ForeignKey("GUID_CONDITION_TYPE")]
        public CONDITION_TYPE? GUID_CONDITION_TYPE_CONDITION_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_INSPECTION_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_INSPECTION_WORK_ORDER")]
        public WORK_ORDER? GUID_INSPECTION_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_CORRECTIVE_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_CORRECTIVE_WORK_ORDER")]
        public WORK_ORDER? GUID_CORRECTIVE_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_CHECKED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CHECKED_BY")]
        public USR? GUID_USER_CHECKED_BY_USR { get; set; }

        /// <summary>
        /// CONDITION_DATE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CONDITION_DATE { get; set; }
        /// <summary>
        /// REMARKS of the WORK_ORDER_X_AREA 
        /// </summary>
        public string? REMARKS { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WORK_ORDER_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}