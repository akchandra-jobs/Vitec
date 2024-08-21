using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a organization entity with essential details
    /// </summary>
    [Table("ORGANIZATION", Schema = "dbo")]
    public class ORGANIZATION
    {
        /// <summary>
        /// Initializes a new instance of the ORGANIZATION class.
        /// </summary>
        public ORGANIZATION()
        {
            COLOR = 0;
            HATCHING_PATTERN = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ORGANIZATION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field COLOR of the ORGANIZATION 
        /// </summary>
        [Required]
        public int COLOR { get; set; }

        /// <summary>
        /// Required field HATCHING_PATTERN of the ORGANIZATION 
        /// </summary>
        [Required]
        public int HATCHING_PATTERN { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ORGANIZATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ORGANIZATION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ORGANIZATION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ORGANIZATION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TEXT_01 of the ORGANIZATION 
        /// </summary>
        public string? TEXT_01 { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ORGANIZATION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the ORGANIZATION belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// ID of the ORGANIZATION 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the ORGANIZATION 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}