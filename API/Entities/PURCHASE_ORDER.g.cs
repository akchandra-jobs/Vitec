using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a purchase_order entity with essential details
    /// </summary>
    [Table("PURCHASE_ORDER", Schema = "dbo")]
    public class PURCHASE_ORDER
    {
        /// <summary>
        /// Initializes a new instance of the PURCHASE_ORDER class.
        /// </summary>
        public PURCHASE_ORDER()
        {
            HAS_AUTO_ORDERING = false;
            STATUS = 0;
            IS_CONFIRMED = false;
            IS_CLOSED = false;
            IS_FORCED_RECEIVED = false;
            IS_LOCKED_PROPOSAL = false;
            FORM_NUMBER = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PURCHASE_ORDER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field HAS_AUTO_ORDERING of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public bool HAS_AUTO_ORDERING { get; set; }

        /// <summary>
        /// Required field AMOUNT of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public double AMOUNT { get; set; }

        /// <summary>
        /// Required field STATUS of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field IS_CONFIRMED of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public bool IS_CONFIRMED { get; set; }

        /// <summary>
        /// Required field IS_CLOSED of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public bool IS_CLOSED { get; set; }

        /// <summary>
        /// Required field IS_FORCED_RECEIVED of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public bool IS_FORCED_RECEIVED { get; set; }

        /// <summary>
        /// Required field IS_LOCKED_PROPOSAL of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public bool IS_LOCKED_PROPOSAL { get; set; }

        /// <summary>
        /// Required field FORM_NUMBER of the PURCHASE_ORDER 
        /// </summary>
        [Required]
        public int FORM_NUMBER { get; set; }
        /// <summary>
        /// NOTE of the PURCHASE_ORDER 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PURCHASE_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PURCHASE_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the ALARM_LOG to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_ALARM_LOG { get; set; }

        /// <summary>
        /// Navigation property representing the associated ALARM_LOG
        /// </summary>
        [ForeignKey("GUID_ALARM_LOG")]
        public ALARM_LOG? GUID_ALARM_LOG_ALARM_LOG { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the PURCHASE_ORDER 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }

        /// <summary>
        /// BUDGET_DATE of the PURCHASE_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? BUDGET_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_TERM to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_TERM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_TERM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_TERM")]
        public PAYMENT_TERM? GUID_PAYMENT_TERM_PAYMENT_TERM { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_PRINTED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_PRINTED_BY")]
        public USR? GUID_USER_PRINTED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_RECEIVED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_RECEIVED_BY")]
        public USR? GUID_USER_RECEIVED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER_AGREEMENT to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER_AGREEMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER_AGREEMENT
        /// </summary>
        [ForeignKey("GUID_SUPPLIER_AGREEMENT")]
        public SUPPLIER_AGREEMENT? GUID_SUPPLIER_AGREEMENT_SUPPLIER_AGREEMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the DELIVERY_TERM to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_DELIVERY_TERM { get; set; }

        /// <summary>
        /// Navigation property representing the associated DELIVERY_TERM
        /// </summary>
        [ForeignKey("GUID_DELIVERY_TERM")]
        public DELIVERY_TERM? GUID_DELIVERY_TERM_DELIVERY_TERM { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER_FORM to which the PURCHASE_ORDER belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER_FORM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER_FORM
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER_FORM")]
        public PURCHASE_ORDER_FORM? GUID_PURCHASE_ORDER_FORM_PURCHASE_ORDER_FORM { get; set; }
        /// <summary>
        /// ID of the PURCHASE_ORDER 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PURCHASE_ORDER 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// ORDERING_DATE of the PURCHASE_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ORDERING_DATE { get; set; }

        /// <summary>
        /// DELIVERY_DATE of the PURCHASE_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DELIVERY_DATE { get; set; }
        /// <summary>
        /// OUR_REFERENCE of the PURCHASE_ORDER 
        /// </summary>
        public string? OUR_REFERENCE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the PURCHASE_ORDER 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
    }
}