using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a work_order entity with essential details
    /// </summary>
    [Table("WORK_ORDER", Schema = "dbo")]
    public class WORK_ORDER
    {
        /// <summary>
        /// Initializes a new instance of the WORK_ORDER class.
        /// </summary>
        public WORK_ORDER()
        {
            TYPE = -1;
            IS_CLOSED = false;
            STAGE = -1;
            PURCHASE_ORDER_STATUS = -1;
            IS_AREA_IN_WORK_PROGRESS = false;
            IS_EQUIPMENT_IN_WORK_PROGRESS = false;
            IS_FIRE_RELATED = false;
            IS_ELECTRO_RELATED = false;
            NB_PURCHASE_ORDER_ITEM = 0;
            REINVOICING_STATUS = 0;
            FHS_TYPE = -1;
            FHS_STATUS = -1;
            FHS_NR = 0;
            PERIODIC_TASK_ID = 0;
            STATUS = -1;
            IS_HSE_RELATED = false;
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the WORK_ORDER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the WORK_ORDER 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field REAL_COST of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REAL_COST { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the WORK_ORDER 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field REAL_TIME of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REAL_TIME { get; set; }

        /// <summary>
        /// Required field TYPE of the WORK_ORDER 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field ALLOCATED_COST of the WORK_ORDER 
        /// </summary>
        [Required]
        public double ALLOCATED_COST { get; set; }

        /// <summary>
        /// Required field EXTERNAL_REAL_COST of the WORK_ORDER 
        /// </summary>
        [Required]
        public double EXTERNAL_REAL_COST { get; set; }

        /// <summary>
        /// Required field IS_CLOSED of the WORK_ORDER 
        /// </summary>
        [Required]
        public bool IS_CLOSED { get; set; }

        /// <summary>
        /// Required field STAGE of the WORK_ORDER 
        /// </summary>
        [Required]
        public int STAGE { get; set; }

        /// <summary>
        /// Required field PURCHASE_ORDER_STATUS of the WORK_ORDER 
        /// </summary>
        [Required]
        public int PURCHASE_ORDER_STATUS { get; set; }

        /// <summary>
        /// Required field IS_AREA_IN_WORK_PROGRESS of the WORK_ORDER 
        /// </summary>
        [Required]
        public bool IS_AREA_IN_WORK_PROGRESS { get; set; }

        /// <summary>
        /// Required field IS_EQUIPMENT_IN_WORK_PROGRESS of the WORK_ORDER 
        /// </summary>
        [Required]
        public bool IS_EQUIPMENT_IN_WORK_PROGRESS { get; set; }

        /// <summary>
        /// Required field IS_FIRE_RELATED of the WORK_ORDER 
        /// </summary>
        [Required]
        public bool IS_FIRE_RELATED { get; set; }

        /// <summary>
        /// Required field IS_ELECTRO_RELATED of the WORK_ORDER 
        /// </summary>
        [Required]
        public bool IS_ELECTRO_RELATED { get; set; }

        /// <summary>
        /// Required field NB_PURCHASE_ORDER_ITEM of the WORK_ORDER 
        /// </summary>
        [Required]
        public int NB_PURCHASE_ORDER_ITEM { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the WORK_ORDER 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field REINVOICING_STATUS of the WORK_ORDER 
        /// </summary>
        [Required]
        public int REINVOICING_STATUS { get; set; }

        /// <summary>
        /// Required field FHS_TYPE of the WORK_ORDER 
        /// </summary>
        [Required]
        public int FHS_TYPE { get; set; }

        /// <summary>
        /// Required field FHS_STATUS of the WORK_ORDER 
        /// </summary>
        [Required]
        public int FHS_STATUS { get; set; }

        /// <summary>
        /// Required field FHS_NR of the WORK_ORDER 
        /// </summary>
        [Required]
        public int FHS_NR { get; set; }

        /// <summary>
        /// Required field SUM_EQUIPMENT_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_EQUIPMENT_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EQUIPMENT_REGISTERED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_EQUIPMENT_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_EQUIPMENT_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_EQUIPMENT_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_PAYMENT_ORDER_SUM of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_PAYMENT_ORDER_SUM { get; set; }

        /// <summary>
        /// Required field PAYMENT_ORDER_COVERAGE_RATE of the WORK_ORDER 
        /// </summary>
        [Required]
        public double PAYMENT_ORDER_COVERAGE_RATE { get; set; }

        /// <summary>
        /// Required field REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_INVOICE of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_INVOICE { get; set; }

        /// <summary>
        /// Required field REST_TOTAL_COST_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_TOTAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field PERIODIC_TASK_ID of the WORK_ORDER 
        /// </summary>
        [Required]
        public int PERIODIC_TASK_ID { get; set; }

        /// <summary>
        /// Required field STATUS of the WORK_ORDER 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field EXTERNAL_ESTIMATED_COST of the WORK_ORDER 
        /// </summary>
        [Required]
        public double EXTERNAL_ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field IS_HSE_RELATED of the WORK_ORDER 
        /// </summary>
        [Required]
        public bool IS_HSE_RELATED { get; set; }

        /// <summary>
        /// Required field SUM_CORRECTIVE_ACTION_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_CORRECTIVE_ACTION_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EXTERNAL_COST_ORDERED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_EXTERNAL_COST_ORDERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_EXTERNAL_COST_INVOICE_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_EXTERNAL_COST_INVOICE_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_ORDER of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_EXTERNAL_ESTIMATED_AMOUNT_AFTER_ORDER { get; set; }

        /// <summary>
        /// Required field SUM_SPARE_PART_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_SPARE_PART_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_RESOURCE_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_RESOURCE_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_INTERNAL_COST_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_INTERNAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_SPARE_PART_REGISTERED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_SPARE_PART_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_RESOURCE_REGISTERED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_RESOURCE_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_INTERNAL_COST_REGISTERED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double SUM_INTERNAL_COST_REGISTERED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_SPARE_PART_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_SPARE_PART_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_RESOURCE_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_RESOURCE_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_INTERNAL_COST_ESTIMATED_AMOUNT of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_INTERNAL_COST_ESTIMATED_AMOUNT { get; set; }

        /// <summary>
        /// Required field REST_RESOURCE_ESTIMATED_HOURS of the WORK_ORDER 
        /// </summary>
        [Required]
        public double REST_RESOURCE_ESTIMATED_HOURS { get; set; }

        /// <summary>
        /// Required field ID of the WORK_ORDER 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field COMPLETION_RATE of the WORK_ORDER 
        /// </summary>
        [Required]
        public double COMPLETION_RATE { get; set; }

        /// <summary>
        /// COMPLETION_RATE_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? COMPLETION_RATE_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the ALARM_LOG to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_ALARM_LOG { get; set; }

        /// <summary>
        /// Navigation property representing the associated ALARM_LOG
        /// </summary>
        [ForeignKey("GUID_ALARM_LOG")]
        public ALARM_LOG? GUID_ALARM_LOG_ALARM_LOG { get; set; }
        /// <summary>
        /// DESCRIPTION of the WORK_ORDER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_INVOICE_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_INVOICE_CUSTOMER")]
        public CUSTOMER? GUID_INVOICE_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the ACTIVITY_GROUP to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_ACTIVITY_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACTIVITY_GROUP
        /// </summary>
        [ForeignKey("GUID_ACTIVITY_GROUP")]
        public ACTIVITY_GROUP? GUID_ACTIVITY_GROUP_ACTIVITY_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_RESPONSIBLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESOURCE_RESPONSIBLE")]
        public PERSON? GUID_RESOURCE_RESPONSIBLE_PERSON { get; set; }

        /// <summary>
        /// REGISTRATION_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REGISTRATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT_MILESTONE to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_PROJECT_MILESTONE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT_MILESTONE
        /// </summary>
        [ForeignKey("GUID_PROJECT_MILESTONE")]
        public PROJECT_MILESTONE? GUID_PROJECT_MILESTONE_PROJECT_MILESTONE { get; set; }

        /// <summary>
        /// CHECKOUT_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CHECKOUT_DATE { get; set; }
        /// <summary>
        /// GROUPING of the WORK_ORDER 
        /// </summary>
        public string? GROUPING { get; set; }
        /// <summary>
        /// REMARK of the WORK_ORDER 
        /// </summary>
        public string? REMARK { get; set; }
        /// <summary>
        /// CAUSE_ID of the WORK_ORDER 
        /// </summary>
        public string? CAUSE_ID { get; set; }
        /// <summary>
        /// PRIORITY_ID of the WORK_ORDER 
        /// </summary>
        public string? PRIORITY_ID { get; set; }
        /// <summary>
        /// DEPARTMENT_ID of the WORK_ORDER 
        /// </summary>
        public string? DEPARTMENT_ID { get; set; }
        /// <summary>
        /// ACTIVITY_CATEGORY_ID of the WORK_ORDER 
        /// </summary>
        public string? ACTIVITY_CATEGORY_ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TEXT21 of the WORK_ORDER 
        /// </summary>
        public string? TEXT21 { get; set; }
        /// <summary>
        /// TEXT22 of the WORK_ORDER 
        /// </summary>
        public string? TEXT22 { get; set; }
        /// <summary>
        /// TEXT23 of the WORK_ORDER 
        /// </summary>
        public string? TEXT23 { get; set; }
        /// <summary>
        /// TEXT24 of the WORK_ORDER 
        /// </summary>
        public string? TEXT24 { get; set; }
        /// <summary>
        /// TEXT25 of the WORK_ORDER 
        /// </summary>
        public string? TEXT25 { get; set; }
        /// <summary>
        /// TEXT26 of the WORK_ORDER 
        /// </summary>
        public string? TEXT26 { get; set; }
        /// <summary>
        /// TEXT27 of the WORK_ORDER 
        /// </summary>
        public string? TEXT27 { get; set; }
        /// <summary>
        /// TEXT28 of the WORK_ORDER 
        /// </summary>
        public string? TEXT28 { get; set; }
        /// <summary>
        /// TEXT29 of the WORK_ORDER 
        /// </summary>
        public string? TEXT29 { get; set; }
        /// <summary>
        /// TEXT30 of the WORK_ORDER 
        /// </summary>
        public string? TEXT30 { get; set; }
        /// <summary>
        /// COMBO21 of the WORK_ORDER 
        /// </summary>
        public string? COMBO21 { get; set; }
        /// <summary>
        /// COMBO22 of the WORK_ORDER 
        /// </summary>
        public string? COMBO22 { get; set; }
        /// <summary>
        /// COMBO23 of the WORK_ORDER 
        /// </summary>
        public string? COMBO23 { get; set; }
        /// <summary>
        /// COMBO24 of the WORK_ORDER 
        /// </summary>
        public string? COMBO24 { get; set; }
        /// <summary>
        /// COMBO25 of the WORK_ORDER 
        /// </summary>
        public string? COMBO25 { get; set; }
        /// <summary>
        /// COMBO26 of the WORK_ORDER 
        /// </summary>
        public string? COMBO26 { get; set; }
        /// <summary>
        /// COMBO27 of the WORK_ORDER 
        /// </summary>
        public string? COMBO27 { get; set; }
        /// <summary>
        /// COMBO28 of the WORK_ORDER 
        /// </summary>
        public string? COMBO28 { get; set; }
        /// <summary>
        /// COMBO29 of the WORK_ORDER 
        /// </summary>
        public string? COMBO29 { get; set; }
        /// <summary>
        /// COMBO30 of the WORK_ORDER 
        /// </summary>
        public string? COMBO30 { get; set; }
        /// <summary>
        /// COMBO31 of the WORK_ORDER 
        /// </summary>
        public string? COMBO31 { get; set; }
        /// <summary>
        /// COMBO32 of the WORK_ORDER 
        /// </summary>
        public string? COMBO32 { get; set; }
        /// <summary>
        /// COMBO33 of the WORK_ORDER 
        /// </summary>
        public string? COMBO33 { get; set; }
        /// <summary>
        /// COMBO34 of the WORK_ORDER 
        /// </summary>
        public string? COMBO34 { get; set; }
        /// <summary>
        /// COMBO35 of the WORK_ORDER 
        /// </summary>
        public string? COMBO35 { get; set; }
        /// <summary>
        /// COMBO36 of the WORK_ORDER 
        /// </summary>
        public string? COMBO36 { get; set; }
        /// <summary>
        /// COMBO37 of the WORK_ORDER 
        /// </summary>
        public string? COMBO37 { get; set; }
        /// <summary>
        /// COMBO38 of the WORK_ORDER 
        /// </summary>
        public string? COMBO38 { get; set; }
        /// <summary>
        /// COMBO39 of the WORK_ORDER 
        /// </summary>
        public string? COMBO39 { get; set; }
        /// <summary>
        /// COMBO40 of the WORK_ORDER 
        /// </summary>
        public string? COMBO40 { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_CLOSED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CLOSED_BY")]
        public USR? GUID_USER_CLOSED_BY_USR { get; set; }

        /// <summary>
        /// CLOSED_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CLOSED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the GIS_ENTITY to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_GIS_ENTITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated GIS_ENTITY
        /// </summary>
        [ForeignKey("GUID_GIS_ENTITY")]
        public GIS_ENTITY? GUID_GIS_ENTITY_GIS_ENTITY { get; set; }
        /// <summary>
        /// SUM_DAYS_ACTIVE of the WORK_ORDER 
        /// </summary>
        public int? SUM_DAYS_ACTIVE { get; set; }
        /// <summary>
        /// SUM_DAYS_UNTIL_DUE_DATE of the WORK_ORDER 
        /// </summary>
        public int? SUM_DAYS_UNTIL_DUE_DATE { get; set; }
        /// <summary>
        /// SUM_DAYS_ACTIVE_FROM_REG_DATE of the WORK_ORDER 
        /// </summary>
        public int? SUM_DAYS_ACTIVE_FROM_REG_DATE { get; set; }
        /// <summary>
        /// COMBO01 of the WORK_ORDER 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the WORK_ORDER 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the WORK_ORDER 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the WORK_ORDER 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the WORK_ORDER 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the WORK_ORDER 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the WORK_ORDER 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the WORK_ORDER 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the WORK_ORDER 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the WORK_ORDER 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the WORK_ORDER 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the WORK_ORDER 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the WORK_ORDER 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the WORK_ORDER 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the WORK_ORDER 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the WORK_ORDER 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the WORK_ORDER 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the WORK_ORDER 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the WORK_ORDER 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the WORK_ORDER 
        /// </summary>
        public string? COMBO20 { get; set; }
        /// <summary>
        /// BUILDING_ID of the WORK_ORDER 
        /// </summary>
        public string? BUILDING_ID { get; set; }
        /// <summary>
        /// BUILDING_DESCRIPTION of the WORK_ORDER 
        /// </summary>
        public string? BUILDING_DESCRIPTION { get; set; }
        /// <summary>
        /// SUPPLIER_DESCRIPTION of the WORK_ORDER 
        /// </summary>
        public string? SUPPLIER_DESCRIPTION { get; set; }
        /// <summary>
        /// RESOURCE_GROUP_ID of the WORK_ORDER 
        /// </summary>
        public string? RESOURCE_GROUP_ID { get; set; }
        /// <summary>
        /// TEXT01 of the WORK_ORDER 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the WORK_ORDER 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the WORK_ORDER 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the WORK_ORDER 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the WORK_ORDER 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the WORK_ORDER 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the WORK_ORDER 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the WORK_ORDER 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the WORK_ORDER 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the WORK_ORDER 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the WORK_ORDER 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the WORK_ORDER 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the WORK_ORDER 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the WORK_ORDER 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the WORK_ORDER 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the WORK_ORDER 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the WORK_ORDER 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the WORK_ORDER 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the WORK_ORDER 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the WORK_ORDER 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// DATE01 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }

        /// <summary>
        /// DATE11 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE11 { get; set; }

        /// <summary>
        /// DATE12 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE12 { get; set; }

        /// <summary>
        /// DATE13 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE13 { get; set; }

        /// <summary>
        /// DATE14 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE14 { get; set; }

        /// <summary>
        /// DATE15 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE15 { get; set; }

        /// <summary>
        /// DATE16 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE16 { get; set; }

        /// <summary>
        /// DATE17 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE17 { get; set; }

        /// <summary>
        /// DATE18 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE18 { get; set; }

        /// <summary>
        /// DATE19 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE19 { get; set; }

        /// <summary>
        /// DATE20 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE20 { get; set; }

        /// <summary>
        /// DATE21 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE21 { get; set; }

        /// <summary>
        /// DATE22 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE22 { get; set; }

        /// <summary>
        /// DATE23 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE23 { get; set; }

        /// <summary>
        /// DATE24 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE24 { get; set; }

        /// <summary>
        /// DATE25 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE25 { get; set; }

        /// <summary>
        /// DATE26 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE26 { get; set; }

        /// <summary>
        /// DATE27 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE27 { get; set; }

        /// <summary>
        /// DATE28 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE28 { get; set; }

        /// <summary>
        /// DATE29 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE29 { get; set; }

        /// <summary>
        /// DATE30 of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE30 { get; set; }
        /// <summary>
        /// OUR_REFERENCE of the WORK_ORDER 
        /// </summary>
        public string? OUR_REFERENCE { get; set; }

        /// <summary>
        /// START_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// DUE_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DUE_DATE { get; set; }

        /// <summary>
        /// PRINTED_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PRINTED_DATE { get; set; }

        /// <summary>
        /// REPORTED_END_DATE of the WORK_ORDER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REPORTED_END_DATE { get; set; }
        /// <summary>
        /// NOTE of the WORK_ORDER 
        /// </summary>
        public string? NOTE { get; set; }
        /// <summary>
        /// REFERENCE of the WORK_ORDER 
        /// </summary>
        public string? REFERENCE { get; set; }
        /// <summary>
        /// REQUISITION_TEXT of the WORK_ORDER 
        /// </summary>
        public string? REQUISITION_TEXT { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the WORK_ORDER 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CAUSE to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_CAUSE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CAUSE
        /// </summary>
        [ForeignKey("GUID_CAUSE")]
        public CAUSE? GUID_CAUSE_CAUSE { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ITEM")]
        public CONTRACT_ITEM? GUID_CONTRACT_ITEM_CONTRACT_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the ACTIVITY_CATEGORY to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_ACTIVITY_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACTIVITY_CATEGORY
        /// </summary>
        [ForeignKey("GUID_ACTIVITY_CATEGORY")]
        public ACTIVITY_CATEGORY? GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PRIORITY to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_PRIORITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRIORITY
        /// </summary>
        [ForeignKey("GUID_PRIORITY")]
        public PRIORITY? GUID_PRIORITY_PRIORITY { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT
        /// </summary>
        [ForeignKey("GUID_PROJECT")]
        public PROJECT? GUID_PROJECT_PROJECT { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_RESPONSIBLE_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESPONSIBLE_PERSON")]
        public PERSON? GUID_RESPONSIBLE_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_USER_PRINTED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_PRINTED_BY")]
        public USR? GUID_USER_PRINTED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the REQUEST to which the WORK_ORDER belongs 
        /// </summary>
        public Guid? GUID_REQUEST { get; set; }

        /// <summary>
        /// Navigation property representing the associated REQUEST
        /// </summary>
        [ForeignKey("GUID_REQUEST")]
        public REQUEST? GUID_REQUEST_REQUEST { get; set; }
        /// <summary>
        /// ENTITY_ID of the WORK_ORDER 
        /// </summary>
        public string? ENTITY_ID { get; set; }
        /// <summary>
        /// ENTITY_DESCRIPTION of the WORK_ORDER 
        /// </summary>
        public string? ENTITY_DESCRIPTION { get; set; }
    }
}