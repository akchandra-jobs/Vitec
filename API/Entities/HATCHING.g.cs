using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a hatching entity with essential details
    /// </summary>
    [Table("HATCHING", Schema = "dbo")]
    public class HATCHING
    {
        /// <summary>
        /// Initializes a new instance of the HATCHING class.
        /// </summary>
        public HATCHING()
        {
            COLOR = 0;
            PATTERN = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the HATCHING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field COLOR of the HATCHING 
        /// </summary>
        [Required]
        public int COLOR { get; set; }

        /// <summary>
        /// Required field PATTERN of the HATCHING 
        /// </summary>
        [Required]
        public int PATTERN { get; set; }

        /// <summary>
        /// UPDATED_DATE of the HATCHING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the HATCHING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the HATCHING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the HATCHING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the HATCHING belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DRAWING to which the HATCHING belongs 
        /// </summary>
        public Guid? GUID_DRAWING { get; set; }

        /// <summary>
        /// Navigation property representing the associated DRAWING
        /// </summary>
        [ForeignKey("GUID_DRAWING")]
        public DRAWING? GUID_DRAWING_DRAWING { get; set; }
        /// <summary>
        /// ID of the HATCHING 
        /// </summary>
        public string? ID { get; set; }
    }
}