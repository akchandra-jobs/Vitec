using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_profile_x_web_menu entity with essential details
    /// </summary>
    [Table("WEB_PROFILE_X_WEB_MENU", Schema = "dbo")]
    public class WEB_PROFILE_X_WEB_MENU
    {
        /// <summary>
        /// Initializes a new instance of the WEB_PROFILE_X_WEB_MENU class.
        /// </summary>
        public WEB_PROFILE_X_WEB_MENU()
        {
            INDEX_POSITION = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field INDEX_POSITION of the WEB_PROFILE_X_WEB_MENU 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }

        /// <summary>
        /// Primary key for the WEB_PROFILE_X_WEB_MENU 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the WEB_MENU to which the WEB_PROFILE_X_WEB_MENU belongs 
        /// </summary>
        public Guid? GUID_WEB_MENU { get; set; }

        /// <summary>
        /// Navigation property representing the associated WEB_MENU
        /// </summary>
        [ForeignKey("GUID_WEB_MENU")]
        public WEB_MENU? GUID_WEB_MENU_WEB_MENU { get; set; }
        /// <summary>
        /// Foreign key referencing the WEB_PROFILE to which the WEB_PROFILE_X_WEB_MENU belongs 
        /// </summary>
        public Guid? GUID_WEB_PROFILE { get; set; }

        /// <summary>
        /// Navigation property representing the associated WEB_PROFILE
        /// </summary>
        [ForeignKey("GUID_WEB_PROFILE")]
        public WEB_PROFILE? GUID_WEB_PROFILE_WEB_PROFILE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_PROFILE_X_WEB_MENU 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_PROFILE_X_WEB_MENU belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_PROFILE_X_WEB_MENU 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_PROFILE_X_WEB_MENU belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}