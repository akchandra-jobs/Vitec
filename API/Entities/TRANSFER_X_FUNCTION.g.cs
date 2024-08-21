using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a transfer_x_function entity with essential details
    /// </summary>
    [Table("TRANSFER_X_FUNCTION", Schema = "dbo")]
    public class TRANSFER_X_FUNCTION
    {
        /// <summary>
        /// Initializes a new instance of the TRANSFER_X_FUNCTION class.
        /// </summary>
        public TRANSFER_X_FUNCTION()
        {
            IS_TRANSFERRED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field IS_TRANSFERRED of the TRANSFER_X_FUNCTION 
        /// </summary>
        [Required]
        public bool IS_TRANSFERRED { get; set; }

        /// <summary>
        /// Primary key for the TRANSFER_X_FUNCTION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the TRANSFER_X_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the TRANSFER to which the TRANSFER_X_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_TRANSFER { get; set; }

        /// <summary>
        /// Navigation property representing the associated TRANSFER
        /// </summary>
        [ForeignKey("GUID_TRANSFER")]
        public TRANSFER? GUID_TRANSFER_TRANSFER { get; set; }
        /// <summary>
        /// FILENAME of the TRANSFER_X_FUNCTION 
        /// </summary>
        public string? FILENAME { get; set; }

        /// <summary>
        /// GENERATED_DATE of the TRANSFER_X_FUNCTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? GENERATED_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the TRANSFER_X_FUNCTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TRANSFER_X_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the TRANSFER_X_FUNCTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TRANSFER_X_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TRANSFER_X_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_USER_GENERATED { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_GENERATED")]
        public USR? GUID_USER_GENERATED_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOM_FUNCTION to which the TRANSFER_X_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_CUSTOM_FUNCTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOM_FUNCTION
        /// </summary>
        [ForeignKey("GUID_CUSTOM_FUNCTION")]
        public CUSTOM_FUNCTION? GUID_CUSTOM_FUNCTION_CUSTOM_FUNCTION { get; set; }
        /// <summary>
        /// Foreign key referencing the INTEGRATION_DATA to which the TRANSFER_X_FUNCTION belongs 
        /// </summary>
        public Guid? GUID_INTEGRATION_DATA { get; set; }

        /// <summary>
        /// Navigation property representing the associated INTEGRATION_DATA
        /// </summary>
        [ForeignKey("GUID_INTEGRATION_DATA")]
        public INTEGRATION_DATA? GUID_INTEGRATION_DATA_INTEGRATION_DATA { get; set; }
    }
}