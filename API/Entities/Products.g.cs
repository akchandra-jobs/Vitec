using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a products entity with essential details
    /// </summary>
    [Table("Products", Schema = "Bim")]
    public class Products
    {
        /// <summary>
        /// Primary key for the Products 
        /// </summary>
        [Key]
        [Required]
        public Int64 Id { get; set; }
        /// <summary>
        /// ModelId of the Products 
        /// </summary>
        public string? ModelId { get; set; }
        /// <summary>
        /// JsonData of the Products 
        /// </summary>
        public string? JsonData { get; set; }
        /// <summary>
        /// ProjectId of the Products 
        /// </summary>
        public string? ProjectId { get; set; }
        /// <summary>
        /// ObjectId of the Products 
        /// </summary>
        public Int64? ObjectId { get; set; }
        /// <summary>
        /// IfcType of the Products 
        /// </summary>
        public string? IfcType { get; set; }
    }
}