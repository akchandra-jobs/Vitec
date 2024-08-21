using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a building entity with essential details
    /// </summary>
    [Table("BUILDING", Schema = "dbo")]
    public class BUILDING
    {
        /// <summary>
        /// Initializes a new instance of the BUILDING class.
        /// </summary>
        public BUILDING()
        {
            SUM_DIRTY_FLAG = false;
            IS_DEACTIVATED = false;
            IS_TEMPLATE = false;
            IS_GROUND = false;
            COUNTRY_CODE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field NUMBER01 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field NUMBER11 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER11 { get; set; }

        /// <summary>
        /// Required field NUMBER12 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER12 { get; set; }

        /// <summary>
        /// Required field NUMBER13 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER13 { get; set; }

        /// <summary>
        /// Required field NUMBER14 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER14 { get; set; }

        /// <summary>
        /// Required field NUMBER15 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER15 { get; set; }

        /// <summary>
        /// Required field NUMBER16 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER16 { get; set; }

        /// <summary>
        /// Required field NUMBER17 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER17 { get; set; }

        /// <summary>
        /// Required field NUMBER18 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER18 { get; set; }

        /// <summary>
        /// Required field NUMBER19 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER19 { get; set; }

        /// <summary>
        /// Required field NUMBER20 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER20 { get; set; }

        /// <summary>
        /// Required field NUMBER21 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER21 { get; set; }

        /// <summary>
        /// Required field NUMBER22 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER22 { get; set; }

        /// <summary>
        /// Required field NUMBER23 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER23 { get; set; }

        /// <summary>
        /// Required field NUMBER24 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER24 { get; set; }

        /// <summary>
        /// Required field NUMBER25 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER25 { get; set; }

        /// <summary>
        /// Required field NUMBER26 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER26 { get; set; }

        /// <summary>
        /// Required field NUMBER27 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER27 { get; set; }

        /// <summary>
        /// Required field NUMBER28 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER28 { get; set; }

        /// <summary>
        /// Required field NUMBER29 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER29 { get; set; }

        /// <summary>
        /// Required field NUMBER30 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER30 { get; set; }

        /// <summary>
        /// Required field NUMBER31 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER31 { get; set; }

        /// <summary>
        /// Required field NUMBER32 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER32 { get; set; }

        /// <summary>
        /// Required field NUMBER33 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER33 { get; set; }

        /// <summary>
        /// Required field NUMBER34 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER34 { get; set; }

        /// <summary>
        /// Required field NUMBER35 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER35 { get; set; }

        /// <summary>
        /// Required field NUMBER36 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER36 { get; set; }

        /// <summary>
        /// Required field NUMBER37 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER37 { get; set; }

        /// <summary>
        /// Required field NUMBER38 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER38 { get; set; }

        /// <summary>
        /// Required field NUMBER39 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER39 { get; set; }

        /// <summary>
        /// Required field NUMBER40 of the BUILDING 
        /// </summary>
        [Required]
        public double NUMBER40 { get; set; }

        /// <summary>
        /// Required field SUM_ESTATE_COMMON_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_ESTATE_COMMON_AREA { get; set; }

        /// <summary>
        /// Required field SUM_BUILDING_COMMON_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_BUILDING_COMMON_AREA { get; set; }

        /// <summary>
        /// Required field SUM_STOREY_COMMON_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_STOREY_COMMON_AREA { get; set; }

        /// <summary>
        /// Required field SUM_NON_COMMON_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_NON_COMMON_AREA { get; set; }

        /// <summary>
        /// Required field SUM_RESERVED_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_RESERVED_AREA { get; set; }

        /// <summary>
        /// Required field SUM_EXTERNALLY_RENTED_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_EXTERNALLY_RENTED_AREA { get; set; }

        /// <summary>
        /// Required field SUM_INTERNALLY_RENTED_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_INTERNALLY_RENTED_AREA { get; set; }

        /// <summary>
        /// Required field SUM_VACANT_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double SUM_VACANT_AREA { get; set; }

        /// <summary>
        /// Required field SUM_DIRTY_FLAG of the BUILDING 
        /// </summary>
        [Required]
        public bool SUM_DIRTY_FLAG { get; set; }

        /// <summary>
        /// Required field COMPUTED_GROSS_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double COMPUTED_GROSS_AREA { get; set; }

        /// <summary>
        /// Required field COMPUTED_NET_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double COMPUTED_NET_AREA { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the BUILDING 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field IS_TEMPLATE of the BUILDING 
        /// </summary>
        [Required]
        public bool IS_TEMPLATE { get; set; }

        /// <summary>
        /// Primary key for the BUILDING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field REGISTERED_NET_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double REGISTERED_NET_AREA { get; set; }

        /// <summary>
        /// Required field REGISTERED_GROSS_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double REGISTERED_GROSS_AREA { get; set; }

        /// <summary>
        /// Required field COMMON_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double COMMON_AREA { get; set; }

        /// <summary>
        /// Required field NON_COMMON_AREA of the BUILDING 
        /// </summary>
        [Required]
        public double NON_COMMON_AREA { get; set; }

        /// <summary>
        /// Required field COMMON_AREA_FACTOR of the BUILDING 
        /// </summary>
        [Required]
        public double COMMON_AREA_FACTOR { get; set; }

        /// <summary>
        /// Required field IS_GROUND of the BUILDING 
        /// </summary>
        [Required]
        public bool IS_GROUND { get; set; }

        /// <summary>
        /// Required field GROSS_NET_FACTOR of the BUILDING 
        /// </summary>
        [Required]
        public double GROSS_NET_FACTOR { get; set; }

        /// <summary>
        /// Required field COUNTRY_CODE of the BUILDING 
        /// </summary>
        [Required]
        public int COUNTRY_CODE { get; set; }

        /// <summary>
        /// Required field PROPERTY_REGISTRATION_NUMBER of the BUILDING 
        /// </summary>
        [Required]
        public string PROPERTY_REGISTRATION_NUMBER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_MANAGER_PERSON1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_MANAGER_PERSON1")]
        public PERSON? GUID_MANAGER_PERSON1_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_MANAGER_PERSON2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_MANAGER_PERSON2")]
        public PERSON? GUID_MANAGER_PERSON2_PERSON { get; set; }

        /// <summary>
        /// AREA_COMPUTATION_DATE of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? AREA_COMPUTATION_DATE { get; set; }

        /// <summary>
        /// CAF_COMPUTATION_DATE of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CAF_COMPUTATION_DATE { get; set; }
        /// <summary>
        /// CADASTRE_IDENTIFICATION_NUMBER of the BUILDING 
        /// </summary>
        public string? CADASTRE_IDENTIFICATION_NUMBER { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the BUILDING 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// INTERNAL_CODE of the BUILDING 
        /// </summary>
        public string? INTERNAL_CODE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_OPERATIONS_MANAGER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_OPERATIONS_MANAGER")]
        public PERSON? GUID_OPERATIONS_MANAGER_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the RENTAL_GROUP to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_RENTAL_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RENTAL_GROUP
        /// </summary>
        [ForeignKey("GUID_RENTAL_GROUP")]
        public RENTAL_GROUP? GUID_RENTAL_GROUP_RENTAL_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING_CATEGORY to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_BUILDING_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING_CATEGORY
        /// </summary>
        [ForeignKey("GUID_BUILDING_CATEGORY")]
        public BUILDING_CATEGORY? GUID_BUILDING_CATEGORY_BUILDING_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the REGION to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_REGION { get; set; }

        /// <summary>
        /// Navigation property representing the associated REGION
        /// </summary>
        [ForeignKey("GUID_REGION")]
        public REGION? GUID_REGION_REGION { get; set; }
        /// <summary>
        /// Foreign key referencing the POSTAL_CODE to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_POST { get; set; }

        /// <summary>
        /// Navigation property representing the associated POSTAL_CODE
        /// </summary>
        [ForeignKey("GUID_POST")]
        public POSTAL_CODE? GUID_POST_POSTAL_CODE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_USER_AREA_COMPUTED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_AREA_COMPUTED_BY")]
        public USR? GUID_USER_AREA_COMPUTED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_USER_CAF_COMPUTED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CAF_COMPUTED_BY")]
        public USR? GUID_USER_CAF_COMPUTED_BY_USR { get; set; }
        /// <summary>
        /// ID of the BUILDING 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the BUILDING 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// ADDRESS of the BUILDING 
        /// </summary>
        public string? ADDRESS { get; set; }
        /// <summary>
        /// POSTAL_CODE of the BUILDING 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the BUILDING 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// COUNTRY of the BUILDING 
        /// </summary>
        public string? COUNTRY { get; set; }
        /// <summary>
        /// COUNTY of the BUILDING 
        /// </summary>
        public string? COUNTY { get; set; }
        /// <summary>
        /// MUNICIPALITY of the BUILDING 
        /// </summary>
        public string? MUNICIPALITY { get; set; }
        /// <summary>
        /// REFERENCE of the BUILDING 
        /// </summary>
        public string? REFERENCE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_CONDITION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION
        /// </summary>
        [ForeignKey("GUID_CONDITION")]
        public CONDITION? GUID_CONDITION_CONDITION { get; set; }
        /// <summary>
        /// SITE_ID of the BUILDING 
        /// </summary>
        public string? SITE_ID { get; set; }
        /// <summary>
        /// Foreign key referencing the REFERENCE_DATA to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_BUILDING_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated REFERENCE_DATA
        /// </summary>
        [ForeignKey("GUID_BUILDING_TYPE")]
        public REFERENCE_DATA? GUID_BUILDING_TYPE_REFERENCE_DATA { get; set; }
        /// <summary>
        /// GLOBAL_LOCATION_NUMBER of the BUILDING 
        /// </summary>
        public string? GLOBAL_LOCATION_NUMBER { get; set; }
        /// <summary>
        /// Foreign key referencing the GIS_ENTITY to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_GIS_ENTITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated GIS_ENTITY
        /// </summary>
        [ForeignKey("GUID_GIS_ENTITY")]
        public GIS_ENTITY? GUID_GIS_ENTITY_GIS_ENTITY { get; set; }
        /// <summary>
        /// COMBO31 of the BUILDING 
        /// </summary>
        public string? COMBO31 { get; set; }
        /// <summary>
        /// COMBO32 of the BUILDING 
        /// </summary>
        public string? COMBO32 { get; set; }
        /// <summary>
        /// COMBO33 of the BUILDING 
        /// </summary>
        public string? COMBO33 { get; set; }
        /// <summary>
        /// COMBO34 of the BUILDING 
        /// </summary>
        public string? COMBO34 { get; set; }
        /// <summary>
        /// COMBO35 of the BUILDING 
        /// </summary>
        public string? COMBO35 { get; set; }
        /// <summary>
        /// COMBO36 of the BUILDING 
        /// </summary>
        public string? COMBO36 { get; set; }
        /// <summary>
        /// COMBO37 of the BUILDING 
        /// </summary>
        public string? COMBO37 { get; set; }
        /// <summary>
        /// COMBO38 of the BUILDING 
        /// </summary>
        public string? COMBO38 { get; set; }
        /// <summary>
        /// COMBO39 of the BUILDING 
        /// </summary>
        public string? COMBO39 { get; set; }
        /// <summary>
        /// COMBO40 of the BUILDING 
        /// </summary>
        public string? COMBO40 { get; set; }
        /// <summary>
        /// COMBO41 of the BUILDING 
        /// </summary>
        public string? COMBO41 { get; set; }
        /// <summary>
        /// COMBO42 of the BUILDING 
        /// </summary>
        public string? COMBO42 { get; set; }
        /// <summary>
        /// COMBO43 of the BUILDING 
        /// </summary>
        public string? COMBO43 { get; set; }
        /// <summary>
        /// COMBO44 of the BUILDING 
        /// </summary>
        public string? COMBO44 { get; set; }
        /// <summary>
        /// COMBO45 of the BUILDING 
        /// </summary>
        public string? COMBO45 { get; set; }
        /// <summary>
        /// COMBO46 of the BUILDING 
        /// </summary>
        public string? COMBO46 { get; set; }
        /// <summary>
        /// COMBO47 of the BUILDING 
        /// </summary>
        public string? COMBO47 { get; set; }
        /// <summary>
        /// COMBO48 of the BUILDING 
        /// </summary>
        public string? COMBO48 { get; set; }
        /// <summary>
        /// COMBO49 of the BUILDING 
        /// </summary>
        public string? COMBO49 { get; set; }
        /// <summary>
        /// COMBO50 of the BUILDING 
        /// </summary>
        public string? COMBO50 { get; set; }
        /// <summary>
        /// Foreign key referencing the REFERENCE_DATA to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_BUSINESS_UNIT { get; set; }

        /// <summary>
        /// Navigation property representing the associated REFERENCE_DATA
        /// </summary>
        [ForeignKey("GUID_BUSINESS_UNIT")]
        public REFERENCE_DATA? GUID_BUSINESS_UNIT_REFERENCE_DATA { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_OWNER")]
        public CUSTOMER? GUID_OWNER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_EXTERNAL_FACILITY_MANAGER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_EXTERNAL_FACILITY_MANAGER")]
        public CUSTOMER? GUID_EXTERNAL_FACILITY_MANAGER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_FACILITY_MANAGER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_FACILITY_MANAGER")]
        public PERSON? GUID_FACILITY_MANAGER_PERSON { get; set; }
        /// <summary>
        /// OWNER_COMMENT of the BUILDING 
        /// </summary>
        public string? OWNER_COMMENT { get; set; }
        /// <summary>
        /// PROPERTY_CADASTRAL_NUMBER of the BUILDING 
        /// </summary>
        public string? PROPERTY_CADASTRAL_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_UNIT_NUMBER of the BUILDING 
        /// </summary>
        public string? PROPERTY_UNIT_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_LEASEHOLD_NUMBER of the BUILDING 
        /// </summary>
        public string? PROPERTY_LEASEHOLD_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_UNDER_NUMBER of the BUILDING 
        /// </summary>
        public string? PROPERTY_UNDER_NUMBER { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the BUILDING 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the BUILDING belongs 
        /// </summary>
        public Guid? GUID_TEMPLATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_TEMPLATE")]
        public BUILDING? GUID_TEMPLATE_BUILDING { get; set; }
        /// <summary>
        /// TEXT01 of the BUILDING 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the BUILDING 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the BUILDING 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the BUILDING 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the BUILDING 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the BUILDING 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the BUILDING 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the BUILDING 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the BUILDING 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the BUILDING 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the BUILDING 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the BUILDING 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the BUILDING 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the BUILDING 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the BUILDING 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the BUILDING 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the BUILDING 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the BUILDING 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the BUILDING 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the BUILDING 
        /// </summary>
        public string? TEXT20 { get; set; }
        /// <summary>
        /// TEXT21 of the BUILDING 
        /// </summary>
        public string? TEXT21 { get; set; }
        /// <summary>
        /// TEXT22 of the BUILDING 
        /// </summary>
        public string? TEXT22 { get; set; }
        /// <summary>
        /// TEXT23 of the BUILDING 
        /// </summary>
        public string? TEXT23 { get; set; }
        /// <summary>
        /// TEXT24 of the BUILDING 
        /// </summary>
        public string? TEXT24 { get; set; }
        /// <summary>
        /// TEXT25 of the BUILDING 
        /// </summary>
        public string? TEXT25 { get; set; }
        /// <summary>
        /// TEXT26 of the BUILDING 
        /// </summary>
        public string? TEXT26 { get; set; }
        /// <summary>
        /// TEXT27 of the BUILDING 
        /// </summary>
        public string? TEXT27 { get; set; }
        /// <summary>
        /// TEXT28 of the BUILDING 
        /// </summary>
        public string? TEXT28 { get; set; }
        /// <summary>
        /// TEXT29 of the BUILDING 
        /// </summary>
        public string? TEXT29 { get; set; }
        /// <summary>
        /// TEXT30 of the BUILDING 
        /// </summary>
        public string? TEXT30 { get; set; }
        /// <summary>
        /// TEXT31 of the BUILDING 
        /// </summary>
        public string? TEXT31 { get; set; }
        /// <summary>
        /// TEXT32 of the BUILDING 
        /// </summary>
        public string? TEXT32 { get; set; }
        /// <summary>
        /// TEXT33 of the BUILDING 
        /// </summary>
        public string? TEXT33 { get; set; }
        /// <summary>
        /// TEXT34 of the BUILDING 
        /// </summary>
        public string? TEXT34 { get; set; }
        /// <summary>
        /// TEXT35 of the BUILDING 
        /// </summary>
        public string? TEXT35 { get; set; }
        /// <summary>
        /// TEXT36 of the BUILDING 
        /// </summary>
        public string? TEXT36 { get; set; }
        /// <summary>
        /// TEXT37 of the BUILDING 
        /// </summary>
        public string? TEXT37 { get; set; }
        /// <summary>
        /// TEXT38 of the BUILDING 
        /// </summary>
        public string? TEXT38 { get; set; }
        /// <summary>
        /// TEXT39 of the BUILDING 
        /// </summary>
        public string? TEXT39 { get; set; }
        /// <summary>
        /// TEXT40 of the BUILDING 
        /// </summary>
        public string? TEXT40 { get; set; }

        /// <summary>
        /// DATE01 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the BUILDING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }
        /// <summary>
        /// COMBO01 of the BUILDING 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the BUILDING 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the BUILDING 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the BUILDING 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the BUILDING 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the BUILDING 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the BUILDING 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the BUILDING 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the BUILDING 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the BUILDING 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the BUILDING 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the BUILDING 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the BUILDING 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the BUILDING 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the BUILDING 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the BUILDING 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the BUILDING 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the BUILDING 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the BUILDING 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the BUILDING 
        /// </summary>
        public string? COMBO20 { get; set; }
        /// <summary>
        /// COMBO21 of the BUILDING 
        /// </summary>
        public string? COMBO21 { get; set; }
        /// <summary>
        /// COMBO22 of the BUILDING 
        /// </summary>
        public string? COMBO22 { get; set; }
        /// <summary>
        /// COMBO23 of the BUILDING 
        /// </summary>
        public string? COMBO23 { get; set; }
        /// <summary>
        /// COMBO24 of the BUILDING 
        /// </summary>
        public string? COMBO24 { get; set; }
        /// <summary>
        /// COMBO25 of the BUILDING 
        /// </summary>
        public string? COMBO25 { get; set; }
        /// <summary>
        /// COMBO26 of the BUILDING 
        /// </summary>
        public string? COMBO26 { get; set; }
        /// <summary>
        /// COMBO27 of the BUILDING 
        /// </summary>
        public string? COMBO27 { get; set; }
        /// <summary>
        /// COMBO28 of the BUILDING 
        /// </summary>
        public string? COMBO28 { get; set; }
        /// <summary>
        /// COMBO29 of the BUILDING 
        /// </summary>
        public string? COMBO29 { get; set; }
        /// <summary>
        /// COMBO30 of the BUILDING 
        /// </summary>
        public string? COMBO30 { get; set; }
    }
}