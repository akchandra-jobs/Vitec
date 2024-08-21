using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a custom_function_x_data_owner entity with essential details
    /// </summary>
    [Table("CUSTOM_FUNCTION_X_DATA_OWNER", Schema = "dbo")]
    public class CUSTOM_FUNCTION_X_DATA_OWNER
    {
        /// <summary>
        /// Initializes a new instance of the CUSTOM_FUNCTION_X_DATA_OWNER class.
        /// </summary>
        public CUSTOM_FUNCTION_X_DATA_OWNER()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CUSTOM_FUNCTION_X_DATA_OWNER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOM_FUNCTION to which the CUSTOM_FUNCTION_X_DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_CUSTOM_FUNCTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOM_FUNCTION
        /// </summary>
        [ForeignKey("GUID_CUSTOM_FUNCTION")]
        public CUSTOM_FUNCTION? GUID_CUSTOM_FUNCTION_CUSTOM_FUNCTION { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CUSTOM_FUNCTION_X_DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// FOLDER of the CUSTOM_FUNCTION_X_DATA_OWNER 
        /// </summary>
        public string? FOLDER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CUSTOM_FUNCTION_X_DATA_OWNER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOM_FUNCTION_X_DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CUSTOM_FUNCTION_X_DATA_OWNER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CUSTOM_FUNCTION_X_DATA_OWNER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}