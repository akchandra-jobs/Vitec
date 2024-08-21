using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cost entity with essential details
    /// </summary>
    [Table("COST", Schema = "dbo")]
    public class COST
    {
        /// <summary>
        /// Initializes a new instance of the COST class.
        /// </summary>
        public COST()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the COST 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field AMOUNT of the COST 
        /// </summary>
        [Required]
        public double AMOUNT { get; set; }

        /// <summary>
        /// Required field UNIT_PRICE of the COST 
        /// </summary>
        [Required]
        public double UNIT_PRICE { get; set; }

        /// <summary>
        /// Required field COST_JAN of the COST 
        /// </summary>
        [Required]
        public double COST_JAN { get; set; }

        /// <summary>
        /// Required field COST_FEB of the COST 
        /// </summary>
        [Required]
        public double COST_FEB { get; set; }

        /// <summary>
        /// Required field COST_MAR of the COST 
        /// </summary>
        [Required]
        public double COST_MAR { get; set; }

        /// <summary>
        /// Required field COST_APR of the COST 
        /// </summary>
        [Required]
        public double COST_APR { get; set; }

        /// <summary>
        /// Required field COST_MAY of the COST 
        /// </summary>
        [Required]
        public double COST_MAY { get; set; }

        /// <summary>
        /// Required field COST_JUN of the COST 
        /// </summary>
        [Required]
        public double COST_JUN { get; set; }

        /// <summary>
        /// Required field COST_JUL of the COST 
        /// </summary>
        [Required]
        public double COST_JUL { get; set; }

        /// <summary>
        /// Required field COST_AUG of the COST 
        /// </summary>
        [Required]
        public double COST_AUG { get; set; }

        /// <summary>
        /// Required field COST_SEP of the COST 
        /// </summary>
        [Required]
        public double COST_SEP { get; set; }

        /// <summary>
        /// Required field COST_OCT of the COST 
        /// </summary>
        [Required]
        public double COST_OCT { get; set; }

        /// <summary>
        /// Required field COST_NOV of the COST 
        /// </summary>
        [Required]
        public double COST_NOV { get; set; }

        /// <summary>
        /// Required field COST_DEC of the COST 
        /// </summary>
        [Required]
        public double COST_DEC { get; set; }

        /// <summary>
        /// Required field INVOICE_AMOUNT of the COST 
        /// </summary>
        [Required]
        public double INVOICE_AMOUNT { get; set; }

        /// <summary>
        /// Required field QUANTITY of the COST 
        /// </summary>
        [Required]
        public double QUANTITY { get; set; }

        /// <summary>
        /// Required field GROSS_AMOUNT of the COST 
        /// </summary>
        [Required]
        public double GROSS_AMOUNT { get; set; }
        /// <summary>
        /// UNIT of the COST 
        /// </summary>
        public string? UNIT { get; set; }
        /// <summary>
        /// VOUCHER_NUMBER of the COST 
        /// </summary>
        public string? VOUCHER_NUMBER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the COST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COST belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the COST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COST belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the COST belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the COST belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the COST belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the COST belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the COST belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER to which the COST belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER")]
        public PURCHASE_ORDER? GUID_PURCHASE_ORDER_PURCHASE_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the COST belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COST belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING0")]
        public ACCOUNTING? GUID_ACCOUNTING0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COST belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING1")]
        public ACCOUNTING? GUID_ACCOUNTING1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COST belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING2")]
        public ACCOUNTING? GUID_ACCOUNTING2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COST belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING3")]
        public ACCOUNTING? GUID_ACCOUNTING3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COST belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING4")]
        public ACCOUNTING? GUID_ACCOUNTING4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONSUMABLE to which the COST belongs 
        /// </summary>
        public Guid? GUID_CONSUMABLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONSUMABLE
        /// </summary>
        [ForeignKey("GUID_CONSUMABLE")]
        public CONSUMABLE? GUID_CONSUMABLE_CONSUMABLE { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the COST belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the COST belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the COST belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT to which the COST belongs 
        /// </summary>
        public Guid? GUID_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT
        /// </summary>
        [ForeignKey("GUID_PROJECT")]
        public PROJECT? GUID_PROJECT_PROJECT { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER_ITEM to which the COST belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER_ITEM")]
        public PURCHASE_ORDER_ITEM? GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM { get; set; }
        /// <summary>
        /// DESCRIPTION of the COST 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// ENTITY_ID of the COST 
        /// </summary>
        public string? ENTITY_ID { get; set; }
        /// <summary>
        /// ENTITY_DESCRIPTION of the COST 
        /// </summary>
        public string? ENTITY_DESCRIPTION { get; set; }

        /// <summary>
        /// INVOICE_DATE of the COST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? INVOICE_DATE { get; set; }

        /// <summary>
        /// POSTING_DATE of the COST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? POSTING_DATE { get; set; }
        /// <summary>
        /// INVOICE_NUMBER of the COST 
        /// </summary>
        public string? INVOICE_NUMBER { get; set; }
    }
}