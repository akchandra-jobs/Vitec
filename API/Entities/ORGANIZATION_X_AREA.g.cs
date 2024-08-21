using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a organization_x_area entity with essential details
    /// </summary>
    [Table("ORGANIZATION_X_AREA", Schema = "dbo")]
    public class ORGANIZATION_X_AREA
    {
        /// <summary>
        /// Initializes a new instance of the ORGANIZATION_X_AREA class.
        /// </summary>
        public ORGANIZATION_X_AREA()
        {
            IS_BOOKING = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ORGANIZATION_X_AREA 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_BOOKING of the ORGANIZATION_X_AREA 
        /// </summary>
        [Required]
        public bool IS_BOOKING { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ORGANIZATION_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ORGANIZATION_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ORGANIZATION_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ORGANIZATION_X_AREA belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// RECURRENCE of the ORGANIZATION_X_AREA 
        /// </summary>
        public string? RECURRENCE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ORGANIZATION_X_AREA belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the ORGANIZATION_X_AREA belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION to which the ORGANIZATION_X_AREA belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION")]
        public ORGANIZATION? GUID_ORGANIZATION_ORGANIZATION { get; set; }

        /// <summary>
        /// START_DATE of the ORGANIZATION_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the ORGANIZATION_X_AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
    }
}