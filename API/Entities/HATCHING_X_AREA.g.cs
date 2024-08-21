using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a hatching_x_area entity with essential details
    /// </summary>
    [Table("HATCHING_X_AREA", Schema = "dbo")]
    public class HATCHING_X_AREA
    {
        /// <summary>
        /// Initializes a new instance of the HATCHING_X_AREA class.
        /// </summary>
        public HATCHING_X_AREA()
        {
            IS_GROSS = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the HATCHING_X_AREA 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_GROSS of the HATCHING_X_AREA 
        /// </summary>
        [Required]
        public bool IS_GROSS { get; set; }

        /// <summary>
        /// UPDATED_DATE of the HATCHING_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the HATCHING_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the HATCHING_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the HATCHING_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the HATCHING_X_AREA belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the HATCHING_X_AREA belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the HATCHING to which the HATCHING_X_AREA belongs 
        /// </summary>
        public Guid? GUID_HATCHING { get; set; }

        /// <summary>
        /// Navigation property representing the associated HATCHING
        /// </summary>
        [ForeignKey("GUID_HATCHING")]
        public HATCHING? GUID_HATCHING_HATCHING { get; set; }
    }
}