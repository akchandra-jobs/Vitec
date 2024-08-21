using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a spare_part_counting_item entity with essential details
    /// </summary>
    [Table("SPARE_PART_COUNTING_ITEM", Schema = "dbo")]
    public class SPARE_PART_COUNTING_ITEM
    {
        /// <summary>
        /// Initializes a new instance of the SPARE_PART_COUNTING_ITEM class.
        /// </summary>
        public SPARE_PART_COUNTING_ITEM()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field RECORD_QUANTITY of the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        [Required]
        public double RECORD_QUANTITY { get; set; }

        /// <summary>
        /// Required field PHYSICAL_QUANTITY of the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        [Required]
        public double PHYSICAL_QUANTITY { get; set; }

        /// <summary>
        /// Required field QUANTITY_DEVIATION of the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        [Required]
        public double QUANTITY_DEVIATION { get; set; }

        /// <summary>
        /// Primary key for the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the SPARE_PART_COUNTING_ITEM belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the SPARE_PART to which the SPARE_PART_COUNTING_ITEM belongs 
        /// </summary>
        public Guid? GUID_SPARE_PART { get; set; }

        /// <summary>
        /// Navigation property representing the associated SPARE_PART
        /// </summary>
        [ForeignKey("GUID_SPARE_PART")]
        public SPARE_PART? GUID_SPARE_PART_SPARE_PART { get; set; }
        /// <summary>
        /// Foreign key referencing the SPARE_PART_COUNTING_LIST to which the SPARE_PART_COUNTING_ITEM belongs 
        /// </summary>
        public Guid? GUID_SPARE_PART_COUNTING_LIST { get; set; }

        /// <summary>
        /// Navigation property representing the associated SPARE_PART_COUNTING_LIST
        /// </summary>
        [ForeignKey("GUID_SPARE_PART_COUNTING_LIST")]
        public SPARE_PART_COUNTING_LIST? GUID_SPARE_PART_COUNTING_LIST_SPARE_PART_COUNTING_LIST { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART_COUNTING_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_COUNTED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_COUNTED_BY")]
        public USR? GUID_USER_COUNTED_BY_USR { get; set; }

        /// <summary>
        /// COUNTED_DATE of the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? COUNTED_DATE { get; set; }
        /// <summary>
        /// COMMENT of the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        public string? COMMENT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART_COUNTING_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SPARE_PART_COUNTING_ITEM 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART_COUNTING_ITEM belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}