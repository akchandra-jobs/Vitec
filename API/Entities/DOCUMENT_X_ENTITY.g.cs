using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a document_x_entity entity with essential details
    /// </summary>
    [Table("DOCUMENT_X_ENTITY", Schema = "dbo")]
    public class DOCUMENT_X_ENTITY
    {
        /// <summary>
        /// Initializes a new instance of the DOCUMENT_X_ENTITY class.
        /// </summary>
        public DOCUMENT_X_ENTITY()
        {
            ENTITY_TYPE = -1;
            DATA_ACQUISITION_STATUS = -1;
            ARCHIVE_STATUS = -1;
            IS_ATTACHMENT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the DOCUMENT_X_ENTITY 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Primary key for the DOCUMENT_X_ENTITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field DATA_ACQUISITION_STATUS of the DOCUMENT_X_ENTITY 
        /// </summary>
        [Required]
        public int DATA_ACQUISITION_STATUS { get; set; }

        /// <summary>
        /// Required field ARCHIVE_STATUS of the DOCUMENT_X_ENTITY 
        /// </summary>
        [Required]
        public int ARCHIVE_STATUS { get; set; }

        /// <summary>
        /// Required field IS_ATTACHMENT of the DOCUMENT_X_ENTITY 
        /// </summary>
        [Required]
        public bool IS_ATTACHMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT
        /// </summary>
        [ForeignKey("GUID_DOCUMENT")]
        public DOCUMENT? GUID_DOCUMENT_DOCUMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER")]
        public PURCHASE_ORDER? GUID_PURCHASE_ORDER_PURCHASE_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_CONDITION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION
        /// </summary>
        [ForeignKey("GUID_CONDITION")]
        public CONDITION? GUID_CONDITION_CONDITION { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the REQUEST to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_REQUEST { get; set; }

        /// <summary>
        /// Navigation property representing the associated REQUEST
        /// </summary>
        [ForeignKey("GUID_REQUEST")]
        public REQUEST? GUID_REQUEST_REQUEST { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_LEASE to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_LEASE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_LEASE
        /// </summary>
        [ForeignKey("GUID_CONTRACT_LEASE")]
        public CONTRACT_LEASE? GUID_CONTRACT_LEASE_CONTRACT_LEASE { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_LOCK to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DOOR_LOCK { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_LOCK
        /// </summary>
        [ForeignKey("GUID_DOOR_LOCK")]
        public DOOR_LOCK? GUID_DOOR_LOCK_DOOR_LOCK { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_KEY to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DOOR_KEY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_KEY
        /// </summary>
        [ForeignKey("GUID_DOOR_KEY")]
        public DOOR_KEY? GUID_DOOR_KEY_DOOR_KEY { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT
        /// </summary>
        [ForeignKey("GUID_PROJECT")]
        public PROJECT? GUID_PROJECT_PROJECT { get; set; }
        /// <summary>
        /// ISSUE_ID of the DOCUMENT_X_ENTITY 
        /// </summary>
        public string? ISSUE_ID { get; set; }
        /// <summary>
        /// JOURNAL_ID of the DOCUMENT_X_ENTITY 
        /// </summary>
        public string? JOURNAL_ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOCUMENT_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOCUMENT_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_TASK to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_TASK
        /// </summary>
        [ForeignKey("GUID_CLEANING_TASK")]
        public CLEANING_TASK? GUID_CLEANING_TASK_CLEANING_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the DEVIATION to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DEVIATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEVIATION
        /// </summary>
        [ForeignKey("GUID_DEVIATION")]
        public DEVIATION? GUID_DEVIATION_DEVIATION { get; set; }
        /// <summary>
        /// Foreign key referencing the COST to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_COST { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST
        /// </summary>
        [ForeignKey("GUID_COST")]
        public COST? GUID_COST_COST { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER to which the DOCUMENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER")]
        public PAYMENT_ORDER? GUID_PAYMENT_ORDER_PAYMENT_ORDER { get; set; }
    }
}