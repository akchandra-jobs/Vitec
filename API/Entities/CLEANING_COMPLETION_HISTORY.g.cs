using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning_completion_history entity with essential details
    /// </summary>
    [Table("CLEANING_COMPLETION_HISTORY", Schema = "dbo")]
    public class CLEANING_COMPLETION_HISTORY
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING_COMPLETION_HISTORY class.
        /// </summary>
        public CLEANING_COMPLETION_HISTORY()
        {
            YEAR = 0;
            MONTH = 0;
            SUM_EXPIRED = 0;
            SUM_COMPLETED = 0;
            SUM_DELAYED = 0;
            SUM_CANCELLED = 0;
            SUM_ESTIMATED_TIME = 0;
            SUM_EXTRA_TIME = 0;
            SUM_COMPLETED_BY_EXIT_CLEANING = 0;
            SUM_EXIT_CLEANING_REQUEST_STATUS_POSSIBLE = 0;
            SUM_EXIT_CLEANING_REQUEST_STATUS_CONFIRMED = 0;
            SUM_EXIT_CLEANING_REQUEST_STATUS_DISCHARGED = 0;
            CLEANING_TYPE = 0;
            SUM_PAUSED = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field YEAR of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int YEAR { get; set; }

        /// <summary>
        /// Required field MONTH of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int MONTH { get; set; }

        /// <summary>
        /// Required field SUM_EXPIRED of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_EXPIRED { get; set; }

        /// <summary>
        /// Required field SUM_COMPLETED of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_COMPLETED { get; set; }

        /// <summary>
        /// Required field SUM_DELAYED of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_DELAYED { get; set; }

        /// <summary>
        /// Required field SUM_CANCELLED of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_CANCELLED { get; set; }

        /// <summary>
        /// Required field SUM_ESTIMATED_TIME of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field SUM_EXTRA_TIME of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_EXTRA_TIME { get; set; }

        /// <summary>
        /// Required field SUM_COMPLETED_BY_EXIT_CLEANING of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_COMPLETED_BY_EXIT_CLEANING { get; set; }

        /// <summary>
        /// Required field SUM_EXIT_CLEANING_REQUEST_STATUS_POSSIBLE of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_EXIT_CLEANING_REQUEST_STATUS_POSSIBLE { get; set; }

        /// <summary>
        /// Required field SUM_EXIT_CLEANING_REQUEST_STATUS_CONFIRMED of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_EXIT_CLEANING_REQUEST_STATUS_CONFIRMED { get; set; }

        /// <summary>
        /// Required field SUM_EXIT_CLEANING_REQUEST_STATUS_DISCHARGED of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_EXIT_CLEANING_REQUEST_STATUS_DISCHARGED { get; set; }

        /// <summary>
        /// Required field CLEANING_TYPE of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int CLEANING_TYPE { get; set; }

        /// <summary>
        /// Required field SUM_PAUSED of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Required]
        public int SUM_PAUSED { get; set; }
        /// <summary>
        /// ESTATE of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? ESTATE { get; set; }
        /// <summary>
        /// BUILDING of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? BUILDING { get; set; }
        /// <summary>
        /// AREA_CATEGORY of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? AREA_CATEGORY { get; set; }
        /// <summary>
        /// AREA_CLASSIFICATION of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? AREA_CLASSIFICATION { get; set; }
        /// <summary>
        /// AREA_CLEANING_QUALITY of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? AREA_CLEANING_QUALITY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_COMPLETION_HISTORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_COMPLETION_HISTORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// DATA_OWNER of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? DATA_OWNER { get; set; }
        /// <summary>
        /// RESOURCE_GROUP of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? RESOURCE_GROUP { get; set; }
        /// <summary>
        /// CLEANING_TASK of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public string? CLEANING_TASK { get; set; }
        /// <summary>
        /// GUID_DATA_OWNER of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }
        /// <summary>
        /// GUID_BUILDING of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }
        /// <summary>
        /// GUID_ESTATE of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }
        /// <summary>
        /// GUID_AREA_CATEGORY of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public Guid? GUID_AREA_CATEGORY { get; set; }
        /// <summary>
        /// GUID_CLEANING_QUALITY of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public Guid? GUID_CLEANING_QUALITY { get; set; }
        /// <summary>
        /// GUID_RESOURCE_GROUP of the CLEANING_COMPLETION_HISTORY 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }
    }
}