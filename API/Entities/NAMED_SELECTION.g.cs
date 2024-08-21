using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a named_selection entity with essential details
    /// </summary>
    [Table("NAMED_SELECTION", Schema = "dbo")]
    public class NAMED_SELECTION
    {
        /// <summary>
        /// Initializes a new instance of the NAMED_SELECTION class.
        /// </summary>
        public NAMED_SELECTION()
        {
            ENTITY_TYPE = -1;
            SIZE_OF_COMBO = 0;
            IS_MULTI_SELECT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the NAMED_SELECTION 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field SIZE_OF_COMBO of the NAMED_SELECTION 
        /// </summary>
        [Required]
        public int SIZE_OF_COMBO { get; set; }

        /// <summary>
        /// Primary key for the NAMED_SELECTION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_MULTI_SELECT of the NAMED_SELECTION 
        /// </summary>
        [Required]
        public bool IS_MULTI_SELECT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the NAMED_SELECTION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// VALUE of the NAMED_SELECTION 
        /// </summary>
        public string? VALUE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the NAMED_SELECTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the NAMED_SELECTION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the NAMED_SELECTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the NAMED_SELECTION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the NAMED_SELECTION_VALUE to which the NAMED_SELECTION belongs 
        /// </summary>
        public Guid? GUID_DEFAULT_NAMED_SELECTION_VALUE { get; set; }

        /// <summary>
        /// Navigation property representing the associated NAMED_SELECTION_VALUE
        /// </summary>
        [ForeignKey("GUID_DEFAULT_NAMED_SELECTION_VALUE")]
        public NAMED_SELECTION_VALUE? GUID_DEFAULT_NAMED_SELECTION_VALUE_NAMED_SELECTION_VALUE { get; set; }
    }
}