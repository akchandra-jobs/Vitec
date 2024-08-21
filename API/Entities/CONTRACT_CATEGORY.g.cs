using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contract_category entity with essential details
    /// </summary>
    [Table("CONTRACT_CATEGORY", Schema = "dbo")]
    public class CONTRACT_CATEGORY
    {
        /// <summary>
        /// Initializes a new instance of the CONTRACT_CATEGORY class.
        /// </summary>
        public CONTRACT_CATEGORY()
        {
            IS_ABSTRACT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTRACT_CATEGORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_ABSTRACT of the CONTRACT_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_ABSTRACT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTRACT_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTRACT_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_10 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_11 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_12 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_13 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_14 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_15 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_16 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_17 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_18 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_19 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_19 { get; set; }
        /// <summary>
        /// SETTINGS of the CONTRACT_CATEGORY 
        /// </summary>
        public string? SETTINGS { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTRACT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the CONTRACT_CATEGORY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_00 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_01 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_02 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_03 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_04 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_05 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_06 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_07 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_08 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_09 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_00 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_01 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_02 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_03 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_04 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_05 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_06 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_07 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_08 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_09 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_10 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_11 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_12 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_13 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_14 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_00 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_01 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_02 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_03 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_04 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_00 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_01 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_02 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_03 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_04 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_05 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_06 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_07 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_08 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_09 of the CONTRACT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_09 { get; set; }
    }
}