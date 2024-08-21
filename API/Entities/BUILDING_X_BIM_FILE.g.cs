using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a building_x_bim_file entity with essential details
    /// </summary>
    [Table("BUILDING_X_BIM_FILE", Schema = "dbo")]
    public class BUILDING_X_BIM_FILE
    {
        /// <summary>
        /// Initializes a new instance of the BUILDING_X_BIM_FILE class.
        /// </summary>
        public BUILDING_X_BIM_FILE()
        {
            SHOW_AS_DEFAULT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the BUILDING_X_BIM_FILE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field SHOW_AS_DEFAULT of the BUILDING_X_BIM_FILE 
        /// </summary>
        [Required]
        public bool SHOW_AS_DEFAULT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the BUILDING_X_BIM_FILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING_X_BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the BUILDING_X_BIM_FILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUILDING_X_BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the BUILDING_X_BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the BUILDING_X_BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the BIM_FILE to which the BUILDING_X_BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_BIM_FILE { get; set; }

        /// <summary>
        /// Navigation property representing the associated BIM_FILE
        /// </summary>
        [ForeignKey("GUID_BIM_FILE")]
        public BIM_FILE? GUID_BIM_FILE_BIM_FILE { get; set; }
    }
}