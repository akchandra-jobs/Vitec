using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a data_import entity with essential details
    /// </summary>
    [Table("DATA_IMPORT", Schema = "dbo")]
    public class DATA_IMPORT
    {
        /// <summary>
        /// Initializes a new instance of the DATA_IMPORT class.
        /// </summary>
        public DATA_IMPORT()
        {
            ENTITY_TYPE = -1;
            STATUS = -1;
            RUN_MODE = -1;
            SKIP_MANDATORY_FIELDS = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ENTITY_TYPE of the DATA_IMPORT 
        /// </summary>
        [Required]
        public int ENTITY_TYPE { get; set; }

        /// <summary>
        /// Required field STATUS of the DATA_IMPORT 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field RUN_MODE of the DATA_IMPORT 
        /// </summary>
        [Required]
        public int RUN_MODE { get; set; }

        /// <summary>
        /// Required field SKIP_MANDATORY_FIELDS of the DATA_IMPORT 
        /// </summary>
        [Required]
        public bool SKIP_MANDATORY_FIELDS { get; set; }

        /// <summary>
        /// Primary key for the DATA_IMPORT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DATA_IMPORT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the BINARY_DATA to which the DATA_IMPORT belongs 
        /// </summary>
        public Guid? GUID_BINARY_DATA { get; set; }

        /// <summary>
        /// Navigation property representing the associated BINARY_DATA
        /// </summary>
        [ForeignKey("GUID_BINARY_DATA")]
        public BINARY_DATA? GUID_BINARY_DATA_BINARY_DATA { get; set; }
        /// <summary>
        /// ID of the DATA_IMPORT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DATA_IMPORT 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// INPUT_CONFIG_JSON of the DATA_IMPORT 
        /// </summary>
        public string? INPUT_CONFIG_JSON { get; set; }
        /// <summary>
        /// FIELD_MAPPING_JSON of the DATA_IMPORT 
        /// </summary>
        public string? FIELD_MAPPING_JSON { get; set; }
        /// <summary>
        /// PRIMARY_FIELD of the DATA_IMPORT 
        /// </summary>
        public string? PRIMARY_FIELD { get; set; }
        /// <summary>
        /// STATUS_MESSAGE of the DATA_IMPORT 
        /// </summary>
        public string? STATUS_MESSAGE { get; set; }
        /// <summary>
        /// SUMMARY of the DATA_IMPORT 
        /// </summary>
        public string? SUMMARY { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DATA_IMPORT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DATA_IMPORT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DATA_IMPORT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DATA_IMPORT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// VALIDATION_SUMMARY of the DATA_IMPORT 
        /// </summary>
        public string? VALIDATION_SUMMARY { get; set; }
    }
}