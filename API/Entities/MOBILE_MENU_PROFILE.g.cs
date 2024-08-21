using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a mobile_menu_profile entity with essential details
    /// </summary>
    [Table("MOBILE_MENU_PROFILE", Schema = "dbo")]
    public class MOBILE_MENU_PROFILE
    {
        /// <summary>
        /// Initializes a new instance of the MOBILE_MENU_PROFILE class.
        /// </summary>
        public MOBILE_MENU_PROFILE()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the MOBILE_MENU_PROFILE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// ID of the MOBILE_MENU_PROFILE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the MOBILE_MENU_PROFILE 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the MOBILE_MENU_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the MOBILE_MENU_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the MOBILE_MENU_PROFILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the MOBILE_MENU_PROFILE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// TAB_LIST of the MOBILE_MENU_PROFILE 
        /// </summary>
        public string? TAB_LIST { get; set; }
        /// <summary>
        /// ACTIVITY_MENU_LIST of the MOBILE_MENU_PROFILE 
        /// </summary>
        public string? ACTIVITY_MENU_LIST { get; set; }
    }
}