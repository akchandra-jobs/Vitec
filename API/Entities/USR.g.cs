using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a usr entity with essential details
    /// </summary>
    [Table("USR", Schema = "dbo")]
    public class USR
    {
        /// <summary>
        /// Initializes a new instance of the USR class.
        /// </summary>
        public USR()
        {
            CAN_RUN_NEW_ENERGY_PERIOD = false;
            IS_BOOKING_ADMINISTRATOR = false;
            IS_USER_GROUP = false;
            IS_LOCKED = false;
            IS_USER_ADMINISTRATOR = false;
            IS_SYSTEM_ADMINISTRATOR = false;
            CAN_RUN_NEW_PERIOD = false;
            CAN_CHANGE_DATA_OWNER = false;
            CAN_PRINT_PURCHASE_ORDER = false;
            IS_PASSWORD_PERMANENT = false;
            CAN_RUN_SYSTEM_FUNCTION = false;
            OFFICE_STYLE = -1;
            IS_USING_TABBED_DOCUMENTS = false;
            IS_SEARCH_OUTPUT_FILTERED = false;
            LOGIN_ATTEMPTS = 0;
            IS_DEACTIVATED = false;
            ACCESS_TYPE = 0;
            CAN_OVERRIDE_PERMISSIONS = false;
            IS_START_PAGE_FORCED = false;
            IS_EXTERNAL_USER = false;
            CAN_CHANGE_REQUEST_STATUS = false;
            CAN_SEE_WEB_MAIN_MENU = false;
            CAN_CHANGE_DATA_ACQUISITION_STATUS = false;
            IS_TWO_FACTOR_AUTHENTICATION_ENABLED = false;
            ACCOUNT_TYPE = 0;
            CAN_EXPORT_TO_EXCEL = false;
            ENABLE_WEB_NAVIGATION = false;
            MOST_PERMISSIVE_PROFILE_TYPE = -1;
            LICENSE_TYPE = 3;
            IS_PROJECT_ADMINISTRATOR = false;
            CAN_OVERRIDE_USER_PROFILES = false;
            CREATION_DATE = DateTime.UtcNow;
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USR 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field CAN_RUN_NEW_ENERGY_PERIOD of the USR 
        /// </summary>
        [Required]
        public bool CAN_RUN_NEW_ENERGY_PERIOD { get; set; }

        /// <summary>
        /// Required field IS_BOOKING_ADMINISTRATOR of the USR 
        /// </summary>
        [Required]
        public bool IS_BOOKING_ADMINISTRATOR { get; set; }

        /// <summary>
        /// Required field IS_USER_GROUP of the USR 
        /// </summary>
        [Required]
        public bool IS_USER_GROUP { get; set; }

        /// <summary>
        /// Required field IS_LOCKED of the USR 
        /// </summary>
        [Required]
        public bool IS_LOCKED { get; set; }

        /// <summary>
        /// Required field IS_USER_ADMINISTRATOR of the USR 
        /// </summary>
        [Required]
        public bool IS_USER_ADMINISTRATOR { get; set; }

        /// <summary>
        /// Required field IS_SYSTEM_ADMINISTRATOR of the USR 
        /// </summary>
        [Required]
        public bool IS_SYSTEM_ADMINISTRATOR { get; set; }

        /// <summary>
        /// Required field CAN_RUN_NEW_PERIOD of the USR 
        /// </summary>
        [Required]
        public bool CAN_RUN_NEW_PERIOD { get; set; }

        /// <summary>
        /// Required field CAN_CHANGE_DATA_OWNER of the USR 
        /// </summary>
        [Required]
        public bool CAN_CHANGE_DATA_OWNER { get; set; }

        /// <summary>
        /// Required field CAN_PRINT_PURCHASE_ORDER of the USR 
        /// </summary>
        [Required]
        public bool CAN_PRINT_PURCHASE_ORDER { get; set; }

        /// <summary>
        /// Required field IS_PASSWORD_PERMANENT of the USR 
        /// </summary>
        [Required]
        public bool IS_PASSWORD_PERMANENT { get; set; }

        /// <summary>
        /// Required field CAN_RUN_SYSTEM_FUNCTION of the USR 
        /// </summary>
        [Required]
        public bool CAN_RUN_SYSTEM_FUNCTION { get; set; }

        /// <summary>
        /// Required field OFFICE_STYLE of the USR 
        /// </summary>
        [Required]
        public int OFFICE_STYLE { get; set; }

        /// <summary>
        /// Required field IS_USING_TABBED_DOCUMENTS of the USR 
        /// </summary>
        [Required]
        public bool IS_USING_TABBED_DOCUMENTS { get; set; }

        /// <summary>
        /// Required field IS_SEARCH_OUTPUT_FILTERED of the USR 
        /// </summary>
        [Required]
        public bool IS_SEARCH_OUTPUT_FILTERED { get; set; }

        /// <summary>
        /// Required field LOGIN_ATTEMPTS of the USR 
        /// </summary>
        [Required]
        public int LOGIN_ATTEMPTS { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the USR 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field ACCESS_TYPE of the USR 
        /// </summary>
        [Required]
        public int ACCESS_TYPE { get; set; }

        /// <summary>
        /// Required field CAN_OVERRIDE_PERMISSIONS of the USR 
        /// </summary>
        [Required]
        public bool CAN_OVERRIDE_PERMISSIONS { get; set; }

        /// <summary>
        /// Required field PROCURATION of the USR 
        /// </summary>
        [Required]
        public double PROCURATION { get; set; }

        /// <summary>
        /// Required field IS_START_PAGE_FORCED of the USR 
        /// </summary>
        [Required]
        public bool IS_START_PAGE_FORCED { get; set; }

        /// <summary>
        /// Required field IS_EXTERNAL_USER of the USR 
        /// </summary>
        [Required]
        public bool IS_EXTERNAL_USER { get; set; }

        /// <summary>
        /// Required field CAN_CHANGE_REQUEST_STATUS of the USR 
        /// </summary>
        [Required]
        public bool CAN_CHANGE_REQUEST_STATUS { get; set; }

        /// <summary>
        /// Required field CAN_SEE_WEB_MAIN_MENU of the USR 
        /// </summary>
        [Required]
        public bool CAN_SEE_WEB_MAIN_MENU { get; set; }

        /// <summary>
        /// Required field CAN_CHANGE_DATA_ACQUISITION_STATUS of the USR 
        /// </summary>
        [Required]
        public bool CAN_CHANGE_DATA_ACQUISITION_STATUS { get; set; }

        /// <summary>
        /// Required field IS_TWO_FACTOR_AUTHENTICATION_ENABLED of the USR 
        /// </summary>
        [Required]
        public bool IS_TWO_FACTOR_AUTHENTICATION_ENABLED { get; set; }

        /// <summary>
        /// Required field ACCOUNT_TYPE of the USR 
        /// </summary>
        [Required]
        public int ACCOUNT_TYPE { get; set; }

        /// <summary>
        /// Required field CAN_EXPORT_TO_EXCEL of the USR 
        /// </summary>
        [Required]
        public bool CAN_EXPORT_TO_EXCEL { get; set; }

        /// <summary>
        /// Required field ENABLE_WEB_NAVIGATION of the USR 
        /// </summary>
        [Required]
        public bool ENABLE_WEB_NAVIGATION { get; set; }

        /// <summary>
        /// Required field MOST_PERMISSIVE_PROFILE_TYPE of the USR 
        /// </summary>
        [Required]
        public int MOST_PERMISSIVE_PROFILE_TYPE { get; set; }

        /// <summary>
        /// Required field LICENSE_TYPE of the USR 
        /// </summary>
        [Required]
        public int LICENSE_TYPE { get; set; }

        /// <summary>
        /// Required field IS_PROJECT_ADMINISTRATOR of the USR 
        /// </summary>
        [Required]
        public bool IS_PROJECT_ADMINISTRATOR { get; set; }

        /// <summary>
        /// Required field CAN_OVERRIDE_USER_PROFILES of the USR 
        /// </summary>
        [Required]
        public bool CAN_OVERRIDE_USER_PROFILES { get; set; }

        /// <summary>
        /// TERMS_OF_USE_ACCEPTED_DATE of the USR 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TERMS_OF_USE_ACCEPTED_DATE { get; set; }
        /// <summary>
        /// ADDITIONAL_PERMISSIONS of the USR 
        /// </summary>
        public string? ADDITIONAL_PERMISSIONS { get; set; }
        /// <summary>
        /// CELL_PHONE of the USR 
        /// </summary>
        public string? CELL_PHONE { get; set; }
        /// <summary>
        /// ADMINISTRATOR_COMMENT of the USR 
        /// </summary>
        public string? ADMINISTRATOR_COMMENT { get; set; }

        /// <summary>
        /// LOCKED_DATE of the USR 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LOCKED_DATE { get; set; }
        /// <summary>
        /// LDAP_SAML_ID of the USR 
        /// </summary>
        public string? LDAP_SAML_ID { get; set; }
        /// <summary>
        /// MRU_ENTITIES of the USR 
        /// </summary>
        public string? MRU_ENTITIES { get; set; }
        /// <summary>
        /// MRU_DOCUMENTS of the USR 
        /// </summary>
        public byte[]? MRU_DOCUMENTS { get; set; }
        /// <summary>
        /// Foreign key referencing the IMAGE to which the USR belongs 
        /// </summary>
        public Guid? GUID_IMAGE { get; set; }

        /// <summary>
        /// Navigation property representing the associated IMAGE
        /// </summary>
        [ForeignKey("GUID_IMAGE")]
        public IMAGE? GUID_IMAGE_IMAGE { get; set; }
        /// <summary>
        /// Foreign key referencing the MOBILE_MENU_PROFILE to which the USR belongs 
        /// </summary>
        public Guid? GUID_MOBILE_MENU_PROFILE { get; set; }

        /// <summary>
        /// Navigation property representing the associated MOBILE_MENU_PROFILE
        /// </summary>
        [ForeignKey("GUID_MOBILE_MENU_PROFILE")]
        public MOBILE_MENU_PROFILE? GUID_MOBILE_MENU_PROFILE_MOBILE_MENU_PROFILE { get; set; }
        /// <summary>
        /// LDAP_GROUP of the USR 
        /// </summary>
        public string? LDAP_GROUP { get; set; }
        /// <summary>
        /// LDAP_GUID of the USR 
        /// </summary>
        public string? LDAP_GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USR belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USR 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USR belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// SQL_CUSTOMER_FILTER of the USR 
        /// </summary>
        public string? SQL_CUSTOMER_FILTER { get; set; }
        /// <summary>
        /// THEME_FILE of the USR 
        /// </summary>
        public string? THEME_FILE { get; set; }
        /// <summary>
        /// LDAP_DN of the USR 
        /// </summary>
        public string? LDAP_DN { get; set; }
        /// <summary>
        /// MY_PAGE of the USR 
        /// </summary>
        public byte[]? MY_PAGE { get; set; }
        /// <summary>
        /// CUSTOM_MENU of the USR 
        /// </summary>
        public byte[]? CUSTOM_MENU { get; set; }
        /// <summary>
        /// CUSTOM_REPORT_MENU of the USR 
        /// </summary>
        public byte[]? CUSTOM_REPORT_MENU { get; set; }

        /// <summary>
        /// LAST_LOGIN_DATE of the USR 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_LOGIN_DATE { get; set; }

        /// <summary>
        /// PASSWORD_LAST_DAY_DATE of the USR 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PASSWORD_LAST_DAY_DATE { get; set; }
        /// <summary>
        /// OPTIONS of the USR 
        /// </summary>
        public string? OPTIONS { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the USR belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the USR belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the USR belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the USR belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the USR belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING_SELECTION to which the USR belongs 
        /// </summary>
        public Guid? GUID_BUILDING_SELECTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING_SELECTION
        /// </summary>
        [ForeignKey("GUID_BUILDING_SELECTION")]
        public BUILDING_SELECTION? GUID_BUILDING_SELECTION_BUILDING_SELECTION { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USR belongs 
        /// </summary>
        public Guid? GUID_USER_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_GROUP")]
        public USR? GUID_USER_GROUP_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the WEB_MENU to which the USR belongs 
        /// </summary>
        public Guid? GUID_WEB_MENU { get; set; }

        /// <summary>
        /// Navigation property representing the associated WEB_MENU
        /// </summary>
        [ForeignKey("GUID_WEB_MENU")]
        public WEB_MENU? GUID_WEB_MENU_WEB_MENU { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the USR belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the USR belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the START_PAGE to which the USR belongs 
        /// </summary>
        public Guid? GUID_START_PAGE { get; set; }

        /// <summary>
        /// Navigation property representing the associated START_PAGE
        /// </summary>
        [ForeignKey("GUID_START_PAGE")]
        public START_PAGE? GUID_START_PAGE_START_PAGE { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_PERMISSION_PROFILE to which the USR belongs 
        /// </summary>
        public Guid? GUID_ENTITY_PERMISSION_PROFILE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_PERMISSION_PROFILE
        /// </summary>
        [ForeignKey("GUID_ENTITY_PERMISSION_PROFILE")]
        public ENTITY_PERMISSION_PROFILE? GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE { get; set; }
        /// <summary>
        /// Foreign key referencing the LANGUAGE to which the USR belongs 
        /// </summary>
        public Guid? GUID_LANGUAGE { get; set; }

        /// <summary>
        /// Navigation property representing the associated LANGUAGE
        /// </summary>
        [ForeignKey("GUID_LANGUAGE")]
        public LANGUAGE? GUID_LANGUAGE_LANGUAGE { get; set; }
        /// <summary>
        /// USERNAME of the USR 
        /// </summary>
        public string? USERNAME { get; set; }
        /// <summary>
        /// PASSWORD of the USR 
        /// </summary>
        public string? PASSWORD { get; set; }
        /// <summary>
        /// REAL_NAME of the USR 
        /// </summary>
        public string? REAL_NAME { get; set; }
        /// <summary>
        /// PHONE_NUMBER of the USR 
        /// </summary>
        public string? PHONE_NUMBER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USR 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }

        /// <summary>
        /// PASSWORD_LAST_UPDATED_DATE of the USR 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PASSWORD_LAST_UPDATED_DATE { get; set; }
        /// <summary>
        /// EMAIL of the USR 
        /// </summary>
        public string? EMAIL { get; set; }
    }
}