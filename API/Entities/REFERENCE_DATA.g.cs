using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a reference_data entity with essential details
    /// </summary>
    [Table("REFERENCE_DATA", Schema = "dbo")]
    public class REFERENCE_DATA
    {
        /// <summary>
        /// Initializes a new instance of the REFERENCE_DATA class.
        /// </summary>
        public REFERENCE_DATA()
        {
            INDEX_POSITION = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the REFERENCE_DATA 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the REFERENCE_DATA 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the REFERENCE_DATA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REFERENCE_DATA belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the REFERENCE_DATA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the REFERENCE_DATA belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// DISABLED_FROM_DATE of the REFERENCE_DATA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DISABLED_FROM_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the REFERENCE_DATA belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the REFERENCE_TYPE to which the REFERENCE_DATA belongs 
        /// </summary>
        public Guid? GUID_REFERENCE_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated REFERENCE_TYPE
        /// </summary>
        [ForeignKey("GUID_REFERENCE_TYPE")]
        public REFERENCE_TYPE? GUID_REFERENCE_TYPE_REFERENCE_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the REFERENCE_DATA to which the REFERENCE_DATA belongs 
        /// </summary>
        public Guid? GUID_PARENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated REFERENCE_DATA
        /// </summary>
        [ForeignKey("GUID_PARENT")]
        public REFERENCE_DATA? GUID_PARENT_REFERENCE_DATA { get; set; }
        /// <summary>
        /// ID of the REFERENCE_DATA 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the REFERENCE_DATA 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT1 of the REFERENCE_DATA 
        /// </summary>
        public string? EXPLANATORY_TEXT1 { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT2 of the REFERENCE_DATA 
        /// </summary>
        public string? EXPLANATORY_TEXT2 { get; set; }
    }
}