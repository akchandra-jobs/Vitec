using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a cleaning_quality entity with essential details
    /// </summary>
    [Table("CLEANING_QUALITY", Schema = "dbo")]
    public class CLEANING_QUALITY
    {
        /// <summary>
        /// Initializes a new instance of the CLEANING_QUALITY class.
        /// </summary>
        public CLEANING_QUALITY()
        {
            INVENTORY_WASTE = 0;
            INVENTORY_SURFACE = 0;
            WALL_WASTE = 0;
            WALL_SURFACE = 0;
            FLOOR_WASTE = 0;
            FLOOR_SURFACE = 0;
            CEILING_WASTE = 0;
            CEILING_SURFACE = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CLEANING_QUALITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field INVENTORY_WASTE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int INVENTORY_WASTE { get; set; }

        /// <summary>
        /// Required field INVENTORY_SURFACE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int INVENTORY_SURFACE { get; set; }

        /// <summary>
        /// Required field WALL_WASTE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int WALL_WASTE { get; set; }

        /// <summary>
        /// Required field WALL_SURFACE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int WALL_SURFACE { get; set; }

        /// <summary>
        /// Required field FLOOR_WASTE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int FLOOR_WASTE { get; set; }

        /// <summary>
        /// Required field FLOOR_SURFACE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int FLOOR_SURFACE { get; set; }

        /// <summary>
        /// Required field CEILING_WASTE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int CEILING_WASTE { get; set; }

        /// <summary>
        /// Required field CEILING_SURFACE of the CLEANING_QUALITY 
        /// </summary>
        [Required]
        public int CEILING_SURFACE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CLEANING_QUALITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the CLEANING_QUALITY 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CLEANING_QUALITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_QUALITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CLEANING_QUALITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CLEANING_QUALITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// DESCRIPTION of the CLEANING_QUALITY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// NOTE of the CLEANING_QUALITY 
        /// </summary>
        public string? NOTE { get; set; }
    }
}