using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a set entity with essential details
    /// </summary>
    [Table("Set", Schema = "HangFire")]
    public class Set
    {
        /// <summary>
        /// Primary key for the Set 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required field Key of the Set 
        /// </summary>
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Required field Score of the Set 
        /// </summary>
        [Required]
        public double Score { get; set; }

        /// <summary>
        /// Required field Value of the Set 
        /// </summary>
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// ExpireAt of the Set 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpireAt { get; set; }
    }
}