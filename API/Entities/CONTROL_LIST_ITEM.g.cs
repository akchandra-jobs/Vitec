using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a control_list_item entity with essential details
    /// </summary>
    [Table("CONTROL_LIST_ITEM", Schema = "dbo")]
    public class CONTROL_LIST_ITEM
    {
        /// <summary>
        /// Initializes a new instance of the CONTROL_LIST_ITEM class.
        /// </summary>
        public CONTROL_LIST_ITEM()
        {
            TYPE = -1;
            IS_MANDATORY = false;
            INDEX_POSITION = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field TYPE of the CONTROL_LIST_ITEM 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field IS_MANDATORY of the CONTROL_LIST_ITEM 
        /// </summary>
        [Required]
        public bool IS_MANDATORY { get; set; }

        /// <summary>
        /// Primary key for the CONTROL_LIST_ITEM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INDEX_POSITION of the CONTROL_LIST_ITEM 
        /// </summary>
        [Required]
        public int INDEX_POSITION { get; set; }
        /// <summary>
        /// NAME of the CONTROL_LIST_ITEM 
        /// </summary>
        public string? NAME { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTROL_LIST_ITEM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST to which the CONTROL_LIST_ITEM belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST")]
        public CONTROL_LIST? GUID_CONTROL_LIST_CONTROL_LIST { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST_ITEM to which the CONTROL_LIST_ITEM belongs 
        /// </summary>
        public Guid? GUID_PARENT_CONTROL_LIST_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST_ITEM
        /// </summary>
        [ForeignKey("GUID_PARENT_CONTROL_LIST_ITEM")]
        public CONTROL_LIST_ITEM? GUID_PARENT_CONTROL_LIST_ITEM_CONTROL_LIST_ITEM { get; set; }
        /// <summary>
        /// DATA of the CONTROL_LIST_ITEM 
        /// </summary>
        public string? DATA { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTROL_LIST_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTROL_LIST_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST_LOG_ITEM to which the CONTROL_LIST_ITEM belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST_LOG_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST_LOG_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST_LOG_ITEM")]
        public CONTROL_LIST_LOG_ITEM? GUID_CONTROL_LIST_LOG_ITEM_CONTROL_LIST_LOG_ITEM { get; set; }
    }
}