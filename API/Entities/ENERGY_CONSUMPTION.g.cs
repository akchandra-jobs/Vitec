using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_consumption entity with essential details
    /// </summary>
    [Table("ENERGY_CONSUMPTION", Schema = "dbo")]
    public class ENERGY_CONSUMPTION
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_CONSUMPTION class.
        /// </summary>
        public ENERGY_CONSUMPTION()
        {
            YEAR = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field YEAR of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public int YEAR { get; set; }

        /// <summary>
        /// Required field JAN of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double JAN { get; set; }

        /// <summary>
        /// Required field FEB of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double FEB { get; set; }

        /// <summary>
        /// Required field MAR of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double MAR { get; set; }

        /// <summary>
        /// Required field APR of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double APR { get; set; }

        /// <summary>
        /// Required field MAY of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double MAY { get; set; }

        /// <summary>
        /// Required field JUN of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double JUN { get; set; }

        /// <summary>
        /// Required field JUL of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double JUL { get; set; }

        /// <summary>
        /// Required field AUG of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double AUG { get; set; }

        /// <summary>
        /// Required field SEP of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double SEP { get; set; }

        /// <summary>
        /// Required field OCT of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double OCT { get; set; }

        /// <summary>
        /// Required field NOV of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double NOV { get; set; }

        /// <summary>
        /// Required field DEC of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double DEC { get; set; }

        /// <summary>
        /// Required field SUM_YEAR of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double SUM_YEAR { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_JAN of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_JAN { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_FEB of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_FEB { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_MAR of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_MAR { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_APR of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_APR { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_MAY of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_MAY { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_JUN of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_JUN { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_JUL of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_JUL { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_AUG of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_AUG { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_SEP of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_SEP { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_OCT of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_OCT { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_NOV of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_NOV { get; set; }

        /// <summary>
        /// Required field ACCUMULATED_DEC of the ENERGY_CONSUMPTION 
        /// </summary>
        [Required]
        public double ACCUMULATED_DEC { get; set; }

        /// <summary>
        /// Primary key for the ENERGY_CONSUMPTION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_COUNTER to which the ENERGY_CONSUMPTION belongs 
        /// </summary>
        public Guid? GUID_ENERGY_COUNTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_COUNTER
        /// </summary>
        [ForeignKey("GUID_ENERGY_COUNTER")]
        public ENERGY_COUNTER? GUID_ENERGY_COUNTER_ENERGY_COUNTER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_CONSUMPTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_CONSUMPTION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_CONSUMPTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_CONSUMPTION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}