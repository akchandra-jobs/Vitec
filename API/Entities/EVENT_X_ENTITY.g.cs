using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a event_x_entity entity with essential details
    /// </summary>
    [Table("EVENT_X_ENTITY", Schema = "dbo")]
    public class EVENT_X_ENTITY
    {
        /// <summary>
        /// Initializes a new instance of the EVENT_X_ENTITY class.
        /// </summary>
        public EVENT_X_ENTITY()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the EVENT_X_ENTITY 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the EVENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the EVENT to which the EVENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_EVENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EVENT
        /// </summary>
        [ForeignKey("GUID_EVENT")]
        public EVENT? GUID_EVENT_EVENT { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the EVENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
        /// <summary>
        /// ID of the EVENT_X_ENTITY 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the EVENT_X_ENTITY 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// START_DATE of the EVENT_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the EVENT_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
        /// <summary>
        /// RECURRENCE of the EVENT_X_ENTITY 
        /// </summary>
        public string? RECURRENCE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the EVENT_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EVENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the EVENT_X_ENTITY 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the EVENT_X_ENTITY belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}