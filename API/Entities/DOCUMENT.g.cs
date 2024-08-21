using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a document entity with essential details
    /// </summary>
    [Table("DOCUMENT", Schema = "dbo")]
    public class DOCUMENT
    {
        /// <summary>
        /// Initializes a new instance of the DOCUMENT class.
        /// </summary>
        public DOCUMENT()
        {
            DOCUMENTATION_CONTEXT = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field NUMBER01 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the DOCUMENT 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Primary key for the DOCUMENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field DOCUMENTATION_CONTEXT of the DOCUMENT 
        /// </summary>
        [Required]
        public int DOCUMENTATION_CONTEXT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT_CATEGORY to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT_CATEGORY
        /// </summary>
        [ForeignKey("GUID_DOCUMENT_CATEGORY")]
        public DOCUMENT_CATEGORY? GUID_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT_TYPE to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT_TYPE
        /// </summary>
        [ForeignKey("GUID_DOCUMENT_TYPE")]
        public DOCUMENT_TYPE? GUID_DOCUMENT_TYPE_DOCUMENT_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT_TEMPLATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT
        /// </summary>
        [ForeignKey("GUID_DOCUMENT_TEMPLATE")]
        public DOCUMENT? GUID_DOCUMENT_TEMPLATE_DOCUMENT { get; set; }
        /// <summary>
        /// ID of the DOCUMENT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DOCUMENT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// FILE_PATH of the DOCUMENT 
        /// </summary>
        public string? FILE_PATH { get; set; }
        /// <summary>
        /// PREPARED_BY of the DOCUMENT 
        /// </summary>
        public string? PREPARED_BY { get; set; }

        /// <summary>
        /// PREPARED_DATE of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? PREPARED_DATE { get; set; }
        /// <summary>
        /// NOTE of the DOCUMENT 
        /// </summary>
        public string? NOTE { get; set; }
        /// <summary>
        /// DOCUMENT_DATA of the DOCUMENT 
        /// </summary>
        public byte[]? DOCUMENT_DATA { get; set; }
        /// <summary>
        /// TEXT01 of the DOCUMENT 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the DOCUMENT 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the DOCUMENT 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the DOCUMENT 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the DOCUMENT 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the DOCUMENT 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the DOCUMENT 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the DOCUMENT 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the DOCUMENT 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the DOCUMENT 
        /// </summary>
        public string? TEXT10 { get; set; }

        /// <summary>
        /// DATE01 of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }
        /// <summary>
        /// COMBO01 of the DOCUMENT 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the DOCUMENT 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the DOCUMENT 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the DOCUMENT 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the DOCUMENT 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the DOCUMENT 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the DOCUMENT 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the DOCUMENT 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the DOCUMENT 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the DOCUMENT 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the DOCUMENT 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the DOCUMENT 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the DOCUMENT 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the DOCUMENT 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the DOCUMENT 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the DOCUMENT 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the DOCUMENT 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the DOCUMENT 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the DOCUMENT 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the DOCUMENT 
        /// </summary>
        public string? COMBO20 { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOCUMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}