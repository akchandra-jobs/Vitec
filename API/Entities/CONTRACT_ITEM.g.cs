using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contract_item entity with essential details
    /// </summary>
    [Table("CONTRACT_ITEM", Schema = "dbo")]
    public class CONTRACT_ITEM
    {
        /// <summary>
        /// Initializes a new instance of the CONTRACT_ITEM class.
        /// </summary>
        public CONTRACT_ITEM()
        {
            ENTITY_TYPE = -1;
            IS_CREDIT = false;
            IS_INVOICED = false;
            IS_ONE_TIME = false;
            IS_CURRENT_VERSION = false;
            VERSION = 0;
            CAN_BE_ADJUSTED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTRACT_ITEM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field QUANTITY of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public double QUANTITY { get; set; }

        /// <summary>
        /// Required field UNIT_PRICE of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public double UNIT_PRICE { get; set; }

        /// <summary>
        /// Required field SHARE_PERCENT of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public double SHARE_PERCENT { get; set; }

        /// <summary>
        /// Required field IS_CREDIT of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public bool IS_CREDIT { get; set; }

        /// <summary>
        /// Required field IS_INVOICED of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public bool IS_INVOICED { get; set; }

        /// <summary>
        /// Required field IS_ONE_TIME of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public bool IS_ONE_TIME { get; set; }

        /// <summary>
        /// Required field IS_CURRENT_VERSION of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public bool IS_CURRENT_VERSION { get; set; }

        /// <summary>
        /// Required field VERSION of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public int VERSION { get; set; }

        /// <summary>
        /// Required field CAN_BE_ADJUSTED of the CONTRACT_ITEM 
        /// </summary>
        [Required]
        public bool CAN_BE_ADJUSTED { get; set; }
        /// <summary>
        /// UNIT of the CONTRACT_ITEM 
        /// </summary>
        public string? UNIT { get; set; }

        /// <summary>
        /// INVOICED_UNTIL_DATE of the CONTRACT_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? INVOICED_UNTIL_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTRACT_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTRACT_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_PREVIOUS_VERSION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_PREVIOUS_VERSION")]
        public CONTRACT_ITEM? GUID_PREVIOUS_VERSION_CONTRACT_ITEM { get; set; }
        /// <summary>
        /// VERSION_COMMENT of the CONTRACT_ITEM 
        /// </summary>
        public string? VERSION_COMMENT { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CONTRACT_ITEM 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_MASTER_RECORD { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_MASTER_RECORD")]
        public CONTRACT_ITEM? GUID_MASTER_RECORD_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// START_DATE of the CONTRACT_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the CONTRACT_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// EFFECTIVE_START_DATE of the CONTRACT_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EFFECTIVE_START_DATE { get; set; }

        /// <summary>
        /// EFFECTIVE_END_DATE of the CONTRACT_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EFFECTIVE_END_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_CATEGORY to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_AREA_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_CATEGORY
        /// </summary>
        [ForeignKey("GUID_AREA_CATEGORY")]
        public AREA_CATEGORY? GUID_AREA_CATEGORY_AREA_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the ARTICLE to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ARTICLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ARTICLE
        /// </summary>
        [ForeignKey("GUID_ARTICLE")]
        public ARTICLE? GUID_ARTICLE_ARTICLE { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING0")]
        public ACCOUNTING? GUID_ACCOUNTING0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING1")]
        public ACCOUNTING? GUID_ACCOUNTING1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING2")]
        public ACCOUNTING? GUID_ACCOUNTING2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING3")]
        public ACCOUNTING? GUID_ACCOUNTING3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING4")]
        public ACCOUNTING? GUID_ACCOUNTING4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION")]
        public ORGANIZATION? GUID_ORGANIZATION_ORGANIZATION { get; set; }
        /// <summary>
        /// Foreign key referencing the PRICE_SHEET_REVISION to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_PRICE_SHEET_REVISION { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRICE_SHEET_REVISION
        /// </summary>
        [ForeignKey("GUID_PRICE_SHEET_REVISION")]
        public PRICE_SHEET_REVISION? GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the CONTRACT_ITEM belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }
        /// <summary>
        /// ID of the CONTRACT_ITEM 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the CONTRACT_ITEM 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}