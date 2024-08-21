using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_data_format entity with essential details
    /// </summary>
    [Table("ENERGY_DATA_FORMAT", Schema = "dbo")]
    public class ENERGY_DATA_FORMAT
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_DATA_FORMAT class.
        /// </summary>
        public ENERGY_DATA_FORMAT()
        {
            TYPE = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENERGY_DATA_FORMAT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field TYPE of the ENERGY_DATA_FORMAT 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_DATA_FORMAT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_DATA_FORMAT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_DATA_FORMAT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_DATA_FORMAT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_DATA_FORMAT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOM_FUNCTION to which the ENERGY_DATA_FORMAT belongs 
        /// </summary>
        public Guid? GUID_IMPORT_FUNCTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOM_FUNCTION
        /// </summary>
        [ForeignKey("GUID_IMPORT_FUNCTION")]
        public CUSTOM_FUNCTION? GUID_IMPORT_FUNCTION_CUSTOM_FUNCTION { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOM_FUNCTION to which the ENERGY_DATA_FORMAT belongs 
        /// </summary>
        public Guid? GUID_EXPORT_FUNCTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOM_FUNCTION
        /// </summary>
        [ForeignKey("GUID_EXPORT_FUNCTION")]
        public CUSTOM_FUNCTION? GUID_EXPORT_FUNCTION_CUSTOM_FUNCTION { get; set; }
        /// <summary>
        /// ID of the ENERGY_DATA_FORMAT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENERGY_DATA_FORMAT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}