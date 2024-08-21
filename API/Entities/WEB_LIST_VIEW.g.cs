using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_list_view entity with essential details
    /// </summary>
    [Table("WEB_LIST_VIEW", Schema = "dbo")]
    public class WEB_LIST_VIEW
    {
        /// <summary>
        /// Initializes a new instance of the WEB_LIST_VIEW class.
        /// </summary>
        public WEB_LIST_VIEW()
        {
            ENTITY_TYPE = -1;
            IS_PUBLIC_VIEW = false;
            IS_SYSTEM_STANDARD = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the WEB_LIST_VIEW 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field IS_PUBLIC_VIEW of the WEB_LIST_VIEW 
        /// </summary>
        [Required]
        public bool IS_PUBLIC_VIEW { get; set; }

        /// <summary>
        /// Primary key for the WEB_LIST_VIEW 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_SYSTEM_STANDARD of the WEB_LIST_VIEW 
        /// </summary>
        [Required]
        public bool IS_SYSTEM_STANDARD { get; set; }
        /// <summary>
        /// USER_FILTER of the WEB_LIST_VIEW 
        /// </summary>
        public string? USER_FILTER { get; set; }
        /// <summary>
        /// ADMIN_FILTER of the WEB_LIST_VIEW 
        /// </summary>
        public string? ADMIN_FILTER { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// ID of the WEB_LIST_VIEW 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_LIST_VIEW 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_LIST_VIEW 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// SORTING of the WEB_LIST_VIEW 
        /// </summary>
        public string? SORTING { get; set; }
        /// <summary>
        /// GROUP_BY of the WEB_LIST_VIEW 
        /// </summary>
        public string? GROUP_BY { get; set; }
        /// <summary>
        /// CONTEXT_ID of the WEB_LIST_VIEW 
        /// </summary>
        public string? CONTEXT_ID { get; set; }
    }
}