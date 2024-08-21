using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a productrelations entity with essential details
    /// </summary>
    [Table("ProductRelations", Schema = "Bim")]
    public class ProductRelations
    {
        /// <summary>
        /// Primary key for the ProductRelations 
        /// </summary>
        [Key]
        [Required]
        public Int64 Id { get; set; }
        /// <summary>
        /// ModelId of the ProductRelations 
        /// </summary>
        public string? ModelId { get; set; }
        /// <summary>
        /// JsonData of the ProductRelations 
        /// </summary>
        public string? JsonData { get; set; }
        /// <summary>
        /// ProjectId of the ProductRelations 
        /// </summary>
        public string? ProjectId { get; set; }
    }
}