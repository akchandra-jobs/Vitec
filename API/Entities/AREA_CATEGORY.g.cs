using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a area_category entity with essential details
    /// </summary>
    [Table("AREA_CATEGORY", Schema = "dbo")]
    public class AREA_CATEGORY
    {
        /// <summary>
        /// Initializes a new instance of the AREA_CATEGORY class.
        /// </summary>
        public AREA_CATEGORY()
        {
            IS_MISCELLANEOUS = false;
            IS_ABSTRACT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field FACTOR of the AREA_CATEGORY 
        /// </summary>
        [Required]
        public double FACTOR { get; set; }

        /// <summary>
        /// Required field IS_MISCELLANEOUS of the AREA_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_MISCELLANEOUS { get; set; }

        /// <summary>
        /// Required field IS_ABSTRACT of the AREA_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_ABSTRACT { get; set; }

        /// <summary>
        /// Primary key for the AREA_CATEGORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the AREA_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the AREA_CATEGORY 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the AREA_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the AREA_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_20 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_21 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_22 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_23 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_24 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_25 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_26 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_27 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_28 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_29 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_10 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_11 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_12 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_13 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_14 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_15 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_16 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_17 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_18 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_19 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_30 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_30 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_31 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_31 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_32 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_32 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_33 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_33 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_34 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_34 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_35 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_35 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_36 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_36 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_37 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_37 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_38 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_38 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_39 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_39 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_40 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_40 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_41 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_41 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_42 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_42 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_43 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_43 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_44 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_44 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_45 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_45 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_46 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_46 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_47 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_47 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_48 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_48 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_49 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_49 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_50 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_50 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_51 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_51 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_52 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_52 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_53 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_53 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_54 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_54 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_55 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_55 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_56 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_56 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_57 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_57 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_58 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_58 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_59 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_59 { get; set; }
        /// <summary>
        /// SETTINGS of the AREA_CATEGORY 
        /// </summary>
        public string? SETTINGS { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_00 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_01 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_02 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_03 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_04 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_05 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_06 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_07 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_08 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_09 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_10 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_11 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_12 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_13 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_14 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_15 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_16 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_17 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_18 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_19 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_00 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_01 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_02 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_03 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_04 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_05 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_06 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_07 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_08 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_09 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_10 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_11 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_12 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_13 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_14 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_00 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_01 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_02 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_03 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_04 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_05 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_06 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_07 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_08 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_09 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_00 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_01 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_02 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_03 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_04 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_05 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_06 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_07 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_08 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_09 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_10 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_11 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_12 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_13 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_14 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_15 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_16 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_17 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_18 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_19 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_20 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_21 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_22 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_23 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_24 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_25 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_26 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_27 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_28 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_29 of the AREA_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_29 { get; set; }
    }
}