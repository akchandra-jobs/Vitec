using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contract_warranty entity with essential details
    /// </summary>
    [Table("CONTRACT_WARRANTY", Schema = "dbo")]
    public class CONTRACT_WARRANTY
    {
        /// <summary>
        /// Initializes a new instance of the CONTRACT_WARRANTY class.
        /// </summary>
        public CONTRACT_WARRANTY()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTRACT_WARRANTY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field AMOUNT of the CONTRACT_WARRANTY 
        /// </summary>
        [Required]
        public double AMOUNT { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the CONTRACT_WARRANTY 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTRACT_WARRANTY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_WARRANTY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTRACT_WARRANTY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTRACT_WARRANTY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTRACT_WARRANTY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the CONTRACT_WARRANTY belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
        /// <summary>
        /// Foreign key referencing the DOCUMENT to which the CONTRACT_WARRANTY belongs 
        /// </summary>
        public Guid? GUID_DOCUMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOCUMENT
        /// </summary>
        [ForeignKey("GUID_DOCUMENT")]
        public DOCUMENT? GUID_DOCUMENT_DOCUMENT { get; set; }
        /// <summary>
        /// ID of the CONTRACT_WARRANTY 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the CONTRACT_WARRANTY 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// START_DATE of the CONTRACT_WARRANTY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the CONTRACT_WARRANTY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
    }
}