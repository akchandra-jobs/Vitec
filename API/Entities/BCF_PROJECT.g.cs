using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a bcf_project entity with essential details
    /// </summary>
    [Table("BCF_PROJECT", Schema = "dbo")]
    public class BCF_PROJECT
    {
        /// <summary>
        /// Initializes a new instance of the BCF_PROJECT class.
        /// </summary>
        public BCF_PROJECT()
        {
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the BCF_PROJECT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the BCF_PROJECT 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// EXPORTED_DATE of the BCF_PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? EXPORTED_DATE { get; set; }

        /// <summary>
        /// CLOSED_DATE of the BCF_PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CLOSED_DATE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the BCF_PROJECT 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the BCF_PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BCF_PROJECT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the BCF_PROJECT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BCF_PROJECT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the BCF_PROJECT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the BCF_PROJECT belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the BCF_PROJECT belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BCF_PROJECT belongs 
        /// </summary>
        public Guid? GUID_EXPORTED_BY_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_EXPORTED_BY_USER")]
        public USR? GUID_EXPORTED_BY_USER_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BCF_PROJECT belongs 
        /// </summary>
        public Guid? GUID_CLOSED_BY_USER { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_CLOSED_BY_USER")]
        public USR? GUID_CLOSED_BY_USER_USR { get; set; }
        /// <summary>
        /// ID of the BCF_PROJECT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// NAME of the BCF_PROJECT 
        /// </summary>
        public string? NAME { get; set; }
    }
}