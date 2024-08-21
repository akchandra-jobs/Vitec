using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a counter entity with essential details
    /// </summary>
    [Table("Counter", Schema = "HangFire")]
    public class Counter
    {
        /// <summary>
        /// Primary key for the Counter 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required field Key of the Counter 
        /// </summary>
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Required field Value of the Counter 
        /// </summary>
        [Required]
        public short Value { get; set; }

        /// <summary>
        /// ExpireAt of the Counter 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpireAt { get; set; }
    }
}