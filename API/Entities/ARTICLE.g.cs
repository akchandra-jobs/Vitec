using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a article entity with essential details
    /// </summary>
    [Table("ARTICLE", Schema = "dbo")]
    public class ARTICLE
    {
        /// <summary>
        /// Initializes a new instance of the ARTICLE class.
        /// </summary>
        public ARTICLE()
        {
            HAS_LOCKED_ACCOUNTING = false;
            TYPE = -1;
            CAN_BE_RENTED_OUT = false;
            RENTAL_PERIOD_UNIT = -1;
            MERGE_IN_INVOICE = false;
            PRICE_ADJUSTMENT_TYPE = -1;
            SHOW_PRICE_ADJUSTMENT_ON_OWN_LINE = false;
            IS_EXTERNALLY_MANAGED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ARTICLE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field HAS_LOCKED_ACCOUNTING of the ARTICLE 
        /// </summary>
        [Required]
        public bool HAS_LOCKED_ACCOUNTING { get; set; }

        /// <summary>
        /// Required field TYPE of the ARTICLE 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field REGULATION_PERCENT of the ARTICLE 
        /// </summary>
        [Required]
        public double REGULATION_PERCENT { get; set; }

        /// <summary>
        /// Required field CAN_BE_RENTED_OUT of the ARTICLE 
        /// </summary>
        [Required]
        public bool CAN_BE_RENTED_OUT { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_YEAR of the ARTICLE 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_YEAR { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_MONTH of the ARTICLE 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_MONTH { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_DAY of the ARTICLE 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_DAY { get; set; }

        /// <summary>
        /// Required field RENTAL_PERIOD_NUMBER of the ARTICLE 
        /// </summary>
        [Required]
        public double RENTAL_PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field RENTAL_PERIOD_UNIT of the ARTICLE 
        /// </summary>
        [Required]
        public int RENTAL_PERIOD_UNIT { get; set; }

        /// <summary>
        /// Required field MERGE_IN_INVOICE of the ARTICLE 
        /// </summary>
        [Required]
        public bool MERGE_IN_INVOICE { get; set; }

        /// <summary>
        /// Required field PRICE_ADJUSTMENT_TYPE of the ARTICLE 
        /// </summary>
        [Required]
        public int PRICE_ADJUSTMENT_TYPE { get; set; }

        /// <summary>
        /// Required field PRICE_ADJUSTMENT_VALUE of the ARTICLE 
        /// </summary>
        [Required]
        public double PRICE_ADJUSTMENT_VALUE { get; set; }

        /// <summary>
        /// Required field SHOW_PRICE_ADJUSTMENT_ON_OWN_LINE of the ARTICLE 
        /// </summary>
        [Required]
        public bool SHOW_PRICE_ADJUSTMENT_ON_OWN_LINE { get; set; }

        /// <summary>
        /// Required field UNIT_PRICE of the ARTICLE 
        /// </summary>
        [Required]
        public double UNIT_PRICE { get; set; }

        /// <summary>
        /// Required field COST_PRICE of the ARTICLE 
        /// </summary>
        [Required]
        public double COST_PRICE { get; set; }

        /// <summary>
        /// Required field IS_EXTERNALLY_MANAGED of the ARTICLE 
        /// </summary>
        [Required]
        public bool IS_EXTERNALLY_MANAGED { get; set; }
        /// <summary>
        /// UNIT of the ARTICLE 
        /// </summary>
        public string? UNIT { get; set; }

        /// <summary>
        /// DISABLED_FROM_DATE of the ARTICLE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DISABLED_FROM_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ARTICLE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ARTICLE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING0")]
        public ACCOUNTING? GUID_ACCOUNTING0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING1")]
        public ACCOUNTING? GUID_ACCOUNTING1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING2")]
        public ACCOUNTING? GUID_ACCOUNTING2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING3")]
        public ACCOUNTING? GUID_ACCOUNTING3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING4")]
        public ACCOUNTING? GUID_ACCOUNTING4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the ARTICLE belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }
        /// <summary>
        /// ID of the ARTICLE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ARTICLE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}