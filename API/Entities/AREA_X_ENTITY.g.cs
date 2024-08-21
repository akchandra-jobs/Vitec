using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a area_x_entity entity with essential details
    /// </summary>
    [Table("AREA_X_ENTITY", Schema = "dbo")]
    public class AREA_X_ENTITY
    {
        /// <summary>
        /// Initializes a new instance of the AREA_X_ENTITY class.
        /// </summary>
        public AREA_X_ENTITY()
        {
            IS_SPECIFIED = false;
            ENTITY_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field QUANTITY of the AREA_X_ENTITY 
        /// </summary>
        [Required]
        public double QUANTITY { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_YEAR of the AREA_X_ENTITY 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_YEAR { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_MONTH of the AREA_X_ENTITY 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_MONTH { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_DAY of the AREA_X_ENTITY 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_DAY { get; set; }

        /// <summary>
        /// Required field IS_SPECIFIED of the AREA_X_ENTITY 
        /// </summary>
        [Required]
        public bool IS_SPECIFIED { get; set; }

        /// <summary>
        /// Required field ENTITY_TYPE of the AREA_X_ENTITY 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Primary key for the AREA_X_ENTITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the AREA_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the AREA_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the AREA_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_ROOM { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_ROOM")]
        public AREA? GUID_ROOM_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the ARTICLE to which the AREA_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_ARTICLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ARTICLE
        /// </summary>
        [ForeignKey("GUID_ARTICLE")]
        public ARTICLE? GUID_ARTICLE_ARTICLE { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the AREA_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }
        /// <summary>
        /// ID of the AREA_X_ENTITY 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the AREA_X_ENTITY 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the AREA_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the AREA_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}