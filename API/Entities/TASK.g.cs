using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a task entity with essential details
    /// </summary>
    [Table("TASK", Schema = "dbo")]
    public class TASK
    {
        /// <summary>
        /// Initializes a new instance of the TASK class.
        /// </summary>
        public TASK()
        {
            ID = 0;
            ENTITY_TYPE = -1;
            IS_BACKGROUND = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the TASK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the TASK 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the TASK 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field IS_BACKGROUND of the TASK 
        /// </summary>
        [Required]
        public bool IS_BACKGROUND { get; set; }

        /// <summary>
        /// UPDATED_DATE of the TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TASK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TASK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// GUID_ENTITY of the TASK 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }

        /// <summary>
        /// START_DATE of the TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the TASK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
        /// <summary>
        /// DESCRIPTION of the TASK 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// Foreign key referencing the TASK to which the TASK belongs 
        /// </summary>
        public Guid? GUID_PARENT_TASK { get; set; }

        /// <summary>
        /// Navigation property representing the associated TASK
        /// </summary>
        [ForeignKey("GUID_PARENT_TASK")]
        public TASK? GUID_PARENT_TASK_TASK { get; set; }
    }
}