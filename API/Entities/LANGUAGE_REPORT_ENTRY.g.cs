using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a language_report_entry entity with essential details
    /// </summary>
    [Table("LANGUAGE_REPORT_ENTRY", Schema = "dbo")]
    public class LANGUAGE_REPORT_ENTRY
    {
        /// <summary>
        /// Primary key for the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        [Key]
        [Required]
        public string GUID { get; set; }
        /// <summary>
        /// ID of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DANISH of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? DANISH { get; set; }
        /// <summary>
        /// ENGLISH of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? ENGLISH { get; set; }
        /// <summary>
        /// NORWEGIAN of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? NORWEGIAN { get; set; }
        /// <summary>
        /// SWEDISH of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? SWEDISH { get; set; }
        /// <summary>
        /// FRENCH of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? FRENCH { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// GUID_USER_UPDATED_BY of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// CREATION_DATE of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// GUID_USER_CREATED_BY of the LANGUAGE_REPORT_ENTRY 
        /// </summary>
        public string? GUID_USER_CREATED_BY { get; set; }
    }
}