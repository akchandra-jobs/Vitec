using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_comment entity with essential details
    /// </summary>
    [Table("ENTITY_COMMENT", Schema = "dbo")]
    public class ENTITY_COMMENT
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_COMMENT class.
        /// </summary>
        public ENTITY_COMMENT()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENTITY_COMMENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the REQUEST to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_REQUEST { get; set; }

        /// <summary>
        /// Navigation property representing the associated REQUEST
        /// </summary>
        [ForeignKey("GUID_REQUEST")]
        public REQUEST? GUID_REQUEST_REQUEST { get; set; }
        /// <summary>
        /// COMMENT of the ENTITY_COMMENT 
        /// </summary>
        public string? COMMENT { get; set; }

        /// <summary>
        /// READ_DATE of the ENTITY_COMMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? READ_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_COMMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_COMMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT
        /// </summary>
        [ForeignKey("GUID_PROJECT")]
        public PROJECT? GUID_PROJECT_PROJECT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEVIATION to which the ENTITY_COMMENT belongs 
        /// </summary>
        public Guid? GUID_DEVIATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEVIATION
        /// </summary>
        [ForeignKey("GUID_DEVIATION")]
        public DEVIATION? GUID_DEVIATION_DEVIATION { get; set; }
    }
}