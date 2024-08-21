using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a periodization entity with essential details
    /// </summary>
    [Table("PERIODIZATION", Schema = "dbo")]
    public class PERIODIZATION
    {
        /// <summary>
        /// Initializes a new instance of the PERIODIZATION class.
        /// </summary>
        public PERIODIZATION()
        {
            PERIOD = 0;
            YEAR = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field PERIOD of the PERIODIZATION 
        /// </summary>
        [Required]
        public int PERIOD { get; set; }

        /// <summary>
        /// Required field AMOUNT of the PERIODIZATION 
        /// </summary>
        [Required]
        public double AMOUNT { get; set; }

        /// <summary>
        /// Required field YEAR of the PERIODIZATION 
        /// </summary>
        [Required]
        public int YEAR { get; set; }

        /// <summary>
        /// Primary key for the PERIODIZATION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PERIODIZATION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_ORDER_ITEM to which the PERIODIZATION belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_ORDER_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_ORDER_ITEM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_ORDER_ITEM")]
        public PAYMENT_ORDER_ITEM? GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the PERIODIZATION belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }

        /// <summary>
        /// TRANSFER_DATE of the PERIODIZATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TRANSFER_DATE { get; set; }

        /// <summary>
        /// APPROVED_DATE of the PERIODIZATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? APPROVED_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PERIODIZATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERIODIZATION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PERIODIZATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERIODIZATION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}