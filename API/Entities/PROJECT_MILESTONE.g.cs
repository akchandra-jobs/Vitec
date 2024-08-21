using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a project_milestone entity with essential details
    /// </summary>
    [Table("PROJECT_MILESTONE", Schema = "dbo")]
    public class PROJECT_MILESTONE
    {
        /// <summary>
        /// Initializes a new instance of the PROJECT_MILESTONE class.
        /// </summary>
        public PROJECT_MILESTONE()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PROJECT_MILESTONE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PROJECT_MILESTONE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT to which the PROJECT_MILESTONE belongs 
        /// </summary>
        public Guid? GUID_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT
        /// </summary>
        [ForeignKey("GUID_PROJECT")]
        public PROJECT? GUID_PROJECT_PROJECT { get; set; }
        /// <summary>
        /// ID of the PROJECT_MILESTONE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PROJECT_MILESTONE 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// DUE_DATE of the PROJECT_MILESTONE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DUE_DATE { get; set; }

        /// <summary>
        /// END_DATE of the PROJECT_MILESTONE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PROJECT_MILESTONE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT_MILESTONE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PROJECT_MILESTONE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT_MILESTONE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}