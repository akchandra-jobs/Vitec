using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a jobparameter entity with essential details
    /// </summary>
    [Table("JobParameter", Schema = "HangFire")]
    public class JobParameter
    {
        /// <summary>
        /// Primary key for the JobParameter 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Foreign key referencing the Job to which the JobParameter belongs 
        /// </summary>
        [Required]
        public int JobId { get; set; }

        /// <summary>
        /// Navigation property representing the associated Job
        /// </summary>
        [ForeignKey("JobId")]
        public Job? JobId_Job { get; set; }

        /// <summary>
        /// Required field Name of the JobParameter 
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Value of the JobParameter 
        /// </summary>
        public string? Value { get; set; }
    }
}