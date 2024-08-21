using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a customer_delivery_address entity with essential details
    /// </summary>
    [Table("CUSTOMER_DELIVERY_ADDRESS", Schema = "dbo")]
    public class CUSTOMER_DELIVERY_ADDRESS
    {
        /// <summary>
        /// Initializes a new instance of the CUSTOMER_DELIVERY_ADDRESS class.
        /// </summary>
        public CUSTOMER_DELIVERY_ADDRESS()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CUSTOMER_DELIVERY_ADDRESS belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the CUSTOMER_DELIVERY_ADDRESS belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// DESCRIPTION of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// STREET_ADDRESS of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        public string? STREET_ADDRESS { get; set; }
        /// <summary>
        /// POSTAL_ADDRESS of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        public string? POSTAL_ADDRESS { get; set; }
        /// <summary>
        /// POSTAL_CODE of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// COUNTRY of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        public string? COUNTRY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOMER_DELIVERY_ADDRESS belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CUSTOMER_DELIVERY_ADDRESS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOMER_DELIVERY_ADDRESS belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}