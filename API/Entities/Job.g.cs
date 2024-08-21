using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a job entity with essential details
    /// </summary>
    [Table("Job", Schema = "HangFire")]
    public class Job
    {
        /// <summary>
        /// Required field InvocationData of the Job 
        /// </summary>
        [Required]
        public string InvocationData { get; set; }

        /// <summary>
        /// Required field Arguments of the Job 
        /// </summary>
        [Required]
        public string Arguments { get; set; }

        /// <summary>
        /// Required field CreatedAt of the Job 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Primary key for the Job 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// StateId of the Job 
        /// </summary>
        public int? StateId { get; set; }
        /// <summary>
        /// StateName of the Job 
        /// </summary>
        public string? StateName { get; set; }

        /// <summary>
        /// ExpireAt of the Job 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpireAt { get; set; }
    }
}