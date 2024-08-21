using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cost_center entity with essential details
    /// </summary>
    [Table("COST_CENTER", Schema = "dbo")]
    public class COST_CENTER
    {
        /// <summary>
        /// Initializes a new instance of the COST_CENTER class.
        /// </summary>
        public COST_CENTER()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the COST_CENTER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the COST_CENTER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the COST_CENTER belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// ID of the COST_CENTER 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the COST_CENTER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// ORGANIZATION_NUMBER of the COST_CENTER 
        /// </summary>
        public string? ORGANIZATION_NUMBER { get; set; }
        /// <summary>
        /// CORPORATE_NAME of the COST_CENTER 
        /// </summary>
        public string? CORPORATE_NAME { get; set; }

        /// <summary>
        /// UPDATED_DATE of the COST_CENTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COST_CENTER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the COST_CENTER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the COST_CENTER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}