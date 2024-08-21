using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_unit entity with essential details
    /// </summary>
    [Table("ENERGY_UNIT", Schema = "dbo")]
    public class ENERGY_UNIT
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_UNIT class.
        /// </summary>
        public ENERGY_UNIT()
        {
            CAN_BE_USED_ON_FIRST_COUNTER = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENERGY_UNIT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field CAN_BE_USED_ON_FIRST_COUNTER of the ENERGY_UNIT 
        /// </summary>
        [Required]
        public bool CAN_BE_USED_ON_FIRST_COUNTER { get; set; }

        /// <summary>
        /// Required field ACCRUAL_RATE of the ENERGY_UNIT 
        /// </summary>
        [Required]
        public double ACCRUAL_RATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_UNIT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_UNIT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_UNIT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_UNIT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_UNIT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_CATEGORY to which the ENERGY_UNIT belongs 
        /// </summary>
        public Guid? GUID_ENERGY_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_CATEGORY
        /// </summary>
        [ForeignKey("GUID_ENERGY_CATEGORY")]
        public ENERGY_CATEGORY? GUID_ENERGY_CATEGORY_ENERGY_CATEGORY { get; set; }
        /// <summary>
        /// ID of the ENERGY_UNIT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// COUNTER_UNIT of the ENERGY_UNIT 
        /// </summary>
        public string? COUNTER_UNIT { get; set; }
        /// <summary>
        /// ACCRUAL_UNIT of the ENERGY_UNIT 
        /// </summary>
        public string? ACCRUAL_UNIT { get; set; }
    }
}