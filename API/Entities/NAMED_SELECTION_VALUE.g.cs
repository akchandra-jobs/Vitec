using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a named_selection_value entity with essential details
    /// </summary>
    [Table("NAMED_SELECTION_VALUE", Schema = "dbo")]
    public class NAMED_SELECTION_VALUE
    {
        /// <summary>
        /// Initializes a new instance of the NAMED_SELECTION_VALUE class.
        /// </summary>
        public NAMED_SELECTION_VALUE()
        {
            INDEX_POSITION = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the NAMED_SELECTION_VALUE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the NAMED_SELECTION_VALUE 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the NAMED_SELECTION_VALUE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the NAMED_SELECTION_VALUE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the NAMED_SELECTION_VALUE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the NAMED_SELECTION_VALUE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the NAMED_SELECTION_VALUE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the NAMED_SELECTION to which the NAMED_SELECTION_VALUE belongs 
        /// </summary>
        public Guid? GUID_NAMED_SELECTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated NAMED_SELECTION
        /// </summary>
        [ForeignKey("GUID_NAMED_SELECTION")]
        public NAMED_SELECTION? GUID_NAMED_SELECTION_NAMED_SELECTION { get; set; }
        /// <summary>
        /// VALUE of the NAMED_SELECTION_VALUE 
        /// </summary>
        public string? VALUE { get; set; }
    }
}