using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a spare_part entity with essential details
    /// </summary>
    [Table("SPARE_PART", Schema = "dbo")]
    public class SPARE_PART
    {
        /// <summary>
        /// Initializes a new instance of the SPARE_PART class.
        /// </summary>
        public SPARE_PART()
        {
            IS_AUTO_ORDERED = false;
            QUANTITY_PER_PACKAGE = 0;
            IS_DEACTIVATED = false;
            IS_IMPORTANT_PART = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the SPARE_PART 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INVENTORY of the SPARE_PART 
        /// </summary>
        [Required]
        public double INVENTORY { get; set; }

        /// <summary>
        /// Required field MINIMUM_NUMBER of the SPARE_PART 
        /// </summary>
        [Required]
        public double MINIMUM_NUMBER { get; set; }

        /// <summary>
        /// Required field MAXIMUM_NUMBER of the SPARE_PART 
        /// </summary>
        [Required]
        public double MAXIMUM_NUMBER { get; set; }

        /// <summary>
        /// Required field IS_AUTO_ORDERED of the SPARE_PART 
        /// </summary>
        [Required]
        public bool IS_AUTO_ORDERED { get; set; }

        /// <summary>
        /// Required field QUANTITY_PER_PACKAGE of the SPARE_PART 
        /// </summary>
        [Required]
        public int QUANTITY_PER_PACKAGE { get; set; }

        /// <summary>
        /// Required field ANNUAL_CONSUMPTION of the SPARE_PART 
        /// </summary>
        [Required]
        public double ANNUAL_CONSUMPTION { get; set; }

        /// <summary>
        /// Required field RECOMMENDED_NUMBER of the SPARE_PART 
        /// </summary>
        [Required]
        public double RECOMMENDED_NUMBER { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the SPARE_PART 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field IS_IMPORTANT_PART of the SPARE_PART 
        /// </summary>
        [Required]
        public bool IS_IMPORTANT_PART { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SPARE_PART 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SPARE_PART 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// LAST_COUNTED_DATE of the SPARE_PART 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_COUNTED_DATE { get; set; }

        /// <summary>
        /// CALCULATION_DATE of the SPARE_PART 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CALCULATION_DATE { get; set; }
        /// <summary>
        /// REFERENCE of the SPARE_PART 
        /// </summary>
        public string? REFERENCE { get; set; }
        /// <summary>
        /// ADDITIONAL_INFO of the SPARE_PART 
        /// </summary>
        public string? ADDITIONAL_INFO { get; set; }
        /// <summary>
        /// LOCATION of the SPARE_PART 
        /// </summary>
        public string? LOCATION { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT_X_SUPPLIER to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_COMPONENT_X_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT_X_SUPPLIER
        /// </summary>
        [ForeignKey("GUID_COMPONENT_X_SUPPLIER")]
        public COMPONENT_X_SUPPLIER? GUID_COMPONENT_X_SUPPLIER_COMPONENT_X_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER_ITEM to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER_ITEM")]
        public PURCHASE_ORDER_ITEM? GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING_DIMENSION0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING_DIMENSION0")]
        public ACCOUNTING? GUID_ACCOUNTING_DIMENSION0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING_DIMENSION1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING_DIMENSION1")]
        public ACCOUNTING? GUID_ACCOUNTING_DIMENSION1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING_DIMENSION2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING_DIMENSION2")]
        public ACCOUNTING? GUID_ACCOUNTING_DIMENSION2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING_DIMENSION3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING_DIMENSION3")]
        public ACCOUNTING? GUID_ACCOUNTING_DIMENSION3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING_DIMENSION4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING_DIMENSION4")]
        public ACCOUNTING? GUID_ACCOUNTING_DIMENSION4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
    }
}