using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a payment_order_form entity with essential details
    /// </summary>
    [Table("PAYMENT_ORDER_FORM", Schema = "dbo")]
    public class PAYMENT_ORDER_FORM
    {
        /// <summary>
        /// Initializes a new instance of the PAYMENT_ORDER_FORM class.
        /// </summary>
        public PAYMENT_ORDER_FORM()
        {
            FORMAT = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PAYMENT_ORDER_FORM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field FORMAT of the PAYMENT_ORDER_FORM 
        /// </summary>
        [Required]
        public int FORMAT { get; set; }
        /// <summary>
        /// NAME of the PAYMENT_ORDER_FORM 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// DEVICE of the PAYMENT_ORDER_FORM 
        /// </summary>
        public string? DEVICE { get; set; }
        /// <summary>
        /// REPORT_FILE_TYPE of the PAYMENT_ORDER_FORM 
        /// </summary>
        public string? REPORT_FILE_TYPE { get; set; }
        /// <summary>
        /// LANGUAGE of the PAYMENT_ORDER_FORM 
        /// </summary>
        public string? LANGUAGE { get; set; }
        /// <summary>
        /// LAYOUT of the PAYMENT_ORDER_FORM 
        /// </summary>
        public string? LAYOUT { get; set; }
        /// <summary>
        /// Foreign key referencing the REPORT to which the PAYMENT_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_REPORT { get; set; }

        /// <summary>
        /// Navigation property representing the associated REPORT
        /// </summary>
        [ForeignKey("GUID_REPORT")]
        public REPORT? GUID_REPORT_REPORT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PAYMENT_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the PAYMENT_ORDER_FORM 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PAYMENT_ORDER_FORM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PAYMENT_ORDER_FORM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}