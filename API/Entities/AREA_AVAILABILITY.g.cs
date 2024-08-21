using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a area_availability entity with essential details
    /// </summary>
    [Table("AREA_AVAILABILITY", Schema = "dbo")]
    public class AREA_AVAILABILITY
    {
        /// <summary>
        /// Initializes a new instance of the AREA_AVAILABILITY class.
        /// </summary>
        public AREA_AVAILABILITY()
        {
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field STATUS of the AREA_AVAILABILITY 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Primary key for the AREA_AVAILABILITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the AREA_AVAILABILITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the AREA_AVAILABILITY belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the AREA_AVAILABILITY belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the AREA_AVAILABILITY belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ITEM")]
        public CONTRACT_ITEM? GUID_CONTRACT_ITEM_CONTRACT_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_AVAILABILITY to which the AREA_AVAILABILITY belongs 
        /// </summary>
        public Guid? GUID_PREVIOUS { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_AVAILABILITY
        /// </summary>
        [ForeignKey("GUID_PREVIOUS")]
        public AREA_AVAILABILITY? GUID_PREVIOUS_AREA_AVAILABILITY { get; set; }

        /// <summary>
        /// START_DATE of the AREA_AVAILABILITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the AREA_AVAILABILITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// SCHEDULED_START_DATE of the AREA_AVAILABILITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SCHEDULED_START_DATE { get; set; }

        /// <summary>
        /// SCHEDULED_END_DATE of the AREA_AVAILABILITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SCHEDULED_END_DATE { get; set; }

        /// <summary>
        /// CANCEL_DATE of the AREA_AVAILABILITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CANCEL_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the AREA_AVAILABILITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_AVAILABILITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the AREA_AVAILABILITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_AVAILABILITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}