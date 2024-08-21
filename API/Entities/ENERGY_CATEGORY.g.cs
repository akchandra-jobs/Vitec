using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_category entity with essential details
    /// </summary>
    [Table("ENERGY_CATEGORY", Schema = "dbo")]
    public class ENERGY_CATEGORY
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_CATEGORY class.
        /// </summary>
        public ENERGY_CATEGORY()
        {
            SYMBOL = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ACCUMULATED_DEVIATION_PERCENT of the ENERGY_CATEGORY 
        /// </summary>
        [Required]
        public double ACCUMULATED_DEVIATION_PERCENT { get; set; }

        /// <summary>
        /// Required field CONSUMPTION_DEVIATION_PERCENT of the ENERGY_CATEGORY 
        /// </summary>
        [Required]
        public double CONSUMPTION_DEVIATION_PERCENT { get; set; }

        /// <summary>
        /// Primary key for the ENERGY_CATEGORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field SYMBOL of the ENERGY_CATEGORY 
        /// </summary>
        [Required]
        public int SYMBOL { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the ENERGY_CATEGORY 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}