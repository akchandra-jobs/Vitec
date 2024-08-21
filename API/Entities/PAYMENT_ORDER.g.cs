using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a payment_order entity with essential details
    /// </summary>
    [Table("PAYMENT_ORDER", Schema = "dbo")]
    public class PAYMENT_ORDER
    {
        /// <summary>
        /// Initializes a new instance of the PAYMENT_ORDER class.
        /// </summary>
        public PAYMENT_ORDER()
        {
            ORDER_NR = 0;
            IS_RELEASED = false;
            INVOICE_NR = 0;
            IS_PRINTED = false;
            IS_PRE_APPROVED = false;
            STATUS = -1;
            IS_FIXED_PRICE = false;
            IS_CORRECTIVE = false;
            BOOKING_STATUS = -1;
            INVOICE_STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PAYMENT_ORDER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ORDER_NR of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public int ORDER_NR { get; set; }

        /// <summary>
        /// Required field IS_RELEASED of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public bool IS_RELEASED { get; set; }

        /// <summary>
        /// Required field SUM_ORDER of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public double SUM_ORDER { get; set; }

        /// <summary>
        /// Required field INVOICE_NR of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public Int64 INVOICE_NR { get; set; }

        /// <summary>
        /// Required field IS_PRINTED of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public bool IS_PRINTED { get; set; }

        /// <summary>
        /// Required field IS_PRE_APPROVED of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public bool IS_PRE_APPROVED { get; set; }

        /// <summary>
        /// Required field STATUS of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field AGREED_PRICE of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public double AGREED_PRICE { get; set; }

        /// <summary>
        /// Required field FIXED_PRICE of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public double FIXED_PRICE { get; set; }

        /// <summary>
        /// Required field TIME_PRICE of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public double TIME_PRICE { get; set; }

        /// <summary>
        /// Required field IS_FIXED_PRICE of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public bool IS_FIXED_PRICE { get; set; }

        /// <summary>
        /// Required field IS_CORRECTIVE of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public bool IS_CORRECTIVE { get; set; }

        /// <summary>
        /// Required field BOOKING_STATUS of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public int BOOKING_STATUS { get; set; }

        /// <summary>
        /// Required field INVOICE_STATUS of the PAYMENT_ORDER 
        /// </summary>
        [Required]
        public int INVOICE_STATUS { get; set; }
        /// <summary>
        /// ERROR_MESSAGE of the PAYMENT_ORDER 
        /// </summary>
        public string? ERROR_MESSAGE { get; set; }
        /// <summary>
        /// YOUR_REFERENCE of the PAYMENT_ORDER 
        /// </summary>
        public string? YOUR_REFERENCE { get; set; }
        /// <summary>
        /// REVISION_TEXT of the PAYMENT_ORDER 
        /// </summary>
        public string? REVISION_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }

        /// <summary>
        /// PREVIOUS_INVOICE_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PREVIOUS_INVOICE_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_BOOKED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_BOOKED_BY")]
        public USR? GUID_USER_BOOKED_BY_USR { get; set; }
        /// <summary>
        /// USER_BOOKED_FOR_NAME of the PAYMENT_ORDER 
        /// </summary>
        public string? USER_BOOKED_FOR_NAME { get; set; }
        /// <summary>
        /// USER_BOOKED_FOR_DEPARTMENT of the PAYMENT_ORDER 
        /// </summary>
        public string? USER_BOOKED_FOR_DEPARTMENT { get; set; }
        /// <summary>
        /// USER_BOOKED_FOR_TELEPHONE of the PAYMENT_ORDER 
        /// </summary>
        public string? USER_BOOKED_FOR_TELEPHONE { get; set; }
        /// <summary>
        /// USER_BOOKED_FOR_EMAIL of the PAYMENT_ORDER 
        /// </summary>
        public string? USER_BOOKED_FOR_EMAIL { get; set; }

        /// <summary>
        /// DELIVERY_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DELIVERY_DATE { get; set; }
        /// <summary>
        /// KIDNR of the PAYMENT_ORDER 
        /// </summary>
        public string? KIDNR { get; set; }
        /// <summary>
        /// PROJECT_NR of the PAYMENT_ORDER 
        /// </summary>
        public string? PROJECT_NR { get; set; }
        /// <summary>
        /// INVOICE_TEXT of the PAYMENT_ORDER 
        /// </summary>
        public string? INVOICE_TEXT { get; set; }

        /// <summary>
        /// PERIOD_START_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PERIOD_START_DATE { get; set; }

        /// <summary>
        /// PERIOD_END_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PERIOD_END_DATE { get; set; }

        /// <summary>
        /// DUE_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DUE_DATE { get; set; }

        /// <summary>
        /// PAYMENT_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PAYMENT_DATE { get; set; }
        /// <summary>
        /// LOCATION of the PAYMENT_ORDER 
        /// </summary>
        public string? LOCATION { get; set; }

        /// <summary>
        /// ADJUSTMENT_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ADJUSTMENT_DATE { get; set; }
        /// <summary>
        /// ADJUSTMENT_TEXT of the PAYMENT_ORDER 
        /// </summary>
        public string? ADJUSTMENT_TEXT { get; set; }

        /// <summary>
        /// INVOICED_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? INVOICED_DATE { get; set; }
        /// <summary>
        /// OUR_REFERENCE of the PAYMENT_ORDER 
        /// </summary>
        public string? OUR_REFERENCE { get; set; }

        /// <summary>
        /// ORDER_DATE of the PAYMENT_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ORDER_DATE { get; set; }
        /// <summary>
        /// DESCRIPTION of the PAYMENT_ORDER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the PAYMENT_ORDER 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_TERM to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_TERM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_TERM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_TERM")]
        public PAYMENT_TERM? GUID_PAYMENT_TERM_PAYMENT_TERM { get; set; }
        /// <summary>
        /// Foreign key referencing the BOOKING_CATEGORY to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_BOOKING_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated BOOKING_CATEGORY
        /// </summary>
        [ForeignKey("GUID_BOOKING_CATEGORY")]
        public BOOKING_CATEGORY? GUID_BOOKING_CATEGORY_BOOKING_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the TRANSFER to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_TRANSFER { get; set; }

        /// <summary>
        /// Navigation property representing the associated TRANSFER
        /// </summary>
        [ForeignKey("GUID_TRANSFER")]
        public TRANSFER? GUID_TRANSFER_TRANSFER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER_DELIVERY_ADDRESS to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER_DELIVERY_ADDRESS { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER_DELIVERY_ADDRESS
        /// </summary>
        [ForeignKey("GUID_CUSTOMER_DELIVERY_ADDRESS")]
        public CUSTOMER_DELIVERY_ADDRESS? GUID_CUSTOMER_DELIVERY_ADDRESS_CUSTOMER_DELIVERY_ADDRESS { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_FORM to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_FORM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_FORM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_FORM")]
        public PAYMENT_ORDER_FORM? GUID_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION")]
        public ORGANIZATION? GUID_ORGANIZATION_ORGANIZATION { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the PAYMENT_ORDER belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
    }
}