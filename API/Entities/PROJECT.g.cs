using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a project entity with essential details
    /// </summary>
    [Table("PROJECT", Schema = "dbo")]
    public class PROJECT
    {
        /// <summary>
        /// Initializes a new instance of the PROJECT class.
        /// </summary>
        public PROJECT()
        {
            VOLUME_RISK_FACTOR = 0;
            NUMBER_OF_WORK_ORDERS = 0;
            IS_COMPLETED = false;
            FLAG = false;
            TYPE = 0;
            IS_TEMPLATE = false;
            GENERAL_RISK_FACTOR = 0;
            ECONOMY_RISK_FACTOR = 0;
            TIME_RISK_FACTOR = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field VOLUME_RISK_FACTOR of the PROJECT 
        /// </summary>
        [Required]
        public int VOLUME_RISK_FACTOR { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field NUMBER11 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER11 { get; set; }

        /// <summary>
        /// Required field NUMBER12 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER12 { get; set; }

        /// <summary>
        /// Required field NUMBER13 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER13 { get; set; }

        /// <summary>
        /// Required field NUMBER14 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER14 { get; set; }

        /// <summary>
        /// Required field NUMBER15 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER15 { get; set; }

        /// <summary>
        /// Required field NUMBER16 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER16 { get; set; }

        /// <summary>
        /// Required field NUMBER17 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER17 { get; set; }

        /// <summary>
        /// Required field NUMBER18 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER18 { get; set; }

        /// <summary>
        /// Required field NUMBER19 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER19 { get; set; }

        /// <summary>
        /// Required field NUMBER20 of the PROJECT 
        /// </summary>
        [Required]
        public double NUMBER20 { get; set; }

        /// <summary>
        /// Required field AVERAGE_COMPLETION_RATE of the PROJECT 
        /// </summary>
        [Required]
        public double AVERAGE_COMPLETION_RATE { get; set; }

        /// <summary>
        /// Required field SUM_CORRECTIVE_ACTION_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_CORRECTIVE_ACTION_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EXTERNAL_COST_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_EXTERNAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EXTERNAL_COST_REGISTERED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_EXTERNAL_COST_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EXTERNAL_COST_ORDERED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_EXTERNAL_COST_ORDERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EXTERNAL_COST_INVOICE_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_EXTERNAL_COST_INVOICE_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_EXTERNAL_COST_ALLOCATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_EXTERNAL_COST_ALLOCATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_ORDER of the PROJECT 
        /// </summary>
        [Required]
        public double REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_ORDER { get; set; }

        /// <summary>
        /// Required field SUM_SPARE_PART_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_SPARE_PART_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_RESOURCE_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_RESOURCE_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_INTERNAL_COST_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_INTERNAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_SPARE_PART_REGISTERED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_SPARE_PART_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_RESOURCE_REGISTERED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_RESOURCE_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_INTERNAL_COST_REGISTERED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_INTERNAL_COST_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_SPARE_PART_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_SPARE_PART_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_RESOURCE_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_RESOURCE_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_INTERNAL_COST_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_INTERNAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_BUDGET_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_BUDGET_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_TOTAL_COST_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_TOTAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_TOTAL_COST_REGISTERED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_TOTAL_COST_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_BUDGET_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_BUDGET_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_RESOURCE_ESTIMATED_HOURS of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_RESOURCE_ESTIMATED_HOURS { get; set; }

        /// <summary>
        /// Required field SUM_RESOURCE_REGISTERED_HOURS of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_RESOURCE_REGISTERED_HOURS { get; set; }

        /// <summary>
        /// Required field REST_RESOURCE_ESTIMATED_HOURS of the PROJECT 
        /// </summary>
        [Required]
        public double REST_RESOURCE_ESTIMATED_HOURS { get; set; }

        /// <summary>
        /// Required field NUMBER_OF_WORK_ORDERS of the PROJECT 
        /// </summary>
        [Required]
        public int NUMBER_OF_WORK_ORDERS { get; set; }

        /// <summary>
        /// Required field SUM_EQUIPMENT_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_EQUIPMENT_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EQUIPMENT_REGISTERED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_EQUIPMENT_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_EQUIPMENT_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_EQUIPMENT_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_PAYMENT_ORDER_SUM of the PROJECT 
        /// </summary>
        [Required]
        public double SUM_PAYMENT_ORDER_SUM { get; set; }

        /// <summary>
        /// Required field PAYMENT_ORDER_COVERAGE_RATE of the PROJECT 
        /// </summary>
        [Required]
        public double PAYMENT_ORDER_COVERAGE_RATE { get; set; }

        /// <summary>
        /// Required field REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_INVOICE of the PROJECT 
        /// </summary>
        [Required]
        public double REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_INVOICE { get; set; }

        /// <summary>
        /// Required field REST_TOTAL_COST_ESTIMATED_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double REST_TOTAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_BUDGET_AFTER_TOTAL_COST of the PROJECT 
        /// </summary>
        [Required]
        public double REST_BUDGET_AFTER_TOTAL_COST { get; set; }

        /// <summary>
        /// Primary key for the PROJECT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field BUDGET_AMOUNT of the PROJECT 
        /// </summary>
        [Required]
        public double BUDGET_AMOUNT { get; set; }

        /// <summary>
        /// Required field IS_COMPLETED of the PROJECT 
        /// </summary>
        [Required]
        public bool IS_COMPLETED { get; set; }

        /// <summary>
        /// Required field FLAG of the PROJECT 
        /// </summary>
        [Required]
        public bool FLAG { get; set; }

        /// <summary>
        /// Required field TYPE of the PROJECT 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field IS_TEMPLATE of the PROJECT 
        /// </summary>
        [Required]
        public bool IS_TEMPLATE { get; set; }

        /// <summary>
        /// Required field GENERAL_RISK_FACTOR of the PROJECT 
        /// </summary>
        [Required]
        public int GENERAL_RISK_FACTOR { get; set; }

        /// <summary>
        /// Required field ECONOMY_RISK_FACTOR of the PROJECT 
        /// </summary>
        [Required]
        public int ECONOMY_RISK_FACTOR { get; set; }

        /// <summary>
        /// Required field TIME_RISK_FACTOR of the PROJECT 
        /// </summary>
        [Required]
        public int TIME_RISK_FACTOR { get; set; }
        /// <summary>
        /// TIME_RISK_FACTOR_COMMENT of the PROJECT 
        /// </summary>
        public string? TIME_RISK_FACTOR_COMMENT { get; set; }
        /// <summary>
        /// ECONOMY_RISK_FACTOR_COMMENT of the PROJECT 
        /// </summary>
        public string? ECONOMY_RISK_FACTOR_COMMENT { get; set; }
        /// <summary>
        /// GENERAL_RISK_FACTOR_COMMENT of the PROJECT 
        /// </summary>
        public string? GENERAL_RISK_FACTOR_COMMENT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// TEXT of the PROJECT 
        /// </summary>
        public string? TEXT { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT_CATEGORY to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_PROJECT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_PROJECT_CATEGORY")]
        public PROJECT_CATEGORY? GUID_PROJECT_CATEGORY_PROJECT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_MANAGER_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_MANAGER_PERSON")]
        public PERSON? GUID_MANAGER_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_OWNER_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_OWNER_PERSON")]
        public PERSON? GUID_OWNER_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT_STATUS to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_PROJECT_STATUS { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT_STATUS
        /// </summary>
        [ForeignKey("GUID_PROJECT_STATUS")]
        public PROJECT_STATUS? GUID_PROJECT_STATUS_PROJECT_STATUS { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_RESPONSIBLE_PERSON2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESPONSIBLE_PERSON2")]
        public PERSON? GUID_RESPONSIBLE_PERSON2_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_RESPONSIBLE_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESPONSIBLE_PERSON")]
        public PERSON? GUID_RESPONSIBLE_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT_TYPE to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_PROJECT_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT_TYPE
        /// </summary>
        [ForeignKey("GUID_PROJECT_TYPE")]
        public PROJECT_TYPE? GUID_PROJECT_TYPE_PROJECT_TYPE { get; set; }
        /// <summary>
        /// ID of the PROJECT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PROJECT 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// END_DATE of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// START_DATE of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// CLOSED_DATE of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CLOSED_DATE { get; set; }
        /// <summary>
        /// COMBO01 of the PROJECT 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the PROJECT 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the PROJECT 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the PROJECT 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the PROJECT 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the PROJECT 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the PROJECT 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the PROJECT 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the PROJECT 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the PROJECT 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the PROJECT 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the PROJECT 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the PROJECT 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the PROJECT 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the PROJECT 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the PROJECT 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the PROJECT 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the PROJECT 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the PROJECT 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the PROJECT 
        /// </summary>
        public string? COMBO20 { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the PROJECT belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// VOLUME_RISK_FACTOR_COMMENT of the PROJECT 
        /// </summary>
        public string? VOLUME_RISK_FACTOR_COMMENT { get; set; }
        /// <summary>
        /// TEXT01 of the PROJECT 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the PROJECT 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the PROJECT 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the PROJECT 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the PROJECT 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the PROJECT 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the PROJECT 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the PROJECT 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the PROJECT 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the PROJECT 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the PROJECT 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the PROJECT 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the PROJECT 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the PROJECT 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the PROJECT 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the PROJECT 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the PROJECT 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the PROJECT 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the PROJECT 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the PROJECT 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// DATE01 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }

        /// <summary>
        /// DATE11 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE11 { get; set; }

        /// <summary>
        /// DATE12 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE12 { get; set; }

        /// <summary>
        /// DATE13 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE13 { get; set; }

        /// <summary>
        /// DATE14 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE14 { get; set; }

        /// <summary>
        /// DATE15 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE15 { get; set; }

        /// <summary>
        /// DATE16 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE16 { get; set; }

        /// <summary>
        /// DATE17 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE17 { get; set; }

        /// <summary>
        /// DATE18 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE18 { get; set; }

        /// <summary>
        /// DATE19 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE19 { get; set; }

        /// <summary>
        /// DATE20 of the PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE20 { get; set; }
    }
}