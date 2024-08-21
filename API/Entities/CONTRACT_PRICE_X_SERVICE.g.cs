using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contract_price_x_service entity with essential details
    /// </summary>
    [Table("CONTRACT_PRICE_X_SERVICE", Schema = "dbo")]
    public class CONTRACT_PRICE_X_SERVICE
    {
        /// <summary>
        /// Initializes a new instance of the CONTRACT_PRICE_X_SERVICE class.
        /// </summary>
        public CONTRACT_PRICE_X_SERVICE()
        {
            ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the CONTRACT_PRICE_X_SERVICE 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_YEAR of the CONTRACT_PRICE_X_SERVICE 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_YEAR { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_MONTH of the CONTRACT_PRICE_X_SERVICE 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_MONTH { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_DAY of the CONTRACT_PRICE_X_SERVICE 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_DAY { get; set; }

        /// <summary>
        /// Primary key for the CONTRACT_PRICE_X_SERVICE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTRACT_PRICE_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTRACT_PRICE_X_SERVICE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_PRICE_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTRACT_PRICE_X_SERVICE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_PRICE_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the CONTRACT_PRICE_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the CONTRACT_PRICE_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the CONTRACT_PRICE_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the COMPONENT to which the CONTRACT_PRICE_X_SERVICE belongs 
        /// </summary>
        public Guid? GUID_COMPONENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated COMPONENT
        /// </summary>
        [ForeignKey("GUID_COMPONENT")]
        public COMPONENT? GUID_COMPONENT_COMPONENT { get; set; }
    }
}