using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a project_status entity with essential details
    /// </summary>
    [Table("PROJECT_STATUS", Schema = "dbo")]
    public class PROJECT_STATUS
    {
        /// <summary>
        /// Initializes a new instance of the PROJECT_STATUS class.
        /// </summary>
        public PROJECT_STATUS()
        {
            INDEX_POSITION = 0;
            STAGE = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PROJECT_STATUS 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the PROJECT_STATUS 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }

        /// <summary>
        /// Required field STAGE of the PROJECT_STATUS 
        /// </summary>
        [Required]
        public int STAGE { get; set; }
        /// <summary>
        /// COLOR of the PROJECT_STATUS 
        /// </summary>
        public string? COLOR { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PROJECT_STATUS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT_STATUS belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PROJECT_STATUS 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT_STATUS belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PROJECT_STATUS belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PROJECT_PHASE to which the PROJECT_STATUS belongs 
        /// </summary>
        public Guid? GUID_PROJECT_PHASE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PROJECT_PHASE
        /// </summary>
        [ForeignKey("GUID_PROJECT_PHASE")]
        public PROJECT_PHASE? GUID_PROJECT_PHASE_PROJECT_PHASE { get; set; }
        /// <summary>
        /// ID of the PROJECT_STATUS 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PROJECT_STATUS 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}