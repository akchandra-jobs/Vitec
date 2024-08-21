using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a price_sheet entity with essential details
    /// </summary>
    [Table("PRICE_SHEET", Schema = "dbo")]
    public class PRICE_SHEET
    {
        /// <summary>
        /// Initializes a new instance of the PRICE_SHEET class.
        /// </summary>
        public PRICE_SHEET()
        {
            IS_HISTORY = false;
            STATUS = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PRICE_SHEET 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_HISTORY of the PRICE_SHEET 
        /// </summary>
        [Required]
        public bool IS_HISTORY { get; set; }

        /// <summary>
        /// Required field STATUS of the PRICE_SHEET 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PRICE_SHEET 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PRICE_SHEET belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PRICE_SHEET 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PRICE_SHEET belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PRICE_SHEET belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PRICE_SHEET_CATEGORY to which the PRICE_SHEET belongs 
        /// </summary>
        public Guid? GUID_PRICE_SHEET_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRICE_SHEET_CATEGORY
        /// </summary>
        [ForeignKey("GUID_PRICE_SHEET_CATEGORY")]
        public PRICE_SHEET_CATEGORY? GUID_PRICE_SHEET_CATEGORY_PRICE_SHEET_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the PRICE_SHEET_REVISION to which the PRICE_SHEET belongs 
        /// </summary>
        public Guid? GUID_LAST_APPROVED_REVISION { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRICE_SHEET_REVISION
        /// </summary>
        [ForeignKey("GUID_LAST_APPROVED_REVISION")]
        public PRICE_SHEET_REVISION? GUID_LAST_APPROVED_REVISION_PRICE_SHEET_REVISION { get; set; }
        /// <summary>
        /// ID of the PRICE_SHEET 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PRICE_SHEET 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// NOTE of the PRICE_SHEET 
        /// </summary>
        public string? NOTE { get; set; }
    }
}