using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a component entity with essential details
    /// </summary>
    [Table("COMPONENT", Schema = "dbo")]
    public class COMPONENT
    {
        /// <summary>
        /// Initializes a new instance of the COMPONENT class.
        /// </summary>
        public COMPONENT()
        {
            IS_RENTABLE = false;
            IS_REPAIRABLE = false;
            MAXIMUM_TOTAL_QUANTITY = 0;
            IS_DEACTIVATED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the COMPONENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_RENTABLE of the COMPONENT 
        /// </summary>
        [Required]
        public bool IS_RENTABLE { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_YEAR of the COMPONENT 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_YEAR { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_MONTH of the COMPONENT 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_MONTH { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_DAY of the COMPONENT 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_DAY { get; set; }

        /// <summary>
        /// Required field IS_REPAIRABLE of the COMPONENT 
        /// </summary>
        [Required]
        public bool IS_REPAIRABLE { get; set; }

        /// <summary>
        /// Required field MAXIMUM_TOTAL_QUANTITY of the COMPONENT 
        /// </summary>
        [Required]
        public int MAXIMUM_TOTAL_QUANTITY { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the COMPONENT 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the COMPONENT 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// UPDATED_DATE of the COMPONENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the COMPONENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the IMAGE to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_IMAGE { get; set; }

        /// <summary>
        /// Navigation property representing the associated IMAGE
        /// </summary>
        [ForeignKey("GUID_IMAGE")]
        public IMAGE? GUID_IMAGE_IMAGE { get; set; }
        /// <summary>
        /// COMBO01 of the COMPONENT 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the COMPONENT 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the COMPONENT 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the COMPONENT 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the COMPONENT 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the COMPONENT 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the COMPONENT 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the COMPONENT 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the COMPONENT 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the COMPONENT 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the COMPONENT 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the COMPONENT 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the COMPONENT 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the COMPONENT 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the COMPONENT 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the COMPONENT 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the COMPONENT 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the COMPONENT 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the COMPONENT 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the COMPONENT 
        /// </summary>
        public string? COMBO20 { get; set; }
        /// <summary>
        /// TEXT01 of the COMPONENT 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the COMPONENT 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the COMPONENT 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the COMPONENT 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the COMPONENT 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the COMPONENT 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the COMPONENT 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the COMPONENT 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the COMPONENT 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the COMPONENT 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the COMPONENT 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the COMPONENT 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the COMPONENT 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the COMPONENT 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the COMPONENT 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the COMPONENT 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the COMPONENT 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the COMPONENT 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the COMPONENT 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the COMPONENT 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// DATE01 of the COMPONENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the COMPONENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the COMPONENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the COMPONENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the COMPONENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT_CATEGORY to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_COMPONENT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_COMPONENT_CATEGORY")]
        public COMPONENT_CATEGORY? GUID_COMPONENT_CATEGORY_COMPONENT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING0")]
        public ACCOUNTING? GUID_ACCOUNTING0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING1")]
        public ACCOUNTING? GUID_ACCOUNTING1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING2")]
        public ACCOUNTING? GUID_ACCOUNTING2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING3")]
        public ACCOUNTING? GUID_ACCOUNTING3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING4")]
        public ACCOUNTING? GUID_ACCOUNTING4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_PARENT_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_PARENT_COMPONENT")]
        public COMPONENT? GUID_PARENT_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the COMPONENT belongs 
        /// </summary>
        public Guid? GUID_PREFERRED_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_PREFERRED_COMPONENT")]
        public COMPONENT? GUID_PREFERRED_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// ID of the COMPONENT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the COMPONENT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// UNIT of the COMPONENT 
        /// </summary>
        public string? UNIT { get; set; }
        /// <summary>
        /// REFERENCE of the COMPONENT 
        /// </summary>
        public string? REFERENCE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the COMPONENT 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
    }
}