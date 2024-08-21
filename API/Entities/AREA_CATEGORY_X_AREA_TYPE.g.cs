using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a area_category_x_area_type entity with essential details
    /// </summary>
    [Table("AREA_CATEGORY_X_AREA_TYPE", Schema = "dbo")]
    public class AREA_CATEGORY_X_AREA_TYPE
    {
        /// <summary>
        /// Initializes a new instance of the AREA_CATEGORY_X_AREA_TYPE class.
        /// </summary>
        public AREA_CATEGORY_X_AREA_TYPE()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the AREA_CATEGORY_X_AREA_TYPE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_CATEGORY to which the AREA_CATEGORY_X_AREA_TYPE belongs 
        /// </summary>
        public Guid? GUID_AREA_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_CATEGORY
        /// </summary>
        [ForeignKey("GUID_AREA_CATEGORY")]
        public AREA_CATEGORY? GUID_AREA_CATEGORY_AREA_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_TYPE to which the AREA_CATEGORY_X_AREA_TYPE belongs 
        /// </summary>
        public Guid? GUID_AREA_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_TYPE
        /// </summary>
        [ForeignKey("GUID_AREA_TYPE")]
        public AREA_TYPE? GUID_AREA_TYPE_AREA_TYPE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the AREA_CATEGORY_X_AREA_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_CATEGORY_X_AREA_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the AREA_CATEGORY_X_AREA_TYPE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_CATEGORY_X_AREA_TYPE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}