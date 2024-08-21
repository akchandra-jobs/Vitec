using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a entity_link entity with essential details
    /// </summary>
    [Table("ENTITY_LINK", Schema = "dbo")]
    public class ENTITY_LINK
    {
        /// <summary>
        /// Initializes a new instance of the ENTITY_LINK class.
        /// </summary>
        public ENTITY_LINK()
        {
            USE_URL_ENCODING = false;
            INDEX_POSITION = 0;
            ENTITY_TYPE = -1;
            TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ENTITY_LINK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field USE_URL_ENCODING of the ENTITY_LINK 
        /// </summary>
        [Required]
        public bool USE_URL_ENCODING { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the ENTITY_LINK 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the ENTITY_LINK 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field TYPE of the ENTITY_LINK 
        /// </summary>
        [Required]
        public int TYPE { get; set; }
        /// <summary>
        /// HTTP_HEADERS of the ENTITY_LINK 
        /// </summary>
        public string? HTTP_HEADERS { get; set; }
        /// <summary>
        /// ACTION_RULE of the ENTITY_LINK 
        /// </summary>
        public string? ACTION_RULE { get; set; }
        /// <summary>
        /// URL of the ENTITY_LINK 
        /// </summary>
        public string? URL { get; set; }
        /// <summary>
        /// FILTER of the ENTITY_LINK 
        /// </summary>
        public string? FILTER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENTITY_LINK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_LINK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENTITY_LINK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENTITY_LINK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENTITY_LINK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// NAME of the ENTITY_LINK 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENTITY_LINK 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}