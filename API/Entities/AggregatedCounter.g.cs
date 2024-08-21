using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a aggregatedcounter entity with essential details
    /// </summary>
    [Table("AggregatedCounter", Schema = "HangFire")]
    public class AggregatedCounter
    {
        /// <summary>
        /// Primary key for the AggregatedCounter 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required field Key of the AggregatedCounter 
        /// </summary>
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Required field Value of the AggregatedCounter 
        /// </summary>
        [Required]
        public Int64 Value { get; set; }

        /// <summary>
        /// ExpireAt of the AggregatedCounter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpireAt { get; set; }
    }
}