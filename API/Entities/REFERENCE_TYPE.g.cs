using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a reference_type entity with essential details
    /// </summary>
    [Table("REFERENCE_TYPE", Schema = "dbo")]
    public class REFERENCE_TYPE
    {
        /// <summary>
        /// Initializes a new instance of the REFERENCE_TYPE class.
        /// </summary>
        public REFERENCE_TYPE()
        {
            ENTITY_TYPE = -1;
            CONTEXT = -1;
            IS_HIERARCHY = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the REFERENCE_TYPE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the REFERENCE_TYPE 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field CONTEXT of the REFERENCE_TYPE 
        /// </summary>
        [Required]
        public int CONTEXT { get; set; }

        /// <summary>
        /// Required field IS_HIERARCHY of the REFERENCE_TYPE 
        /// </summary>
        [Required]
        public bool IS_HIERARCHY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the REFERENCE_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REFERENCE_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the REFERENCE_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REFERENCE_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the REFERENCE_TYPE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the REFERENCE_TYPE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the REFERENCE_TYPE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the REFERENCE_TYPE 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
    }
}