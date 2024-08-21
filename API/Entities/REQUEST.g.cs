using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a request entity with essential details
    /// </summary>
    [Table("REQUEST", Schema = "dbo")]
    public class REQUEST
    {
        /// <summary>
        /// Initializes a new instance of the REQUEST class.
        /// </summary>
        public REQUEST()
        {
            STATUS = -1;
            GROUP_ID = 0;
            IS_TEMPLATE = false;
            ID = 0;
            REQUIRES_BIM_UPDATE = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the REQUEST 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the REQUEST 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field GROUP_ID of the REQUEST 
        /// </summary>
        [Required]
        public int GROUP_ID { get; set; }

        /// <summary>
        /// Required field IS_TEMPLATE of the REQUEST 
        /// </summary>
        [Required]
        public bool IS_TEMPLATE { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the REQUEST 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field ID of the REQUEST 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field REQUIRES_BIM_UPDATE of the REQUEST 
        /// </summary>
        [Required]
        public bool REQUIRES_BIM_UPDATE { get; set; }
        /// <summary>
        /// SUM_DAYS_ACTIVE of the REQUEST 
        /// </summary>
        public int? SUM_DAYS_ACTIVE { get; set; }
        /// <summary>
        /// SUM_DAYS_UNTIL_DUE_DATE of the REQUEST 
        /// </summary>
        public int? SUM_DAYS_UNTIL_DUE_DATE { get; set; }
        /// <summary>
        /// DESCRIPTION of the REQUEST 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// CONTACT_PERSON of the REQUEST 
        /// </summary>
        public string? CONTACT_PERSON { get; set; }
        /// <summary>
        /// LOCATION of the REQUEST 
        /// </summary>
        public string? LOCATION { get; set; }
        /// <summary>
        /// COMBO01 of the REQUEST 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the REQUEST 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the REQUEST 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the REQUEST 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the REQUEST 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the REQUEST 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the REQUEST 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the REQUEST 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the REQUEST 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the REQUEST 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the REQUEST 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the REQUEST 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the REQUEST 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the REQUEST 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the REQUEST 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the REQUEST 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the REQUEST 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the REQUEST 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the REQUEST 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the REQUEST 
        /// </summary>
        public string? COMBO20 { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST_ITEM_ANSWER to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST_ITEM_ANSWER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST_ITEM_ANSWER
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST_ITEM_ANSWER")]
        public CONTROL_LIST_ITEM_ANSWER? GUID_CONTROL_LIST_ITEM_ANSWER_CONTROL_LIST_ITEM_ANSWER { get; set; }
        /// <summary>
        /// Foreign key referencing the GIS_ENTITY to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_GIS_ENTITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated GIS_ENTITY
        /// </summary>
        [ForeignKey("GUID_GIS_ENTITY")]
        public GIS_ENTITY? GUID_GIS_ENTITY_GIS_ENTITY { get; set; }
        /// <summary>
        /// TEXT21 of the REQUEST 
        /// </summary>
        public string? TEXT21 { get; set; }
        /// <summary>
        /// TEXT22 of the REQUEST 
        /// </summary>
        public string? TEXT22 { get; set; }
        /// <summary>
        /// TEXT23 of the REQUEST 
        /// </summary>
        public string? TEXT23 { get; set; }
        /// <summary>
        /// TEXT24 of the REQUEST 
        /// </summary>
        public string? TEXT24 { get; set; }
        /// <summary>
        /// TEXT25 of the REQUEST 
        /// </summary>
        public string? TEXT25 { get; set; }
        /// <summary>
        /// TEXT26 of the REQUEST 
        /// </summary>
        public string? TEXT26 { get; set; }
        /// <summary>
        /// TEXT27 of the REQUEST 
        /// </summary>
        public string? TEXT27 { get; set; }
        /// <summary>
        /// TEXT28 of the REQUEST 
        /// </summary>
        public string? TEXT28 { get; set; }
        /// <summary>
        /// TEXT29 of the REQUEST 
        /// </summary>
        public string? TEXT29 { get; set; }
        /// <summary>
        /// TEXT30 of the REQUEST 
        /// </summary>
        public string? TEXT30 { get; set; }
        /// <summary>
        /// BIM_VISUALIZATION_INFO of the REQUEST 
        /// </summary>
        public string? BIM_VISUALIZATION_INFO { get; set; }
        /// <summary>
        /// COMBO21 of the REQUEST 
        /// </summary>
        public string? COMBO21 { get; set; }
        /// <summary>
        /// COMBO22 of the REQUEST 
        /// </summary>
        public string? COMBO22 { get; set; }
        /// <summary>
        /// COMBO23 of the REQUEST 
        /// </summary>
        public string? COMBO23 { get; set; }
        /// <summary>
        /// COMBO24 of the REQUEST 
        /// </summary>
        public string? COMBO24 { get; set; }
        /// <summary>
        /// COMBO25 of the REQUEST 
        /// </summary>
        public string? COMBO25 { get; set; }
        /// <summary>
        /// COMBO26 of the REQUEST 
        /// </summary>
        public string? COMBO26 { get; set; }
        /// <summary>
        /// COMBO27 of the REQUEST 
        /// </summary>
        public string? COMBO27 { get; set; }
        /// <summary>
        /// COMBO28 of the REQUEST 
        /// </summary>
        public string? COMBO28 { get; set; }
        /// <summary>
        /// COMBO29 of the REQUEST 
        /// </summary>
        public string? COMBO29 { get; set; }
        /// <summary>
        /// COMBO30 of the REQUEST 
        /// </summary>
        public string? COMBO30 { get; set; }
        /// <summary>
        /// COMBO31 of the REQUEST 
        /// </summary>
        public string? COMBO31 { get; set; }
        /// <summary>
        /// COMBO32 of the REQUEST 
        /// </summary>
        public string? COMBO32 { get; set; }
        /// <summary>
        /// COMBO33 of the REQUEST 
        /// </summary>
        public string? COMBO33 { get; set; }
        /// <summary>
        /// COMBO34 of the REQUEST 
        /// </summary>
        public string? COMBO34 { get; set; }
        /// <summary>
        /// COMBO35 of the REQUEST 
        /// </summary>
        public string? COMBO35 { get; set; }
        /// <summary>
        /// COMBO36 of the REQUEST 
        /// </summary>
        public string? COMBO36 { get; set; }
        /// <summary>
        /// COMBO37 of the REQUEST 
        /// </summary>
        public string? COMBO37 { get; set; }
        /// <summary>
        /// COMBO38 of the REQUEST 
        /// </summary>
        public string? COMBO38 { get; set; }
        /// <summary>
        /// COMBO39 of the REQUEST 
        /// </summary>
        public string? COMBO39 { get; set; }
        /// <summary>
        /// COMBO40 of the REQUEST 
        /// </summary>
        public string? COMBO40 { get; set; }
        /// <summary>
        /// Foreign key referencing the BCF_PROJECT to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_BCF_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated BCF_PROJECT
        /// </summary>
        [ForeignKey("GUID_BCF_PROJECT")]
        public BCF_PROJECT? GUID_BCF_PROJECT_BCF_PROJECT { get; set; }

        /// <summary>
        /// CLOSED_DATE of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CLOSED_DATE { get; set; }
        /// <summary>
        /// TEXT01 of the REQUEST 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the REQUEST 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the REQUEST 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the REQUEST 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the REQUEST 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the REQUEST 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the REQUEST 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the REQUEST 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the REQUEST 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the REQUEST 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the REQUEST 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the REQUEST 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the REQUEST 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the REQUEST 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the REQUEST 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the REQUEST 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the REQUEST 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the REQUEST 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the REQUEST 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the REQUEST 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// DATE01 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }

        /// <summary>
        /// DATE11 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE11 { get; set; }

        /// <summary>
        /// DATE12 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE12 { get; set; }

        /// <summary>
        /// DATE13 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE13 { get; set; }

        /// <summary>
        /// DATE14 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE14 { get; set; }

        /// <summary>
        /// DATE15 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE15 { get; set; }

        /// <summary>
        /// DATE16 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE16 { get; set; }

        /// <summary>
        /// DATE17 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE17 { get; set; }

        /// <summary>
        /// DATE18 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE18 { get; set; }

        /// <summary>
        /// DATE19 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE19 { get; set; }

        /// <summary>
        /// DATE20 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE20 { get; set; }

        /// <summary>
        /// DATE21 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE21 { get; set; }

        /// <summary>
        /// DATE22 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE22 { get; set; }

        /// <summary>
        /// DATE23 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE23 { get; set; }

        /// <summary>
        /// DATE24 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE24 { get; set; }

        /// <summary>
        /// DATE25 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE25 { get; set; }

        /// <summary>
        /// DATE26 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE26 { get; set; }

        /// <summary>
        /// DATE27 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE27 { get; set; }

        /// <summary>
        /// DATE28 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE28 { get; set; }

        /// <summary>
        /// DATE29 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE29 { get; set; }

        /// <summary>
        /// DATE30 of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE30 { get; set; }
        /// <summary>
        /// REGISTERED_BY of the REQUEST 
        /// </summary>
        public string? REGISTERED_BY { get; set; }

        /// <summary>
        /// REGISTERED_DATE of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REGISTERED_DATE { get; set; }

        /// <summary>
        /// DUE_DATE of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DUE_DATE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the REQUEST 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// TELEPHONE of the REQUEST 
        /// </summary>
        public string? TELEPHONE { get; set; }

        /// <summary>
        /// START_DATE of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }
        /// <summary>
        /// EMAIL_ADDRESS of the REQUEST 
        /// </summary>
        public string? EMAIL_ADDRESS { get; set; }
        /// <summary>
        /// CASE_NUMBER of the REQUEST 
        /// </summary>
        public string? CASE_NUMBER { get; set; }
        /// <summary>
        /// FORWARD_PHONE of the REQUEST 
        /// </summary>
        public string? FORWARD_PHONE { get; set; }
        /// <summary>
        /// FORWARD_PERSON of the REQUEST 
        /// </summary>
        public string? FORWARD_PERSON { get; set; }
        /// <summary>
        /// FORWARD_EMAIL of the REQUEST 
        /// </summary>
        public string? FORWARD_EMAIL { get; set; }

        /// <summary>
        /// UPDATED_DATE of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the REQUEST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CAUSE to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_CAUSE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CAUSE
        /// </summary>
        [ForeignKey("GUID_CAUSE")]
        public CAUSE? GUID_CAUSE_CAUSE { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the ACTIVITY_CATEGORY to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_ACTIVITY_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACTIVITY_CATEGORY
        /// </summary>
        [ForeignKey("GUID_ACTIVITY_CATEGORY")]
        public ACTIVITY_CATEGORY? GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PRIORITY to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_PRIORITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRIORITY
        /// </summary>
        [ForeignKey("GUID_PRIORITY")]
        public PRIORITY? GUID_PRIORITY_PRIORITY { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT
        /// </summary>
        [ForeignKey("GUID_PROJECT")]
        public PROJECT? GUID_PROJECT_PROJECT { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_RESPONSIBLE_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESPONSIBLE_PERSON")]
        public PERSON? GUID_RESPONSIBLE_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DRAWING to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_DRAWING { get; set; }

        /// <summary>
        /// Navigation property representing the associated DRAWING
        /// </summary>
        [ForeignKey("GUID_DRAWING")]
        public DRAWING? GUID_DRAWING_DRAWING { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the REQUEST belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
    }
}