using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning_completion entity with essential details
    /// </summary>
    [Table("CLEANING_COMPLETION", Schema = "dbo")]
    public class CLEANING_COMPLETION
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING_COMPLETION class.
        /// </summary>
        public CLEANING_COMPLETION()
        {
            EXTRA_TIME = 0;
            EXIT_CLEANING_REQUEST_STATUS = -1;
            COMPLETION_STATUS = -1;
            ESTIMATED_TIME = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field EXTRA_TIME of the CLEANING_COMPLETION 
        /// </summary>
        [Required]
        public int EXTRA_TIME { get; set; }

        /// <summary>
        /// Primary key for the CLEANING_COMPLETION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field EXIT_CLEANING_REQUEST_STATUS of the CLEANING_COMPLETION 
        /// </summary>
        [Required]
        public int EXIT_CLEANING_REQUEST_STATUS { get; set; }

        /// <summary>
        /// Required field COMPLETION_STATUS of the CLEANING_COMPLETION 
        /// </summary>
        [Required]
        public int COMPLETION_STATUS { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the CLEANING_COMPLETION 
        /// </summary>
        [Required]
        public int ESTIMATED_TIME { get; set; }

        /// <summary>
        /// COMPLETION_DATE of the CLEANING_COMPLETION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? COMPLETION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CLEANING_COMPLETION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the CLEANING_COMPLETION belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the CLEANING_COMPLETION belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CLEANING_COMPLETION 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING_COMPLETION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_COMPLETION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING_COMPLETION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_COMPLETION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_TASK to which the CLEANING_COMPLETION belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_TASK
        /// </summary>
        [ForeignKey("GUID_CLEANING_TASK")]
        public CLEANING_TASK? GUID_CLEANING_TASK_CLEANING_TASK { get; set; }

        /// <summary>
        /// ADDITIONAL_CLEANING_CREATION_DATE of the CLEANING_COMPLETION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ADDITIONAL_CLEANING_CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the CLEANING_COMPLETION belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// EXIT_CLEANING_DECISION_DATE of the CLEANING_COMPLETION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXIT_CLEANING_DECISION_DATE { get; set; }

        /// <summary>
        /// EXIT_CLEANING_CONFIRMED_DATE of the CLEANING_COMPLETION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXIT_CLEANING_CONFIRMED_DATE { get; set; }
    }
}