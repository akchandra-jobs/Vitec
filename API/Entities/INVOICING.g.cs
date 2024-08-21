using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a invoicing entity with essential details
    /// </summary>
    [Table("INVOICING", Schema = "dbo")]
    public class INVOICING
    {
        /// <summary>
        /// Initializes a new instance of the INVOICING class.
        /// </summary>
        public INVOICING()
        {
            TYPE = 0;
            PERIOD_UNIT = 2;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field PERIOD_NUMBER of the INVOICING 
        /// </summary>
        [Required]
        public double PERIOD_NUMBER { get; set; }

        /// <summary>
        /// Required field TYPE of the INVOICING 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Primary key for the INVOICING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field PERIOD_UNIT of the INVOICING 
        /// </summary>
        [Required]
        public int PERIOD_UNIT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the INVOICING belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the INVOICING 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the INVOICING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the INVOICING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the INVOICING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the INVOICING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}