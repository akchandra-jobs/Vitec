using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a condition_type entity with essential details
    /// </summary>
    [Table("CONDITION_TYPE", Schema = "dbo")]
    public class CONDITION_TYPE
    {
        /// <summary>
        /// Initializes a new instance of the CONDITION_TYPE class.
        /// </summary>
        public CONDITION_TYPE()
        {
            IS_APPROVED = false;
            ENTITY = -1;
            LIKERT_SCALE = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field IS_APPROVED of the CONDITION_TYPE 
        /// </summary>
        [Required]
        public bool IS_APPROVED { get; set; }

        /// <summary>
        /// Required field ENTITY of the CONDITION_TYPE 
        /// </summary>
        [Required]
        public int ENTITY { get; set; }

        /// <summary>
        /// Primary key for the CONDITION_TYPE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field LIKERT_SCALE of the CONDITION_TYPE 
        /// </summary>
        [Required]
        public int LIKERT_SCALE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONDITION_TYPE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the CONDITION_TYPE 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONDITION_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONDITION_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONDITION_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONDITION_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}