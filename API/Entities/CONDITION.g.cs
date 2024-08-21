using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a condition entity with essential details
    /// </summary>
    [Table("CONDITION", Schema = "dbo")]
    public class CONDITION
    {
        /// <summary>
        /// Initializes a new instance of the CONDITION class.
        /// </summary>
        public CONDITION()
        {
            STATUS = -1;
            TYPE = -1;
            IS_CANCELLED = false;
            PERIODICITY_UNIT = -1;
            YEAR = 0;
            CORRECTIVE_ACTION_TYPE = -1;
            IS_CURRENT_VERSION = false;
            VERSION = 0;
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONDITION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the CONDITION 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field TYPE of the CONDITION 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field QUANTITY of the CONDITION 
        /// </summary>
        [Required]
        public double QUANTITY { get; set; }

        /// <summary>
        /// Required field UNIT_PRICE of the CONDITION 
        /// </summary>
        [Required]
        public double UNIT_PRICE { get; set; }

        /// <summary>
        /// Required field IS_CANCELLED of the CONDITION 
        /// </summary>
        [Required]
        public bool IS_CANCELLED { get; set; }

        /// <summary>
        /// Required field PERIODICITY_NUMBER of the CONDITION 
        /// </summary>
        [Required]
        public double PERIODICITY_NUMBER { get; set; }

        /// <summary>
        /// Required field PERIODICITY_UNIT of the CONDITION 
        /// </summary>
        [Required]
        public int PERIODICITY_UNIT { get; set; }

        /// <summary>
        /// Required field ESTIMATE of the CONDITION 
        /// </summary>
        [Required]
        public double ESTIMATE { get; set; }

        /// <summary>
        /// Required field YEAR of the CONDITION 
        /// </summary>
        [Required]
        public int YEAR { get; set; }

        /// <summary>
        /// Required field CORRECTIVE_ACTION_TYPE of the CONDITION 
        /// </summary>
        [Required]
        public int CORRECTIVE_ACTION_TYPE { get; set; }

        /// <summary>
        /// Required field ADJUSTMENT_FACTOR of the CONDITION 
        /// </summary>
        [Required]
        public double ADJUSTMENT_FACTOR { get; set; }

        /// <summary>
        /// Required field IS_CURRENT_VERSION of the CONDITION 
        /// </summary>
        [Required]
        public bool IS_CURRENT_VERSION { get; set; }

        /// <summary>
        /// Required field VERSION of the CONDITION 
        /// </summary>
        [Required]
        public int VERSION { get; set; }

        /// <summary>
        /// Required field ID of the CONDITION 
        /// </summary>
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// OBJECT_CONTEXT_DESCRIPTION of the CONDITION 
        /// </summary>
        public string? OBJECT_CONTEXT_DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_PREVIOUS_VERSION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION
        /// </summary>
        [ForeignKey("GUID_PREVIOUS_VERSION")]
        public CONDITION? GUID_PREVIOUS_VERSION_CONDITION { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_USER_CONFIRMED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CONFIRMED_BY")]
        public USR? GUID_USER_CONFIRMED_BY_USR { get; set; }

        /// <summary>
        /// CONFIRMED_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CONFIRMED_DATE { get; set; }
        /// <summary>
        /// VERSION_COMMENT of the CONDITION 
        /// </summary>
        public string? VERSION_COMMENT { get; set; }

        /// <summary>
        /// EFFECTIVE_START_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EFFECTIVE_START_DATE { get; set; }

        /// <summary>
        /// EFFECTIVE_END_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EFFECTIVE_END_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// PRIORITY_COMMENT of the CONDITION 
        /// </summary>
        public string? PRIORITY_COMMENT { get; set; }
        /// <summary>
        /// FLOOR of the CONDITION 
        /// </summary>
        public string? FLOOR { get; set; }
        /// <summary>
        /// ACTION_COMMENT of the CONDITION 
        /// </summary>
        public string? ACTION_COMMENT { get; set; }

        /// <summary>
        /// END_OF_RECURRENCE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_OF_RECURRENCE { get; set; }
        /// <summary>
        /// UNIT of the CONDITION 
        /// </summary>
        public string? UNIT { get; set; }

        /// <summary>
        /// ESTIMATE_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ESTIMATE_DATE { get; set; }

        /// <summary>
        /// START_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// REPORTED_END_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REPORTED_END_DATE { get; set; }

        /// <summary>
        /// END_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// DEADLINE_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DEADLINE_DATE { get; set; }
        /// <summary>
        /// STATUS_COMMENT of the CONDITION 
        /// </summary>
        public string? STATUS_COMMENT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_ADJUSTED_BY_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_ADJUSTED_BY_USER")]
        public USR? GUID_ADJUSTED_BY_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_BASE_RECORD { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION
        /// </summary>
        [ForeignKey("GUID_BASE_RECORD")]
        public CONDITION? GUID_BASE_RECORD_CONDITION { get; set; }
        /// <summary>
        /// Foreign key referencing the PRIORITY to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_PRIORITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRIORITY
        /// </summary>
        [ForeignKey("GUID_PRIORITY")]
        public PRIORITY? GUID_PRIORITY_PRIORITY { get; set; }
        /// <summary>
        /// Foreign key referencing the CONSTRUCTION_TYPE to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_CONSTRUCTION_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONSTRUCTION_TYPE
        /// </summary>
        [ForeignKey("GUID_CONSTRUCTION_TYPE")]
        public CONSTRUCTION_TYPE? GUID_CONSTRUCTION_TYPE_CONSTRUCTION_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_MASTER_RECORD { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION
        /// </summary>
        [ForeignKey("GUID_MASTER_RECORD")]
        public CONDITION? GUID_MASTER_RECORD_CONDITION { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONSEQUENCE to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_CONSEQUENCE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONSEQUENCE
        /// </summary>
        [ForeignKey("GUID_CONSEQUENCE")]
        public CONSEQUENCE? GUID_CONSEQUENCE_CONSEQUENCE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONSEQUENCE_TYPE to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_CONSEQUENCE_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONSEQUENCE_TYPE
        /// </summary>
        [ForeignKey("GUID_CONSEQUENCE_TYPE")]
        public CONSEQUENCE_TYPE? GUID_CONSEQUENCE_TYPE_CONSEQUENCE_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION_TYPE to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_CONDITION_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION_TYPE
        /// </summary>
        [ForeignKey("GUID_CONDITION_TYPE")]
        public CONDITION_TYPE? GUID_CONDITION_TYPE_CONDITION_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_INSPECTION_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_INSPECTION_WORK_ORDER")]
        public WORK_ORDER? GUID_INSPECTION_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_CORRECTIVE_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_CORRECTIVE_WORK_ORDER")]
        public WORK_ORDER? GUID_CORRECTIVE_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONDITION belongs 
        /// </summary>
        public Guid? GUID_USER_CHECKED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CHECKED_BY")]
        public USR? GUID_USER_CHECKED_BY_USR { get; set; }

        /// <summary>
        /// CONDITION_DATE of the CONDITION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CONDITION_DATE { get; set; }
        /// <summary>
        /// REMARKS of the CONDITION 
        /// </summary>
        public string? REMARKS { get; set; }
    }
}