using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a list_layout entity with essential details
    /// </summary>
    [Table("LIST_LAYOUT", Schema = "dbo")]
    public class LIST_LAYOUT
    {
        /// <summary>
        /// Initializes a new instance of the LIST_LAYOUT class.
        /// </summary>
        public LIST_LAYOUT()
        {
            HEADER_SIZE = 0;
            HEADER_WEIGHT = false;
            HEADER_CONTROL_SIZE = 0;
            HEADER_CONTROL_WEIGHT = false;
            GROUP_HEADER_SIZE = 0;
            GROUP_HEADER_WEIGHT = false;
            FOOTER_SIZE = 0;
            FOOTER_WEIGHT = false;
            DATA_SIZE = 0;
            DATA_WEIGHT = false;
            HEADING_SIZE = 0;
            HEADING_WEIGHT = false;
            ORIENTATION = 0;
            COLOR = 0;
            HAS_GRID = false;
            IS_GROUPED = false;
            HAS_FIXED_COLUMN_WIDTHS = false;
            SHARING_TYPE = -1;
            IS_REPORT = false;
            ENTITY_TYPE = -1;
            CONTEXT_TYPE = -1;
            IS_HISTORY = -1;
            HAS_SELECT_BOX = false;
            NUMBER_OF_TIMES_USED = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field HEADER_SIZE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int HEADER_SIZE { get; set; }

        /// <summary>
        /// Required field HEADER_WEIGHT of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool HEADER_WEIGHT { get; set; }

        /// <summary>
        /// Required field HEADER_CONTROL_SIZE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int HEADER_CONTROL_SIZE { get; set; }

        /// <summary>
        /// Required field HEADER_CONTROL_WEIGHT of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool HEADER_CONTROL_WEIGHT { get; set; }

        /// <summary>
        /// Required field GROUP_HEADER_SIZE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int GROUP_HEADER_SIZE { get; set; }

        /// <summary>
        /// Required field GROUP_HEADER_WEIGHT of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool GROUP_HEADER_WEIGHT { get; set; }

        /// <summary>
        /// Required field FOOTER_SIZE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int FOOTER_SIZE { get; set; }

        /// <summary>
        /// Required field FOOTER_WEIGHT of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool FOOTER_WEIGHT { get; set; }

        /// <summary>
        /// Required field DATA_SIZE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int DATA_SIZE { get; set; }

        /// <summary>
        /// Required field DATA_WEIGHT of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool DATA_WEIGHT { get; set; }

        /// <summary>
        /// Required field HEADING_SIZE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int HEADING_SIZE { get; set; }

        /// <summary>
        /// Required field HEADING_WEIGHT of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool HEADING_WEIGHT { get; set; }

        /// <summary>
        /// Required field ORIENTATION of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int ORIENTATION { get; set; }

        /// <summary>
        /// Required field COLOR of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int COLOR { get; set; }

        /// <summary>
        /// Required field HAS_GRID of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool HAS_GRID { get; set; }

        /// <summary>
        /// Required field IS_GROUPED of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool IS_GROUPED { get; set; }

        /// <summary>
        /// Required field HAS_FIXED_COLUMN_WIDTHS of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool HAS_FIXED_COLUMN_WIDTHS { get; set; }

        /// <summary>
        /// Primary key for the LIST_LAYOUT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field SHARING_TYPE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int SHARING_TYPE { get; set; }

        /// <summary>
        /// Required field IS_REPORT of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool IS_REPORT { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field CONTEXT_TYPE of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int CONTEXT_TYPE { get; set; }

        /// <summary>
        /// Required field IS_HISTORY of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int IS_HISTORY { get; set; }

        /// <summary>
        /// Required field HAS_SELECT_BOX of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public bool HAS_SELECT_BOX { get; set; }

        /// <summary>
        /// Required field NUMBER_OF_TIMES_USED of the LIST_LAYOUT 
        /// </summary>
        [Required]
        public int NUMBER_OF_TIMES_USED { get; set; }
        /// <summary>
        /// PRINT_FONT of the LIST_LAYOUT 
        /// </summary>
        public string? PRINT_FONT { get; set; }
        /// <summary>
        /// BINARY_DATA of the LIST_LAYOUT 
        /// </summary>
        public byte[]? BINARY_DATA { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the LIST_LAYOUT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LIST_LAYOUT belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }
        /// <summary>
        /// ID of the LIST_LAYOUT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the LIST_LAYOUT 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the LIST_LAYOUT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LIST_LAYOUT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the LIST_LAYOUT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the LIST_LAYOUT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }

        /// <summary>
        /// LAST_USED_DATE of the LIST_LAYOUT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? LAST_USED_DATE { get; set; }
    }
}