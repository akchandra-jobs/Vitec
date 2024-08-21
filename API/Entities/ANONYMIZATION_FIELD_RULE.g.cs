using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a anonymization_field_rule entity with essential details
    /// </summary>
    [Table("ANONYMIZATION_FIELD_RULE", Schema = "dbo")]
    public class ANONYMIZATION_FIELD_RULE
    {
        /// <summary>
        /// Initializes a new instance of the ANONYMIZATION_FIELD_RULE class.
        /// </summary>
        public ANONYMIZATION_FIELD_RULE()
        {
            GROUP = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field GROUP of the ANONYMIZATION_FIELD_RULE 
        /// </summary>
        [Required]
        public int GROUP { get; set; }

        /// <summary>
        /// Primary key for the ANONYMIZATION_FIELD_RULE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the REGISTERED_FIELD to which the ANONYMIZATION_FIELD_RULE belongs 
        /// </summary>
        public Guid? GUID_REGISTERED_FIELD { get; set; }

        /// <summary>
        /// Navigation property representing the associated REGISTERED_FIELD
        /// </summary>
        [ForeignKey("GUID_REGISTERED_FIELD")]
        public REGISTERED_FIELD? GUID_REGISTERED_FIELD_REGISTERED_FIELD { get; set; }
        /// <summary>
        /// EXPRESSION of the ANONYMIZATION_FIELD_RULE 
        /// </summary>
        public string? EXPRESSION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ANONYMIZATION_FIELD_RULE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ANONYMIZATION_FIELD_RULE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ANONYMIZATION_FIELD_RULE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ANONYMIZATION_FIELD_RULE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}