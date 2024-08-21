using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a bim_file entity with essential details
    /// </summary>
    [Table("BIM_FILE", Schema = "dbo")]
    public class BIM_FILE
    {
        /// <summary>
        /// Initializes a new instance of the BIM_FILE class.
        /// </summary>
        public BIM_FILE()
        {
            MODEL_VERSION = 0;
            PROCESSING_STATUS = -1;
            SHOW_AS_DEFAULT_IN_BIM_PROJECT = false;
            IS_LOCKED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the BIM_FILE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field MODEL_VERSION of the BIM_FILE 
        /// </summary>
        [Required]
        public int MODEL_VERSION { get; set; }

        /// <summary>
        /// Required field PROCESSING_STATUS of the BIM_FILE 
        /// </summary>
        [Required]
        public int PROCESSING_STATUS { get; set; }

        /// <summary>
        /// Required field SHOW_AS_DEFAULT_IN_BIM_PROJECT of the BIM_FILE 
        /// </summary>
        [Required]
        public bool SHOW_AS_DEFAULT_IN_BIM_PROJECT { get; set; }

        /// <summary>
        /// Required field IS_LOCKED of the BIM_FILE 
        /// </summary>
        [Required]
        public bool IS_LOCKED { get; set; }
        /// <summary>
        /// SETTINGS_JSON of the BIM_FILE 
        /// </summary>
        public string? SETTINGS_JSON { get; set; }
        /// <summary>
        /// PROCESSING_ERROR of the BIM_FILE 
        /// </summary>
        public string? PROCESSING_ERROR { get; set; }
        /// <summary>
        /// Foreign key referencing the BIM_PROJECT to which the BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_BIM_PROJECT { get; set; }

        /// <summary>
        /// Navigation property representing the associated BIM_PROJECT
        /// </summary>
        [ForeignKey("GUID_BIM_PROJECT")]
        public BIM_PROJECT? GUID_BIM_PROJECT_BIM_PROJECT { get; set; }
        /// <summary>
        /// FILE_NAME of the BIM_FILE 
        /// </summary>
        public string? FILE_NAME { get; set; }
        /// <summary>
        /// REVISION_COMMENT of the BIM_FILE 
        /// </summary>
        public string? REVISION_COMMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the BIM_FILE 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the BIM_FILE 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// FILE_PATH of the BIM_FILE 
        /// </summary>
        public string? FILE_PATH { get; set; }
        /// <summary>
        /// NOTE of the BIM_FILE 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the BIM_FILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the BIM_FILE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BIM_FILE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the BIM_FILE 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }
        /// <summary>
        /// EXTERNAL_PROCESSING_REVISION_STATUS_ID of the BIM_FILE 
        /// </summary>
        public string? EXTERNAL_PROCESSING_REVISION_STATUS_ID { get; set; }
    }
}