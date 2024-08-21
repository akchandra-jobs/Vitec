using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_type_info entity with essential details
    /// </summary>
    [Table("ENTITY_TYPE_INFO", Schema = "dbo")]
    public class ENTITY_TYPE_INFO
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_TYPE_INFO class.
        /// </summary>
        public ENTITY_TYPE_INFO()
        {
            TYPE = -1;
            MODULE = -1;
            INDEX_POSITION = 0;
        }

        /// <summary>
        /// Required field TYPE of the ENTITY_TYPE_INFO 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Primary key for the ENTITY_TYPE_INFO 
        /// </summary>
        [Key]
        [Required]
        public Int64 MODULE { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the ENTITY_TYPE_INFO 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }
    }
}