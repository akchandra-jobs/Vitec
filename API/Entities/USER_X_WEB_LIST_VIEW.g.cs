using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user_x_web_list_view entity with essential details
    /// </summary>
    [Table("USER_X_WEB_LIST_VIEW", Schema = "dbo")]
    public class USER_X_WEB_LIST_VIEW
    {
        /// <summary>
        /// Initializes a new instance of the USER_X_WEB_LIST_VIEW class.
        /// </summary>
        public USER_X_WEB_LIST_VIEW()
        {
            ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USER_X_WEB_LIST_VIEW 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the USER_X_WEB_LIST_VIEW 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USER_X_WEB_LIST_VIEW 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USER_X_WEB_LIST_VIEW 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the USER_X_WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the WEB_LIST_VIEW to which the USER_X_WEB_LIST_VIEW belongs 
        /// </summary>
        public Guid? GUID_WEB_LIST_VIEW { get; set; }

        /// <summary>
        /// Navigation property representing the associated WEB_LIST_VIEW
        /// </summary>
        [ForeignKey("GUID_WEB_LIST_VIEW")]
        public WEB_LIST_VIEW? GUID_WEB_LIST_VIEW_WEB_LIST_VIEW { get; set; }
    }
}