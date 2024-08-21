using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a setting entity with essential details
    /// </summary>
    [Table("SETTING", Schema = "dbo")]
    public class SETTING
    {
        /// <summary>
        /// Initializes a new instance of the SETTING class.
        /// </summary>
        public SETTING()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the SETTING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// KEY of the SETTING 
        /// </summary>
        public string? KEY { get; set; }
        /// <summary>
        /// VALUE of the SETTING 
        /// </summary>
        public string? VALUE { get; set; }
        /// <summary>
        /// DESCRIPTION of the SETTING 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SETTING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SETTING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SETTING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SETTING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}