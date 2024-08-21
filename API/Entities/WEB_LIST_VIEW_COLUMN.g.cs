using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_list_view_column entity with essential details
    /// </summary>
    [Table("WEB_LIST_VIEW_COLUMN", Schema = "dbo")]
    public class WEB_LIST_VIEW_COLUMN
    {
        /// <summary>
        /// Initializes a new instance of the WEB_LIST_VIEW_COLUMN class.
        /// </summary>
        public WEB_LIST_VIEW_COLUMN()
        {
            POSITION = 0;
            IS_HIDDEN = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field POSITION of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        [Required]
        public int POSITION { get; set; }

        /// <summary>
        /// Primary key for the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_HIDDEN of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        [Required]
        public bool IS_HIDDEN { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WEB_LIST_VIEW_COLUMN belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WEB_LIST_VIEW to which the WEB_LIST_VIEW_COLUMN belongs 
        /// </summary>
        public Guid? GUID_WEB_LIST_VIEW { get; set; }

        /// <summary>
        /// Navigation property representing the associated WEB_LIST_VIEW
        /// </summary>
        [ForeignKey("GUID_WEB_LIST_VIEW")]
        public WEB_LIST_VIEW? GUID_WEB_LIST_VIEW_WEB_LIST_VIEW { get; set; }
        /// <summary>
        /// TITLE of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        public string? TITLE { get; set; }
        /// <summary>
        /// PROPERTY of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        public string? PROPERTY { get; set; }
        /// <summary>
        /// PROPERTY_TYPE of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        public string? PROPERTY_TYPE { get; set; }
        /// <summary>
        /// AUTOCOMPLETE_SERVICE of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        public string? AUTOCOMPLETE_SERVICE { get; set; }
        /// <summary>
        /// AUTOCOMPLETE_PROPERTY of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        public string? AUTOCOMPLETE_PROPERTY { get; set; }
        /// <summary>
        /// FILTER of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        public string? FILTER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_LIST_VIEW_COLUMN belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_LIST_VIEW_COLUMN 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_LIST_VIEW_COLUMN belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}