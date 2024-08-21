using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a relationship_type entity with essential details
    /// </summary>
    [Table("RELATIONSHIP_TYPE", Schema = "dbo")]
    public class RELATIONSHIP_TYPE
    {
        /// <summary>
        /// Initializes a new instance of the RELATIONSHIP_TYPE class.
        /// </summary>
        public RELATIONSHIP_TYPE()
        {
            IS_DIRECTIONAL = false;
            HAS_SINGLE_TARGET = false;
            ALLOWS_CIRCULAR = false;
            IS_SYSTEM_OWNED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field IS_DIRECTIONAL of the RELATIONSHIP_TYPE 
        /// </summary>
        [Required]
        public bool IS_DIRECTIONAL { get; set; }

        /// <summary>
        /// Required field HAS_SINGLE_TARGET of the RELATIONSHIP_TYPE 
        /// </summary>
        [Required]
        public bool HAS_SINGLE_TARGET { get; set; }

        /// <summary>
        /// Required field ALLOWS_CIRCULAR of the RELATIONSHIP_TYPE 
        /// </summary>
        [Required]
        public bool ALLOWS_CIRCULAR { get; set; }

        /// <summary>
        /// Required field IS_SYSTEM_OWNED of the RELATIONSHIP_TYPE 
        /// </summary>
        [Required]
        public bool IS_SYSTEM_OWNED { get; set; }

        /// <summary>
        /// Primary key for the RELATIONSHIP_TYPE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// NAME of the RELATIONSHIP_TYPE 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// FORWARD_NAME of the RELATIONSHIP_TYPE 
        /// </summary>
        public string? FORWARD_NAME { get; set; }
        /// <summary>
        /// REVERSE_NAME of the RELATIONSHIP_TYPE 
        /// </summary>
        public string? REVERSE_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the RELATIONSHIP_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RELATIONSHIP_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the RELATIONSHIP_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RELATIONSHIP_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}