using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a purchase_order_form entity with essential details
    /// </summary>
    [Table("PURCHASE_ORDER_FORM", Schema = "dbo")]
    public class PURCHASE_ORDER_FORM
    {
        /// <summary>
        /// Initializes a new instance of the PURCHASE_ORDER_FORM class.
        /// </summary>
        public PURCHASE_ORDER_FORM()
        {
            APPLIED_COUNTER = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field APPLIED_COUNTER of the PURCHASE_ORDER_FORM 
        /// </summary>
        [Required]
        public int APPLIED_COUNTER { get; set; }

        /// <summary>
        /// Primary key for the PURCHASE_ORDER_FORM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PURCHASE_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the PURCHASE_ORDER_FORM 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// FILE_PATH of the PURCHASE_ORDER_FORM 
        /// </summary>
        public string? FILE_PATH { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PURCHASE_ORDER_FORM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PURCHASE_ORDER_FORM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PURCHASE_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the REPORT to which the PURCHASE_ORDER_FORM belongs 
        /// </summary>
        public Guid? GUID_REPORT { get; set; }

        /// <summary>
        /// Navigation property representing the associated REPORT
        /// </summary>
        [ForeignKey("GUID_REPORT")]
        public REPORT? GUID_REPORT_REPORT { get; set; }
    }
}