using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a two_factor_token entity with essential details
    /// </summary>
    [Table("TWO_FACTOR_TOKEN", Schema = "dbo")]
    public class TWO_FACTOR_TOKEN
    {
        /// <summary>
        /// Initializes a new instance of the TWO_FACTOR_TOKEN class.
        /// </summary>
        public TWO_FACTOR_TOKEN()
        {
            NUMBER_OF_ATTEMPTS = 0;
            STATUS = -1;
            IS_SENT_TO_HOME = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field NUMBER_OF_ATTEMPTS of the TWO_FACTOR_TOKEN 
        /// </summary>
        [Required]
        public int NUMBER_OF_ATTEMPTS { get; set; }

        /// <summary>
        /// Required field STATUS of the TWO_FACTOR_TOKEN 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Primary key for the TWO_FACTOR_TOKEN 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_SENT_TO_HOME of the TWO_FACTOR_TOKEN 
        /// </summary>
        [Required]
        public bool IS_SENT_TO_HOME { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TWO_FACTOR_TOKEN belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// ID of the TWO_FACTOR_TOKEN 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// TOKEN of the TWO_FACTOR_TOKEN 
        /// </summary>
        public string? TOKEN { get; set; }
        /// <summary>
        /// DEVICE_FINGERPRINT of the TWO_FACTOR_TOKEN 
        /// </summary>
        public string? DEVICE_FINGERPRINT { get; set; }
        /// <summary>
        /// PHONE_NUMBER of the TWO_FACTOR_TOKEN 
        /// </summary>
        public string? PHONE_NUMBER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the TWO_FACTOR_TOKEN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TWO_FACTOR_TOKEN belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the TWO_FACTOR_TOKEN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TWO_FACTOR_TOKEN belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}