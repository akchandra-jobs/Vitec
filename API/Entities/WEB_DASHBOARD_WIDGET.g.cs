using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_dashboard_widget entity with essential details
    /// </summary>
    [Table("WEB_DASHBOARD_WIDGET", Schema = "dbo")]
    public class WEB_DASHBOARD_WIDGET
    {
        /// <summary>
        /// Initializes a new instance of the WEB_DASHBOARD_WIDGET class.
        /// </summary>
        public WEB_DASHBOARD_WIDGET()
        {
            GRID_POSITION_X = 0;
            GRID_POSITION_Y = 0;
            GRID_WIDTH = 0;
            GRID_HEIGHT = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field GRID_POSITION_X of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        [Required]
        public int GRID_POSITION_X { get; set; }

        /// <summary>
        /// Required field GRID_POSITION_Y of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        [Required]
        public int GRID_POSITION_Y { get; set; }

        /// <summary>
        /// Required field GRID_WIDTH of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        [Required]
        public int GRID_WIDTH { get; set; }

        /// <summary>
        /// Required field GRID_HEIGHT of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        [Required]
        public int GRID_HEIGHT { get; set; }

        /// <summary>
        /// Primary key for the WEB_DASHBOARD_WIDGET 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WEB_DASHBOARD_WIDGET belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WEB_DASHBOARD to which the WEB_DASHBOARD_WIDGET belongs 
        /// </summary>
        public Guid? GUID_WEB_DASHBOARD { get; set; }

        /// <summary>
        /// Navigation property representing the associated WEB_DASHBOARD
        /// </summary>
        [ForeignKey("GUID_WEB_DASHBOARD")]
        public WEB_DASHBOARD? GUID_WEB_DASHBOARD_WEB_DASHBOARD { get; set; }
        /// <summary>
        /// ID of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// WIDGET_TYPE of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        public string? WIDGET_TYPE { get; set; }
        /// <summary>
        /// WIDGET_DATA of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        public string? WIDGET_DATA { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_DASHBOARD_WIDGET belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_DASHBOARD_WIDGET 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_DASHBOARD_WIDGET belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}