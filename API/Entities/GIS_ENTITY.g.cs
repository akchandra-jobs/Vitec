using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a gis_entity entity with essential details
    /// </summary>
    [Table("GIS_ENTITY", Schema = "dbo")]
    public class GIS_ENTITY
    {
        /// <summary>
        /// Initializes a new instance of the GIS_ENTITY class.
        /// </summary>
        public GIS_ENTITY()
        {
            GEOMETRY_TYPE = 0;
            ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field REFERENCE_POINT_LONGITUDE of the GIS_ENTITY 
        /// </summary>
        [Required]
        public double REFERENCE_POINT_LONGITUDE { get; set; }

        /// <summary>
        /// Required field REFERENCE_POINT_LATITUDE of the GIS_ENTITY 
        /// </summary>
        [Required]
        public double REFERENCE_POINT_LATITUDE { get; set; }

        /// <summary>
        /// Required field LONGITUDE_MIN of the GIS_ENTITY 
        /// </summary>
        [Required]
        public double LONGITUDE_MIN { get; set; }

        /// <summary>
        /// Required field LATITUDE_MIN of the GIS_ENTITY 
        /// </summary>
        [Required]
        public double LATITUDE_MIN { get; set; }

        /// <summary>
        /// Required field LONGITUDE_MAX of the GIS_ENTITY 
        /// </summary>
        [Required]
        public double LONGITUDE_MAX { get; set; }

        /// <summary>
        /// Required field LATITUDE_MAX of the GIS_ENTITY 
        /// </summary>
        [Required]
        public double LATITUDE_MAX { get; set; }

        /// <summary>
        /// Required field GEOMETRY_TYPE of the GIS_ENTITY 
        /// </summary>
        [Required]
        public int GEOMETRY_TYPE { get; set; }

        /// <summary>
        /// Primary key for the GIS_ENTITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the GIS_ENTITY 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the GIS_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// GEOMETRY_DATA of the GIS_ENTITY 
        /// </summary>
        public byte[]? GEOMETRY_DATA { get; set; }

        /// <summary>
        /// UPDATED_DATE of the GIS_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the GIS_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the GIS_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the GIS_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// GUID_ENTITY of the GIS_ENTITY 
        /// </summary>
        public Guid? GUID_ENTITY { get; set; }
    }
}