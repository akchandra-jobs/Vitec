using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a equipment entity with essential details
    /// </summary>
    [Table("EQUIPMENT", Schema = "dbo")]
    public class EQUIPMENT
    {
        /// <summary>
        /// Initializes a new instance of the EQUIPMENT class.
        /// </summary>
        public EQUIPMENT()
        {
            HAS_CONDITION_CONTROL = false;
            IS_EQUIPMENT_GROUP = false;
            CAN_BE_RENTED_OUT = false;
            RENTAL_STATUS = 0;
            IS_FIRE_ITEM = false;
            IS_ELECTRICAL_ITEM = false;
            AVAILABILITY_CAUSE = -1;
            IS_TEMPLATE = false;
            IS_DEACTIVATED = false;
            DATA_ACQUISITION_STATUS = 0;
            ELHUB_STATUS = -1;
            IS_MAINTAINABLE = false;
            CAN_HAVE_DOWNTIME = false;
            NONS_REFERENCE_TYPE = -1;
            IS_HSE_RELATED = false;
            IS_INVENTORY = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the EQUIPMENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field HAS_CONDITION_CONTROL of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool HAS_CONDITION_CONTROL { get; set; }

        /// <summary>
        /// Required field ESTIMATE of the EQUIPMENT 
        /// </summary>
        [Required]
        public double ESTIMATE { get; set; }

        /// <summary>
        /// Required field PRICE of the EQUIPMENT 
        /// </summary>
        [Required]
        public double PRICE { get; set; }

        /// <summary>
        /// Required field IS_EQUIPMENT_GROUP of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_EQUIPMENT_GROUP { get; set; }

        /// <summary>
        /// Required field IMAGE_X of the EQUIPMENT 
        /// </summary>
        [Required]
        public double IMAGE_X { get; set; }

        /// <summary>
        /// Required field IMAGE_Y of the EQUIPMENT 
        /// </summary>
        [Required]
        public double IMAGE_Y { get; set; }

        /// <summary>
        /// Required field IMAGE_WIDTH of the EQUIPMENT 
        /// </summary>
        [Required]
        public double IMAGE_WIDTH { get; set; }

        /// <summary>
        /// Required field IMAGE_HEIGHT of the EQUIPMENT 
        /// </summary>
        [Required]
        public double IMAGE_HEIGHT { get; set; }

        /// <summary>
        /// Required field HIRE_PRICE of the EQUIPMENT 
        /// </summary>
        [Required]
        public double HIRE_PRICE { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE of the EQUIPMENT 
        /// </summary>
        [Required]
        public double RENTAL_PRICE { get; set; }

        /// <summary>
        /// Required field CAN_BE_RENTED_OUT of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool CAN_BE_RENTED_OUT { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_YEAR of the EQUIPMENT 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_YEAR { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_MONTH of the EQUIPMENT 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_MONTH { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_DAY of the EQUIPMENT 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_DAY { get; set; }

        /// <summary>
        /// Required field RENTAL_STATUS of the EQUIPMENT 
        /// </summary>
        [Required]
        public int RENTAL_STATUS { get; set; }

        /// <summary>
        /// Required field IS_FIRE_ITEM of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_FIRE_ITEM { get; set; }

        /// <summary>
        /// Required field IS_ELECTRICAL_ITEM of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_ELECTRICAL_ITEM { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field NUMBER11 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER11 { get; set; }

        /// <summary>
        /// Required field NUMBER12 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER12 { get; set; }

        /// <summary>
        /// Required field NUMBER13 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER13 { get; set; }

        /// <summary>
        /// Required field NUMBER14 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER14 { get; set; }

        /// <summary>
        /// Required field NUMBER15 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER15 { get; set; }

        /// <summary>
        /// Required field NUMBER16 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER16 { get; set; }

        /// <summary>
        /// Required field NUMBER17 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER17 { get; set; }

        /// <summary>
        /// Required field NUMBER18 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER18 { get; set; }

        /// <summary>
        /// Required field NUMBER19 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER19 { get; set; }

        /// <summary>
        /// Required field NUMBER20 of the EQUIPMENT 
        /// </summary>
        [Required]
        public double NUMBER20 { get; set; }

        /// <summary>
        /// Required field AVAILABILITY_CAUSE of the EQUIPMENT 
        /// </summary>
        [Required]
        public int AVAILABILITY_CAUSE { get; set; }

        /// <summary>
        /// Required field IS_TEMPLATE of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_TEMPLATE { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field DATA_ACQUISITION_STATUS of the EQUIPMENT 
        /// </summary>
        [Required]
        public int DATA_ACQUISITION_STATUS { get; set; }

        /// <summary>
        /// Required field ELHUB_STATUS of the EQUIPMENT 
        /// </summary>
        [Required]
        public int ELHUB_STATUS { get; set; }

        /// <summary>
        /// Required field IS_MAINTAINABLE of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_MAINTAINABLE { get; set; }

        /// <summary>
        /// Required field CAN_HAVE_DOWNTIME of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool CAN_HAVE_DOWNTIME { get; set; }

        /// <summary>
        /// Required field NONS_REFERENCE_TYPE of the EQUIPMENT 
        /// </summary>
        [Required]
        public int NONS_REFERENCE_TYPE { get; set; }

        /// <summary>
        /// Required field IS_HSE_RELATED of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_HSE_RELATED { get; set; }

        /// <summary>
        /// Required field IS_INVENTORY of the EQUIPMENT 
        /// </summary>
        [Required]
        public bool IS_INVENTORY { get; set; }
        /// <summary>
        /// INVENTORY_ID of the EQUIPMENT 
        /// </summary>
        public int? INVENTORY_ID { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_TEMPLATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_TEMPLATE")]
        public EQUIPMENT? GUID_TEMPLATE_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_CONTRACTOR { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_CONTRACTOR")]
        public SUPPLIER? GUID_CONTRACTOR_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_INSTALLER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_INSTALLER")]
        public SUPPLIER? GUID_INSTALLER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_SERVICE_PROVIDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SERVICE_PROVIDER")]
        public SUPPLIER? GUID_SERVICE_PROVIDER_SUPPLIER { get; set; }
        /// <summary>
        /// GLOBAL_INDIVIDUAL_ASSET_IDENTIFIER of the EQUIPMENT 
        /// </summary>
        public string? GLOBAL_INDIVIDUAL_ASSET_IDENTIFIER { get; set; }
        /// <summary>
        /// Foreign key referencing the NONS_REFERENCE to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_NONS_REFERENCE { get; set; }

        /// <summary>
        /// Navigation property representing the associated NONS_REFERENCE
        /// </summary>
        [ForeignKey("GUID_NONS_REFERENCE")]
        public NONS_REFERENCE? GUID_NONS_REFERENCE_NONS_REFERENCE { get; set; }
        /// <summary>
        /// CONDITION_CONTEXT_DESCRIPTION of the EQUIPMENT 
        /// </summary>
        public string? CONDITION_CONTEXT_DESCRIPTION { get; set; }
        /// <summary>
        /// GLOBAL_TRADE_ITEM_NUMBER of the EQUIPMENT 
        /// </summary>
        public string? GLOBAL_TRADE_ITEM_NUMBER { get; set; }
        /// <summary>
        /// Foreign key referencing the GIS_ENTITY to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_GIS_ENTITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated GIS_ENTITY
        /// </summary>
        [ForeignKey("GUID_GIS_ENTITY")]
        public GIS_ENTITY? GUID_GIS_ENTITY_GIS_ENTITY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TEXT21 of the EQUIPMENT 
        /// </summary>
        public string? TEXT21 { get; set; }
        /// <summary>
        /// TEXT22 of the EQUIPMENT 
        /// </summary>
        public string? TEXT22 { get; set; }
        /// <summary>
        /// TEXT23 of the EQUIPMENT 
        /// </summary>
        public string? TEXT23 { get; set; }
        /// <summary>
        /// TEXT24 of the EQUIPMENT 
        /// </summary>
        public string? TEXT24 { get; set; }
        /// <summary>
        /// TEXT25 of the EQUIPMENT 
        /// </summary>
        public string? TEXT25 { get; set; }
        /// <summary>
        /// TEXT26 of the EQUIPMENT 
        /// </summary>
        public string? TEXT26 { get; set; }
        /// <summary>
        /// TEXT27 of the EQUIPMENT 
        /// </summary>
        public string? TEXT27 { get; set; }
        /// <summary>
        /// TEXT28 of the EQUIPMENT 
        /// </summary>
        public string? TEXT28 { get; set; }
        /// <summary>
        /// TEXT29 of the EQUIPMENT 
        /// </summary>
        public string? TEXT29 { get; set; }
        /// <summary>
        /// TEXT30 of the EQUIPMENT 
        /// </summary>
        public string? TEXT30 { get; set; }
        /// <summary>
        /// TEXT31 of the EQUIPMENT 
        /// </summary>
        public string? TEXT31 { get; set; }
        /// <summary>
        /// TEXT32 of the EQUIPMENT 
        /// </summary>
        public string? TEXT32 { get; set; }
        /// <summary>
        /// TEXT33 of the EQUIPMENT 
        /// </summary>
        public string? TEXT33 { get; set; }
        /// <summary>
        /// TEXT34 of the EQUIPMENT 
        /// </summary>
        public string? TEXT34 { get; set; }
        /// <summary>
        /// TEXT35 of the EQUIPMENT 
        /// </summary>
        public string? TEXT35 { get; set; }
        /// <summary>
        /// TEXT36 of the EQUIPMENT 
        /// </summary>
        public string? TEXT36 { get; set; }
        /// <summary>
        /// TEXT37 of the EQUIPMENT 
        /// </summary>
        public string? TEXT37 { get; set; }
        /// <summary>
        /// TEXT38 of the EQUIPMENT 
        /// </summary>
        public string? TEXT38 { get; set; }
        /// <summary>
        /// TEXT39 of the EQUIPMENT 
        /// </summary>
        public string? TEXT39 { get; set; }
        /// <summary>
        /// TEXT40 of the EQUIPMENT 
        /// </summary>
        public string? TEXT40 { get; set; }
        /// <summary>
        /// COMBO31 of the EQUIPMENT 
        /// </summary>
        public string? COMBO31 { get; set; }
        /// <summary>
        /// COMBO32 of the EQUIPMENT 
        /// </summary>
        public string? COMBO32 { get; set; }
        /// <summary>
        /// COMBO33 of the EQUIPMENT 
        /// </summary>
        public string? COMBO33 { get; set; }
        /// <summary>
        /// COMBO34 of the EQUIPMENT 
        /// </summary>
        public string? COMBO34 { get; set; }
        /// <summary>
        /// COMBO35 of the EQUIPMENT 
        /// </summary>
        public string? COMBO35 { get; set; }
        /// <summary>
        /// COMBO36 of the EQUIPMENT 
        /// </summary>
        public string? COMBO36 { get; set; }
        /// <summary>
        /// COMBO37 of the EQUIPMENT 
        /// </summary>
        public string? COMBO37 { get; set; }
        /// <summary>
        /// COMBO38 of the EQUIPMENT 
        /// </summary>
        public string? COMBO38 { get; set; }
        /// <summary>
        /// COMBO39 of the EQUIPMENT 
        /// </summary>
        public string? COMBO39 { get; set; }
        /// <summary>
        /// COMBO40 of the EQUIPMENT 
        /// </summary>
        public string? COMBO40 { get; set; }
        /// <summary>
        /// TEXT01 of the EQUIPMENT 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the EQUIPMENT 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the EQUIPMENT 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the EQUIPMENT 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the EQUIPMENT 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the EQUIPMENT 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the EQUIPMENT 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the EQUIPMENT 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the EQUIPMENT 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the EQUIPMENT 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the EQUIPMENT 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the EQUIPMENT 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the EQUIPMENT 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the EQUIPMENT 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the EQUIPMENT 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the EQUIPMENT 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the EQUIPMENT 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the EQUIPMENT 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the EQUIPMENT 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the EQUIPMENT 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// DATE01 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }
        /// <summary>
        /// COMBO01 of the EQUIPMENT 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the EQUIPMENT 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the EQUIPMENT 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the EQUIPMENT 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the EQUIPMENT 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the EQUIPMENT 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the EQUIPMENT 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the EQUIPMENT 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the EQUIPMENT 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the EQUIPMENT 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the EQUIPMENT 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the EQUIPMENT 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the EQUIPMENT 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the EQUIPMENT 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the EQUIPMENT 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the EQUIPMENT 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the EQUIPMENT 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the EQUIPMENT 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the EQUIPMENT 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the EQUIPMENT 
        /// </summary>
        public string? COMBO20 { get; set; }
        /// <summary>
        /// COMBO21 of the EQUIPMENT 
        /// </summary>
        public string? COMBO21 { get; set; }
        /// <summary>
        /// COMBO22 of the EQUIPMENT 
        /// </summary>
        public string? COMBO22 { get; set; }
        /// <summary>
        /// COMBO23 of the EQUIPMENT 
        /// </summary>
        public string? COMBO23 { get; set; }
        /// <summary>
        /// COMBO24 of the EQUIPMENT 
        /// </summary>
        public string? COMBO24 { get; set; }
        /// <summary>
        /// COMBO25 of the EQUIPMENT 
        /// </summary>
        public string? COMBO25 { get; set; }
        /// <summary>
        /// COMBO26 of the EQUIPMENT 
        /// </summary>
        public string? COMBO26 { get; set; }
        /// <summary>
        /// COMBO27 of the EQUIPMENT 
        /// </summary>
        public string? COMBO27 { get; set; }
        /// <summary>
        /// COMBO28 of the EQUIPMENT 
        /// </summary>
        public string? COMBO28 { get; set; }
        /// <summary>
        /// COMBO29 of the EQUIPMENT 
        /// </summary>
        public string? COMBO29 { get; set; }
        /// <summary>
        /// COMBO30 of the EQUIPMENT 
        /// </summary>
        public string? COMBO30 { get; set; }
        /// <summary>
        /// GUID_IFC of the EQUIPMENT 
        /// </summary>
        public string? GUID_IFC { get; set; }

        /// <summary>
        /// COMMISSIONING_DATE of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? COMMISSIONING_DATE { get; set; }

        /// <summary>
        /// AVAILABILITY_DATE of the EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? AVAILABILITY_DATE { get; set; }
        /// <summary>
        /// MANUFACTURER of the EQUIPMENT 
        /// </summary>
        public string? MANUFACTURER { get; set; }
        /// <summary>
        /// IMAGE_FILE of the EQUIPMENT 
        /// </summary>
        public string? IMAGE_FILE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ITEM")]
        public CONTRACT_ITEM? GUID_CONTRACT_ITEM_CONTRACT_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_OPERATIONS_MANAGER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_OPERATIONS_MANAGER")]
        public PERSON? GUID_OPERATIONS_MANAGER_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT_TEMPLATE to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT_TEMPLATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT_TEMPLATE
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT_TEMPLATE")]
        public EQUIPMENT_TEMPLATE? GUID_EQUIPMENT_TEMPLATE_EQUIPMENT_TEMPLATE { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT_GROUP")]
        public EQUIPMENT? GUID_EQUIPMENT_GROUP_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT_CATEGORY to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT_CATEGORY")]
        public EQUIPMENT_CATEGORY? GUID_EQUIPMENT_CATEGORY_EQUIPMENT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION")]
        public ORGANIZATION? GUID_ORGANIZATION_ORGANIZATION { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION_SECTION to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION_SECTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION_SECTION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION_SECTION")]
        public ORGANIZATION_SECTION? GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION_UNIT to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION_UNIT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION_UNIT
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION_UNIT")]
        public ORGANIZATION_UNIT? GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT { get; set; }
        /// <summary>
        /// Foreign key referencing the DRAWING to which the EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_DRAWING { get; set; }

        /// <summary>
        /// Navigation property representing the associated DRAWING
        /// </summary>
        [ForeignKey("GUID_DRAWING")]
        public DRAWING? GUID_DRAWING_DRAWING { get; set; }
        /// <summary>
        /// ID of the EQUIPMENT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the EQUIPMENT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// ALTERNATE_ID of the EQUIPMENT 
        /// </summary>
        public string? ALTERNATE_ID { get; set; }
        /// <summary>
        /// RESPONSIBLE of the EQUIPMENT 
        /// </summary>
        public string? RESPONSIBLE { get; set; }
        /// <summary>
        /// LOCATION of the EQUIPMENT 
        /// </summary>
        public string? LOCATION { get; set; }
        /// <summary>
        /// REFERENCE of the EQUIPMENT 
        /// </summary>
        public string? REFERENCE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the EQUIPMENT 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// DIMENSION1 of the EQUIPMENT 
        /// </summary>
        public string? DIMENSION1 { get; set; }
        /// <summary>
        /// DIMENSION2 of the EQUIPMENT 
        /// </summary>
        public string? DIMENSION2 { get; set; }
        /// <summary>
        /// DIMENSION3 of the EQUIPMENT 
        /// </summary>
        public string? DIMENSION3 { get; set; }
        /// <summary>
        /// DIMENSION4 of the EQUIPMENT 
        /// </summary>
        public string? DIMENSION4 { get; set; }
        /// <summary>
        /// DIMENSION5 of the EQUIPMENT 
        /// </summary>
        public string? DIMENSION5 { get; set; }
    }
}