using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a daily_update_log entity with essential details
    /// </summary>
    [Table("DAILY_UPDATE_LOG", Schema = "dbo")]
    public class DAILY_UPDATE_LOG
    {
        /// <summary>
        /// Initializes a new instance of the DAILY_UPDATE_LOG class.
        /// </summary>
        public DAILY_UPDATE_LOG()
        {
            ID = 0;
        }

        /// <summary>
        /// Primary key for the DAILY_UPDATE_LOG 
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// START_DATE of the DAILY_UPDATE_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the DAILY_UPDATE_LOG 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
    }
}