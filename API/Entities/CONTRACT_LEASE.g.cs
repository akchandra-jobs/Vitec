using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contract_lease entity with essential details
    /// </summary>
    [Table("CONTRACT_LEASE", Schema = "dbo")]
    public class CONTRACT_LEASE
    {
        /// <summary>
        /// Initializes a new instance of the CONTRACT_LEASE class.
        /// </summary>
        public CONTRACT_LEASE()
        {
            IS_OFFICIALLY_REGISTERED = false;
            ADJUSTMENT_TYPE = 0;
            ADJUSTMENT_INTERVAL = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTRACT_LEASE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field SUM of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double SUM { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field WARRANTY_AMOUNT of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double WARRANTY_AMOUNT { get; set; }

        /// <summary>
        /// Required field IS_OFFICIALLY_REGISTERED of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public bool IS_OFFICIALLY_REGISTERED { get; set; }

        /// <summary>
        /// Required field ADJUSTMENT_TYPE of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public int ADJUSTMENT_TYPE { get; set; }

        /// <summary>
        /// Required field ADJUSTMENT_INTERVAL of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public int ADJUSTMENT_INTERVAL { get; set; }

        /// <summary>
        /// Required field ADJUSTMENT_PERCENT of the CONTRACT_LEASE 
        /// </summary>
        [Required]
        public double ADJUSTMENT_PERCENT { get; set; }
        /// <summary>
        /// TEXT11 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// LAST_ADJUSTMENT_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_ADJUSTMENT_DATE { get; set; }

        /// <summary>
        /// NEXT_ADJUSTMENT_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NEXT_ADJUSTMENT_DATE { get; set; }

        /// <summary>
        /// ADJUSTMENT_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ADJUSTMENT_DATE { get; set; }
        /// <summary>
        /// OUR_REFERENCE of the CONTRACT_LEASE 
        /// </summary>
        public string? OUR_REFERENCE { get; set; }
        /// <summary>
        /// WARRANTY_TEXT of the CONTRACT_LEASE 
        /// </summary>
        public string? WARRANTY_TEXT { get; set; }
        /// <summary>
        /// COMBO01 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the CONTRACT_LEASE 
        /// </summary>
        public string? COMBO10 { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_FORM to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_FORM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_FORM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_FORM")]
        public PAYMENT_ORDER_FORM? GUID_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM { get; set; }

        /// <summary>
        /// INVOICED_UNTIL_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? INVOICED_UNTIL_DATE { get; set; }

        /// <summary>
        /// LEASE_FROM_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LEASE_FROM_DATE { get; set; }

        /// <summary>
        /// LEASE_TO_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LEASE_TO_DATE { get; set; }
        /// <summary>
        /// KID_NR of the CONTRACT_LEASE 
        /// </summary>
        public string? KID_NR { get; set; }
        /// <summary>
        /// TEXT01 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the CONTRACT_LEASE 
        /// </summary>
        public string? TEXT10 { get; set; }

        /// <summary>
        /// DATE01 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }

        /// <summary>
        /// DATE11 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE11 { get; set; }

        /// <summary>
        /// DATE12 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE12 { get; set; }

        /// <summary>
        /// DATE13 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE13 { get; set; }

        /// <summary>
        /// DATE14 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE14 { get; set; }

        /// <summary>
        /// DATE15 of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE15 { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_TERM to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_TERM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_TERM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_TERM")]
        public PAYMENT_TERM? GUID_PAYMENT_TERM_PAYMENT_TERM { get; set; }
        /// <summary>
        /// Foreign key referencing the INVOICING to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_INVOICING { get; set; }

        /// <summary>
        /// Navigation property representing the associated INVOICING
        /// </summary>
        [ForeignKey("GUID_INVOICING")]
        public INVOICING? GUID_INVOICING_INVOICING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_CATEGORY to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_CONTRACT_CATEGORY")]
        public CONTRACT_CATEGORY? GUID_CONTRACT_CATEGORY_CONTRACT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIOD_OF_NOTICE to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_PERIOD_OF_NOTICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIOD_OF_NOTICE
        /// </summary>
        [ForeignKey("GUID_PERIOD_OF_NOTICE")]
        public PERIOD_OF_NOTICE? GUID_PERIOD_OF_NOTICE_PERIOD_OF_NOTICE { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_TYPE to which the CONTRACT_LEASE belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_TYPE
        /// </summary>
        [ForeignKey("GUID_CONTRACT_TYPE")]
        public CONTRACT_TYPE? GUID_CONTRACT_TYPE_CONTRACT_TYPE { get; set; }
        /// <summary>
        /// ID of the CONTRACT_LEASE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the CONTRACT_LEASE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CONTRACT_LEASE 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// START_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// TERMINATION_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TERMINATION_DATE { get; set; }

        /// <summary>
        /// OPTION_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? OPTION_DATE { get; set; }

        /// <summary>
        /// WARRANTY_DATE of the CONTRACT_LEASE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? WARRANTY_DATE { get; set; }
    }
}