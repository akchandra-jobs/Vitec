using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contract_adjustment entity with essential details
    /// </summary>
    [Table("CONTRACT_ADJUSTMENT", Schema = "dbo")]
    public class CONTRACT_ADJUSTMENT
    {
        /// <summary>
        /// Initializes a new instance of the CONTRACT_ADJUSTMENT class.
        /// </summary>
        public CONTRACT_ADJUSTMENT()
        {
            IS_PERCENT = false;
            UPDATE_OBJECT_PRICE = false;
            ROUNDING = 0;
            PERIODICITY_UNIT = -1;
            IS_TEMPLATE = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field AMOUNT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public double AMOUNT { get; set; }

        /// <summary>
        /// Required field IS_PERCENT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public bool IS_PERCENT { get; set; }

        /// <summary>
        /// Required field UPDATE_OBJECT_PRICE of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public bool UPDATE_OBJECT_PRICE { get; set; }

        /// <summary>
        /// Required field ROUNDING of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public int ROUNDING { get; set; }

        /// <summary>
        /// Required field PERIODICITY_NUMBER of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public double PERIODICITY_NUMBER { get; set; }

        /// <summary>
        /// Required field PERIODICITY_UNIT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public int PERIODICITY_UNIT { get; set; }

        /// <summary>
        /// Required field IS_TEMPLATE of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public bool IS_TEMPLATE { get; set; }

        /// <summary>
        /// Required field PRICE_SUM_TOTAL_BEFORE_ADJUSTMENT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public double PRICE_SUM_TOTAL_BEFORE_ADJUSTMENT { get; set; }

        /// <summary>
        /// Required field PRICE_SUM_TOTAL_AFTER_ADJUSTMENT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public double PRICE_SUM_TOTAL_AFTER_ADJUSTMENT { get; set; }

        /// <summary>
        /// Required field ROOM_PRICE_BEFORE_ADJUSTMENT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public double ROOM_PRICE_BEFORE_ADJUSTMENT { get; set; }

        /// <summary>
        /// Required field ROOM_PRICE_AFTER_ADJUSTMENT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Required]
        public double ROOM_PRICE_AFTER_ADJUSTMENT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_ADJUSTMENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_ADJUSTMENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ADJUSTMENT to which the CONTRACT_ADJUSTMENT belongs 
        /// </summary>
        public Guid? GUID_PREVIOUS_CONTRACT_ADJUSTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ADJUSTMENT
        /// </summary>
        [ForeignKey("GUID_PREVIOUS_CONTRACT_ADJUSTMENT")]
        public CONTRACT_ADJUSTMENT? GUID_PREVIOUS_CONTRACT_ADJUSTMENT_CONTRACT_ADJUSTMENT { get; set; }

        /// <summary>
        /// REFERENCE_DATE of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REFERENCE_DATE { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CONTRACT_ADJUSTMENT 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// ADJUSTMENT_DATE of the CONTRACT_ADJUSTMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? ADJUSTMENT_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTRACT_ADJUSTMENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the CONTRACT_ADJUSTMENT belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
        /// <summary>
        /// Foreign key referencing the ADJUSTMENT to which the CONTRACT_ADJUSTMENT belongs 
        /// </summary>
        public Guid? GUID_ADJUSTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ADJUSTMENT
        /// </summary>
        [ForeignKey("GUID_ADJUSTMENT")]
        public ADJUSTMENT? GUID_ADJUSTMENT_ADJUSTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the CONTRACT_ADJUSTMENT belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }
    }
}