using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a spare_part_counting_list entity with essential details
    /// </summary>
    [Table("SPARE_PART_COUNTING_LIST", Schema = "dbo")]
    public class SPARE_PART_COUNTING_LIST
    {
        /// <summary>
        /// Initializes a new instance of the SPARE_PART_COUNTING_LIST class.
        /// </summary>
        public SPARE_PART_COUNTING_LIST()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the SPARE_PART_COUNTING_LIST 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the SPARE_PART_COUNTING to which the SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_SPARE_PART_COUNTING { get; set; }

        /// <summary>
        /// Navigation property representing the associated SPARE_PART_COUNTING
        /// </summary>
        [ForeignKey("GUID_SPARE_PART_COUNTING")]
        public SPARE_PART_COUNTING? GUID_SPARE_PART_COUNTING_SPARE_PART_COUNTING { get; set; }
        /// <summary>
        /// ID of the SPARE_PART_COUNTING_LIST 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the SPARE_PART_COUNTING_LIST 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SPARE_PART_COUNTING_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SPARE_PART_COUNTING_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}