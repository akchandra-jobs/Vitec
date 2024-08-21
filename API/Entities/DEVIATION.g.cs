using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a deviation entity with essential details
    /// </summary>
    [Table("DEVIATION", Schema = "dbo")]
    public class DEVIATION
    {
        /// <summary>
        /// Initializes a new instance of the DEVIATION class.
        /// </summary>
        public DEVIATION()
        {
            ID = 0;
            STATUS = -1;
            CLOSED_REASON = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DEVIATION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the DEVIATION 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field STATUS of the DEVIATION 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field CLOSED_REASON of the DEVIATION 
        /// </summary>
        [Required]
        public int CLOSED_REASON { get; set; }
        /// <summary>
        /// Foreign key referencing the PRIORITY to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_PRIORITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRIORITY
        /// </summary>
        [ForeignKey("GUID_PRIORITY")]
        public PRIORITY? GUID_PRIORITY_PRIORITY { get; set; }
        /// <summary>
        /// PRIORITY_COMMENT of the DEVIATION 
        /// </summary>
        public string? PRIORITY_COMMENT { get; set; }
        /// <summary>
        /// STATUS_COMMENT of the DEVIATION 
        /// </summary>
        public string? STATUS_COMMENT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DEVIATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DEVIATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_USER_CLOSED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CLOSED_BY")]
        public USR? GUID_USER_CLOSED_BY_USR { get; set; }
        /// <summary>
        /// REMARKS of the DEVIATION 
        /// </summary>
        public string? REMARKS { get; set; }

        /// <summary>
        /// START_DATE of the DEVIATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// DEADLINE_DATE of the DEVIATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DEADLINE_DATE { get; set; }

        /// <summary>
        /// REPORTED_END_DATE of the DEVIATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REPORTED_END_DATE { get; set; }

        /// <summary>
        /// END_DATE of the DEVIATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
        /// <summary>
        /// ACTION_COMMENT of the DEVIATION 
        /// </summary>
        public string? ACTION_COMMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST_ITEM_ANSWER to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST_ITEM_ANSWER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST_ITEM_ANSWER
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST_ITEM_ANSWER")]
        public CONTROL_LIST_ITEM_ANSWER? GUID_CONTROL_LIST_ITEM_ANSWER_CONTROL_LIST_ITEM_ANSWER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_CORRECTIVE_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_CORRECTIVE_WORK_ORDER")]
        public WORK_ORDER? GUID_CORRECTIVE_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEVIATION_TYPE to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_DEVIATION_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEVIATION_TYPE
        /// </summary>
        [ForeignKey("GUID_DEVIATION_TYPE")]
        public DEVIATION_TYPE? GUID_DEVIATION_TYPE_DEVIATION_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_INSPECTION_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_INSPECTION_WORK_ORDER")]
        public WORK_ORDER? GUID_INSPECTION_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the DEVIATION belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
    }
}