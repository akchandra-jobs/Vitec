using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning entity with essential details
    /// </summary>
    [Table("CLEANING", Schema = "dbo")]
    public class CLEANING
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING class.
        /// </summary>
        public CLEANING()
        {
            COLOR = 0;
            HATCHING_PATTERN = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field COLOR of the CLEANING 
        /// </summary>
        [Required]
        public int COLOR { get; set; }

        /// <summary>
        /// Required field HATCHING_PATTERN of the CLEANING 
        /// </summary>
        [Required]
        public int HATCHING_PATTERN { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the CLEANING 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the CLEANING 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field FACTOR of the CLEANING 
        /// </summary>
        [Required]
        public double FACTOR { get; set; }

        /// <summary>
        /// Required field FULL_TIME_EQUIVALENT of the CLEANING 
        /// </summary>
        [Required]
        public double FULL_TIME_EQUIVALENT { get; set; }

        /// <summary>
        /// Primary key for the CLEANING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CLEANING belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the INTERVAL to which the CLEANING belongs 
        /// </summary>
        public Guid? GUID_INTERVAL { get; set; }

        /// <summary>
        /// Navigation property representing the associated INTERVAL
        /// </summary>
        [ForeignKey("GUID_INTERVAL")]
        public INTERVAL? GUID_INTERVAL_INTERVAL { get; set; }
        /// <summary>
        /// ID of the CLEANING 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}