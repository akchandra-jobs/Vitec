using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a language entity with essential details
    /// </summary>
    [Table("LANGUAGE", Schema = "dbo")]
    public class LANGUAGE
    {
        /// <summary>
        /// Initializes a new instance of the LANGUAGE class.
        /// </summary>
        public LANGUAGE()
        {
            INDEX_POSITION = 0;
            CREATION_DATE = DateTime.UtcNow;
            UPDATED_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the LANGUAGE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the LANGUAGE 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }
        /// <summary>
        /// COUNTRY of the LANGUAGE 
        /// </summary>
        public string? COUNTRY { get; set; }
        /// <summary>
        /// LOCALE of the LANGUAGE 
        /// </summary>
        public string? LOCALE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the LANGUAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LANGUAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
    }
}