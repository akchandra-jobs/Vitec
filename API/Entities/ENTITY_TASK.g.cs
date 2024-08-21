using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_task entity with essential details
    /// </summary>
    [Table("ENTITY_TASK", Schema = "dbo")]
    public class ENTITY_TASK
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_TASK class.
        /// </summary>
        public ENTITY_TASK()
        {
            ENTITY_TYPE = -1;
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENTITY_TASK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the ENTITY_TASK 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field STATUS of the ENTITY_TASK 
        /// </summary>
        [Required]
        public int STATUS { get; set; }
        /// <summary>
        /// URL of the ENTITY_TASK 
        /// </summary>
        public string? URL { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_TASK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// ID of the ENTITY_TASK 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENTITY_TASK 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the ENTITY_LINK to which the ENTITY_TASK belongs 
        /// </summary>
        public Guid? GUID_ENTITY_LINK { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENTITY_LINK
        /// </summary>
        [ForeignKey("GUID_ENTITY_LINK")]
        public ENTITY_LINK? GUID_ENTITY_LINK_ENTITY_LINK { get; set; }
        /// <summary>
        /// GUID_ENTITY of the ENTITY_TASK 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }
    }
}