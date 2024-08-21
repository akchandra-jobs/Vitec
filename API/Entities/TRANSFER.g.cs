using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a transfer entity with essential details
    /// </summary>
    [Table("TRANSFER", Schema = "dbo")]
    public class TRANSFER
    {
        /// <summary>
        /// Initializes a new instance of the TRANSFER class.
        /// </summary>
        public TRANSFER()
        {
            ID = 0;
            STATUS = -1;
            NUMBER_OF_RECORDS = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the TRANSFER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field ID of the TRANSFER 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Required field STATUS of the TRANSFER 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field NUMBER_OF_RECORDS of the TRANSFER 
        /// </summary>
        [Required]
        public int NUMBER_OF_RECORDS { get; set; }

        /// <summary>
        /// GENERATED_DATE of the TRANSFER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? GENERATED_DATE { get; set; }

        /// <summary>
        /// APPROVED_DATE of the TRANSFER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? APPROVED_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the TRANSFER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TRANSFER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the TRANSFER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TRANSFER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// NOTE of the TRANSFER 
        /// </summary>
        public string? NOTE { get; set; }
        /// <summary>
        /// DESCRIPTION of the TRANSFER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// FILENAME of the TRANSFER 
        /// </summary>
        public string? FILENAME { get; set; }
        /// <summary>
        /// FILEPATH of the TRANSFER 
        /// </summary>
        public string? FILEPATH { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the TRANSFER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TRANSFER belongs 
        /// </summary>
        public Guid? GUID_USER_GENERATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_GENERATED_BY")]
        public USR? GUID_USER_GENERATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the TRANSFER belongs 
        /// </summary>
        public Guid? GUID_USER_APPROVED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_APPROVED_BY")]
        public USR? GUID_USER_APPROVED_BY_USR { get; set; }
    }
}