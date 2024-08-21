using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a log_performance entity with essential details
    /// </summary>
    [Table("LOG_PERFORMANCE", Schema = "dbo")]
    public class LOG_PERFORMANCE
    {
        /// <summary>
        /// Initializes a new instance of the LOG_PERFORMANCE class.
        /// </summary>
        public LOG_PERFORMANCE()
        {
            TOTAL_CALLS = 0;
            TOTAL_ELAPSED_TIME = 0;
            LONGEST_ELAPSED_TIME = 0;
            SHORTEST_ELAPSED_TIME = 0;
            AVERAGE_ELAPSED_TIME = 0;
            TOTAL_EXCEPTIONS_THROWN = 0;
        }

        /// <summary>
        /// Required field ID of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public string ID { get; set; }

        /// <summary>
        /// Required field API_VERSION of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public string API_VERSION { get; set; }

        /// <summary>
        /// Required field TOTAL_CALLS of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public int TOTAL_CALLS { get; set; }

        /// <summary>
        /// Required field TOTAL_ELAPSED_TIME of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public Int64 TOTAL_ELAPSED_TIME { get; set; }

        /// <summary>
        /// Required field LONGEST_ELAPSED_TIME of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public int LONGEST_ELAPSED_TIME { get; set; }

        /// <summary>
        /// Required field SHORTEST_ELAPSED_TIME of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public int SHORTEST_ELAPSED_TIME { get; set; }

        /// <summary>
        /// Required field AVERAGE_ELAPSED_TIME of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public int AVERAGE_ELAPSED_TIME { get; set; }

        /// <summary>
        /// Required field TOTAL_EXCEPTIONS_THROWN of the LOG_PERFORMANCE 
        /// </summary>
        [Required]
        public int TOTAL_EXCEPTIONS_THROWN { get; set; }

        /// <summary>
        /// Primary key for the LOG_PERFORMANCE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// GUID_API_CLIENT of the LOG_PERFORMANCE 
        /// </summary>
        public Guid? GUID_API_CLIENT { get; set; }
    }
}