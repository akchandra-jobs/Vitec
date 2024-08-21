using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_job entity with essential details
    /// </summary>
    [Table("ENERGY_JOB", Schema = "dbo")]
    public class ENERGY_JOB
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_JOB class.
        /// </summary>
        public ENERGY_JOB()
        {
            TYPE = 0;
            STATUS = 0;
            QUANTITY_STATUS0 = 0;
            QUANTITY_STATUS1 = 0;
            QUANTITY_STATUS2 = 0;
            QUANTITY_STATUS3 = 0;
            QUANTITY_STATUS4 = 0;
            QUANTITY_STATUS5 = 0;
            QUANTITY_STATUS6 = 0;
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field TYPE of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field STATUS of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field QUANTITY_STATUS0 of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int QUANTITY_STATUS0 { get; set; }

        /// <summary>
        /// Required field QUANTITY_STATUS1 of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int QUANTITY_STATUS1 { get; set; }

        /// <summary>
        /// Required field QUANTITY_STATUS2 of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int QUANTITY_STATUS2 { get; set; }

        /// <summary>
        /// Required field QUANTITY_STATUS3 of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int QUANTITY_STATUS3 { get; set; }

        /// <summary>
        /// Required field QUANTITY_STATUS4 of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int QUANTITY_STATUS4 { get; set; }

        /// <summary>
        /// Required field QUANTITY_STATUS5 of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int QUANTITY_STATUS5 { get; set; }

        /// <summary>
        /// Required field QUANTITY_STATUS6 of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int QUANTITY_STATUS6 { get; set; }

        /// <summary>
        /// Primary key for the ENERGY_JOB 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the ENERGY_JOB 
        /// </summary>
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENERGY_JOB 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_JOB belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_BLOCK to which the ENERGY_JOB belongs 
        /// </summary>
        public Guid? GUID_ENERGY_BLOCK { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_BLOCK
        /// </summary>
        [ForeignKey("GUID_ENERGY_BLOCK")]
        public ENERGY_BLOCK? GUID_ENERGY_BLOCK_ENERGY_BLOCK { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_JOB belongs 
        /// </summary>
        public Guid? GUID_USER_ENDED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_ENDED_BY")]
        public USR? GUID_USER_ENDED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_PERIODIC_TASK to which the ENERGY_JOB belongs 
        /// </summary>
        public Guid? GUID_ENERGY_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_PERIODIC_TASK
        /// </summary>
        [ForeignKey("GUID_ENERGY_PERIODIC_TASK")]
        public ENERGY_PERIODIC_TASK? GUID_ENERGY_PERIODIC_TASK_ENERGY_PERIODIC_TASK { get; set; }

        /// <summary>
        /// START_DATE of the ENERGY_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the ENERGY_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// DEADLINE_DATE of the ENERGY_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DEADLINE_DATE { get; set; }
        /// <summary>
        /// FILENAME_OUT of the ENERGY_JOB 
        /// </summary>
        public string? FILENAME_OUT { get; set; }

        /// <summary>
        /// FILENAME_OUT_DATE of the ENERGY_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? FILENAME_OUT_DATE { get; set; }
        /// <summary>
        /// FILENAME_IN of the ENERGY_JOB 
        /// </summary>
        public string? FILENAME_IN { get; set; }

        /// <summary>
        /// FILENAME_IN_DATE of the ENERGY_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? FILENAME_IN_DATE { get; set; }
        /// <summary>
        /// FILENAME_LOG of the ENERGY_JOB 
        /// </summary>
        public string? FILENAME_LOG { get; set; }
        /// <summary>
        /// FILENAME_APPROVED of the ENERGY_JOB 
        /// </summary>
        public string? FILENAME_APPROVED { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_JOB belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_JOB 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_JOB belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}