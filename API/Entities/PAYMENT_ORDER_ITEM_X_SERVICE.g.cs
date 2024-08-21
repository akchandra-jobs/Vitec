using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a payment_order_item_x_service entity with essential details
    /// </summary>
    [Table("PAYMENT_ORDER_ITEM_X_SERVICE", Schema = "dbo")]
    public class PAYMENT_ORDER_ITEM_X_SERVICE
    {
        /// <summary>
        /// Initializes a new instance of the PAYMENT_ORDER_ITEM_X_SERVICE class.
        /// </summary>
        public PAYMENT_ORDER_ITEM_X_SERVICE()
        {
            SERIAL_NUMBER = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PAYMENT_ORDER_ITEM_X_SERVICE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field PRICE of the PAYMENT_ORDER_ITEM_X_SERVICE 
        /// </summary>
        [Required]
        public double PRICE { get; set; }

        /// <summary>
        /// Required field SERIAL_NUMBER of the PAYMENT_ORDER_ITEM_X_SERVICE 
        /// </summary>
        [Required]
        public int SERIAL_NUMBER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PAYMENT_ORDER_ITEM_X_SERVICE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER_ITEM_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PAYMENT_ORDER_ITEM_X_SERVICE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PAYMENT_ORDER_ITEM_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PAYMENT_ORDER_ITEM_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_ITEM to which the PAYMENT_ORDER_ITEM_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_ITEM")]
        public PAYMENT_ORDER_ITEM? GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the PAYMENT_ORDER_ITEM_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }
    }
}