using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a work_order_x_equipment entity with essential details
    /// </summary>
    [Table("WORK_ORDER_X_EQUIPMENT", Schema = "dbo")]
    public class WORK_ORDER_X_EQUIPMENT
    {
        /// <summary>
        /// Initializes a new instance of the WORK_ORDER_X_EQUIPMENT class.
        /// </summary>
        public WORK_ORDER_X_EQUIPMENT()
        {
            RENTAL_PERIOD_UNIT = 8;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field RENTAL_PERIOD_NUMBER of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Required]
        public double RENTAL_PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field RENTAL_PERIOD_UNIT of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Required]
        public int RENTAL_PERIOD_UNIT { get; set; }

        /// <summary>
        /// Required field UNIT_PRICE of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Required]
        public double UNIT_PRICE { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field REAL_TIME of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Required]
        public double REAL_TIME { get; set; }

        /// <summary>
        /// Required field REAL_COST of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Required]
        public double REAL_COST { get; set; }

        /// <summary>
        /// Primary key for the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WORK_ORDER_X_EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the WORK_ORDER_X_EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the WORK_ORDER_X_EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }

        /// <summary>
        /// START_DATE of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_X_EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WORK_ORDER_X_EQUIPMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_X_EQUIPMENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}