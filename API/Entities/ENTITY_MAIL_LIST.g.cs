using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_mail_list entity with essential details
    /// </summary>
    [Table("ENTITY_MAIL_LIST", Schema = "dbo")]
    public class ENTITY_MAIL_LIST
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_MAIL_LIST class.
        /// </summary>
        public ENTITY_MAIL_LIST()
        {
            IS_COPY = false;
            STATUS = -1;
            ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENTITY_MAIL_LIST 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_COPY of the ENTITY_MAIL_LIST 
        /// </summary>
        [Required]
        public bool IS_COPY { get; set; }

        /// <summary>
        /// Required field STATUS of the ENTITY_MAIL_LIST 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the ENTITY_MAIL_LIST 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }
        /// <summary>
        /// RECEIVER_NAME of the ENTITY_MAIL_LIST 
        /// </summary>
        public string? RECEIVER_NAME { get; set; }
        /// <summary>
        /// RECEIVER_MAIL of the ENTITY_MAIL_LIST 
        /// </summary>
        public string? RECEIVER_MAIL { get; set; }
        /// <summary>
        /// RECEIVER_PHONE of the ENTITY_MAIL_LIST 
        /// </summary>
        public string? RECEIVER_PHONE { get; set; }

        /// <summary>
        /// SENT_DATE of the ENTITY_MAIL_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SENT_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_MAIL_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_MAIL_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER")]
        public PAYMENT_ORDER? GUID_PAYMENT_ORDER_PAYMENT_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the PURCHASE_ORDER to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_PURCHASE_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PURCHASE_ORDER
        /// </summary>
        [ForeignKey("GUID_PURCHASE_ORDER")]
        public PURCHASE_ORDER? GUID_PURCHASE_ORDER_PURCHASE_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERIODIC_TASK to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_PERIODIC_TASK")]
        public PERIODIC_TASK? GUID_PERIODIC_TASK_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the ENTITY_MAIL_LIST belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
    }
}