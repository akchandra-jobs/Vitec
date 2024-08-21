using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a customer entity with essential details
    /// </summary>
    [Table("CUSTOMER", Schema = "dbo")]
    public class CUSTOMER
    {
        /// <summary>
        /// Initializes a new instance of the CUSTOMER class.
        /// </summary>
        public CUSTOMER()
        {
            TYPE = 0;
            HATCHING_PATTERN = 0;
            COLOR = 0;
            CUSTOMER_NR = 0;
            MARITAL_STATUS = -1;
            NUMBER_PERSONS_HOUSEHOLD = 0;
            NATIONALITY = -1;
            IS_ADDRESS_LOCKED = false;
            CUSTOMER_TYPE = -1;
            IS_DEACTIVATED = false;
            IS_ADDRESS_CONFIDENTIAL = false;
            ANONYMIZATION_ACTION = -1;
            CAN_BE_INVOICE_RECIPIENT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
            AGRESSO = "I";
        }

        /// <summary>
        /// Primary key for the CUSTOMER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field TYPE of the CUSTOMER 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field HATCHING_PATTERN of the CUSTOMER 
        /// </summary>
        [Required]
        public int HATCHING_PATTERN { get; set; }

        /// <summary>
        /// Required field COLOR of the CUSTOMER 
        /// </summary>
        [Required]
        public int COLOR { get; set; }

        /// <summary>
        /// Required field CUSTOMER_NR of the CUSTOMER 
        /// </summary>
        [Required]
        public int CUSTOMER_NR { get; set; }

        /// <summary>
        /// Required field MARITAL_STATUS of the CUSTOMER 
        /// </summary>
        [Required]
        public int MARITAL_STATUS { get; set; }

        /// <summary>
        /// Required field NUMBER_PERSONS_HOUSEHOLD of the CUSTOMER 
        /// </summary>
        [Required]
        public int NUMBER_PERSONS_HOUSEHOLD { get; set; }

        /// <summary>
        /// Required field NATIONALITY of the CUSTOMER 
        /// </summary>
        [Required]
        public int NATIONALITY { get; set; }

        /// <summary>
        /// Required field IS_ADDRESS_LOCKED of the CUSTOMER 
        /// </summary>
        [Required]
        public bool IS_ADDRESS_LOCKED { get; set; }

        /// <summary>
        /// Required field CUSTOMER_TYPE of the CUSTOMER 
        /// </summary>
        [Required]
        public int CUSTOMER_TYPE { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the CUSTOMER 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field IS_ADDRESS_CONFIDENTIAL of the CUSTOMER 
        /// </summary>
        [Required]
        public bool IS_ADDRESS_CONFIDENTIAL { get; set; }

        /// <summary>
        /// Required field ANONYMIZATION_ACTION of the CUSTOMER 
        /// </summary>
        [Required]
        public int ANONYMIZATION_ACTION { get; set; }

        /// <summary>
        /// Required field CAN_BE_INVOICE_RECIPIENT of the CUSTOMER 
        /// </summary>
        [Required]
        public bool CAN_BE_INVOICE_RECIPIENT { get; set; }
        /// <summary>
        /// CELL_PHONE of the CUSTOMER 
        /// </summary>
        public string? CELL_PHONE { get; set; }

        /// <summary>
        /// ANONYMIZATION_DATE of the CUSTOMER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ANONYMIZATION_DATE { get; set; }

        /// <summary>
        /// EXPECTED_ANONYMIZATION_DATE of the CUSTOMER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXPECTED_ANONYMIZATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER_DELIVERY_ADDRESS to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER_DELIVERY_ADDRESS { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER_DELIVERY_ADDRESS
        /// </summary>
        [ForeignKey("GUID_CUSTOMER_DELIVERY_ADDRESS")]
        public CUSTOMER_DELIVERY_ADDRESS? GUID_CUSTOMER_DELIVERY_ADDRESS_CUSTOMER_DELIVERY_ADDRESS { get; set; }
        /// <summary>
        /// LANGUAGE of the CUSTOMER 
        /// </summary>
        public string? LANGUAGE { get; set; }

        /// <summary>
        /// DATE_OF_DEATH of the CUSTOMER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE_OF_DEATH { get; set; }
        /// <summary>
        /// ANONYMIZATION_COMMENT of the CUSTOMER 
        /// </summary>
        public string? ANONYMIZATION_COMMENT { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the CUSTOMER 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }
        /// <summary>
        /// MAILING_STREET_ADDRESS of the CUSTOMER 
        /// </summary>
        public string? MAILING_STREET_ADDRESS { get; set; }
        /// <summary>
        /// MAILING_POSTAL_ADDRESS of the CUSTOMER 
        /// </summary>
        public string? MAILING_POSTAL_ADDRESS { get; set; }
        /// <summary>
        /// MAILING_POSTAL_CODE of the CUSTOMER 
        /// </summary>
        public string? MAILING_POSTAL_CODE { get; set; }
        /// <summary>
        /// MAILING_POSTAL_AREA of the CUSTOMER 
        /// </summary>
        public string? MAILING_POSTAL_AREA { get; set; }
        /// <summary>
        /// MAILING_COUNTRY of the CUSTOMER 
        /// </summary>
        public string? MAILING_COUNTRY { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CUSTOMER 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CUSTOMER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CUSTOMER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// DIVISION of the CUSTOMER 
        /// </summary>
        public string? DIVISION { get; set; }
        /// <summary>
        /// AGRESSO of the CUSTOMER 
        /// </summary>
        public string? AGRESSO { get; set; }
        /// <summary>
        /// INVOICE_STREET_ADDRESS of the CUSTOMER 
        /// </summary>
        public string? INVOICE_STREET_ADDRESS { get; set; }
        /// <summary>
        /// INVOICE_POSTAL_ADDRESS of the CUSTOMER 
        /// </summary>
        public string? INVOICE_POSTAL_ADDRESS { get; set; }
        /// <summary>
        /// INVOICE_POSTAL_CODE of the CUSTOMER 
        /// </summary>
        public string? INVOICE_POSTAL_CODE { get; set; }
        /// <summary>
        /// INVOICE_POSTAL_AREA of the CUSTOMER 
        /// </summary>
        public string? INVOICE_POSTAL_AREA { get; set; }
        /// <summary>
        /// INVOICE_COUNTRY of the CUSTOMER 
        /// </summary>
        public string? INVOICE_COUNTRY { get; set; }
        /// <summary>
        /// EMAIL of the CUSTOMER 
        /// </summary>
        public string? EMAIL { get; set; }
        /// <summary>
        /// COMPANY_NR of the CUSTOMER 
        /// </summary>
        public string? COMPANY_NR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER_LINE_OF_BUSINESS to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_LINE_OF_BUSINESS { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER_LINE_OF_BUSINESS
        /// </summary>
        [ForeignKey("GUID_LINE_OF_BUSINESS")]
        public CUSTOMER_LINE_OF_BUSINESS? GUID_LINE_OF_BUSINESS_CUSTOMER_LINE_OF_BUSINESS { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER_CATEGORY to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER_CATEGORY
        /// </summary>
        [ForeignKey("GUID_CUSTOMER_CATEGORY")]
        public CUSTOMER_CATEGORY? GUID_CUSTOMER_CATEGORY_CUSTOMER_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER_GROUP to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER_GROUP
        /// </summary>
        [ForeignKey("GUID_CUSTOMER_GROUP")]
        public CUSTOMER_GROUP? GUID_CUSTOMER_GROUP_CUSTOMER_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_INVOICE_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_INVOICE_CUSTOMER")]
        public CUSTOMER? GUID_INVOICE_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the POSTAL_CODE to which the CUSTOMER belongs 
        /// </summary>
        public Guid? GUID_POST { get; set; }

        /// <summary>
        /// Navigation property representing the associated POSTAL_CODE
        /// </summary>
        [ForeignKey("GUID_POST")]
        public POSTAL_CODE? GUID_POST_POSTAL_CODE { get; set; }
        /// <summary>
        /// ID of the CUSTOMER 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the CUSTOMER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// STREET_ADDRESS of the CUSTOMER 
        /// </summary>
        public string? STREET_ADDRESS { get; set; }
        /// <summary>
        /// POSTAL_ADDRESS of the CUSTOMER 
        /// </summary>
        public string? POSTAL_ADDRESS { get; set; }
        /// <summary>
        /// POSTAL_CODE of the CUSTOMER 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the CUSTOMER 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// TELEPHONE of the CUSTOMER 
        /// </summary>
        public string? TELEPHONE { get; set; }
        /// <summary>
        /// TELEFAX of the CUSTOMER 
        /// </summary>
        public string? TELEFAX { get; set; }
        /// <summary>
        /// COUNTRY of the CUSTOMER 
        /// </summary>
        public string? COUNTRY { get; set; }
    }
}