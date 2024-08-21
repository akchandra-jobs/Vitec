using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_counter entity with essential details
    /// </summary>
    [Table("ENERGY_COUNTER", Schema = "dbo")]
    public class ENERGY_COUNTER
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_COUNTER class.
        /// </summary>
        public ENERGY_COUNTER()
        {
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENERGY_COUNTER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the ENERGY_COUNTER 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field FACTOR of the ENERGY_COUNTER 
        /// </summary>
        [Required]
        public double FACTOR { get; set; }

        /// <summary>
        /// Required field MAXIMUM_VALUE of the ENERGY_COUNTER 
        /// </summary>
        [Required]
        public double MAXIMUM_VALUE { get; set; }

        /// <summary>
        /// Required field EXPECTED_YEARLY_CONSUMPTION of the ENERGY_COUNTER 
        /// </summary>
        [Required]
        public double EXPECTED_YEARLY_CONSUMPTION { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_START_VALUE of the ENERGY_COUNTER 
        /// </summary>
        [Required]
        public double ACCUMULATED_START_VALUE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_COUNTER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_COUNTER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// LAST_CONSUMPTION_UPDATE_DATE of the ENERGY_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_CONSUMPTION_UPDATE_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_COUNTER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_READING to which the ENERGY_COUNTER belongs 
        /// </summary>
        public Guid? GUID_LAST_ENERGY_READING { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_READING
        /// </summary>
        [ForeignKey("GUID_LAST_ENERGY_READING")]
        public ENERGY_READING? GUID_LAST_ENERGY_READING_ENERGY_READING { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_UNIT to which the ENERGY_COUNTER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_UNIT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_UNIT
        /// </summary>
        [ForeignKey("GUID_ENERGY_UNIT")]
        public ENERGY_UNIT? GUID_ENERGY_UNIT_ENERGY_UNIT { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_METER to which the ENERGY_COUNTER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_METER { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_METER
        /// </summary>
        [ForeignKey("GUID_ENERGY_METER")]
        public ENERGY_METER? GUID_ENERGY_METER_ENERGY_METER { get; set; }
    }
}