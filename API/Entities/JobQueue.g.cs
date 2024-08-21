using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a jobqueue entity with essential details
    /// </summary>
    [Table("JobQueue", Schema = "HangFire")]
    public class JobQueue
    {
        /// <summary>
        /// Primary key for the JobQueue 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required field JobId of the JobQueue 
        /// </summary>
        [Required]
        public int JobId { get; set; }

        /// <summary>
        /// Required field Queue of the JobQueue 
        /// </summary>
        [Required]
        public string Queue { get; set; }

        /// <summary>
        /// FetchedAt of the JobQueue 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? FetchedAt { get; set; }
    }
}