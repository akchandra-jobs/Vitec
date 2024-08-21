using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a priority entity with essential details
    /// </summary>
    [Table("PRIORITY", Schema = "dbo")]
    public class PRIORITY
    {
        /// <summary>
        /// Initializes a new instance of the PRIORITY class.
        /// </summary>
        public PRIORITY()
        {
            HAS_DEADLINE = false;
            DEADLINE_PERIOD_UNIT = -1;
            ENTITY_TYPE = 6;
            IS_DEACTIVATED = false;
            LEVEL = 1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field HAS_DEADLINE of the PRIORITY 
        /// </summary>
        [Required]
        public bool HAS_DEADLINE { get; set; }

        /// <summary>
        /// Required field DEADLINE_PERIOD_NUMBER of the PRIORITY 
        /// </summary>
        [Required]
        public double DEADLINE_PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field DEADLINE_PERIOD_UNIT of the PRIORITY 
        /// </summary>
        [Required]
        public int DEADLINE_PERIOD_UNIT { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the PRIORITY 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the PRIORITY 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field LEVEL of the PRIORITY 
        /// </summary>
        [Required]
        public int LEVEL { get; set; }

        /// <summary>
        /// Primary key for the PRIORITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PRIORITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the PRIORITY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// COLOR of the PRIORITY 
        /// </summary>
        public string? COLOR { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the PRIORITY 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PRIORITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PRIORITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PRIORITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PRIORITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}