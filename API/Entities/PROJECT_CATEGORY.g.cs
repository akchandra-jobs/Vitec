using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a project_category entity with essential details
    /// </summary>
    [Table("PROJECT_CATEGORY", Schema = "dbo")]
    public class PROJECT_CATEGORY
    {
        /// <summary>
        /// Initializes a new instance of the PROJECT_CATEGORY class.
        /// </summary>
        public PROJECT_CATEGORY()
        {
            IS_ABSTRACT = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PROJECT_CATEGORY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_ABSTRACT of the PROJECT_CATEGORY 
        /// </summary>
        [Required]
        public bool IS_ABSTRACT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PROJECT_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PROJECT_CATEGORY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PROJECT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PROJECT_CATEGORY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// DESCRIPTION of the PROJECT_CATEGORY 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_00 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_01 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_02 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_03 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_04 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_05 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_06 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_07 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_08 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_09 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_10 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_11 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_12 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_13 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_14 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_15 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_16 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_17 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_18 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_19 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_20 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_21 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_22 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_23 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_24 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_25 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_26 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_27 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_28 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_29 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_30 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_30 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_31 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_31 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_32 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_32 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_33 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_33 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_34 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_34 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_35 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_35 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_36 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_36 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_37 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_37 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_38 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_38 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_TEXT_39 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_TEXT_39 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_00 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_01 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_02 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_03 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_04 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_05 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_06 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_07 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_08 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_09 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_10 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_11 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_12 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_13 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_14 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_15 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_16 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_17 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_18 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_19 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_20 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_21 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_22 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_23 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_24 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_25 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_26 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_27 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_28 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_DATE_29 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_DATE_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_00 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_01 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_02 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_03 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_04 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_05 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_06 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_07 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_08 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_09 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_10 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_11 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_12 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_13 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_14 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_15 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_16 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_17 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_18 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_19 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_20 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_21 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_22 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_23 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_24 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_25 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_26 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_27 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_28 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_29 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_29 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_30 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_30 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_31 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_31 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_32 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_32 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_33 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_33 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_34 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_34 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_35 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_35 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_36 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_36 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_37 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_37 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_38 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_38 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_NUMERIC_39 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_NUMERIC_39 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_00 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_00 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_01 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_01 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_02 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_02 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_03 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_03 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_04 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_04 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_05 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_05 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_06 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_06 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_07 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_07 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_08 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_08 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_09 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_09 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_10 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_10 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_11 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_11 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_12 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_12 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_13 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_13 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_14 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_14 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_15 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_15 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_16 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_16 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_17 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_17 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_18 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_18 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_19 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_19 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_20 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_20 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_21 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_21 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_22 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_22 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_23 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_23 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_24 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_24 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_25 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_25 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_26 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_26 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_27 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_27 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_28 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_28 { get; set; }
        /// <summary>
        /// LABEL_DYNAMIC_COMBO_29 of the PROJECT_CATEGORY 
        /// </summary>
        public string? LABEL_DYNAMIC_COMBO_29 { get; set; }
        /// <summary>
        /// SETTINGS of the PROJECT_CATEGORY 
        /// </summary>
        public string? SETTINGS { get; set; }
    }
}