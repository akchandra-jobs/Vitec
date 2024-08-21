using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a data_owner entity with essential details
    /// </summary>
    [Table("DATA_OWNER", Schema = "dbo")]
    public class DATA_OWNER
    {
        /// <summary>
        /// Initializes a new instance of the DATA_OWNER class.
        /// </summary>
        public DATA_OWNER()
        {
            DEPARTMENT_BUDGET = false;
            DEPARTMENT_COST = false;
            LAST_DIMENSION_BUDGET = 0;
            LAST_DIMENSION_COST = 0;
            ACTIVITY_PERIOD_UNIT = -1;
            BUDGET_YEAR = 0;
            ENERGY_PERIOD_UNIT = -1;
            MUNICIPALITY_NUMBER = 0;
            COUNTRY_CODE = -1;
            CREATION_DATE = DateTime.UtcNow;
            LANGUAGE = "Norwegian";
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DATA_OWNER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field DEPARTMENT_BUDGET of the DATA_OWNER 
        /// </summary>
        [Required]
        public bool DEPARTMENT_BUDGET { get; set; }

        /// <summary>
        /// Required field DEPARTMENT_COST of the DATA_OWNER 
        /// </summary>
        [Required]
        public bool DEPARTMENT_COST { get; set; }

        /// <summary>
        /// Required field LAST_DIMENSION_BUDGET of the DATA_OWNER 
        /// </summary>
        [Required]
        public int LAST_DIMENSION_BUDGET { get; set; }

        /// <summary>
        /// Required field LAST_DIMENSION_COST of the DATA_OWNER 
        /// </summary>
        [Required]
        public int LAST_DIMENSION_COST { get; set; }

        /// <summary>
        /// Required field ACTIVITY_PERIOD_UNIT of the DATA_OWNER 
        /// </summary>
        [Required]
        public int ACTIVITY_PERIOD_UNIT { get; set; }

        /// <summary>
        /// Required field BUDGET_YEAR of the DATA_OWNER 
        /// </summary>
        [Required]
        public int BUDGET_YEAR { get; set; }

        /// <summary>
        /// Required field ENERGY_PERIOD_NUMBER of the DATA_OWNER 
        /// </summary>
        [Required]
        public double ENERGY_PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field ENERGY_PERIOD_UNIT of the DATA_OWNER 
        /// </summary>
        [Required]
        public int ENERGY_PERIOD_UNIT { get; set; }

        /// <summary>
        /// Required field ACTIVITY_PERIOD_NUMBER of the DATA_OWNER 
        /// </summary>
        [Required]
        public double ACTIVITY_PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field INTEREST_RATE of the DATA_OWNER 
        /// </summary>
        [Required]
        public double INTEREST_RATE { get; set; }

        /// <summary>
        /// Required field TRANSACTION_COST of the DATA_OWNER 
        /// </summary>
        [Required]
        public double TRANSACTION_COST { get; set; }

        /// <summary>
        /// Required field VAT_RATE of the DATA_OWNER 
        /// </summary>
        [Required]
        public double VAT_RATE { get; set; }

        /// <summary>
        /// Required field HOURS_PER_YEAR of the DATA_OWNER 
        /// </summary>
        [Required]
        public double HOURS_PER_YEAR { get; set; }

        /// <summary>
        /// Required field MUNICIPALITY_NUMBER of the DATA_OWNER 
        /// </summary>
        [Required]
        public int MUNICIPALITY_NUMBER { get; set; }

        /// <summary>
        /// Required field COUNTRY_CODE of the DATA_OWNER 
        /// </summary>
        [Required]
        public int COUNTRY_CODE { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT_CATEGORY to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER_EMAIL_DOCUMENT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER_EMAIL_DOCUMENT_CATEGORY")]
        public DOCUMENT_CATEGORY? GUID_WORK_ORDER_EMAIL_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT_TYPE to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_DEFAULT_EMAIL_DOCUMENT_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT_TYPE
        /// </summary>
        [ForeignKey("GUID_DEFAULT_EMAIL_DOCUMENT_TYPE")]
        public DOCUMENT_TYPE? GUID_DEFAULT_EMAIL_DOCUMENT_TYPE_DOCUMENT_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT_CATEGORY to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER_EMAIL_DOCUMENT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER_EMAIL_DOCUMENT_CATEGORY")]
        public DOCUMENT_CATEGORY? GUID_PURCHASE_ORDER_EMAIL_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY { get; set; }
        /// <summary>
        /// COMPANY of the DATA_OWNER 
        /// </summary>
        public string? COMPANY { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT_CATEGORY to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_WO_X_EQ_DOCUMENT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_WO_X_EQ_DOCUMENT_CATEGORY")]
        public DOCUMENT_CATEGORY? GUID_WO_X_EQ_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the IMAGE to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_IMAGE_LOGO { get; set; }

        /// <summary>
        /// Navigation property representing the associated IMAGE
        /// </summary>
        [ForeignKey("GUID_IMAGE_LOGO")]
        public IMAGE? GUID_IMAGE_LOGO_IMAGE { get; set; }
        /// <summary>
        /// COMMON_LABELS of the DATA_OWNER 
        /// </summary>
        public string? COMMON_LABELS { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the DATA_OWNER 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT_TYPE to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_DEFAULT_DOCUMENT_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT_TYPE
        /// </summary>
        [ForeignKey("GUID_DEFAULT_DOCUMENT_TYPE")]
        public DOCUMENT_TYPE? GUID_DEFAULT_DOCUMENT_TYPE_DOCUMENT_TYPE { get; set; }
        /// <summary>
        /// GIS_URL of the DATA_OWNER 
        /// </summary>
        public string? GIS_URL { get; set; }
        /// <summary>
        /// GIS_URL2 of the DATA_OWNER 
        /// </summary>
        public string? GIS_URL2 { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DATA_OWNER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// EXTRA of the DATA_OWNER 
        /// </summary>
        public string? EXTRA { get; set; }

        /// <summary>
        /// ENERGY_PERIOD_DATE of the DATA_OWNER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ENERGY_PERIOD_DATE { get; set; }
        /// <summary>
        /// ID of the DATA_OWNER 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// TRANSFER_PATH of the DATA_OWNER 
        /// </summary>
        public string? TRANSFER_PATH { get; set; }

        /// <summary>
        /// ACTIVITY_PERIOD_DATE of the DATA_OWNER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ACTIVITY_PERIOD_DATE { get; set; }
        /// <summary>
        /// DESCRIPTION of the DATA_OWNER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// DIMENSION1 of the DATA_OWNER 
        /// </summary>
        public string? DIMENSION1 { get; set; }
        /// <summary>
        /// DIMENSION2 of the DATA_OWNER 
        /// </summary>
        public string? DIMENSION2 { get; set; }
        /// <summary>
        /// DIMENSION3 of the DATA_OWNER 
        /// </summary>
        public string? DIMENSION3 { get; set; }
        /// <summary>
        /// DIMENSION4 of the DATA_OWNER 
        /// </summary>
        public string? DIMENSION4 { get; set; }
        /// <summary>
        /// DIMENSION5 of the DATA_OWNER 
        /// </summary>
        public string? DIMENSION5 { get; set; }
        /// <summary>
        /// LANGUAGE of the DATA_OWNER 
        /// </summary>
        public string? LANGUAGE { get; set; }
        /// <summary>
        /// ADDRESS of the DATA_OWNER 
        /// </summary>
        public string? ADDRESS { get; set; }
        /// <summary>
        /// POSTBOX of the DATA_OWNER 
        /// </summary>
        public string? POSTBOX { get; set; }
        /// <summary>
        /// POSTAL_CODE of the DATA_OWNER 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the DATA_OWNER 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// TELEPHONE of the DATA_OWNER 
        /// </summary>
        public string? TELEPHONE { get; set; }
        /// <summary>
        /// TELEFAX of the DATA_OWNER 
        /// </summary>
        public string? TELEFAX { get; set; }
        /// <summary>
        /// EMAIL of the DATA_OWNER 
        /// </summary>
        public string? EMAIL { get; set; }
        /// <summary>
        /// WEB_ADDRESS of the DATA_OWNER 
        /// </summary>
        public string? WEB_ADDRESS { get; set; }
        /// <summary>
        /// ORGANIZATION_NR of the DATA_OWNER 
        /// </summary>
        public string? ORGANIZATION_NR { get; set; }
        /// <summary>
        /// TEXT01 of the DATA_OWNER 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the DATA_OWNER 
        /// </summary>
        public string? TEXT02 { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DATA_OWNER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// COUNTRY of the DATA_OWNER 
        /// </summary>
        public string? COUNTRY { get; set; }
    }
}