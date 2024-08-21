using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a work_order_invoice_item entity with essential details
    /// </summary>
    [Table("WORK_ORDER_INVOICE_ITEM", Schema = "dbo")]
    public class WORK_ORDER_INVOICE_ITEM
    {
        /// <summary>
        /// Initializes a new instance of the WORK_ORDER_INVOICE_ITEM class.
        /// </summary>
        public WORK_ORDER_INVOICE_ITEM()
        {
            ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the WORK_ORDER_INVOICE_ITEM 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Primary key for the WORK_ORDER_INVOICE_ITEM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_ITEM to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_ITEM")]
        public PAYMENT_ORDER_ITEM? GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_ITEM to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_ITEM_ADJUSTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_ITEM_ADJUSTMENT")]
        public PAYMENT_ORDER_ITEM? GUID_PAYMENT_ORDER_ITEM_ADJUSTMENT_PAYMENT_ORDER_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ITEM")]
        public CONTRACT_ITEM? GUID_CONTRACT_ITEM_CONTRACT_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER_ITEM to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER_ITEM")]
        public PURCHASE_ORDER_ITEM? GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER_X_EQUIPMENT to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER_X_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER_X_EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER_X_EQUIPMENT")]
        public WORK_ORDER_X_EQUIPMENT? GUID_WORK_ORDER_X_EQUIPMENT_WORK_ORDER_X_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER_X_RESOURCE_GROUP to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER_X_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER_X_RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER_X_RESOURCE_GROUP")]
        public WORK_ORDER_X_RESOURCE_GROUP? GUID_WORK_ORDER_X_RESOURCE_GROUP_WORK_ORDER_X_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER_X_SPARE_PART to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER_X_SPARE_PART { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER_X_SPARE_PART
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER_X_SPARE_PART")]
        public WORK_ORDER_X_SPARE_PART? GUID_WORK_ORDER_X_SPARE_PART_WORK_ORDER_X_SPARE_PART { get; set; }
        /// <summary>
        /// Foreign key referencing the COST to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_COST { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST
        /// </summary>
        [ForeignKey("GUID_COST")]
        public COST? GUID_COST_COST { get; set; }
        /// <summary>
        /// Foreign key referencing the ARTICLE to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_ARTICLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ARTICLE
        /// </summary>
        [ForeignKey("GUID_ARTICLE")]
        public ARTICLE? GUID_ARTICLE_ARTICLE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WORK_ORDER_INVOICE_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WORK_ORDER_INVOICE_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_INVOICE_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}