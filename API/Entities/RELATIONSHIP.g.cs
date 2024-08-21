using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a relationship entity with essential details
    /// </summary>
    [Table("RELATIONSHIP", Schema = "dbo")]
    public class RELATIONSHIP
    {
        /// <summary>
        /// Initializes a new instance of the RELATIONSHIP class.
        /// </summary>
        public RELATIONSHIP()
        {
            SOURCE_ENTITY_TYPE = -1;
            TARGET_ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the RELATIONSHIP 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field SOURCE_ENTITY_TYPE of the RELATIONSHIP 
        /// </summary>
        [Required]
        public int SOURCE_ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field TARGET_ENTITY_TYPE of the RELATIONSHIP 
        /// </summary>
        [Required]
        public int TARGET_ENTITY_TYPE { get; set; }
        /// <summary>
        /// GUID_TARGET_ENTITY of the RELATIONSHIP 
        /// </summary>
        public Guid? GUID_TARGET_ENTITY { get; set; }
        /// <summary>
        /// ADDITIONAL_INFO of the RELATIONSHIP 
        /// </summary>
        public string? ADDITIONAL_INFO { get; set; }

        /// <summary>
        /// UPDATED_DATE of the RELATIONSHIP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RELATIONSHIP belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the RELATIONSHIP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the RELATIONSHIP belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// GUID_SOURCE_ENTITY of the RELATIONSHIP 
        /// </summary>
        public Guid? GUID_SOURCE_ENTITY { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the RELATIONSHIP belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the RELATIONSHIP_TYPE to which the RELATIONSHIP belongs 
        /// </summary>
        public Guid? GUID_RELATIONSHIP_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated RELATIONSHIP_TYPE
        /// </summary>
        [ForeignKey("GUID_RELATIONSHIP_TYPE")]
        public RELATIONSHIP_TYPE? GUID_RELATIONSHIP_TYPE_RELATIONSHIP_TYPE { get; set; }
    }
}