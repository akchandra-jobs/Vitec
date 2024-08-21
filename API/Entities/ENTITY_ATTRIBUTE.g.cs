using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_attribute entity with essential details
    /// </summary>
    [Table("ENTITY_ATTRIBUTE", Schema = "dbo")]
    public class ENTITY_ATTRIBUTE
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_ATTRIBUTE class.
        /// </summary>
        public ENTITY_ATTRIBUTE()
        {
            VALUE_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENTITY_ATTRIBUTE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field VALUE_TYPE of the ENTITY_ATTRIBUTE 
        /// </summary>
        [Required]
        public int VALUE_TYPE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_ATTRIBUTE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_ATTRIBUTE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENTITY_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the NAMED_SELECTION to which the ENTITY_ATTRIBUTE belongs 
        /// </summary>
        public Guid? GUID_NAMED_SELECTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated NAMED_SELECTION
        /// </summary>
        [ForeignKey("GUID_NAMED_SELECTION")]
        public NAMED_SELECTION? GUID_NAMED_SELECTION_NAMED_SELECTION { get; set; }
        /// <summary>
        /// ID of the ENTITY_ATTRIBUTE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENTITY_ATTRIBUTE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}