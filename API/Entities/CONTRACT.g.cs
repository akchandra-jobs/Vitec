using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contract entity with essential details
    /// </summary>
    [Table("CONTRACT", Schema = "dbo")]
    public class CONTRACT
    {
        /// <summary>
        /// Initializes a new instance of the CONTRACT class.
        /// </summary>
        public CONTRACT()
        {
            STATUS = -1;
            RENTAL_TYPE = -1;
            IS_INVOICEABLE = false;
            USE_PRICE_SHEET = false;
            RENTAL_TYPE_PERIOD = -1;
            STATUS_APPLICATION = -1;
            DIRTY_FLAG = 0;
            CREDIT_OBJECT_COUNT = 0;
            APPROVAL_STATUS = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTRACT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the CONTRACT 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field RENTAL_TYPE of the CONTRACT 
        /// </summary>
        [Required]
        public int RENTAL_TYPE { get; set; }

        /// <summary>
        /// Required field PRICE_SUM_EQUIPMENT of the CONTRACT 
        /// </summary>
        [Required]
        public double PRICE_SUM_EQUIPMENT { get; set; }

        /// <summary>
        /// Required field PRICE_SUM_AREA of the CONTRACT 
        /// </summary>
        [Required]
        public double PRICE_SUM_AREA { get; set; }

        /// <summary>
        /// Required field PRICE_SUM_ARTICLE of the CONTRACT 
        /// </summary>
        [Required]
        public double PRICE_SUM_ARTICLE { get; set; }

        /// <summary>
        /// Required field PRICE_SUM_COMPONENT of the CONTRACT 
        /// </summary>
        [Required]
        public double PRICE_SUM_COMPONENT { get; set; }

        /// <summary>
        /// Required field PRICE_SUM_TOTAL of the CONTRACT 
        /// </summary>
        [Required]
        public double PRICE_SUM_TOTAL { get; set; }

        /// <summary>
        /// Required field IS_INVOICEABLE of the CONTRACT 
        /// </summary>
        [Required]
        public bool IS_INVOICEABLE { get; set; }

        /// <summary>
        /// Required field USE_PRICE_SHEET of the CONTRACT 
        /// </summary>
        [Required]
        public bool USE_PRICE_SHEET { get; set; }

        /// <summary>
        /// Required field ROOM_PRICE of the CONTRACT 
        /// </summary>
        [Required]
        public double ROOM_PRICE { get; set; }

        /// <summary>
        /// Required field RENTAL_TYPE_PERIOD of the CONTRACT 
        /// </summary>
        [Required]
        public int RENTAL_TYPE_PERIOD { get; set; }

        /// <summary>
        /// Required field STATUS_APPLICATION of the CONTRACT 
        /// </summary>
        [Required]
        public int STATUS_APPLICATION { get; set; }

        /// <summary>
        /// Required field DIRTY_FLAG of the CONTRACT 
        /// </summary>
        [Required]
        public int DIRTY_FLAG { get; set; }

        /// <summary>
        /// Required field CREDIT_OBJECT_COUNT of the CONTRACT 
        /// </summary>
        [Required]
        public int CREDIT_OBJECT_COUNT { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the CONTRACT 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the CONTRACT 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the CONTRACT 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the CONTRACT 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the CONTRACT 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field APPROVAL_STATUS of the CONTRACT 
        /// </summary>
        [Required]
        public int APPROVAL_STATUS { get; set; }

        /// <summary>
        /// Required field TOTAL_ANNUAL_VALUE of the CONTRACT 
        /// </summary>
        [Required]
        public double TOTAL_ANNUAL_VALUE { get; set; }
        /// <summary>
        /// APPROVAL_COMMENT of the CONTRACT 
        /// </summary>
        public string? APPROVAL_COMMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_APPROVAL_STATUS_MODIFIED_BY_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_APPROVAL_STATUS_MODIFIED_BY_USER")]
        public USR? GUID_APPROVAL_STATUS_MODIFIED_BY_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ADJUSTMENT to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_LAST_CONTRACT_ADJUSTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ADJUSTMENT
        /// </summary>
        [ForeignKey("GUID_LAST_CONTRACT_ADJUSTMENT")]
        public CONTRACT_ADJUSTMENT? GUID_LAST_CONTRACT_ADJUSTMENT_CONTRACT_ADJUSTMENT { get; set; }
        /// <summary>
        /// COMBO01 of the CONTRACT 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the CONTRACT 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the CONTRACT 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the CONTRACT 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the CONTRACT 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the CONTRACT 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the CONTRACT 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the CONTRACT 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the CONTRACT 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the CONTRACT 
        /// </summary>
        public string? COMBO10 { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TEXT11 of the CONTRACT 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the CONTRACT 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the CONTRACT 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the CONTRACT 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the CONTRACT 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the CONTRACT 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the CONTRACT 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the CONTRACT 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the CONTRACT 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the CONTRACT 
        /// </summary>
        public string? TEXT20 { get; set; }
        /// <summary>
        /// YOUR_REFERENCE of the CONTRACT 
        /// </summary>
        public string? YOUR_REFERENCE { get; set; }
        /// <summary>
        /// REVISION_TEXT of the CONTRACT 
        /// </summary>
        public string? REVISION_TEXT { get; set; }

        /// <summary>
        /// REVISION_TEXT_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REVISION_TEXT_DATE { get; set; }
        /// <summary>
        /// TEXT01 of the CONTRACT 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the CONTRACT 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the CONTRACT 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the CONTRACT 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the CONTRACT 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the CONTRACT 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the CONTRACT 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the CONTRACT 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the CONTRACT 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the CONTRACT 
        /// </summary>
        public string? TEXT10 { get; set; }

        /// <summary>
        /// DATE01 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }

        /// <summary>
        /// DATE11 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE11 { get; set; }

        /// <summary>
        /// DATE12 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE12 { get; set; }

        /// <summary>
        /// DATE13 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE13 { get; set; }

        /// <summary>
        /// DATE14 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE14 { get; set; }

        /// <summary>
        /// DATE15 of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE15 { get; set; }

        /// <summary>
        /// APPLICATION_REGISTERED_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? APPLICATION_REGISTERED_DATE { get; set; }

        /// <summary>
        /// REFUSAL_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REFUSAL_DATE { get; set; }

        /// <summary>
        /// APPROVAL_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? APPROVAL_DATE { get; set; }

        /// <summary>
        /// ALLOCATION_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ALLOCATION_DATE { get; set; }

        /// <summary>
        /// LAST_ADJUSTMENT_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_ADJUSTMENT_DATE { get; set; }

        /// <summary>
        /// ADJUSTMENT_REFERENCE_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ADJUSTMENT_REFERENCE_DATE { get; set; }

        /// <summary>
        /// CHECKOUT_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CHECKOUT_DATE { get; set; }

        /// <summary>
        /// PRICE_SUM_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PRICE_SUM_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_TERM to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_TERM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_TERM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_TERM")]
        public PAYMENT_TERM? GUID_PAYMENT_TERM_PAYMENT_TERM { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_USER_CHECKOUT_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CHECKOUT_BY")]
        public USR? GUID_USER_CHECKOUT_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ADJUSTMENT to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ADJUSTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ADJUSTMENT
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ADJUSTMENT")]
        public CONTRACT_ADJUSTMENT? GUID_CONTRACT_ADJUSTMENT_CONTRACT_ADJUSTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the INVOICING to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_INVOICING { get; set; }

        /// <summary>
        /// Navigation property representing the associated INVOICING
        /// </summary>
        [ForeignKey("GUID_INVOICING")]
        public INVOICING? GUID_INVOICING_INVOICING { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_FORM to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_FORM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_FORM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_FORM")]
        public PAYMENT_ORDER_FORM? GUID_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_CATEGORY to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_AREA_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_CATEGORY
        /// </summary>
        [ForeignKey("GUID_AREA_CATEGORY")]
        public AREA_CATEGORY? GUID_AREA_CATEGORY_AREA_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_CATEGORY to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_CONTRACT_CATEGORY")]
        public CONTRACT_CATEGORY? GUID_CONTRACT_CATEGORY_CONTRACT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_TYPE to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_TYPE
        /// </summary>
        [ForeignKey("GUID_CONTRACT_TYPE")]
        public CONTRACT_TYPE? GUID_CONTRACT_TYPE_CONTRACT_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER_DELIVERY_ADDRESS to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER_DELIVERY_ADDRESS { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER_DELIVERY_ADDRESS
        /// </summary>
        [ForeignKey("GUID_CUSTOMER_DELIVERY_ADDRESS")]
        public CUSTOMER_DELIVERY_ADDRESS? GUID_CUSTOMER_DELIVERY_ADDRESS_CUSTOMER_DELIVERY_ADDRESS { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIOD_OF_NOTICE to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_PERIOD_OF_NOTICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIOD_OF_NOTICE
        /// </summary>
        [ForeignKey("GUID_PERIOD_OF_NOTICE")]
        public PERIOD_OF_NOTICE? GUID_PERIOD_OF_NOTICE_PERIOD_OF_NOTICE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the CONTRACT belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
        /// <summary>
        /// ID of the CONTRACT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the CONTRACT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// OUR_REFERENCE of the CONTRACT 
        /// </summary>
        public string? OUR_REFERENCE { get; set; }
        /// <summary>
        /// PLACEMENT of the CONTRACT 
        /// </summary>
        public string? PLACEMENT { get; set; }

        /// <summary>
        /// START_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// SCHEDULED_END_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SCHEDULED_END_DATE { get; set; }

        /// <summary>
        /// END_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// INVOICED_UNTIL_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? INVOICED_UNTIL_DATE { get; set; }

        /// <summary>
        /// NEXT_INVOICED_UNTIL_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NEXT_INVOICED_UNTIL_DATE { get; set; }

        /// <summary>
        /// ORDER_DATE of the CONTRACT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ORDER_DATE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CONTRACT 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// INVOICE_TEXT of the CONTRACT 
        /// </summary>
        public string? INVOICE_TEXT { get; set; }
    }
}