using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a building_selection entity with essential details
    /// </summary>
    [Table("BUILDING_SELECTION", Schema = "dbo")]
    public class BUILDING_SELECTION
    {
        /// <summary>
        /// Initializes a new instance of the BUILDING_SELECTION class.
        /// </summary>
        public BUILDING_SELECTION()
        {
            IS_SESSION_ONLY = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field IS_SESSION_ONLY of the BUILDING_SELECTION 
        /// </summary>
        [Required]
        public bool IS_SESSION_ONLY { get; set; }

        /// <summary>
        /// Primary key for the BUILDING_SELECTION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the BUILDING_SELECTION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the BUILDING_SELECTION 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the BUILDING_SELECTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING_SELECTION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the BUILDING_SELECTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING_SELECTION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}