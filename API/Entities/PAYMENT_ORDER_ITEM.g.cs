using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a payment_order_item entity with essential details
    /// </summary>
    [Table("PAYMENT_ORDER_ITEM", Schema = "dbo")]
    public class PAYMENT_ORDER_ITEM
    {
        /// <summary>
        /// Initializes a new instance of the PAYMENT_ORDER_ITEM class.
        /// </summary>
        public PAYMENT_ORDER_ITEM()
        {
            LINE_NR = 0;
            ORIGINAL_LINE_NR = 0;
            IS_CREDIT = false;
            NUMBER_OF_PERSONS = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field LINE_NR of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Required]
        public int LINE_NR { get; set; }

        /// <summary>
        /// Required field ORIGINAL_LINE_NR of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Required]
        public int ORIGINAL_LINE_NR { get; set; }

        /// <summary>
        /// Required field IS_CREDIT of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Required]
        public bool IS_CREDIT { get; set; }

        /// <summary>
        /// Required field NUMBER_OF_PERSONS of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Required]
        public int NUMBER_OF_PERSONS { get; set; }

        /// <summary>
        /// Required field AMOUNT of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Required]
        public double AMOUNT { get; set; }

        /// <summary>
        /// Required field QUANTITY of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Required]
        public double QUANTITY { get; set; }

        /// <summary>
        /// Required field UNIT_PRICE of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Required]
        public double UNIT_PRICE { get; set; }
        /// <summary>
        /// UNIT of the PAYMENT_ORDER_ITEM 
        /// </summary>
        public string? UNIT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the ARTICLE to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ARTICLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ARTICLE
        /// </summary>
        [ForeignKey("GUID_ARTICLE")]
        public ARTICLE? GUID_ARTICLE_ARTICLE { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING0")]
        public ACCOUNTING? GUID_ACCOUNTING0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING1")]
        public ACCOUNTING? GUID_ACCOUNTING1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING2")]
        public ACCOUNTING? GUID_ACCOUNTING2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING3")]
        public ACCOUNTING? GUID_ACCOUNTING3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING4")]
        public ACCOUNTING? GUID_ACCOUNTING4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER")]
        public PAYMENT_ORDER? GUID_PAYMENT_ORDER_PAYMENT_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the PAYMENT_ORDER_ITEM belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ITEM")]
        public CONTRACT_ITEM? GUID_CONTRACT_ITEM_CONTRACT_ITEM { get; set; }
        /// <summary>
        /// ID of the PAYMENT_ORDER_ITEM 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PAYMENT_ORDER_ITEM 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// INVOICED_FROM_DATE of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? INVOICED_FROM_DATE { get; set; }

        /// <summary>
        /// INVOICED_TO_DATE of the PAYMENT_ORDER_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? INVOICED_TO_DATE { get; set; }
    }
}