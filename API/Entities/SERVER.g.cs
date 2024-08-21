using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a server entity with essential details
    /// </summary>
    [Table("SERVER", Schema = "dbo")]
    public class SERVER
    {
        /// <summary>
        /// Initializes a new instance of the SERVER class.
        /// </summary>
        public SERVER()
        {
            IS_TEST = false;
        }

        /// <summary>
        /// Primary key for the SERVER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// WEB_VERSION of the SERVER 
        /// </summary>
        public string? WEB_VERSION { get; set; }

        /// <summary>
        /// UPGRADE_START_DATE of the SERVER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPGRADE_START_DATE { get; set; }
        /// <summary>
        /// IS_TEST of the SERVER 
        /// </summary>
        public bool? IS_TEST { get; set; }

        /// <summary>
        /// CREATION_DATE of the SERVER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// LICENSE_ID of the SERVER 
        /// </summary>
        public string? LICENSE_ID { get; set; }

        /// <summary>
        /// ALIVE_SIGNAL_DATE of the SERVER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ALIVE_SIGNAL_DATE { get; set; }
        /// <summary>
        /// LICENSE_NUMBER of the SERVER 
        /// </summary>
        public string? LICENSE_NUMBER { get; set; }
        /// <summary>
        /// DEMO_NUMBER of the SERVER 
        /// </summary>
        public string? DEMO_NUMBER { get; set; }
        /// <summary>
        /// DATABASE_VERSION of the SERVER 
        /// </summary>
        public string? DATABASE_VERSION { get; set; }
    }
}