using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a control_list_x_entity entity with essential details
    /// </summary>
    [Table("CONTROL_LIST_X_ENTITY", Schema = "dbo")]
    public class CONTROL_LIST_X_ENTITY
    {
        /// <summary>
        /// Initializes a new instance of the CONTROL_LIST_X_ENTITY class.
        /// </summary>
        public CONTROL_LIST_X_ENTITY()
        {
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTROL_LIST_X_ENTITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the CONTROL_LIST_X_ENTITY 
        /// </summary>
        [Required]
        public int STATUS { get; set; }
        /// <summary>
        /// Foreign key referencing the REFERENCE_DATA to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_REFERENCE_DATA_NOT_EXECUTED { get; set; }

        /// <summary>
        /// Navigation property representing the associated REFERENCE_DATA
        /// </summary>
        [ForeignKey("GUID_REFERENCE_DATA_NOT_EXECUTED")]
        public REFERENCE_DATA? GUID_REFERENCE_DATA_NOT_EXECUTED_REFERENCE_DATA { get; set; }
        /// <summary>
        /// NOT_EXECUTED_COMMENT of the CONTROL_LIST_X_ENTITY 
        /// </summary>
        public string? NOT_EXECUTED_COMMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST")]
        public CONTROL_LIST? GUID_CONTROL_LIST_CONTROL_LIST { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_CLOSED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CLOSED_BY")]
        public USR? GUID_USER_CLOSED_BY_USR { get; set; }

        /// <summary>
        /// CLOSED_DATE of the CONTROL_LIST_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CLOSED_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTROL_LIST_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTROL_LIST_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}