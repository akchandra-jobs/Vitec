using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning_task entity with essential details
    /// </summary>
    [Table("CLEANING_TASK", Schema = "dbo")]
    public class CLEANING_TASK
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING_TASK class.
        /// </summary>
        public CLEANING_TASK()
        {
            IS_ADDITIONAL_TASK = false;
            IS_TEMPLATE = false;
            CLEANING_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ESTIMATED_TIME of the CLEANING_TASK 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the CLEANING_TASK 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field IS_ADDITIONAL_TASK of the CLEANING_TASK 
        /// </summary>
        [Required]
        public bool IS_ADDITIONAL_TASK { get; set; }

        /// <summary>
        /// Required field IS_TEMPLATE of the CLEANING_TASK 
        /// </summary>
        [Required]
        public bool IS_TEMPLATE { get; set; }

        /// <summary>
        /// Required field CLEANING_TYPE of the CLEANING_TASK 
        /// </summary>
        [Required]
        public int CLEANING_TYPE { get; set; }

        /// <summary>
        /// Primary key for the CLEANING_TASK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field AVERAGE_CLEANING_PR_YEAR of the CLEANING_TASK 
        /// </summary>
        [Required]
        public double AVERAGE_CLEANING_PR_YEAR { get; set; }
        /// <summary>
        /// OLD_CLEANING_TYPE_ID of the CLEANING_TASK 
        /// </summary>
        public string? OLD_CLEANING_TYPE_ID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the CLEANING_TASK 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// EXIT_CLEANING_DECISION_DATE of the CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXIT_CLEANING_DECISION_DATE { get; set; }

        /// <summary>
        /// NEXT_CLEANING_DATE of the CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NEXT_CLEANING_DATE { get; set; }
        /// <summary>
        /// NUMERIC_FIELD_NAME of the CLEANING_TASK 
        /// </summary>
        public string? NUMERIC_FIELD_NAME { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CLEANING_TASK 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// RECURRENCE of the CLEANING_TASK 
        /// </summary>
        public string? RECURRENCE { get; set; }
    }
}