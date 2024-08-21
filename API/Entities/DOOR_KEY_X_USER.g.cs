using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a door_key_x_user entity with essential details
    /// </summary>
    [Table("DOOR_KEY_X_USER", Schema = "dbo")]
    public class DOOR_KEY_X_USER
    {
        /// <summary>
        /// Initializes a new instance of the DOOR_KEY_X_USER class.
        /// </summary>
        public DOOR_KEY_X_USER()
        {
            QUANTITY = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOOR_KEY_X_USER 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field QUANTITY of the DOOR_KEY_X_USER 
        /// </summary>
        [Required]
        public int QUANTITY { get; set; }
        /// <summary>
        /// NOTE of the DOOR_KEY_X_USER 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOOR_KEY_X_USER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_X_USER belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOOR_KEY_X_USER 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_X_USER belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOOR_KEY_X_USER belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_KEY to which the DOOR_KEY_X_USER belongs 
        /// </summary>
        public Guid? GUID_DOOR_KEY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_KEY
        /// </summary>
        [ForeignKey("GUID_DOOR_KEY")]
        public DOOR_KEY? GUID_DOOR_KEY_DOOR_KEY { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the DOOR_KEY_X_USER belongs 
        /// </summary>
        public Guid? GUID_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_PERSON")]
        public PERSON? GUID_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the DOOR_KEY_X_USER belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// ID of the DOOR_KEY_X_USER 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the DOOR_KEY_X_USER 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}