using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a estate_category entity with essential details
    /// </summary>
    [Table("ESTATE_CATEGORY", Schema = "dbo")]
    public class ESTATE_CATEGORY
    {
        /// <summary>
        /// Initializes a new instance of the ESTATE_CATEGORY class.
        /// </summary>
        public ESTATE_CATEGORY()
        {
            IS_ABSTRACT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ESTATE_CATEGORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_ABSTRACT of the ESTATE_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_ABSTRACT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ESTATE_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ESTATE_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ESTATE_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ESTATE_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// SETTINGS of the ESTATE_CATEGORY 
        /// </summary>
        public string? SETTINGS { get; set; }
        /// <summary>
        /// COLOR of the ESTATE_CATEGORY 
        /// </summary>
        public string? COLOR { get; set; }
        /// <summary>
        /// ICON of the ESTATE_CATEGORY 
        /// </summary>
        public string? ICON { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ESTATE_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the ESTATE_CATEGORY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_00 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_01 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_02 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_03 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_04 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_05 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_06 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_07 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_08 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_09 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_10 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_11 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_12 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_13 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_14 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_15 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_16 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_17 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_18 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_19 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_20 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_21 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_22 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_23 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_24 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_25 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_26 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_27 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_28 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_29 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_30 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_30 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_31 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_31 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_32 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_32 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_33 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_33 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_34 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_34 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_35 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_35 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_36 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_36 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_37 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_37 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_38 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_38 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_39 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_39 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_00 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_01 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_02 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_03 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_04 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_00 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_01 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_02 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_03 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_04 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_05 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_06 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_07 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_08 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_09 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_10 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_11 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_12 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_13 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_14 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_15 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_16 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_17 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_18 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_19 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_20 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_21 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_22 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_23 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_24 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_25 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_26 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_27 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_28 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_29 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_30 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_30 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_31 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_31 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_32 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_32 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_33 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_33 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_34 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_34 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_35 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_35 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_36 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_36 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_37 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_37 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_38 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_38 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_39 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_39 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_00 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_01 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_02 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_03 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_04 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_05 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_06 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_07 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_08 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_09 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_10 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_11 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_12 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_13 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_14 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_15 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_16 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_17 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_18 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_19 of the ESTATE_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_19 { get; set; }
    }
}