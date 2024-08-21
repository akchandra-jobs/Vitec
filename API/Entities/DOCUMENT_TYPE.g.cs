using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a document_type entity with essential details
    /// </summary>
    [Table("DOCUMENT_TYPE", Schema = "dbo")]
    public class DOCUMENT_TYPE
    {
        /// <summary>
        /// Initializes a new instance of the DOCUMENT_TYPE class.
        /// </summary>
        public DOCUMENT_TYPE()
        {
            UPDATE_FROM_DATABASE = false;
            IS_UNIQUE_FOR_XREF = false;
            IS_DOCUMENT_TEMPLATE = false;
            DO_NOT_SAVE_IN_DATABASE = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field UPDATE_FROM_DATABASE of the DOCUMENT_TYPE 
        /// </summary>
        [Required]
        public bool UPDATE_FROM_DATABASE { get; set; }

        /// <summary>
        /// Required field IS_UNIQUE_FOR_XREF of the DOCUMENT_TYPE 
        /// </summary>
        [Required]
        public bool IS_UNIQUE_FOR_XREF { get; set; }

        /// <summary>
        /// Required field IS_DOCUMENT_TEMPLATE of the DOCUMENT_TYPE 
        /// </summary>
        [Required]
        public bool IS_DOCUMENT_TEMPLATE { get; set; }

        /// <summary>
        /// Required field DO_NOT_SAVE_IN_DATABASE of the DOCUMENT_TYPE 
        /// </summary>
        [Required]
        public bool DO_NOT_SAVE_IN_DATABASE { get; set; }

        /// <summary>
        /// Primary key for the DOCUMENT_TYPE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOCUMENT_TYPE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the DOCUMENT_TYPE 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOCUMENT_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOCUMENT_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}