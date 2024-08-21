using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a web_menu entity with essential details
    /// </summary>
    [Table("WEB_MENU", Schema = "dbo")]
    public class WEB_MENU
    {
        /// <summary>
        /// Initializes a new instance of the WEB_MENU class.
        /// </summary>
        public WEB_MENU()
        {
            ID = 0;
            IS_BUILDING_DEPENDENT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the WEB_MENU 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the WEB_MENU 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field IS_BUILDING_DEPENDENT of the WEB_MENU 
        /// </summary>
        [Required]
        public bool IS_BUILDING_DEPENDENT { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the WEB_MENU 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WEB_MENU 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_MENU belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WEB_MENU 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WEB_MENU belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// NAME of the WEB_MENU 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// DESCRIPTION of the WEB_MENU 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// TYPE of the WEB_MENU 
        /// </summary>
        public string? TYPE { get; set; }
        /// <summary>
        /// CONTEXT of the WEB_MENU 
        /// </summary>
        public string? CONTEXT { get; set; }
        /// <summary>
        /// REFERENCE of the WEB_MENU 
        /// </summary>
        public string? REFERENCE { get; set; }
    }
}