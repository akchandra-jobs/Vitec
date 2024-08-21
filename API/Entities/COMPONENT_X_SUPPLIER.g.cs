using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a component_x_supplier entity with essential details
    /// </summary>
    [Table("COMPONENT_X_SUPPLIER", Schema = "dbo")]
    public class COMPONENT_X_SUPPLIER
    {
        /// <summary>
        /// Initializes a new instance of the COMPONENT_X_SUPPLIER class.
        /// </summary>
        public COMPONENT_X_SUPPLIER()
        {
            DELIVERY_TIME_PERIOD_UNIT = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the COMPONENT_X_SUPPLIER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field PRICE of the COMPONENT_X_SUPPLIER 
        /// </summary>
        [Required]
        public double PRICE { get; set; }

        /// <summary>
        /// Required field DELIVERY_TIME_PERIOD_NUMBER of the COMPONENT_X_SUPPLIER 
        /// </summary>
        [Required]
        public double DELIVERY_TIME_PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field DELIVERY_TIME_PERIOD_UNIT of the COMPONENT_X_SUPPLIER 
        /// </summary>
        [Required]
        public int DELIVERY_TIME_PERIOD_UNIT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the COMPONENT_X_SUPPLIER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COMPONENT_X_SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the COMPONENT_X_SUPPLIER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COMPONENT_X_SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the COMPONENT_X_SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the COMPONENT_X_SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the COMPONENT_X_SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER_AGREEMENT to which the COMPONENT_X_SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER_AGREEMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER_AGREEMENT
        /// </summary>
        [ForeignKey("GUID_SUPPLIER_AGREEMENT")]
        public SUPPLIER_AGREEMENT? GUID_SUPPLIER_AGREEMENT_SUPPLIER_AGREEMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the COMPONENT_X_SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
        /// <summary>
        /// MANUFACTURER of the COMPONENT_X_SUPPLIER 
        /// </summary>
        public string? MANUFACTURER { get; set; }
        /// <summary>
        /// PART_NUMBER of the COMPONENT_X_SUPPLIER 
        /// </summary>
        public string? PART_NUMBER { get; set; }
        /// <summary>
        /// PART_NUMBER_TAG of the COMPONENT_X_SUPPLIER 
        /// </summary>
        public string? PART_NUMBER_TAG { get; set; }
    }
}