using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a organization_unit entity with essential details
    /// </summary>
    [Table("ORGANIZATION_UNIT", Schema = "dbo")]
    public class ORGANIZATION_UNIT
    {
        /// <summary>
        /// Initializes a new instance of the ORGANIZATION_UNIT class.
        /// </summary>
        public ORGANIZATION_UNIT()
        {
            COLOR = 0;
            HATCHING_PATTERN = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ORGANIZATION_UNIT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field COLOR of the ORGANIZATION_UNIT 
        /// </summary>
        [Required]
        public int COLOR { get; set; }

        /// <summary>
        /// Required field HATCHING_PATTERN of the ORGANIZATION_UNIT 
        /// </summary>
        [Required]
        public int HATCHING_PATTERN { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ORGANIZATION_UNIT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ORGANIZATION_UNIT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ORGANIZATION_UNIT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ORGANIZATION_UNIT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TEXT_01 of the ORGANIZATION_UNIT 
        /// </summary>
        public string? TEXT_01 { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ORGANIZATION_UNIT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION to which the ORGANIZATION_UNIT belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION")]
        public ORGANIZATION? GUID_ORGANIZATION_ORGANIZATION { get; set; }
        /// <summary>
        /// ID of the ORGANIZATION_UNIT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ORGANIZATION_UNIT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}