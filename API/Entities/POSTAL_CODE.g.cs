using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a postal_code entity with essential details
    /// </summary>
    [Table("POSTAL_CODE", Schema = "dbo")]
    public class POSTAL_CODE
    {
        /// <summary>
        /// Initializes a new instance of the POSTAL_CODE class.
        /// </summary>
        public POSTAL_CODE()
        {
            COUNTRY_CODE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field COUNTRY_CODE of the POSTAL_CODE 
        /// </summary>
        [Required]
        public int COUNTRY_CODE { get; set; }

        /// <summary>
        /// Primary key for the POSTAL_CODE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// ZIP_CODE of the POSTAL_CODE 
        /// </summary>
        public string? ZIP_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the POSTAL_CODE 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// MUNICIPALITY_NR of the POSTAL_CODE 
        /// </summary>
        public string? MUNICIPALITY_NR { get; set; }
        /// <summary>
        /// MUNICIPALITY_NAME of the POSTAL_CODE 
        /// </summary>
        public string? MUNICIPALITY_NAME { get; set; }
        /// <summary>
        /// COUNTY of the POSTAL_CODE 
        /// </summary>
        public string? COUNTY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the POSTAL_CODE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the POSTAL_CODE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the POSTAL_CODE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the POSTAL_CODE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}