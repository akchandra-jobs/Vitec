using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a schema entity with essential details
    /// </summary>
    [Table("Schema", Schema = "HangFire")]
    public class Schema
    {
        /// <summary>
        /// Primary key for the Schema 
        /// </summary>
        [Key]
        [Required]
        public int Version { get; set; }
    }
}