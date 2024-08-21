using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a duty_log_event entity with essential details
    /// </summary>
    [Table("DUTY_LOG_EVENT", Schema = "dbo")]
    public class DUTY_LOG_EVENT
    {
        /// <summary>
        /// Initializes a new instance of the DUTY_LOG_EVENT class.
        /// </summary>
        public DUTY_LOG_EVENT()
        {
            IS_LAST_REVISION = false;
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field NUMBER01 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field NUMBER11 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER11 { get; set; }

        /// <summary>
        /// Required field NUMBER12 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER12 { get; set; }

        /// <summary>
        /// Required field NUMBER13 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER13 { get; set; }

        /// <summary>
        /// Required field NUMBER14 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER14 { get; set; }

        /// <summary>
        /// Required field NUMBER15 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER15 { get; set; }

        /// <summary>
        /// Required field NUMBER16 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER16 { get; set; }

        /// <summary>
        /// Required field NUMBER17 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER17 { get; set; }

        /// <summary>
        /// Required field NUMBER18 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER18 { get; set; }

        /// <summary>
        /// Required field NUMBER19 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER19 { get; set; }

        /// <summary>
        /// Required field NUMBER20 of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public double NUMBER20 { get; set; }

        /// <summary>
        /// Required field IS_LAST_REVISION of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public bool IS_LAST_REVISION { get; set; }

        /// <summary>
        /// Primary key for the DUTY_LOG_EVENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the DUTY_LOG_EVENT 
        /// </summary>
        [Required]
        public int ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DUTY_LOG_EVENT 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// OCCURRENCE_DATE of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? OCCURRENCE_DATE { get; set; }

        /// <summary>
        /// CREATED_DATE of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATED_DATE { get; set; }

        /// <summary>
        /// CLOSED_DATE of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CLOSED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the DUTY_LOG_CATEGORY to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_DUTY_LOG_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DUTY_LOG_CATEGORY
        /// </summary>
        [ForeignKey("GUID_DUTY_LOG_CATEGORY")]
        public DUTY_LOG_CATEGORY? GUID_DUTY_LOG_CATEGORY_DUTY_LOG_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the DUTY_LOG to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_DUTY_LOG { get; set; }

        /// <summary>
        /// Navigation property representing the associated DUTY_LOG
        /// </summary>
        [ForeignKey("GUID_DUTY_LOG")]
        public DUTY_LOG? GUID_DUTY_LOG_DUTY_LOG { get; set; }
        /// <summary>
        /// TEXT01 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// DATE01 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }
        /// <summary>
        /// COMBO01 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the DUTY_LOG_EVENT 
        /// </summary>
        public string? COMBO20 { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DUTY_LOG_EVENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DUTY_LOG_EVENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}