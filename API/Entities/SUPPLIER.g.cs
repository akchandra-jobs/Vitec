using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a supplier entity with essential details
    /// </summary>
    [Table("SUPPLIER", Schema = "dbo")]
    public class SUPPLIER
    {
        /// <summary>
        /// Initializes a new instance of the SUPPLIER class.
        /// </summary>
        public SUPPLIER()
        {
            HAS_LOCKED_MAIN_SUPPLIER = false;
            TYPE = -1;
            HAS_NOT_REQUISITION = false;
            IS_DEACTIVATED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the SUPPLIER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field HAS_LOCKED_MAIN_SUPPLIER of the SUPPLIER 
        /// </summary>
        [Required]
        public bool HAS_LOCKED_MAIN_SUPPLIER { get; set; }

        /// <summary>
        /// Required field TYPE of the SUPPLIER 
        /// </summary>
        [Required]
        public int TYPE { get; set; }

        /// <summary>
        /// Required field HAS_NOT_REQUISITION of the SUPPLIER 
        /// </summary>
        [Required]
        public bool HAS_NOT_REQUISITION { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the SUPPLIER 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }
        /// <summary>
        /// YOUR_REFERENCE of the SUPPLIER 
        /// </summary>
        public string? YOUR_REFERENCE { get; set; }
        /// <summary>
        /// ORGANIZATION_NR of the SUPPLIER 
        /// </summary>
        public string? ORGANIZATION_NR { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SUPPLIER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SUPPLIER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// DIVISION of the SUPPLIER 
        /// </summary>
        public string? DIVISION { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER_LINE_OF_BUSINESS to which the SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER_LINE_OF_BUSINESS { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER_LINE_OF_BUSINESS
        /// </summary>
        [ForeignKey("GUID_SUPPLIER_LINE_OF_BUSINESS")]
        public SUPPLIER_LINE_OF_BUSINESS? GUID_SUPPLIER_LINE_OF_BUSINESS_SUPPLIER_LINE_OF_BUSINESS { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the SUPPLIER belongs 
        /// </summary>
        public Guid? GUID_MAIN_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_MAIN_SUPPLIER")]
        public SUPPLIER? GUID_MAIN_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// ID of the SUPPLIER 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the SUPPLIER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// ADDRESS1 of the SUPPLIER 
        /// </summary>
        public string? ADDRESS1 { get; set; }
        /// <summary>
        /// ADDRESS2 of the SUPPLIER 
        /// </summary>
        public string? ADDRESS2 { get; set; }
        /// <summary>
        /// ADDRESS3 of the SUPPLIER 
        /// </summary>
        public string? ADDRESS3 { get; set; }
        /// <summary>
        /// ADDRESS4 of the SUPPLIER 
        /// </summary>
        public string? ADDRESS4 { get; set; }
        /// <summary>
        /// POSTBOX of the SUPPLIER 
        /// </summary>
        public string? POSTBOX { get; set; }
        /// <summary>
        /// POSTAL_CODE of the SUPPLIER 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the SUPPLIER 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// COUNTRY of the SUPPLIER 
        /// </summary>
        public string? COUNTRY { get; set; }
        /// <summary>
        /// AGREEMENT of the SUPPLIER 
        /// </summary>
        public string? AGREEMENT { get; set; }
        /// <summary>
        /// NOTE of the SUPPLIER 
        /// </summary>
        public string? NOTE { get; set; }
        /// <summary>
        /// TELEPHONE of the SUPPLIER 
        /// </summary>
        public string? TELEPHONE { get; set; }
        /// <summary>
        /// TELEFAX of the SUPPLIER 
        /// </summary>
        public string? TELEFAX { get; set; }
        /// <summary>
        /// EMAIL of the SUPPLIER 
        /// </summary>
        public string? EMAIL { get; set; }
        /// <summary>
        /// WEB_ADDRESS of the SUPPLIER 
        /// </summary>
        public string? WEB_ADDRESS { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the SUPPLIER 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
    }
}