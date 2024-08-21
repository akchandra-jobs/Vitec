using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a state entity with essential details
    /// </summary>
    [Table("State", Schema = "HangFire")]
    public class State
    {
        /// <summary>
        /// Primary key for the State 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Job to which the State belongs 
        /// </summary>
        [Required]
        public int JobId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Job
        /// </summary>
        [ForeignKey("JobId")]
        public Job? JobId_Job { get; set; }

        /// <summary>
        /// Required field Name of the State 
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Required field CreatedAt of the State 
        /// </summary>
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Data of the State 
        /// </summary>
        public string? Data { get; set; }
        /// <summary>
        /// Reason of the State 
        /// </summary>
        public string? Reason { get; set; }
    }
}