using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a control_list entity with essential details
    /// </summary>
    [Table("CONTROL_LIST", Schema = "dbo")]
    public class CONTROL_LIST
    {
        /// <summary>
        /// Initializes a new instance of the CONTROL_LIST class.
        /// </summary>
        public CONTROL_LIST()
        {
            USE_WITH_EQUIPMENT = false;
            USE_WITH_AREA = false;
            USE_WITH_WORK_ORDER = false;
            IS_DEACTIVATED = false;
            IS_CURRENT_VERSION = false;
            ID = 0;
            USE_IMAGE = false;
            IS_MANDATORY = false;
            VERSION = 0;
            VERSION_STATUS = -1;
            CREATION_DATE = DateTime.UtcNow;
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTROL_LIST 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field USE_WITH_EQUIPMENT of the CONTROL_LIST 
        /// </summary>
        [Required]
        public bool USE_WITH_EQUIPMENT { get; set; }

        /// <summary>
        /// Required field USE_WITH_AREA of the CONTROL_LIST 
        /// </summary>
        [Required]
        public bool USE_WITH_AREA { get; set; }

        /// <summary>
        /// Required field USE_WITH_WORK_ORDER of the CONTROL_LIST 
        /// </summary>
        [Required]
        public bool USE_WITH_WORK_ORDER { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the CONTROL_LIST 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field IS_CURRENT_VERSION of the CONTROL_LIST 
        /// </summary>
        [Required]
        public bool IS_CURRENT_VERSION { get; set; }

        /// <summary>
        /// Required field ID of the CONTROL_LIST 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field USE_IMAGE of the CONTROL_LIST 
        /// </summary>
        [Required]
        public bool USE_IMAGE { get; set; }

        /// <summary>
        /// Required field IS_MANDATORY of the CONTROL_LIST 
        /// </summary>
        [Required]
        public bool IS_MANDATORY { get; set; }

        /// <summary>
        /// Required field VERSION of the CONTROL_LIST 
        /// </summary>
        [Required]
        public int VERSION { get; set; }

        /// <summary>
        /// Required field VERSION_STATUS of the CONTROL_LIST 
        /// </summary>
        [Required]
        public int VERSION_STATUS { get; set; }
        /// <summary>
        /// VERSION_COMMENT of the CONTROL_LIST 
        /// </summary>
        public string? VERSION_COMMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST to which the CONTROL_LIST belongs 
        /// </summary>
        public Guid? GUID_MASTER_RECORD { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST
        /// </summary>
        [ForeignKey("GUID_MASTER_RECORD")]
        public CONTROL_LIST? GUID_MASTER_RECORD_CONTROL_LIST { get; set; }
        /// <summary>
        /// COLOR of the CONTROL_LIST 
        /// </summary>
        public string? COLOR { get; set; }
        /// <summary>
        /// ICON of the CONTROL_LIST 
        /// </summary>
        public string? ICON { get; set; }
        /// <summary>
        /// CONDITIONS of the CONTROL_LIST 
        /// </summary>
        public string? CONDITIONS { get; set; }
        /// <summary>
        /// Foreign key referencing the REFERENCE_TYPE to which the CONTROL_LIST belongs 
        /// </summary>
        public Guid? GUID_REFERENCE_TYPE_NOT_EXECUTED { get; set; }

        /// <summary>
        /// Navigation property representing the associated REFERENCE_TYPE
        /// </summary>
        [ForeignKey("GUID_REFERENCE_TYPE_NOT_EXECUTED")]
        public REFERENCE_TYPE? GUID_REFERENCE_TYPE_NOT_EXECUTED_REFERENCE_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST to which the CONTROL_LIST belongs 
        /// </summary>
        public Guid? GUID_PREVIOUS_VERSION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST
        /// </summary>
        [ForeignKey("GUID_PREVIOUS_VERSION")]
        public CONTROL_LIST? GUID_PREVIOUS_VERSION_CONTROL_LIST { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST to which the CONTROL_LIST belongs 
        /// </summary>
        public Guid? GUID_DRAFT_VERSION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST
        /// </summary>
        [ForeignKey("GUID_DRAFT_VERSION")]
        public CONTROL_LIST? GUID_DRAFT_VERSION_CONTROL_LIST { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTROL_LIST belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// NAME of the CONTROL_LIST 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// DESCRIPTION of the CONTROL_LIST 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTROL_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTROL_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
    }
}