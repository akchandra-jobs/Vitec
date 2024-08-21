using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_job_x_counter entity with essential details
    /// </summary>
    [Table("ENERGY_JOB_X_COUNTER", Schema = "dbo")]
    public class ENERGY_JOB_X_COUNTER
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_JOB_X_COUNTER class.
        /// </summary>
        public ENERGY_JOB_X_COUNTER()
        {
            STATUS = 0;
            CARD_ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field LAST_ACCUMULATED of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double LAST_ACCUMULATED { get; set; }

        /// <summary>
        /// Required field LAST_CONSUMPTION of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double LAST_CONSUMPTION { get; set; }

        /// <summary>
        /// Required field EXPECTED_ACCUMULATED of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double EXPECTED_ACCUMULATED { get; set; }

        /// <summary>
        /// Required field EXPECTED_CONSUMPTION of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double EXPECTED_CONSUMPTION { get; set; }

        /// <summary>
        /// Required field STATUS of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field NEW_ACCUMULATED of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double NEW_ACCUMULATED { get; set; }

        /// <summary>
        /// Required field NEW_CONSUMPTION of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double NEW_CONSUMPTION { get; set; }

        /// <summary>
        /// Required field MAXIMUM_VALUE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double MAXIMUM_VALUE { get; set; }

        /// <summary>
        /// Required field EXPECTED_YEARLY_CONSUMPTION of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public double EXPECTED_YEARLY_CONSUMPTION { get; set; }

        /// <summary>
        /// Required field CARD_ID of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Required]
        public int CARD_ID { get; set; }
        /// <summary>
        /// LOCATION of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        public string? LOCATION { get; set; }
        /// <summary>
        /// NOTE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_JOB_X_COUNTER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_JOB_X_COUNTER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// STATUS_DESCRIPTION of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        public string? STATUS_DESCRIPTION { get; set; }

        /// <summary>
        /// LAST_FROM_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_FROM_DATE { get; set; }

        /// <summary>
        /// LAST_TO_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_TO_DATE { get; set; }

        /// <summary>
        /// NEW_FROM_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NEW_FROM_DATE { get; set; }

        /// <summary>
        /// NEW_TO_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NEW_TO_DATE { get; set; }

        /// <summary>
        /// EXPECTED_FROM_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXPECTED_FROM_DATE { get; set; }

        /// <summary>
        /// EXPECTED_TO_DATE of the ENERGY_JOB_X_COUNTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXPECTED_TO_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_JOB_X_COUNTER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_READING to which the ENERGY_JOB_X_COUNTER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_READING { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_READING
        /// </summary>
        [ForeignKey("GUID_ENERGY_READING")]
        public ENERGY_READING? GUID_ENERGY_READING_ENERGY_READING { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_JOB to which the ENERGY_JOB_X_COUNTER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_JOB { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_JOB
        /// </summary>
        [ForeignKey("GUID_ENERGY_JOB")]
        public ENERGY_JOB? GUID_ENERGY_JOB_ENERGY_JOB { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_COUNTER to which the ENERGY_JOB_X_COUNTER belongs 
        /// </summary>
        public Guid? GUID_ENERGY_COUNTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_COUNTER
        /// </summary>
        [ForeignKey("GUID_ENERGY_COUNTER")]
        public ENERGY_COUNTER? GUID_ENERGY_COUNTER_ENERGY_COUNTER { get; set; }
    }
}