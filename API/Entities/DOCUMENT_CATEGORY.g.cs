using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a document_category entity with essential details
    /// </summary>
    [Table("DOCUMENT_CATEGORY", Schema = "dbo")]
    public class DOCUMENT_CATEGORY
    {
        /// <summary>
        /// Initializes a new instance of the DOCUMENT_CATEGORY class.
        /// </summary>
        public DOCUMENT_CATEGORY()
        {
            IS_ABSTRACT = false;
            MUST_FILTER_BY_SUPPLIER = false;
            ARCHIVE_TYPE = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOCUMENT_CATEGORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_ABSTRACT of the DOCUMENT_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_ABSTRACT { get; set; }

        /// <summary>
        /// Required field MUST_FILTER_BY_SUPPLIER of the DOCUMENT_CATEGORY 
        /// </summary>
        [Required]
        public bool MUST_FILTER_BY_SUPPLIER { get; set; }

        /// <summary>
        /// Required field ARCHIVE_TYPE of the DOCUMENT_CATEGORY 
        /// </summary>
        [Required]
        public int ARCHIVE_TYPE { get; set; }
        /// <summary>
        /// SETTINGS of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? SETTINGS { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOCUMENT_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOCUMENT_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOCUMENT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOCUMENT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// PATH of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? PATH { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_00 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_01 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_02 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_03 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_04 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_05 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_06 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_07 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_08 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_09 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_00 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_01 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_02 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_03 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_04 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_00 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_01 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_02 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_03 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_04 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_05 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_06 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_07 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_08 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_09 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_00 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_01 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_02 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_03 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_04 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_05 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_06 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_07 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_08 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_09 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_10 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_11 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_12 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_13 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_14 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_15 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_16 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_17 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_18 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_19 of the DOCUMENT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_19 { get; set; }
    }
}