using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a periodic_task entity with essential details
    /// </summary>
    [Table("PERIODIC_TASK", Schema = "dbo")]
    public class PERIODIC_TASK
    {
        /// <summary>
        /// Initializes a new instance of the PERIODIC_TASK class.
        /// </summary>
        public PERIODIC_TASK()
        {
            ID = 0;
            SEASON = 0;
            INTERVAL = 0;
            PERIOD = -1;
            DUE_DATE_CONTROL_CODE = -1;
            DEADLINE_PERIOD_UNIT = -1;
            IS_AREA_IN_WORK_PROGRESS = false;
            IS_EQUIPMENT_IN_WORK_PROGRESS = false;
            IS_FIRE_RELATED = false;
            IS_ELECTRO_RELATED = false;
            IS_USED_IN_CALCULATION = false;
            NB_PURCHASE_ORDER_ITEM = 0;
            MUST_LINK_INSTANCES = false;
            IS_DEACTIVATED = false;
            IS_TEMPLATE = false;
            IS_HSE_RELATED = false;
            IS_CERTIFICATION_JOB = false;
            FHS_TYPE = -1;
            TEMPLATE_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PERIODIC_TASK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field SEASON of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int SEASON { get; set; }

        /// <summary>
        /// Required field INTERVAL of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int INTERVAL { get; set; }

        /// <summary>
        /// Required field PERIOD of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int PERIOD { get; set; }

        /// <summary>
        /// Required field DUE_DATE_CONTROL_CODE of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int DUE_DATE_CONTROL_CODE { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field DUE_VALUE of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public double DUE_VALUE { get; set; }

        /// <summary>
        /// Required field LAST_EXECUTION_VALUE of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public double LAST_EXECUTION_VALUE { get; set; }

        /// <summary>
        /// Required field EXTERNAL_ESTIMATED_COST of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public double EXTERNAL_ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field DEADLINE_PERIOD_NUMBER of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public double DEADLINE_PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field DEADLINE_PERIOD_UNIT of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int DEADLINE_PERIOD_UNIT { get; set; }

        /// <summary>
        /// Required field IS_AREA_IN_WORK_PROGRESS of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_AREA_IN_WORK_PROGRESS { get; set; }

        /// <summary>
        /// Required field IS_EQUIPMENT_IN_WORK_PROGRESS of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_EQUIPMENT_IN_WORK_PROGRESS { get; set; }

        /// <summary>
        /// Required field IS_FIRE_RELATED of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_FIRE_RELATED { get; set; }

        /// <summary>
        /// Required field IS_ELECTRO_RELATED of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_ELECTRO_RELATED { get; set; }

        /// <summary>
        /// Required field IS_USED_IN_CALCULATION of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_USED_IN_CALCULATION { get; set; }

        /// <summary>
        /// Required field NB_PURCHASE_ORDER_ITEM of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int NB_PURCHASE_ORDER_ITEM { get; set; }

        /// <summary>
        /// Required field MUST_LINK_INSTANCES of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool MUST_LINK_INSTANCES { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field IS_TEMPLATE of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_TEMPLATE { get; set; }

        /// <summary>
        /// Required field IS_HSE_RELATED of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_HSE_RELATED { get; set; }

        /// <summary>
        /// Required field IS_CERTIFICATION_JOB of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public bool IS_CERTIFICATION_JOB { get; set; }

        /// <summary>
        /// Required field FHS_TYPE of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int FHS_TYPE { get; set; }

        /// <summary>
        /// Required field TEMPLATE_TYPE of the PERIODIC_TASK 
        /// </summary>
        [Required]
        public int TEMPLATE_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_INVOICE_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_INVOICE_CUSTOMER")]
        public CUSTOMER? GUID_INVOICE_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the PERIODIC_TASK 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// REQUISITION_TEXT of the PERIODIC_TASK 
        /// </summary>
        public string? REQUISITION_TEXT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACTIVITY_GROUP to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_ACTIVITY_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACTIVITY_GROUP
        /// </summary>
        [ForeignKey("GUID_ACTIVITY_GROUP")]
        public ACTIVITY_GROUP? GUID_ACTIVITY_GROUP_ACTIVITY_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_RESPONSIBLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESOURCE_RESPONSIBLE")]
        public PERSON? GUID_RESOURCE_RESPONSIBLE_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT
        /// </summary>
        [ForeignKey("GUID_PROJECT")]
        public PROJECT? GUID_PROJECT_PROJECT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PERIODIC_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PERIODIC_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// NUMBER_OF_AREAS_TO_CONTROL of the PERIODIC_TASK 
        /// </summary>
        public string? NUMBER_OF_AREAS_TO_CONTROL { get; set; }
        /// <summary>
        /// ARTICLE_DESCRIPTION of the PERIODIC_TASK 
        /// </summary>
        public string? ARTICLE_DESCRIPTION { get; set; }
        /// <summary>
        /// GROUPING of the PERIODIC_TASK 
        /// </summary>
        public string? GROUPING { get; set; }
        /// <summary>
        /// POST_IT_NOTE of the PERIODIC_TASK 
        /// </summary>
        public string? POST_IT_NOTE { get; set; }
        /// <summary>
        /// REFERENCE of the PERIODIC_TASK 
        /// </summary>
        public string? REFERENCE { get; set; }

        /// <summary>
        /// LAST_EXECUTED_DATE of the PERIODIC_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_EXECUTED_DATE { get; set; }
        /// <summary>
        /// DESCRIPTION of the PERIODIC_TASK 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// ENTITY_ID of the PERIODIC_TASK 
        /// </summary>
        public string? ENTITY_ID { get; set; }
        /// <summary>
        /// ENTITY_DESCRIPTION of the PERIODIC_TASK 
        /// </summary>
        public string? ENTITY_DESCRIPTION { get; set; }

        /// <summary>
        /// DUE_DATE of the PERIODIC_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DUE_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT_HOURS { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT_HOURS")]
        public EQUIPMENT? GUID_EQUIPMENT_HOURS_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_RESPONSIBLE_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESPONSIBLE_PERSON")]
        public PERSON? GUID_RESPONSIBLE_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the ACTIVITY_CATEGORY to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_ACTIVITY_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACTIVITY_CATEGORY
        /// </summary>
        [ForeignKey("GUID_ACTIVITY_CATEGORY")]
        public ACTIVITY_CATEGORY? GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the CAUSE to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_CAUSE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CAUSE
        /// </summary>
        [ForeignKey("GUID_CAUSE")]
        public CAUSE? GUID_CAUSE_CAUSE { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PRIORITY to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_PRIORITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRIORITY
        /// </summary>
        [ForeignKey("GUID_PRIORITY")]
        public PRIORITY? GUID_PRIORITY_PRIORITY { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER_FORM to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER_FORM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER_FORM
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER_FORM")]
        public PURCHASE_ORDER_FORM? GUID_PURCHASE_ORDER_FORM_PURCHASE_ORDER_FORM { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_TEMPLATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_TEMPLATE")]
        public PERIODIC_TASK? GUID_TEMPLATE_PERIODIC_TASK { get; set; }
    }
}