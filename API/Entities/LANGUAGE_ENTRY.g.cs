using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a language_entry entity with essential details
    /// </summary>
    [Table("LANGUAGE_ENTRY", Schema = "dbo")]
    public class LANGUAGE_ENTRY
    {
        /// <summary>
        /// Initializes a new instance of the LANGUAGE_ENTRY class.
        /// </summary>
        public LANGUAGE_ENTRY()
        {
            ID = 0;
            IS_TO_DELETE = false;
            IS_USED_IN_REPORTS = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ID of the LANGUAGE_ENTRY 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field IS_TO_DELETE of the LANGUAGE_ENTRY 
        /// </summary>
        [Required]
        public bool IS_TO_DELETE { get; set; }

        /// <summary>
        /// Required field IS_USED_IN_REPORTS of the LANGUAGE_ENTRY 
        /// </summary>
        [Required]
        public bool IS_USED_IN_REPORTS { get; set; }

        /// <summary>
        /// Primary key for the LANGUAGE_ENTRY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// RESOURCE_ID of the LANGUAGE_ENTRY 
        /// </summary>
        public string? RESOURCE_ID { get; set; }
        /// <summary>
        /// DANISH_HELP of the LANGUAGE_ENTRY 
        /// </summary>
        public string? DANISH_HELP { get; set; }
        /// <summary>
        /// ENGLISH_HELP of the LANGUAGE_ENTRY 
        /// </summary>
        public string? ENGLISH_HELP { get; set; }
        /// <summary>
        /// NORWEGIAN_HELP of the LANGUAGE_ENTRY 
        /// </summary>
        public string? NORWEGIAN_HELP { get; set; }
        /// <summary>
        /// SWEDISH_HELP of the LANGUAGE_ENTRY 
        /// </summary>
        public string? SWEDISH_HELP { get; set; }
        /// <summary>
        /// FRENCH_HELP of the LANGUAGE_ENTRY 
        /// </summary>
        public string? FRENCH_HELP { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LANGUAGE_ENTRY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE_ENTRY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the LANGUAGE_ENTRY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LANGUAGE_ENTRY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// DESCRIPTION of the LANGUAGE_ENTRY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// DANISH of the LANGUAGE_ENTRY 
        /// </summary>
        public string? DANISH { get; set; }
        /// <summary>
        /// ENGLISH of the LANGUAGE_ENTRY 
        /// </summary>
        public string? ENGLISH { get; set; }
        /// <summary>
        /// NORWEGIAN of the LANGUAGE_ENTRY 
        /// </summary>
        public string? NORWEGIAN { get; set; }
        /// <summary>
        /// SWEDISH of the LANGUAGE_ENTRY 
        /// </summary>
        public string? SWEDISH { get; set; }
        /// <summary>
        /// FRENCH of the LANGUAGE_ENTRY 
        /// </summary>
        public string? FRENCH { get; set; }
        /// <summary>
        /// TYPE of the LANGUAGE_ENTRY 
        /// </summary>
        public string? TYPE { get; set; }
        /// <summary>
        /// GROUP_ID of the LANGUAGE_ENTRY 
        /// </summary>
        public string? GROUP_ID { get; set; }
    }
}