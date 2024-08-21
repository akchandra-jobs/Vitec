using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a area_x_cleaning_task entity with essential details
    /// </summary>
    [Table("AREA_X_CLEANING_TASK", Schema = "dbo")]
    public class AREA_X_CLEANING_TASK
    {
        /// <summary>
        /// Initializes a new instance of the AREA_X_CLEANING_TASK class.
        /// </summary>
        public AREA_X_CLEANING_TASK()
        {
            EXIT_CLEANING_REQUEST_STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the AREA_X_CLEANING_TASK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field AVERAGE_CLEANING_PR_YEAR of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Required]
        public double AVERAGE_CLEANING_PR_YEAR { get; set; }

        /// <summary>
        /// Required field EXIT_CLEANING_REQUEST_STATUS of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Required]
        public int EXIT_CLEANING_REQUEST_STATUS { get; set; }

        /// <summary>
        /// PAUSED_FROM_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PAUSED_FROM_DATE { get; set; }

        /// <summary>
        /// PAUSED_TO_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PAUSED_TO_DATE { get; set; }
        /// <summary>
        /// PAUSED_REASON of the AREA_X_CLEANING_TASK 
        /// </summary>
        public string? PAUSED_REASON { get; set; }

        /// <summary>
        /// START_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// UNTIL_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UNTIL_DATE { get; set; }

        /// <summary>
        /// EXIT_CLEANING_DECISION_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXIT_CLEANING_DECISION_DATE { get; set; }

        /// <summary>
        /// EXIT_CLEANING_CONFIRMED_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXIT_CLEANING_CONFIRMED_DATE { get; set; }

        /// <summary>
        /// NEXT_CLEANING_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NEXT_CLEANING_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the AREA_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the AREA_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_TASK to which the AREA_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_TASK
        /// </summary>
        [ForeignKey("GUID_CLEANING_TASK")]
        public CLEANING_TASK? GUID_CLEANING_TASK_CLEANING_TASK { get; set; }
        /// <summary>
        /// RECURRENCE of the AREA_X_CLEANING_TASK 
        /// </summary>
        public string? RECURRENCE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the AREA_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_CLEANER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_CLEANER")]
        public PERSON? GUID_CLEANER_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the AREA_X_CLEANING_TASK belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TEAM { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_CLEANING_TEAM")]
        public RESOURCE_GROUP? GUID_CLEANING_TEAM_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// DELAYED_DATE of the AREA_X_CLEANING_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DELAYED_DATE { get; set; }
    }
}