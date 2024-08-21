using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a activity_category entity with essential details
    /// </summary>
    [Table("ACTIVITY_CATEGORY", Schema = "dbo")]
    public class ACTIVITY_CATEGORY
    {
        /// <summary>
        /// Initializes a new instance of the ACTIVITY_CATEGORY class.
        /// </summary>
        public ACTIVITY_CATEGORY()
        {
            IS_DEACTIVATED = false;
            USE_IN_WORK_ORDER = false;
            USE_IN_REQUEST = false;
            IS_ABSTRACT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ACTIVITY_CATEGORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the ACTIVITY_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field USE_IN_WORK_ORDER of the ACTIVITY_CATEGORY 
        /// </summary>
        [Required]
        public bool USE_IN_WORK_ORDER { get; set; }

        /// <summary>
        /// Required field USE_IN_REQUEST of the ACTIVITY_CATEGORY 
        /// </summary>
        [Required]
        public bool USE_IN_REQUEST { get; set; }

        /// <summary>
        /// Required field IS_ABSTRACT of the ACTIVITY_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_ABSTRACT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ACTIVITY_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ACTIVITY_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ACTIVITY_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ACTIVITY_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// SETTINGS of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? SETTINGS { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_20 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_21 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_22 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_23 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_24 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_25 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_26 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_27 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_28 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_29 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_20 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_21 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_22 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_23 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_24 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_25 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_26 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_27 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_28 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_29 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_30 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_30 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_31 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_31 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_32 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_32 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_33 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_33 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_34 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_34 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_35 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_35 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_36 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_36 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_37 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_37 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_38 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_38 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_39 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_39 { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ACTIVITY_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_00 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_01 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_02 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_03 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_04 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_05 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_06 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_07 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_08 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_09 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_10 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_11 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_12 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_13 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_14 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_15 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_16 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_17 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_18 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_19 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_00 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_01 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_02 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_03 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_04 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_05 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_06 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_07 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_08 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_09 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_10 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_11 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_12 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_13 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_14 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_15 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_16 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_17 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_18 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_19 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_20 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_21 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_22 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_23 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_24 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_25 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_26 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_27 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_28 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_29 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_00 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_01 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_02 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_03 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_04 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_05 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_06 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_07 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_08 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_09 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_00 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_01 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_02 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_03 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_04 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_05 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_06 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_07 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_08 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_09 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_10 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_11 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_12 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_13 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_14 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_15 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_16 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_17 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_18 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_19 of the ACTIVITY_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_19 { get; set; }
    }
}