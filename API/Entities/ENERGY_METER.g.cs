using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_meter entity with essential details
    /// </summary>
    [Table("ENERGY_METER", Schema = "dbo")]
    public class ENERGY_METER
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_METER class.
        /// </summary>
        public ENERGY_METER()
        {
            IS_TYPE_ACCUMULATED = false;
            NUMBER_OF_COUNTERS = 0;
            IS_GROUP = false;
            IS_DEACTIVATED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENERGY_METER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_TYPE_ACCUMULATED of the ENERGY_METER 
        /// </summary>
        [Required]
        public bool IS_TYPE_ACCUMULATED { get; set; }

        /// <summary>
        /// Required field NUMBER_OF_COUNTERS of the ENERGY_METER 
        /// </summary>
        [Required]
        public int NUMBER_OF_COUNTERS { get; set; }

        /// <summary>
        /// Required field IS_GROUP of the ENERGY_METER 
        /// </summary>
        [Required]
        public bool IS_GROUP { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the ENERGY_METER 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }
        /// <summary>
        /// LOCATION of the ENERGY_METER 
        /// </summary>
        public string? LOCATION { get; set; }
        /// <summary>
        /// TAG_ID of the ENERGY_METER 
        /// </summary>
        public string? TAG_ID { get; set; }

        /// <summary>
        /// START_DATE of the ENERGY_METER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the ENERGY_METER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// READ_DATE of the ENERGY_METER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? READ_DATE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the ENERGY_METER 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_METER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_METER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_CATEGORY to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_CATEGORY
        /// </summary>
        [ForeignKey("GUID_ENERGY_CATEGORY")]
        public ENERGY_CATEGORY? GUID_ENERGY_CATEGORY_ENERGY_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_METER to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_METER_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_METER
        /// </summary>
        [ForeignKey("GUID_ENERGY_METER_GROUP")]
        public ENERGY_METER? GUID_ENERGY_METER_GROUP_ENERGY_METER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_PERIODIC_TASK to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_ENERGY_PERIODIC_TASK")]
        public ENERGY_PERIODIC_TASK? GUID_ENERGY_PERIODIC_TASK_ENERGY_PERIODIC_TASK { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER1")]
        public SUPPLIER? GUID_SUPPLIER1_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the ENERGY_METER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER2")]
        public SUPPLIER? GUID_SUPPLIER2_SUPPLIER { get; set; }
        /// <summary>
        /// ID of the ENERGY_METER 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// INSTALLATION_ID of the ENERGY_METER 
        /// </summary>
        public string? INSTALLATION_ID { get; set; }
        /// <summary>
        /// AGREEMENT_ID of the ENERGY_METER 
        /// </summary>
        public string? AGREEMENT_ID { get; set; }
    }
}