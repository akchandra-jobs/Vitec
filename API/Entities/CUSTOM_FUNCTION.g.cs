using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a custom_function entity with essential details
    /// </summary>
    [Table("CUSTOM_FUNCTION", Schema = "dbo")]
    public class CUSTOM_FUNCTION
    {
        /// <summary>
        /// Initializes a new instance of the CUSTOM_FUNCTION class.
        /// </summary>
        public CUSTOM_FUNCTION()
        {
            TYPE = -1;
            CUSTOMER_ID = -1;
            SERVICE_TYPE = -1;
            IS_ACTIVE = false;
            IS_RUN_BY_SERVICE = false;
            ID = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field TYPE of the CUSTOM_FUNCTION 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field CUSTOMER_ID of the CUSTOM_FUNCTION 
        /// </summary>
        [Required]
        public int CUSTOMER_ID { get; set; }

        /// <summary>
        /// Required field SERVICE_TYPE of the CUSTOM_FUNCTION 
        /// </summary>
        [Required]
        public int SERVICE_TYPE { get; set; }

        /// <summary>
        /// Required field IS_ACTIVE of the CUSTOM_FUNCTION 
        /// </summary>
        [Required]
        public bool IS_ACTIVE { get; set; }

        /// <summary>
        /// Required field IS_RUN_BY_SERVICE of the CUSTOM_FUNCTION 
        /// </summary>
        [Required]
        public bool IS_RUN_BY_SERVICE { get; set; }

        /// <summary>
        /// Primary key for the CUSTOM_FUNCTION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the CUSTOM_FUNCTION 
        /// </summary>
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the CUSTOM_FUNCTION 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// FOLDER of the CUSTOM_FUNCTION 
        /// </summary>
        public string? FOLDER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CUSTOM_FUNCTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOM_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CUSTOM_FUNCTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOM_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}