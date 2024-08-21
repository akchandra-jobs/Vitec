using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_reading entity with essential details
    /// </summary>
    [Table("ENERGY_READING", Schema = "dbo")]
    public class ENERGY_READING
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_READING class.
        /// </summary>
        public ENERGY_READING()
        {
            STATUS = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ACCUMULATED of the ENERGY_READING 
        /// </summary>
        [Required]
        public double ACCUMULATED { get; set; }

        /// <summary>
        /// Required field CONSUMPTION of the ENERGY_READING 
        /// </summary>
        [Required]
        public double CONSUMPTION { get; set; }

        /// <summary>
        /// Required field STATUS of the ENERGY_READING 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Primary key for the ENERGY_READING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_READING belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_READING to which the ENERGY_READING belongs 
        /// </summary>
        public Guid? GUID_PREVIOUS_ENERGY_READING { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_READING
        /// </summary>
        [ForeignKey("GUID_PREVIOUS_ENERGY_READING")]
        public ENERGY_READING? GUID_PREVIOUS_ENERGY_READING_ENERGY_READING { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_COUNTER to which the ENERGY_READING belongs 
        /// </summary>
        public Guid? GUID_ENERGY_COUNTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_COUNTER
        /// </summary>
        [ForeignKey("GUID_ENERGY_COUNTER")]
        public ENERGY_COUNTER? GUID_ENERGY_COUNTER_ENERGY_COUNTER { get; set; }

        /// <summary>
        /// FROM_DATE of the ENERGY_READING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? FROM_DATE { get; set; }

        /// <summary>
        /// TO_DATE of the ENERGY_READING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? TO_DATE { get; set; }
        /// <summary>
        /// NOTE of the ENERGY_READING 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_READING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_READING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_READING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_READING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}