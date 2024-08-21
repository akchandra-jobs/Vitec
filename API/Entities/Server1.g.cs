using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a server1 entity with essential details
    /// </summary>
    [Table("Server1", Schema = "HangFire")]
    public class Server1
    {
        /// <summary>
        /// Primary key for the Server1 
        /// </summary>
        [Key]
        [Required]
        public string Id { get; set; }

        /// <summary>
        /// Required field LastHeartbeat of the Server1 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime LastHeartbeat { get; set; }
        /// <summary>
        /// Data of the Server1 
        /// </summary>
        public string? Data { get; set; }
    }
}