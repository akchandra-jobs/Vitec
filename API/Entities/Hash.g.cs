using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a hash entity with essential details
    /// </summary>
    [Table("Hash", Schema = "HangFire")]
    public class Hash
    {
        /// <summary>
        /// Primary key for the Hash 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required field Key of the Hash 
        /// </summary>
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Required field Field of the Hash 
        /// </summary>
        [Required]
        public string Field { get; set; }
        /// <summary>
        /// Value of the Hash 
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// ExpireAt of the Hash 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpireAt { get; set; }
    }
}