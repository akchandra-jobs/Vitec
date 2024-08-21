using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a service_price entity with essential details
    /// </summary>
    [Table("SERVICE_PRICE", Schema = "dbo")]
    public class SERVICE_PRICE
    {
        /// <summary>
        /// Initializes a new instance of the SERVICE_PRICE class.
        /// </summary>
        public SERVICE_PRICE()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field PRICE of the SERVICE_PRICE 
        /// </summary>
        [Required]
        public double PRICE { get; set; }

        /// <summary>
        /// Required field PREVIOUS_PRICE of the SERVICE_PRICE 
        /// </summary>
        [Required]
        public double PREVIOUS_PRICE { get; set; }

        /// <summary>
        /// Required field ADJUSTMENT_FACTOR of the SERVICE_PRICE 
        /// </summary>
        [Required]
        public double ADJUSTMENT_FACTOR { get; set; }

        /// <summary>
        /// Required field INCREASE_FACTOR of the SERVICE_PRICE 
        /// </summary>
        [Required]
        public double INCREASE_FACTOR { get; set; }

        /// <summary>
        /// Primary key for the SERVICE_PRICE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the SERVICE_PRICE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_CATEGORY to which the SERVICE_PRICE belongs 
        /// </summary>
        public Guid? GUID_AREA_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_CATEGORY
        /// </summary>
        [ForeignKey("GUID_AREA_CATEGORY")]
        public AREA_CATEGORY? GUID_AREA_CATEGORY_AREA_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the PRICE_SHEET_REVISION to which the SERVICE_PRICE belongs 
        /// </summary>
        public Guid? GUID_PRICE_SHEET_REVISION { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRICE_SHEET_REVISION
        /// </summary>
        [ForeignKey("GUID_PRICE_SHEET_REVISION")]
        public PRICE_SHEET_REVISION? GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the SERVICE_PRICE belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SERVICE_PRICE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SERVICE_PRICE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SERVICE_PRICE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SERVICE_PRICE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}