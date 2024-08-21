using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a spare_part_withdrawal entity with essential details
    /// </summary>
    [Table("SPARE_PART_WITHDRAWAL", Schema = "dbo")]
    public class SPARE_PART_WITHDRAWAL
    {
        /// <summary>
        /// Initializes a new instance of the SPARE_PART_WITHDRAWAL class.
        /// </summary>
        public SPARE_PART_WITHDRAWAL()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the SPARE_PART_WITHDRAWAL 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field QUANTITY of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        [Required]
        public double QUANTITY { get; set; }

        /// <summary>
        /// Required field PRICE of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        [Required]
        public double PRICE { get; set; }

        /// <summary>
        /// WITHDRAWAL_DATE of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? WITHDRAWAL_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_ITEM to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_ITEM")]
        public PAYMENT_ORDER_ITEM? GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM { get; set; }
        /// <summary>
        /// ENTITY_ID of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        public string? ENTITY_ID { get; set; }
        /// <summary>
        /// ENTITY_DESCRIPTION of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        public string? ENTITY_DESCRIPTION { get; set; }
        /// <summary>
        /// NOTE of the SPARE_PART_WITHDRAWAL 
        /// </summary>
        public string? NOTE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER_X_SPARE_PART to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER_X_SPARE_PART { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER_X_SPARE_PART
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER_X_SPARE_PART")]
        public WORK_ORDER_X_SPARE_PART? GUID_WORK_ORDER_X_SPARE_PART_WORK_ORDER_X_SPARE_PART { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the SPARE_PART to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_SPARE_PART { get; set; }

        /// <summary>
        /// Navigation property representing the associated SPARE_PART
        /// </summary>
        [ForeignKey("GUID_SPARE_PART")]
        public SPARE_PART? GUID_SPARE_PART_SPARE_PART { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the SPARE_PART_WITHDRAWAL belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ITEM")]
        public CONTRACT_ITEM? GUID_CONTRACT_ITEM_CONTRACT_ITEM { get; set; }
    }
}