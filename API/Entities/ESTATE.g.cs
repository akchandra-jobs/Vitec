using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a estate entity with essential details
    /// </summary>
    [Table("ESTATE", Schema = "dbo")]
    public class ESTATE
    {
        /// <summary>
        /// Initializes a new instance of the ESTATE class.
        /// </summary>
        public ESTATE()
        {
            IS_DEACTIVATED = false;
            COUNTRY_CODE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field COMMON_AREA of the ESTATE 
        /// </summary>
        [Required]
        public double COMMON_AREA { get; set; }

        /// <summary>
        /// Required field NON_COMMON_AREA of the ESTATE 
        /// </summary>
        [Required]
        public double NON_COMMON_AREA { get; set; }

        /// <summary>
        /// Required field COMMON_AREA_FACTOR of the ESTATE 
        /// </summary>
        [Required]
        public double COMMON_AREA_FACTOR { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field NUMBER11 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER11 { get; set; }

        /// <summary>
        /// Required field NUMBER12 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER12 { get; set; }

        /// <summary>
        /// Required field NUMBER13 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER13 { get; set; }

        /// <summary>
        /// Required field NUMBER14 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER14 { get; set; }

        /// <summary>
        /// Required field NUMBER15 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER15 { get; set; }

        /// <summary>
        /// Required field NUMBER16 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER16 { get; set; }

        /// <summary>
        /// Required field NUMBER17 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER17 { get; set; }

        /// <summary>
        /// Required field NUMBER18 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER18 { get; set; }

        /// <summary>
        /// Required field NUMBER19 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER19 { get; set; }

        /// <summary>
        /// Required field NUMBER20 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER20 { get; set; }

        /// <summary>
        /// Required field NUMBER21 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER21 { get; set; }

        /// <summary>
        /// Required field NUMBER22 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER22 { get; set; }

        /// <summary>
        /// Required field NUMBER23 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER23 { get; set; }

        /// <summary>
        /// Required field NUMBER24 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER24 { get; set; }

        /// <summary>
        /// Required field NUMBER25 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER25 { get; set; }

        /// <summary>
        /// Required field NUMBER26 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER26 { get; set; }

        /// <summary>
        /// Required field NUMBER27 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER27 { get; set; }

        /// <summary>
        /// Required field NUMBER28 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER28 { get; set; }

        /// <summary>
        /// Required field NUMBER29 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER29 { get; set; }

        /// <summary>
        /// Required field NUMBER30 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER30 { get; set; }

        /// <summary>
        /// Required field NUMBER31 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER31 { get; set; }

        /// <summary>
        /// Required field NUMBER32 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER32 { get; set; }

        /// <summary>
        /// Required field NUMBER33 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER33 { get; set; }

        /// <summary>
        /// Required field NUMBER34 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER34 { get; set; }

        /// <summary>
        /// Required field NUMBER35 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER35 { get; set; }

        /// <summary>
        /// Required field NUMBER36 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER36 { get; set; }

        /// <summary>
        /// Required field NUMBER37 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER37 { get; set; }

        /// <summary>
        /// Required field NUMBER38 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER38 { get; set; }

        /// <summary>
        /// Required field NUMBER39 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER39 { get; set; }

        /// <summary>
        /// Required field NUMBER40 of the ESTATE 
        /// </summary>
        [Required]
        public double NUMBER40 { get; set; }

        /// <summary>
        /// Primary key for the ESTATE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the ESTATE 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field REGISTERED_NET_AREA of the ESTATE 
        /// </summary>
        [Required]
        public double REGISTERED_NET_AREA { get; set; }

        /// <summary>
        /// Required field REGISTERED_GROSS_AREA of the ESTATE 
        /// </summary>
        [Required]
        public double REGISTERED_GROSS_AREA { get; set; }

        /// <summary>
        /// Required field COMPUTED_NET_AREA of the ESTATE 
        /// </summary>
        [Required]
        public double COMPUTED_NET_AREA { get; set; }

        /// <summary>
        /// Required field COMPUTED_GROSS_AREA of the ESTATE 
        /// </summary>
        [Required]
        public double COMPUTED_GROSS_AREA { get; set; }

        /// <summary>
        /// Required field COUNTRY_CODE of the ESTATE 
        /// </summary>
        [Required]
        public int COUNTRY_CODE { get; set; }

        /// <summary>
        /// Required field PROPERTY_REGISTRATION_NUMBER of the ESTATE 
        /// </summary>
        [Required]
        public string PROPERTY_REGISTRATION_NUMBER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_MANAGER_PERSON1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_MANAGER_PERSON1")]
        public PERSON? GUID_MANAGER_PERSON1_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_MANAGER_PERSON2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_MANAGER_PERSON2")]
        public PERSON? GUID_MANAGER_PERSON2_PERSON { get; set; }
        /// <summary>
        /// CADASTRE_IDENTIFICATION_NUMBER of the ESTATE 
        /// </summary>
        public string? CADASTRE_IDENTIFICATION_NUMBER { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the ESTATE 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// INTERNAL_CODE of the ESTATE 
        /// </summary>
        public string? INTERNAL_CODE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_CONDITION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION
        /// </summary>
        [ForeignKey("GUID_CONDITION")]
        public CONDITION? GUID_CONDITION_CONDITION { get; set; }
        /// <summary>
        /// GLOBAL_LOCATION_NUMBER of the ESTATE 
        /// </summary>
        public string? GLOBAL_LOCATION_NUMBER { get; set; }
        /// <summary>
        /// Foreign key referencing the GIS_ENTITY to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_GIS_ENTITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated GIS_ENTITY
        /// </summary>
        [ForeignKey("GUID_GIS_ENTITY")]
        public GIS_ENTITY? GUID_GIS_ENTITY_GIS_ENTITY { get; set; }
        /// <summary>
        /// Foreign key referencing the REFERENCE_DATA to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_BUSINESS_UNIT { get; set; }

        /// <summary>
        /// Navigation property representing the associated REFERENCE_DATA
        /// </summary>
        [ForeignKey("GUID_BUSINESS_UNIT")]
        public REFERENCE_DATA? GUID_BUSINESS_UNIT_REFERENCE_DATA { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_OWNER")]
        public CUSTOMER? GUID_OWNER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_EXTERNAL_FACILITY_MANAGER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_EXTERNAL_FACILITY_MANAGER")]
        public CUSTOMER? GUID_EXTERNAL_FACILITY_MANAGER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_FACILITY_MANAGER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_FACILITY_MANAGER")]
        public PERSON? GUID_FACILITY_MANAGER_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the BIM_PROJECT to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_BIM_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated BIM_PROJECT
        /// </summary>
        [ForeignKey("GUID_BIM_PROJECT")]
        public BIM_PROJECT? GUID_BIM_PROJECT_BIM_PROJECT { get; set; }
        /// <summary>
        /// OWNER_COMMENT of the ESTATE 
        /// </summary>
        public string? OWNER_COMMENT { get; set; }
        /// <summary>
        /// PROPERTY_CADASTRAL_NUMBER of the ESTATE 
        /// </summary>
        public string? PROPERTY_CADASTRAL_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_UNIT_NUMBER of the ESTATE 
        /// </summary>
        public string? PROPERTY_UNIT_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_LEASEHOLD_NUMBER of the ESTATE 
        /// </summary>
        public string? PROPERTY_LEASEHOLD_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_UNDER_NUMBER of the ESTATE 
        /// </summary>
        public string? PROPERTY_UNDER_NUMBER { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_OPERATIONS_MANAGER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_OPERATIONS_MANAGER")]
        public PERSON? GUID_OPERATIONS_MANAGER_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the RENTAL_GROUP to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_RENTAL_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RENTAL_GROUP
        /// </summary>
        [ForeignKey("GUID_RENTAL_GROUP")]
        public RENTAL_GROUP? GUID_RENTAL_GROUP_RENTAL_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE_CATEGORY to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_ESTATE_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE_CATEGORY
        /// </summary>
        [ForeignKey("GUID_ESTATE_CATEGORY")]
        public ESTATE_CATEGORY? GUID_ESTATE_CATEGORY_ESTATE_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the REGION to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_REGION { get; set; }

        /// <summary>
        /// Navigation property representing the associated REGION
        /// </summary>
        [ForeignKey("GUID_REGION")]
        public REGION? GUID_REGION_REGION { get; set; }
        /// <summary>
        /// Foreign key referencing the POSTAL_CODE to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_POST { get; set; }

        /// <summary>
        /// Navigation property representing the associated POSTAL_CODE
        /// </summary>
        [ForeignKey("GUID_POST")]
        public POSTAL_CODE? GUID_POST_POSTAL_CODE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ESTATE belongs 
        /// </summary>
        public Guid? GUID_USER_CAF_COMPUTED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CAF_COMPUTED_BY")]
        public USR? GUID_USER_CAF_COMPUTED_BY_USR { get; set; }
        /// <summary>
        /// ID of the ESTATE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ESTATE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// ADDRESS of the ESTATE 
        /// </summary>
        public string? ADDRESS { get; set; }
        /// <summary>
        /// POSTAL_CODE of the ESTATE 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the ESTATE 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// COUNTRY of the ESTATE 
        /// </summary>
        public string? COUNTRY { get; set; }
        /// <summary>
        /// COUNTY of the ESTATE 
        /// </summary>
        public string? COUNTY { get; set; }
        /// <summary>
        /// MUNICIPALITY of the ESTATE 
        /// </summary>
        public string? MUNICIPALITY { get; set; }
        /// <summary>
        /// REFERENCE of the ESTATE 
        /// </summary>
        public string? REFERENCE { get; set; }
        /// <summary>
        /// COMBO01 of the ESTATE 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the ESTATE 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the ESTATE 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the ESTATE 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the ESTATE 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the ESTATE 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the ESTATE 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the ESTATE 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the ESTATE 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the ESTATE 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the ESTATE 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the ESTATE 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the ESTATE 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the ESTATE 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the ESTATE 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the ESTATE 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the ESTATE 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the ESTATE 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the ESTATE 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the ESTATE 
        /// </summary>
        public string? COMBO20 { get; set; }

        /// <summary>
        /// CAF_COMPUTATION_DATE of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CAF_COMPUTATION_DATE { get; set; }
        /// <summary>
        /// TEXT01 of the ESTATE 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the ESTATE 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the ESTATE 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the ESTATE 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the ESTATE 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the ESTATE 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the ESTATE 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the ESTATE 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the ESTATE 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the ESTATE 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the ESTATE 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the ESTATE 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the ESTATE 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the ESTATE 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the ESTATE 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the ESTATE 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the ESTATE 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the ESTATE 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the ESTATE 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the ESTATE 
        /// </summary>
        public string? TEXT20 { get; set; }
        /// <summary>
        /// TEXT21 of the ESTATE 
        /// </summary>
        public string? TEXT21 { get; set; }
        /// <summary>
        /// TEXT22 of the ESTATE 
        /// </summary>
        public string? TEXT22 { get; set; }
        /// <summary>
        /// TEXT23 of the ESTATE 
        /// </summary>
        public string? TEXT23 { get; set; }
        /// <summary>
        /// TEXT24 of the ESTATE 
        /// </summary>
        public string? TEXT24 { get; set; }
        /// <summary>
        /// TEXT25 of the ESTATE 
        /// </summary>
        public string? TEXT25 { get; set; }
        /// <summary>
        /// TEXT26 of the ESTATE 
        /// </summary>
        public string? TEXT26 { get; set; }
        /// <summary>
        /// TEXT27 of the ESTATE 
        /// </summary>
        public string? TEXT27 { get; set; }
        /// <summary>
        /// TEXT28 of the ESTATE 
        /// </summary>
        public string? TEXT28 { get; set; }
        /// <summary>
        /// TEXT29 of the ESTATE 
        /// </summary>
        public string? TEXT29 { get; set; }
        /// <summary>
        /// TEXT30 of the ESTATE 
        /// </summary>
        public string? TEXT30 { get; set; }
        /// <summary>
        /// TEXT31 of the ESTATE 
        /// </summary>
        public string? TEXT31 { get; set; }
        /// <summary>
        /// TEXT32 of the ESTATE 
        /// </summary>
        public string? TEXT32 { get; set; }
        /// <summary>
        /// TEXT33 of the ESTATE 
        /// </summary>
        public string? TEXT33 { get; set; }
        /// <summary>
        /// TEXT34 of the ESTATE 
        /// </summary>
        public string? TEXT34 { get; set; }
        /// <summary>
        /// TEXT35 of the ESTATE 
        /// </summary>
        public string? TEXT35 { get; set; }
        /// <summary>
        /// TEXT36 of the ESTATE 
        /// </summary>
        public string? TEXT36 { get; set; }
        /// <summary>
        /// TEXT37 of the ESTATE 
        /// </summary>
        public string? TEXT37 { get; set; }
        /// <summary>
        /// TEXT38 of the ESTATE 
        /// </summary>
        public string? TEXT38 { get; set; }
        /// <summary>
        /// TEXT39 of the ESTATE 
        /// </summary>
        public string? TEXT39 { get; set; }
        /// <summary>
        /// TEXT40 of the ESTATE 
        /// </summary>
        public string? TEXT40 { get; set; }

        /// <summary>
        /// DATE01 of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the ESTATE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }
    }
}