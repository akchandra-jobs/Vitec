using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a control_list_item_answer entity with essential details
    /// </summary>
    [Table("CONTROL_LIST_ITEM_ANSWER", Schema = "dbo")]
    public class CONTROL_LIST_ITEM_ANSWER
    {
        /// <summary>
        /// Initializes a new instance of the CONTROL_LIST_ITEM_ANSWER class.
        /// </summary>
        public CONTROL_LIST_ITEM_ANSWER()
        {
            VALUE_BOOL = false;
            VALUE_INT = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field VALUE_BOOL of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        [Required]
        public bool VALUE_BOOL { get; set; }

        /// <summary>
        /// Required field VALUE_INT of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        [Required]
        public int VALUE_INT { get; set; }

        /// <summary>
        /// VALUE_DATE of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? VALUE_DATE { get; set; }
        /// <summary>
        /// VALUE_DOUBLE of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        public double? VALUE_DOUBLE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_ITEM_ANSWER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTROL_LIST_ITEM_ANSWER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTROL_LIST_ITEM_ANSWER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST_ITEM to which the CONTROL_LIST_ITEM_ANSWER belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST_ITEM")]
        public CONTROL_LIST_ITEM? GUID_CONTROL_LIST_ITEM_CONTROL_LIST_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTROL_LIST_X_ENTITY to which the CONTROL_LIST_ITEM_ANSWER belongs 
        /// </summary>
        public Guid? GUID_CONTROL_LIST_X_ENTITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTROL_LIST_X_ENTITY
        /// </summary>
        [ForeignKey("GUID_CONTROL_LIST_X_ENTITY")]
        public CONTROL_LIST_X_ENTITY? GUID_CONTROL_LIST_X_ENTITY_CONTROL_LIST_X_ENTITY { get; set; }
        /// <summary>
        /// VALUE of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        public string? VALUE { get; set; }
        /// <summary>
        /// VALUE_STRING of the CONTROL_LIST_ITEM_ANSWER 
        /// </summary>
        public string? VALUE_STRING { get; set; }
    }
}