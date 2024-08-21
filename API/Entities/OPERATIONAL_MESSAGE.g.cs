using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a operational_message entity with essential details
    /// </summary>
    [Table("OPERATIONAL_MESSAGE", Schema = "dbo")]
    public class OPERATIONAL_MESSAGE
    {
        /// <summary>
        /// Initializes a new instance of the OPERATIONAL_MESSAGE class.
        /// </summary>
        public OPERATIONAL_MESSAGE()
        {
            TYPE = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the OPERATIONAL_MESSAGE 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field TYPE of the OPERATIONAL_MESSAGE 
        /// </summary>
        [Required]
        public int TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the EQUIPMENT to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_EQUIPMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated EQUIPMENT
        /// </summary>
        [ForeignKey("GUID_EQUIPMENT")]
        public EQUIPMENT? GUID_EQUIPMENT_EQUIPMENT { get; set; }
        /// <summary>
        /// MESSAGE of the OPERATIONAL_MESSAGE 
        /// </summary>
        public string? MESSAGE { get; set; }

        /// <summary>
        /// DUE_DATE of the OPERATIONAL_MESSAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DUE_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the OPERATIONAL_MESSAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the OPERATIONAL_MESSAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the ESTATE to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_ESTATE { get; set; }

        /// <summary>
        /// Navigation property representing the associated ESTATE
        /// </summary>
        [ForeignKey("GUID_ESTATE")]
        public ESTATE? GUID_ESTATE_ESTATE { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public PERSON? GUID_CONTACT_PERSON_PERSON { get; set; }

        /// <summary>
        /// START_DATE of the OPERATIONAL_MESSAGE 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the OPERATIONAL_MESSAGE belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
    }
}