using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a purchase_order_item entity with essential details
    /// </summary>
    [Table("PURCHASE_ORDER_ITEM", Schema = "dbo")]
    public class PURCHASE_ORDER_ITEM
    {
        /// <summary>
        /// Initializes a new instance of the PURCHASE_ORDER_ITEM class.
        /// </summary>
        public PURCHASE_ORDER_ITEM()
        {
            STATUS = -1;
            IS_CANCELLED = false;
            LINE_NUMBER = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ORDERED_QUANTITY of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double ORDERED_QUANTITY { get; set; }

        /// <summary>
        /// Required field UNIT_PRICE of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double UNIT_PRICE { get; set; }

        /// <summary>
        /// Required field ORDERED_AMOUNT of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double ORDERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field STATUS of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field IS_CANCELLED of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public bool IS_CANCELLED { get; set; }

        /// <summary>
        /// Required field ESTIMATE_AMOUNT of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double ESTIMATE_AMOUNT { get; set; }

        /// <summary>
        /// Required field COST_AMOUNT of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double COST_AMOUNT { get; set; }

        /// <summary>
        /// Required field RECEIVED_QUANTITY of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double RECEIVED_QUANTITY { get; set; }

        /// <summary>
        /// Required field REST of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double REST { get; set; }

        /// <summary>
        /// Required field LINE_NUMBER of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public int LINE_NUMBER { get; set; }

        /// <summary>
        /// Required field ALLOCATED_AMOUNT of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double ALLOCATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field VAT_RATE of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double VAT_RATE { get; set; }

        /// <summary>
        /// Required field REST_ESTIMATE_AMOUNT of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Required]
        public double REST_ESTIMATE_AMOUNT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// SUPPLIER_PART_NUMBER of the PURCHASE_ORDER_ITEM 
        /// </summary>
        public string? SUPPLIER_PART_NUMBER { get; set; }

        /// <summary>
        /// RECEIVED_DATE of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? RECEIVED_DATE { get; set; }

        /// <summary>
        /// BUDGET_DATE of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? BUDGET_DATE { get; set; }
        /// <summary>
        /// UNIT of the PURCHASE_ORDER_ITEM 
        /// </summary>
        public string? UNIT { get; set; }

        /// <summary>
        /// DELIVERY_DATE of the PURCHASE_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DELIVERY_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the ARTICLE to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ARTICLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ARTICLE
        /// </summary>
        [ForeignKey("GUID_ARTICLE")]
        public ARTICLE? GUID_ARTICLE_ARTICLE { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER")]
        public PURCHASE_ORDER? GUID_PURCHASE_ORDER_PURCHASE_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING0")]
        public ACCOUNTING? GUID_ACCOUNTING0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING1")]
        public ACCOUNTING? GUID_ACCOUNTING1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING2")]
        public ACCOUNTING? GUID_ACCOUNTING2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING3")]
        public ACCOUNTING? GUID_ACCOUNTING3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING4")]
        public ACCOUNTING? GUID_ACCOUNTING4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the SPARE_PART to which the PURCHASE_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_SPARE_PART { get; set; }

        /// <summary>
        /// Navigation property representing the associated SPARE_PART
        /// </summary>
        [ForeignKey("GUID_SPARE_PART")]
        public SPARE_PART? GUID_SPARE_PART_SPARE_PART { get; set; }
        /// <summary>
        /// ID of the PURCHASE_ORDER_ITEM 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PURCHASE_ORDER_ITEM 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the PURCHASE_ORDER_ITEM 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
    }
}