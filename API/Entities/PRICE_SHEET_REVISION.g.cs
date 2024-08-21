using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a price_sheet_revision entity with essential details
    /// </summary>
    [Table("PRICE_SHEET_REVISION", Schema = "dbo")]
    public class PRICE_SHEET_REVISION
    {
        /// <summary>
        /// Initializes a new instance of the PRICE_SHEET_REVISION class.
        /// </summary>
        public PRICE_SHEET_REVISION()
        {
            STATUS = -1;
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PRICE_SHEET_REVISION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the PRICE_SHEET_REVISION 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field ID of the PRICE_SHEET_REVISION 
        /// </summary>
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the PRICE_SHEET_REVISION 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// NOTE of the PRICE_SHEET_REVISION 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// APPROVED_DATE of the PRICE_SHEET_REVISION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? APPROVED_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PRICE_SHEET_REVISION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PRICE_SHEET_REVISION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PRICE_SHEET_REVISION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PRICE_SHEET_REVISION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PRICE_SHEET_REVISION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PRICE_SHEET_REVISION belongs 
        /// </summary>
        public Guid? GUID_USER_APPROVED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_APPROVED_BY")]
        public USR? GUID_USER_APPROVED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the PRICE_SHEET to which the PRICE_SHEET_REVISION belongs 
        /// </summary>
        public Guid? GUID_PRICE_SHEET { get; set; }

        /// <summary>
        /// Navigation property representing the associated PRICE_SHEET
        /// </summary>
        [ForeignKey("GUID_PRICE_SHEET")]
        public PRICE_SHEET? GUID_PRICE_SHEET_PRICE_SHEET { get; set; }
    }
}