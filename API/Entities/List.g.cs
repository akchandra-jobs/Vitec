using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a list entity with essential details
    /// </summary>
    [Table("List", Schema = "HangFire")]
    public class List
    {
        /// <summary>
        /// Primary key for the List 
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required field Key of the List 
        /// </summary>
        [Required]
        public string Key { get; set; }
        /// <summary>
        /// Value of the List 
        /// </summary>
        public string? Value { get; set; }

        /// <summary>
        /// ExpireAt of the List 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ExpireAt { get; set; }
    }
}