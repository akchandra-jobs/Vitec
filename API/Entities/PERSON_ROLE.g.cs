using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a person_role entity with essential details
    /// </summary>
    [Table("PERSON_ROLE", Schema = "dbo")]
    public class PERSON_ROLE
    {
        /// <summary>
        /// Initializes a new instance of the PERSON_ROLE class.
        /// </summary>
        public PERSON_ROLE()
        {
            IS_FIRE_RELATED = false;
            IS_ELECTRO_RELATED = false;
            IS_HSE_RELATED = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field IS_FIRE_RELATED of the PERSON_ROLE 
        /// </summary>
        [Required]
        public bool IS_FIRE_RELATED { get; set; }

        /// <summary>
        /// Required field IS_ELECTRO_RELATED of the PERSON_ROLE 
        /// </summary>
        [Required]
        public bool IS_ELECTRO_RELATED { get; set; }

        /// <summary>
        /// Primary key for the PERSON_ROLE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_HSE_RELATED of the PERSON_ROLE 
        /// </summary>
        [Required]
        public bool IS_HSE_RELATED { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PERSON_ROLE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// ID of the PERSON_ROLE 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PERSON_ROLE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERSON_ROLE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PERSON_ROLE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERSON_ROLE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}