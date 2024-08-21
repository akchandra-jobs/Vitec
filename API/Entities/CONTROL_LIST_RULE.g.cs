using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a control_list_rule entity with essential details
    /// </summary>
    [Table("CONTROL_LIST_RULE", Schema = "dbo")]
    public class CONTROL_LIST_RULE
    {
        /// <summary>
        /// Initializes a new instance of the CONTROL_LIST_RULE class.
        /// </summary>
        public CONTROL_LIST_RULE()
        {
            ACTION = -1;
            IS_VALID = false;
            IS_MANDATORY = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTROL_LIST_RULE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ACTION of the CONTROL_LIST_RULE 
        /// </summary>
        [Required]
        public int ACTION { get; set; }

        /// <summary>
        /// Required field IS_VALID of the CONTROL_LIST_RULE 
        /// </summary>
        [Required]
        public bool IS_VALID { get; set; }

        /// <summary>
        /// Required field IS_MANDATORY of the CONTROL_LIST_RULE 
        /// </summary>
        [Required]
        public bool IS_MANDATORY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTROL_LIST_RULE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_RULE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTROL_LIST_RULE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_RULE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTROL_LIST_RULE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST to which the CONTROL_LIST_RULE belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST")]
        public CONTROL_LIST? GUID_CONTROL_LIST_CONTROL_LIST { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST_ITEM to which the CONTROL_LIST_RULE belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST_ITEM")]
        public CONTROL_LIST_ITEM? GUID_CONTROL_LIST_ITEM_CONTROL_LIST_ITEM { get; set; }
        /// <summary>
        /// CONDITIONS of the CONTROL_LIST_RULE 
        /// </summary>
        public string? CONDITIONS { get; set; }
        /// <summary>
        /// PARAMETERS of the CONTROL_LIST_RULE 
        /// </summary>
        public string? PARAMETERS { get; set; }
    }
}