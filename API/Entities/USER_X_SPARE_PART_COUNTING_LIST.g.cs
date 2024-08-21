using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a user_x_spare_part_counting_list entity with essential details
    /// </summary>
    [Table("USER_X_SPARE_PART_COUNTING_LIST", Schema = "dbo")]
    public class USER_X_SPARE_PART_COUNTING_LIST
    {
        /// <summary>
        /// Initializes a new instance of the USER_X_SPARE_PART_COUNTING_LIST class.
        /// </summary>
        public USER_X_SPARE_PART_COUNTING_LIST()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the USER_X_SPARE_PART_COUNTING_LIST 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the USER_X_SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the SPARE_PART_COUNTING_LIST to which the USER_X_SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_SPARE_PART_COUNTING_LIST { get; set; }

        /// <summary>
        /// Navigation property representing the associated SPARE_PART_COUNTING_LIST
        /// </summary>
        [ForeignKey("GUID_SPARE_PART_COUNTING_LIST")]
        public SPARE_PART_COUNTING_LIST? GUID_SPARE_PART_COUNTING_LIST_SPARE_PART_COUNTING_LIST { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER")]
        public USR? GUID_USER_USR { get; set; }

        /// <summary>
        /// UPDATED_DATE of the USER_X_SPARE_PART_COUNTING_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the USER_X_SPARE_PART_COUNTING_LIST 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the USER_X_SPARE_PART_COUNTING_LIST belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}