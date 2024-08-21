using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_periodic_task entity with essential details
    /// </summary>
    [Table("ENERGY_PERIODIC_TASK", Schema = "dbo")]
    public class ENERGY_PERIODIC_TASK
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_PERIODIC_TASK class.
        /// </summary>
        public ENERGY_PERIODIC_TASK()
        {
            TYPE = -1;
            INTERVAL = 0;
            PERIOD = -1;
            CODE = 0;
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field TYPE of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field INTERVAL of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Required]
        public int INTERVAL { get; set; }

        /// <summary>
        /// Required field PERIOD of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Required]
        public int PERIOD { get; set; }

        /// <summary>
        /// Required field CODE of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Required]
        public int CODE { get; set; }

        /// <summary>
        /// Primary key for the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENERGY_PERIODIC_TASK 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_ENDED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_ENDED_BY")]
        public USR? GUID_USER_ENDED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_BLOCK to which the ENERGY_PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_ENERGY_BLOCK { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_BLOCK
        /// </summary>
        [ForeignKey("GUID_ENERGY_BLOCK")]
        public ENERGY_BLOCK? GUID_ENERGY_BLOCK_ENERGY_BLOCK { get; set; }

        /// <summary>
        /// DUE_DATE of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DUE_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_PERIODIC_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_PERIODIC_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}