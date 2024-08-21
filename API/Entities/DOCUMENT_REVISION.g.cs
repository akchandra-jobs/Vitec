using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a document_revision entity with essential details
    /// </summary>
    [Table("DOCUMENT_REVISION", Schema = "dbo")]
    public class DOCUMENT_REVISION
    {
        /// <summary>
        /// Initializes a new instance of the DOCUMENT_REVISION class.
        /// </summary>
        public DOCUMENT_REVISION()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOCUMENT_REVISION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOCUMENT_REVISION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT to which the DOCUMENT_REVISION belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT
        /// </summary>
        [ForeignKey("GUID_DOCUMENT")]
        public DOCUMENT? GUID_DOCUMENT_DOCUMENT { get; set; }
        /// <summary>
        /// ID of the DOCUMENT_REVISION 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// NOTE of the DOCUMENT_REVISION 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOCUMENT_REVISION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_REVISION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOCUMENT_REVISION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_REVISION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}