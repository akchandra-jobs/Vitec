using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a general_options entity with essential details
    /// </summary>
    [Table("GENERAL_OPTIONS", Schema = "dbo")]
    public class GENERAL_OPTIONS
    {
        /// <summary>
        /// Initializes a new instance of the GENERAL_OPTIONS class.
        /// </summary>
        public GENERAL_OPTIONS()
        {
            PWD_MIN_NUMBER_CHARS = 0;
            PWD_MUST_CONTAIN_LETTERS = false;
            PWD_MUST_CONTAIN_DIGITS = false;
            PWD_CHECK_HISTORIC = false;
            PWD_NO_OF_TRIES = 0;
            LOGOFF_PERIOD = 0;
            ORG_HAS_UNIQUE_COLOR_HATCHING = false;
            ORG_HAS_SUBDIVISION = false;
            AREA_DECIMALS = 2;
            USE_AREA_AVAILABILITY = false;
            AREA_CAN_HAVE_DEPENDENCIES = false;
            CAN_EDIT_OR_DELETE_COST = false;
            USE_UNIT_PRICE_WITH_COST = false;
            USE_MAIN_SUPPLIER = false;
            EVAL_BLD_SUMS_WITH_VAR_AREA = false;
            COST_CENTER_HAS_UNIQUE_ESTATE = false;
            CAN_EDIT_INVENTORY = false;
            USE_PO_STATUS_CONFIRMED = false;
            USE_PRICE_SHEET = false;
            CAN_INVOICE_HOUSING_CONTRACT = false;
            CONT_ITEM_MUST_HAVE_SERVICE = false;
            MOVE_CO_AFTER_TARGET_INV_DATE = false;
            PS_MUST_HAVE_SERVICE_PRICE = false;
            ADD_SERVICE_IN_FIRST_PS_REV = false;
            SELECTION_MUST_INCLUDE_ALL_CC = false;
            SEND_PO_ONLY_BY_MAIL = false;
            CHECK_DUPLICATES_IN_WO = false;
            UPDATE_WO_CONDITION_ON_CLOSING = false;
            USE_PO_IN_WO = false;
            WO_CAT_IS_MANDATORY_ON_CLOSE = false;
            WO_PRIO_IS_MANDATORY_ON_CLOSE = false;
            WO_DF_ARE_MANDATORY_ON_CLOSE = false;
            SEND_WO_COPY_TO_CURRENT_USER = false;
            PO_RELEASE_IMPLIES_STD_RELEASE = false;
            SET_LOCATION_ON_EQUIP_RETURN = false;
            CONTROL_CONT_ITEM_ON_RETURN = false;
            CAN_SAVE_CONT_ITEM_VERSIONS = false;
            INVOICE_WHOLE_DAYS = false;
            CAN_RENT_OUT_EQUIPMENT = false;
            CAN_RENT_OUT_AREA = false;
            CAN_RENT_OUT_ARTICLE = false;
            CAN_RENT_OUT_COMPONENT = false;
            EQ_CI_HAS_UNIQUE_SERVICE = false;
            AREA_CI_HAS_UNIQUE_SERVICE = false;
            ARTICLE_CI_HAS_UNIQUE_SERVICE = false;
            COMP_CI_HAS_UNIQUE_SERVICE = false;
            EQ_CI_HAS_OWN_ACCOUNTING = false;
            AREA_CI_HAS_OWN_ACCOUNTING = false;
            ARTICLE_CI_HAS_OWN_ACCOUNTING = false;
            COMP_CI_HAS_OWN_ACCOUNTING = false;
            USE_CONTRACT_ITEM_BATCH_INSERT = false;
            HOUS_PRIC_PER_SRV_IS_MANDATORY = false;
            USE_TRANSFER = false;
            USE_PAYMENT = false;
            USE_AUTOMATIC_PERIODIZATION = false;
            USE_OUTLOOK = false;
            SHOW_DEFAULT_INFO_ON_DRAWING = false;
            CAN_SAVE_DRAWING_AS_SVG = false;
            USE_EQUIPMENT_CONTROL_IN_WORKS = false;
            SERVER_CAN_GENERATE_NEW_PERIOD = false;
            PROCESS_AUTOCAD_XREF = false;
            FONT_SIZE = 8;
            ENERGY_BUDGET_YEAR = 0;
            PREVIOUS_ENERGY_BUDGET_YEAR = 0;
            USE_BIT = false;
            CAN_CHANGE_DATA_OWNER = false;
            EQ_MUST_BE_LOCATED_IN_OWN_BLD = false;
            USE_DESKTOP_SINGLE_SIGN_ON = false;
            DYN_CAT_REFERENCES_ONLY_ABSTR = false;
            USE_PROJECTED_ACTIVITIES = false;
            SET_PO_DOCUMENT_AS_ATTACHMENT = false;
            CAN_SET_DOCUMENT_AS_ATTACHMENT = false;
            BLD_CAN_HAVE_SEVERAL_ADDRESSES = false;
            EQ_CAN_HAVE_SAME_DEVIATION = false;
            FILTER_DEVIATION_BY_EQ_PREFIX = false;
            CAN_LOCK_PO_PROPOSAL = false;
            USE_COMPONENT_COUNTER = false;
            DEFAULT_PO_ENTITY_TYPE = 12;
            CHECK_DUPLICATE_ENTITY_IN_PO = false;
            CAN_RELEASE_PO_ZERO_AMOUNT = false;
            CAN_EDIT_PO_ITEM_AFTER_ORDER = false;
            GET_PO_ITEM_ACCOUNTING_FROM_WO = false;
            CAN_CHANGE_PO_ITEM_FROM_COST = false;
            PO_ITEM_UPDATES_COMP_PRICE = false;
            COMPUTE_ALLOC_SUM_PER_PO_ITEM = false;
            ASK_FOR_START_DATE_MANUAL_WO = false;
            USE_AUTO_TRANSLATION_REQUEST = false;
            CAN_SAVE_PERS_WITH_INVALID_ID = false;
            USE_CUSTOMER_IN_REQUEST = false;
            USE_PERSON_SCHEDULING = false;
            USE_PERSON_ROLE = false;
            USE_ONLY_ACTIV_PERSON_ON_ACTIV = false;
            USE_ONLY_PERS_IN_BLD_ON_ACTIV = false;
            OVERRIDE_ACT_WITH_PERS_INFO = false;
            ENTITY_AVAIL_IGNORES_HISTORY = false;
            CAN_SHOW_DEACTIVATED_ENTITIES = false;
            USE_CAUSE_NOT_EXECUTED = false;
            USE_BUILDING_TEMPLATES = false;
            MAIL_SERVER_PORT_NUMBER = 25;
            USE_UNIQUE_KEY = false;
            USE_RECEPTION = false;
            YEAR_RANGE_START = 2000;
            YEAR_RANGE_END = 2030;
            AREA_DWG_EXTRACTION_METHOD = 2;
            CONTRACT_TYPE_RENTAL_PERIOD = 2;
            USE_AREA_CLASSIFICATION = false;
            DESKTOP_USER_AUTHENTICATION = 0;
            BARCODE_GENERATE_AREA = false;
            BARCODE_GENERATE_BUILDING = false;
            BARCODE_GENERATE_EQUIPMENT = false;
            BARCODE_GENERATE_COMPONENT = false;
            WORK_ORDER_SHOW_COMPLETE_BUTTON = false;
            MAIL_SERVER_CONNECTION_TYPE = 0;
            MONITOR_LIST_LAYOUT_USAGE = false;
            LOG_SECURITY_DB_LEVEL = -1;
            LOG_SECURITY_DB_PERSISTED_DAYS = 7;
            LOG_SECURITY_EVENT_LEVEL = -1;
            WEB_USER_AUTHENTICATION = 1;
            PROCESS_ALL_BLOCKS_ON_SAME_LAYER = false;
            WORK_ORDER_CAUSE_IS_MANDATORY_ONLY_ON_END_DATE = false;
            WORK_ORDER_RESPONSIBLE_PERSON_IS_MANDATORY_ONLY_ON_END_DATE = false;
            USE_LOCATION_IN_REQUEST = false;
            ALLOW_API_CONNECTIONS = false;
            USE_API_TOKEN = false;
            ACTIVATE_PURCHASE_ORDER_IN_WEB = false;
            SYNCHRONIZE_PERSON_WITH_LDAP = false;
            SEND_DATA_TO_HOME = false;
            CAN_SAVE_DRAWING_IN_DATABASE = false;
            IS_SERVICE_TIME_SET = false;
            DEVIATION_CORRECTION_PROPOSE_EXISTING_WORK_ORDER = false;
            INVOICING_TYPE = -1;
            TWO_FACTOR_AUTHENTICATION_OPTION = -1;
            DESKTOP_CACHE_EXPIRATION_PERIOD_IN_MINUTES = 15;
            USE_OLD_CLEANING_MODULE = false;
            INSPECTED_ENTITY_LOCATION = 2;
            USE_TERMS_OF_USE = false;
            DEFAULT_FROM_EMAIL_ADDRESS = "post@plania.no";
            MAP_SETTINGS = "{\"TileLayer\":\"http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png\",\"TileLayerOptions\":\"{\\\"maxZoom\\\":\\\"19\\\",\\\"attribution\\\":\\\"&copy; OpenStreetMap\\\"}\",\"CrsCode\":\"\",\"Proj4Def\":\"\",\"Options\":{\"Origin\":\"\\\"\\\"\",\"Resolution\":\"\\\"\\\"\"}}";
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
            LANGUAGE = "ENGLISH";
            FONT_NAME = "MS Sans Serif";
        }

        /// <summary>
        /// Required field PWD_MIN_NUMBER_CHARS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int PWD_MIN_NUMBER_CHARS { get; set; }

        /// <summary>
        /// Required field PWD_MUST_CONTAIN_LETTERS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PWD_MUST_CONTAIN_LETTERS { get; set; }

        /// <summary>
        /// Required field PWD_MUST_CONTAIN_DIGITS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PWD_MUST_CONTAIN_DIGITS { get; set; }

        /// <summary>
        /// Required field PWD_CHECK_HISTORIC of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PWD_CHECK_HISTORIC { get; set; }

        /// <summary>
        /// Required field PWD_NO_OF_TRIES of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int PWD_NO_OF_TRIES { get; set; }

        /// <summary>
        /// Required field LOGOFF_PERIOD of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int LOGOFF_PERIOD { get; set; }

        /// <summary>
        /// Required field ORG_HAS_UNIQUE_COLOR_HATCHING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ORG_HAS_UNIQUE_COLOR_HATCHING { get; set; }

        /// <summary>
        /// Required field ORG_HAS_SUBDIVISION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ORG_HAS_SUBDIVISION { get; set; }

        /// <summary>
        /// Required field AREA_DECIMALS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int AREA_DECIMALS { get; set; }

        /// <summary>
        /// Required field USE_AREA_AVAILABILITY of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_AREA_AVAILABILITY { get; set; }

        /// <summary>
        /// Required field AREA_CAN_HAVE_DEPENDENCIES of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool AREA_CAN_HAVE_DEPENDENCIES { get; set; }

        /// <summary>
        /// Required field CAN_EDIT_OR_DELETE_COST of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_EDIT_OR_DELETE_COST { get; set; }

        /// <summary>
        /// Required field USE_UNIT_PRICE_WITH_COST of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_UNIT_PRICE_WITH_COST { get; set; }

        /// <summary>
        /// Required field USE_MAIN_SUPPLIER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_MAIN_SUPPLIER { get; set; }

        /// <summary>
        /// Required field EVAL_BLD_SUMS_WITH_VAR_AREA of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool EVAL_BLD_SUMS_WITH_VAR_AREA { get; set; }

        /// <summary>
        /// Required field COST_CENTER_HAS_UNIQUE_ESTATE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool COST_CENTER_HAS_UNIQUE_ESTATE { get; set; }

        /// <summary>
        /// Required field CAN_EDIT_INVENTORY of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_EDIT_INVENTORY { get; set; }

        /// <summary>
        /// Required field USE_PO_STATUS_CONFIRMED of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_PO_STATUS_CONFIRMED { get; set; }

        /// <summary>
        /// Required field USE_PRICE_SHEET of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_PRICE_SHEET { get; set; }

        /// <summary>
        /// Required field CAN_INVOICE_HOUSING_CONTRACT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_INVOICE_HOUSING_CONTRACT { get; set; }

        /// <summary>
        /// Required field CONT_ITEM_MUST_HAVE_SERVICE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CONT_ITEM_MUST_HAVE_SERVICE { get; set; }

        /// <summary>
        /// Required field MOVE_CO_AFTER_TARGET_INV_DATE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool MOVE_CO_AFTER_TARGET_INV_DATE { get; set; }

        /// <summary>
        /// Required field PS_MUST_HAVE_SERVICE_PRICE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PS_MUST_HAVE_SERVICE_PRICE { get; set; }

        /// <summary>
        /// Required field ADD_SERVICE_IN_FIRST_PS_REV of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ADD_SERVICE_IN_FIRST_PS_REV { get; set; }

        /// <summary>
        /// Required field SELECTION_MUST_INCLUDE_ALL_CC of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SELECTION_MUST_INCLUDE_ALL_CC { get; set; }

        /// <summary>
        /// Required field SEND_PO_ONLY_BY_MAIL of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SEND_PO_ONLY_BY_MAIL { get; set; }

        /// <summary>
        /// Required field CHECK_DUPLICATES_IN_WO of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CHECK_DUPLICATES_IN_WO { get; set; }

        /// <summary>
        /// Required field UPDATE_WO_CONDITION_ON_CLOSING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool UPDATE_WO_CONDITION_ON_CLOSING { get; set; }

        /// <summary>
        /// Required field USE_PO_IN_WO of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_PO_IN_WO { get; set; }

        /// <summary>
        /// Required field WO_CAT_IS_MANDATORY_ON_CLOSE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool WO_CAT_IS_MANDATORY_ON_CLOSE { get; set; }

        /// <summary>
        /// Required field WO_PRIO_IS_MANDATORY_ON_CLOSE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool WO_PRIO_IS_MANDATORY_ON_CLOSE { get; set; }

        /// <summary>
        /// Required field WO_DF_ARE_MANDATORY_ON_CLOSE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool WO_DF_ARE_MANDATORY_ON_CLOSE { get; set; }

        /// <summary>
        /// Required field SEND_WO_COPY_TO_CURRENT_USER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SEND_WO_COPY_TO_CURRENT_USER { get; set; }

        /// <summary>
        /// Required field PO_RELEASE_IMPLIES_STD_RELEASE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PO_RELEASE_IMPLIES_STD_RELEASE { get; set; }

        /// <summary>
        /// Required field SET_LOCATION_ON_EQUIP_RETURN of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SET_LOCATION_ON_EQUIP_RETURN { get; set; }

        /// <summary>
        /// Required field CONTROL_CONT_ITEM_ON_RETURN of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CONTROL_CONT_ITEM_ON_RETURN { get; set; }

        /// <summary>
        /// Required field CAN_SAVE_CONT_ITEM_VERSIONS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_SAVE_CONT_ITEM_VERSIONS { get; set; }

        /// <summary>
        /// Required field INVOICE_WHOLE_DAYS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool INVOICE_WHOLE_DAYS { get; set; }

        /// <summary>
        /// Required field CAN_RENT_OUT_EQUIPMENT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_RENT_OUT_EQUIPMENT { get; set; }

        /// <summary>
        /// Required field CAN_RENT_OUT_AREA of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_RENT_OUT_AREA { get; set; }

        /// <summary>
        /// Required field CAN_RENT_OUT_ARTICLE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_RENT_OUT_ARTICLE { get; set; }

        /// <summary>
        /// Required field CAN_RENT_OUT_COMPONENT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_RENT_OUT_COMPONENT { get; set; }

        /// <summary>
        /// Required field EQ_CI_HAS_UNIQUE_SERVICE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool EQ_CI_HAS_UNIQUE_SERVICE { get; set; }

        /// <summary>
        /// Required field AREA_CI_HAS_UNIQUE_SERVICE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool AREA_CI_HAS_UNIQUE_SERVICE { get; set; }

        /// <summary>
        /// Required field ARTICLE_CI_HAS_UNIQUE_SERVICE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ARTICLE_CI_HAS_UNIQUE_SERVICE { get; set; }

        /// <summary>
        /// Required field COMP_CI_HAS_UNIQUE_SERVICE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool COMP_CI_HAS_UNIQUE_SERVICE { get; set; }

        /// <summary>
        /// Required field EQ_CI_HAS_OWN_ACCOUNTING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool EQ_CI_HAS_OWN_ACCOUNTING { get; set; }

        /// <summary>
        /// Required field AREA_CI_HAS_OWN_ACCOUNTING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool AREA_CI_HAS_OWN_ACCOUNTING { get; set; }

        /// <summary>
        /// Required field ARTICLE_CI_HAS_OWN_ACCOUNTING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ARTICLE_CI_HAS_OWN_ACCOUNTING { get; set; }

        /// <summary>
        /// Required field COMP_CI_HAS_OWN_ACCOUNTING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool COMP_CI_HAS_OWN_ACCOUNTING { get; set; }

        /// <summary>
        /// Required field USE_CONTRACT_ITEM_BATCH_INSERT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_CONTRACT_ITEM_BATCH_INSERT { get; set; }

        /// <summary>
        /// Required field HOUS_PRIC_PER_SRV_IS_MANDATORY of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool HOUS_PRIC_PER_SRV_IS_MANDATORY { get; set; }

        /// <summary>
        /// Required field USE_TRANSFER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_TRANSFER { get; set; }

        /// <summary>
        /// Required field USE_PAYMENT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_PAYMENT { get; set; }

        /// <summary>
        /// Required field USE_AUTOMATIC_PERIODIZATION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_AUTOMATIC_PERIODIZATION { get; set; }

        /// <summary>
        /// Required field USE_OUTLOOK of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_OUTLOOK { get; set; }

        /// <summary>
        /// Required field SHOW_DEFAULT_INFO_ON_DRAWING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SHOW_DEFAULT_INFO_ON_DRAWING { get; set; }

        /// <summary>
        /// Required field CAN_SAVE_DRAWING_AS_SVG of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_SAVE_DRAWING_AS_SVG { get; set; }

        /// <summary>
        /// Required field USE_EQUIPMENT_CONTROL_IN_WORKS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_EQUIPMENT_CONTROL_IN_WORKS { get; set; }

        /// <summary>
        /// Required field SERVER_CAN_GENERATE_NEW_PERIOD of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SERVER_CAN_GENERATE_NEW_PERIOD { get; set; }

        /// <summary>
        /// Required field PROCESS_AUTOCAD_XREF of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PROCESS_AUTOCAD_XREF { get; set; }

        /// <summary>
        /// Primary key for the GENERAL_OPTIONS 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field FONT_SIZE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int FONT_SIZE { get; set; }

        /// <summary>
        /// Required field ENERGY_BUDGET_YEAR of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int ENERGY_BUDGET_YEAR { get; set; }

        /// <summary>
        /// Required field PREVIOUS_ENERGY_BUDGET_YEAR of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int PREVIOUS_ENERGY_BUDGET_YEAR { get; set; }

        /// <summary>
        /// Required field USE_BIT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_BIT { get; set; }

        /// <summary>
        /// Required field CAN_CHANGE_DATA_OWNER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_CHANGE_DATA_OWNER { get; set; }

        /// <summary>
        /// Required field EQ_MUST_BE_LOCATED_IN_OWN_BLD of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool EQ_MUST_BE_LOCATED_IN_OWN_BLD { get; set; }

        /// <summary>
        /// Required field USE_DESKTOP_SINGLE_SIGN_ON of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_DESKTOP_SINGLE_SIGN_ON { get; set; }

        /// <summary>
        /// Required field DYN_CAT_REFERENCES_ONLY_ABSTR of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool DYN_CAT_REFERENCES_ONLY_ABSTR { get; set; }

        /// <summary>
        /// Required field USE_PROJECTED_ACTIVITIES of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_PROJECTED_ACTIVITIES { get; set; }

        /// <summary>
        /// Required field SET_PO_DOCUMENT_AS_ATTACHMENT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SET_PO_DOCUMENT_AS_ATTACHMENT { get; set; }

        /// <summary>
        /// Required field CAN_SET_DOCUMENT_AS_ATTACHMENT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_SET_DOCUMENT_AS_ATTACHMENT { get; set; }

        /// <summary>
        /// Required field BLD_CAN_HAVE_SEVERAL_ADDRESSES of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool BLD_CAN_HAVE_SEVERAL_ADDRESSES { get; set; }

        /// <summary>
        /// Required field EQ_CAN_HAVE_SAME_DEVIATION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool EQ_CAN_HAVE_SAME_DEVIATION { get; set; }

        /// <summary>
        /// Required field FILTER_DEVIATION_BY_EQ_PREFIX of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool FILTER_DEVIATION_BY_EQ_PREFIX { get; set; }

        /// <summary>
        /// Required field CAN_LOCK_PO_PROPOSAL of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_LOCK_PO_PROPOSAL { get; set; }

        /// <summary>
        /// Required field USE_COMPONENT_COUNTER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_COMPONENT_COUNTER { get; set; }

        /// <summary>
        /// Required field DEFAULT_PO_ENTITY_TYPE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int DEFAULT_PO_ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field CHECK_DUPLICATE_ENTITY_IN_PO of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CHECK_DUPLICATE_ENTITY_IN_PO { get; set; }

        /// <summary>
        /// Required field CAN_RELEASE_PO_ZERO_AMOUNT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_RELEASE_PO_ZERO_AMOUNT { get; set; }

        /// <summary>
        /// Required field CAN_EDIT_PO_ITEM_AFTER_ORDER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_EDIT_PO_ITEM_AFTER_ORDER { get; set; }

        /// <summary>
        /// Required field GET_PO_ITEM_ACCOUNTING_FROM_WO of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool GET_PO_ITEM_ACCOUNTING_FROM_WO { get; set; }

        /// <summary>
        /// Required field CAN_CHANGE_PO_ITEM_FROM_COST of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_CHANGE_PO_ITEM_FROM_COST { get; set; }

        /// <summary>
        /// Required field PO_ITEM_UPDATES_COMP_PRICE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PO_ITEM_UPDATES_COMP_PRICE { get; set; }

        /// <summary>
        /// Required field COMPUTE_ALLOC_SUM_PER_PO_ITEM of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool COMPUTE_ALLOC_SUM_PER_PO_ITEM { get; set; }

        /// <summary>
        /// Required field ASK_FOR_START_DATE_MANUAL_WO of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ASK_FOR_START_DATE_MANUAL_WO { get; set; }

        /// <summary>
        /// Required field USE_AUTO_TRANSLATION_REQUEST of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_AUTO_TRANSLATION_REQUEST { get; set; }

        /// <summary>
        /// Required field CAN_SAVE_PERS_WITH_INVALID_ID of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_SAVE_PERS_WITH_INVALID_ID { get; set; }

        /// <summary>
        /// Required field USE_CUSTOMER_IN_REQUEST of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_CUSTOMER_IN_REQUEST { get; set; }

        /// <summary>
        /// Required field USE_PERSON_SCHEDULING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_PERSON_SCHEDULING { get; set; }

        /// <summary>
        /// Required field USE_PERSON_ROLE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_PERSON_ROLE { get; set; }

        /// <summary>
        /// Required field USE_ONLY_ACTIV_PERSON_ON_ACTIV of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_ONLY_ACTIV_PERSON_ON_ACTIV { get; set; }

        /// <summary>
        /// Required field USE_ONLY_PERS_IN_BLD_ON_ACTIV of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_ONLY_PERS_IN_BLD_ON_ACTIV { get; set; }

        /// <summary>
        /// Required field OVERRIDE_ACT_WITH_PERS_INFO of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool OVERRIDE_ACT_WITH_PERS_INFO { get; set; }

        /// <summary>
        /// Required field ENTITY_AVAIL_IGNORES_HISTORY of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ENTITY_AVAIL_IGNORES_HISTORY { get; set; }

        /// <summary>
        /// Required field CAN_SHOW_DEACTIVATED_ENTITIES of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_SHOW_DEACTIVATED_ENTITIES { get; set; }

        /// <summary>
        /// Required field USE_CAUSE_NOT_EXECUTED of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_CAUSE_NOT_EXECUTED { get; set; }

        /// <summary>
        /// Required field USE_BUILDING_TEMPLATES of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_BUILDING_TEMPLATES { get; set; }

        /// <summary>
        /// Required field MAIL_SERVER_PORT_NUMBER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int MAIL_SERVER_PORT_NUMBER { get; set; }

        /// <summary>
        /// Required field USE_UNIQUE_KEY of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_UNIQUE_KEY { get; set; }

        /// <summary>
        /// Required field USE_RECEPTION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_RECEPTION { get; set; }

        /// <summary>
        /// Required field YEAR_RANGE_START of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int YEAR_RANGE_START { get; set; }

        /// <summary>
        /// Required field YEAR_RANGE_END of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int YEAR_RANGE_END { get; set; }

        /// <summary>
        /// Required field AREA_DWG_EXTRACTION_METHOD of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int AREA_DWG_EXTRACTION_METHOD { get; set; }

        /// <summary>
        /// Required field CONTRACT_TYPE_RENTAL_PERIOD of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int CONTRACT_TYPE_RENTAL_PERIOD { get; set; }

        /// <summary>
        /// Required field USE_AREA_CLASSIFICATION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_AREA_CLASSIFICATION { get; set; }

        /// <summary>
        /// Required field DESKTOP_USER_AUTHENTICATION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int DESKTOP_USER_AUTHENTICATION { get; set; }

        /// <summary>
        /// Required field BARCODE_GENERATE_AREA of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool BARCODE_GENERATE_AREA { get; set; }

        /// <summary>
        /// Required field BARCODE_GENERATE_BUILDING of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool BARCODE_GENERATE_BUILDING { get; set; }

        /// <summary>
        /// Required field BARCODE_GENERATE_EQUIPMENT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool BARCODE_GENERATE_EQUIPMENT { get; set; }

        /// <summary>
        /// Required field BARCODE_GENERATE_COMPONENT of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool BARCODE_GENERATE_COMPONENT { get; set; }

        /// <summary>
        /// Required field WORK_ORDER_SHOW_COMPLETE_BUTTON of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool WORK_ORDER_SHOW_COMPLETE_BUTTON { get; set; }

        /// <summary>
        /// Required field MAIL_SERVER_CONNECTION_TYPE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int MAIL_SERVER_CONNECTION_TYPE { get; set; }

        /// <summary>
        /// Required field MONITOR_LIST_LAYOUT_USAGE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool MONITOR_LIST_LAYOUT_USAGE { get; set; }

        /// <summary>
        /// Required field LOG_SECURITY_DB_LEVEL of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int LOG_SECURITY_DB_LEVEL { get; set; }

        /// <summary>
        /// Required field LOG_SECURITY_DB_PERSISTED_DAYS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int LOG_SECURITY_DB_PERSISTED_DAYS { get; set; }

        /// <summary>
        /// Required field LOG_SECURITY_EVENT_LEVEL of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int LOG_SECURITY_EVENT_LEVEL { get; set; }

        /// <summary>
        /// Required field WEB_USER_AUTHENTICATION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int WEB_USER_AUTHENTICATION { get; set; }

        /// <summary>
        /// Required field PROCESS_ALL_BLOCKS_ON_SAME_LAYER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool PROCESS_ALL_BLOCKS_ON_SAME_LAYER { get; set; }

        /// <summary>
        /// Required field WORK_ORDER_CAUSE_IS_MANDATORY_ONLY_ON_END_DATE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool WORK_ORDER_CAUSE_IS_MANDATORY_ONLY_ON_END_DATE { get; set; }

        /// <summary>
        /// Required field WORK_ORDER_RESPONSIBLE_PERSON_IS_MANDATORY_ONLY_ON_END_DATE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool WORK_ORDER_RESPONSIBLE_PERSON_IS_MANDATORY_ONLY_ON_END_DATE { get; set; }

        /// <summary>
        /// Required field USE_LOCATION_IN_REQUEST of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_LOCATION_IN_REQUEST { get; set; }

        /// <summary>
        /// Required field ALLOW_API_CONNECTIONS of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ALLOW_API_CONNECTIONS { get; set; }

        /// <summary>
        /// Required field USE_API_TOKEN of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_API_TOKEN { get; set; }

        /// <summary>
        /// Required field ACTIVATE_PURCHASE_ORDER_IN_WEB of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool ACTIVATE_PURCHASE_ORDER_IN_WEB { get; set; }

        /// <summary>
        /// Required field SYNCHRONIZE_PERSON_WITH_LDAP of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SYNCHRONIZE_PERSON_WITH_LDAP { get; set; }

        /// <summary>
        /// Required field SEND_DATA_TO_HOME of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool SEND_DATA_TO_HOME { get; set; }

        /// <summary>
        /// Required field CAN_SAVE_DRAWING_IN_DATABASE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool CAN_SAVE_DRAWING_IN_DATABASE { get; set; }

        /// <summary>
        /// Required field IS_SERVICE_TIME_SET of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool IS_SERVICE_TIME_SET { get; set; }

        /// <summary>
        /// Required field DEVIATION_CORRECTION_PROPOSE_EXISTING_WORK_ORDER of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool DEVIATION_CORRECTION_PROPOSE_EXISTING_WORK_ORDER { get; set; }

        /// <summary>
        /// Required field INVOICING_TYPE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int INVOICING_TYPE { get; set; }

        /// <summary>
        /// Required field TWO_FACTOR_AUTHENTICATION_OPTION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int TWO_FACTOR_AUTHENTICATION_OPTION { get; set; }

        /// <summary>
        /// Required field DESKTOP_CACHE_EXPIRATION_PERIOD_IN_MINUTES of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int DESKTOP_CACHE_EXPIRATION_PERIOD_IN_MINUTES { get; set; }

        /// <summary>
        /// Required field USE_OLD_CLEANING_MODULE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_OLD_CLEANING_MODULE { get; set; }

        /// <summary>
        /// Required field INSPECTED_ENTITY_LOCATION of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public int INSPECTED_ENTITY_LOCATION { get; set; }

        /// <summary>
        /// Required field USE_TERMS_OF_USE of the GENERAL_OPTIONS 
        /// </summary>
        [Required]
        public bool USE_TERMS_OF_USE { get; set; }
        /// <summary>
        /// WEB_BASE_URL of the GENERAL_OPTIONS 
        /// </summary>
        public string? WEB_BASE_URL { get; set; }
        /// <summary>
        /// Foreign key referencing the IMAGE to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_IMAGE_BACKGROUND { get; set; }

        /// <summary>
        /// Navigation property representing the associated IMAGE
        /// </summary>
        [ForeignKey("GUID_IMAGE_BACKGROUND")]
        public IMAGE? GUID_IMAGE_BACKGROUND_IMAGE { get; set; }
        /// <summary>
        /// Foreign key referencing the IMAGE to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_IMAGE_LOGO { get; set; }

        /// <summary>
        /// Navigation property representing the associated IMAGE
        /// </summary>
        [ForeignKey("GUID_IMAGE_LOGO")]
        public IMAGE? GUID_IMAGE_LOGO_IMAGE { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT_TERMS_OF_USE { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT
        /// </summary>
        [ForeignKey("GUID_DOCUMENT_TERMS_OF_USE")]
        public DOCUMENT? GUID_DOCUMENT_TERMS_OF_USE_DOCUMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_SYSTEM_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_SYSTEM_OWNER")]
        public USR? GUID_SYSTEM_OWNER_USR { get; set; }
        /// <summary>
        /// CUSTOM_FOLDER of the GENERAL_OPTIONS 
        /// </summary>
        public string? CUSTOM_FOLDER { get; set; }
        /// <summary>
        /// WEB_USER of the GENERAL_OPTIONS 
        /// </summary>
        public string? WEB_USER { get; set; }
        /// <summary>
        /// WEB_PASSWORD of the GENERAL_OPTIONS 
        /// </summary>
        public string? WEB_PASSWORD { get; set; }
        /// <summary>
        /// Foreign key referencing the INVOICING to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_DEFAULT_INVOICING { get; set; }

        /// <summary>
        /// Navigation property representing the associated INVOICING
        /// </summary>
        [ForeignKey("GUID_DEFAULT_INVOICING")]
        public INVOICING? GUID_DEFAULT_INVOICING_INVOICING { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_TERM to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_DEFAULT_PAYMENT_TERM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_TERM
        /// </summary>
        [ForeignKey("GUID_DEFAULT_PAYMENT_TERM")]
        public PAYMENT_TERM? GUID_DEFAULT_PAYMENT_TERM_PAYMENT_TERM { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_FORM to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_DEFAULT_PAYMENT_ORDER_FORM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_FORM
        /// </summary>
        [ForeignKey("GUID_DEFAULT_PAYMENT_ORDER_FORM")]
        public PAYMENT_ORDER_FORM? GUID_DEFAULT_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM { get; set; }
        /// <summary>
        /// BARCODE_AREA_FORMAT of the GENERAL_OPTIONS 
        /// </summary>
        public string? BARCODE_AREA_FORMAT { get; set; }
        /// <summary>
        /// BARCODE_BUILDING_FORMAT of the GENERAL_OPTIONS 
        /// </summary>
        public string? BARCODE_BUILDING_FORMAT { get; set; }
        /// <summary>
        /// BARCODE_EQUIPMENT_FORMAT of the GENERAL_OPTIONS 
        /// </summary>
        public string? BARCODE_EQUIPMENT_FORMAT { get; set; }
        /// <summary>
        /// BARCODE_COMPONENT_FORMAT of the GENERAL_OPTIONS 
        /// </summary>
        public string? BARCODE_COMPONENT_FORMAT { get; set; }
        /// <summary>
        /// DEFAULT_FROM_EMAIL_ADDRESS of the GENERAL_OPTIONS 
        /// </summary>
        public string? DEFAULT_FROM_EMAIL_ADDRESS { get; set; }
        /// <summary>
        /// MAP_SETTINGS of the GENERAL_OPTIONS 
        /// </summary>
        public string? MAP_SETTINGS { get; set; }
        /// <summary>
        /// SERVICE_DESK_APPLICATION_PATH of the GENERAL_OPTIONS 
        /// </summary>
        public string? SERVICE_DESK_APPLICATION_PATH { get; set; }
        /// <summary>
        /// MAIL_DEFAULT_DOMAIN_NAME of the GENERAL_OPTIONS 
        /// </summary>
        public string? MAIL_DEFAULT_DOMAIN_NAME { get; set; }
        /// <summary>
        /// EMAIL_ADDRESS_FORMAT of the GENERAL_OPTIONS 
        /// </summary>
        public string? EMAIL_ADDRESS_FORMAT { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_USER_GROUP_FOR_NEW_USERS { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_GROUP_FOR_NEW_USERS")]
        public USR? GUID_USER_GROUP_FOR_NEW_USERS_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_COMMON_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_COMMON_DATA_OWNER")]
        public DATA_OWNER? GUID_COMMON_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CAUSE to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_CAUSE_NOT_EXECUTED { get; set; }

        /// <summary>
        /// Navigation property representing the associated CAUSE
        /// </summary>
        [ForeignKey("GUID_CAUSE_NOT_EXECUTED")]
        public CAUSE? GUID_CAUSE_NOT_EXECUTED_CAUSE { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER_FORM to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_DEFAULT_ORDER_FORM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER_FORM
        /// </summary>
        [ForeignKey("GUID_DEFAULT_ORDER_FORM")]
        public PURCHASE_ORDER_FORM? GUID_DEFAULT_ORDER_FORM_PURCHASE_ORDER_FORM { get; set; }

        /// <summary>
        /// UPDATED_DATE of the GENERAL_OPTIONS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the GENERAL_OPTIONS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the GENERAL_OPTIONS belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// LANGUAGE of the GENERAL_OPTIONS 
        /// </summary>
        public string? LANGUAGE { get; set; }
        /// <summary>
        /// SERVICE_START_TIME of the GENERAL_OPTIONS 
        /// </summary>
        public string? SERVICE_START_TIME { get; set; }
        /// <summary>
        /// SERVICE_STOP_TIME of the GENERAL_OPTIONS 
        /// </summary>
        public string? SERVICE_STOP_TIME { get; set; }
        /// <summary>
        /// WORKING_HOURS_RULES of the GENERAL_OPTIONS 
        /// </summary>
        public string? WORKING_HOURS_RULES { get; set; }
        /// <summary>
        /// ACTIVITY_PERIOD_START of the GENERAL_OPTIONS 
        /// </summary>
        public string? ACTIVITY_PERIOD_START { get; set; }
        /// <summary>
        /// XML_EXPORT_FOLDER of the GENERAL_OPTIONS 
        /// </summary>
        public string? XML_EXPORT_FOLDER { get; set; }
        /// <summary>
        /// XML_IMPORT_FOLDER of the GENERAL_OPTIONS 
        /// </summary>
        public string? XML_IMPORT_FOLDER { get; set; }
        /// <summary>
        /// MAIL_SERVER_HOST_NAME of the GENERAL_OPTIONS 
        /// </summary>
        public string? MAIL_SERVER_HOST_NAME { get; set; }
        /// <summary>
        /// CUSTOMER_ID_NUMBER_FORMAT of the GENERAL_OPTIONS 
        /// </summary>
        public string? CUSTOMER_ID_NUMBER_FORMAT { get; set; }
        /// <summary>
        /// ENERGY_MODULE_SHARED_PATH of the GENERAL_OPTIONS 
        /// </summary>
        public string? ENERGY_MODULE_SHARED_PATH { get; set; }
        /// <summary>
        /// ID of the GENERAL_OPTIONS 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the GENERAL_OPTIONS 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// REPORTS_FOLDER of the GENERAL_OPTIONS 
        /// </summary>
        public string? REPORTS_FOLDER { get; set; }
        /// <summary>
        /// TEMPORARY_FOLDER of the GENERAL_OPTIONS 
        /// </summary>
        public string? TEMPORARY_FOLDER { get; set; }
        /// <summary>
        /// DRAWING_FOLDER of the GENERAL_OPTIONS 
        /// </summary>
        public string? DRAWING_FOLDER { get; set; }
        /// <summary>
        /// AUTOCAD_AREA_ID_LAYER of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_AREA_ID_LAYER { get; set; }
        /// <summary>
        /// AUTOCAD_AREA_DESCRIPTION_LAYER of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_AREA_DESCRIPTION_LAYER { get; set; }
        /// <summary>
        /// AUTOCAD_AREA_CATEGORY_LAYER of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_AREA_CATEGORY_LAYER { get; set; }
        /// <summary>
        /// AUTOCAD_AREA_COM_STATUS_LAYER of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_AREA_COM_STATUS_LAYER { get; set; }
        /// <summary>
        /// AUTOCAD_NET_POLYGON_LAYER of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_NET_POLYGON_LAYER { get; set; }
        /// <summary>
        /// AUTOCAD_GROSS_POLYGON_LAYER of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_GROSS_POLYGON_LAYER { get; set; }
        /// <summary>
        /// AUTOCAD_PREFIX_AREA_ID of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_PREFIX_AREA_ID { get; set; }
        /// <summary>
        /// AUTOCAD_DWG_BLOCK_NAME of the GENERAL_OPTIONS 
        /// </summary>
        public string? AUTOCAD_DWG_BLOCK_NAME { get; set; }
        /// <summary>
        /// FONT_NAME of the GENERAL_OPTIONS 
        /// </summary>
        public string? FONT_NAME { get; set; }
    }
}