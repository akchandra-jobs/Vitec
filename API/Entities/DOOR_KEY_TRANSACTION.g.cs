using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a door_key_transaction entity with essential details
    /// </summary>
    [Table("DOOR_KEY_TRANSACTION", Schema = "dbo")]
    public class DOOR_KEY_TRANSACTION
    {
        /// <summary>
        /// Initializes a new instance of the DOOR_KEY_TRANSACTION class.
        /// </summary>
        public DOOR_KEY_TRANSACTION()
        {
            STATUS = -1;
            QUANTITY = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the DOOR_KEY_TRANSACTION 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field STATUS of the DOOR_KEY_TRANSACTION 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// Required field QUANTITY of the DOOR_KEY_TRANSACTION 
        /// </summary>
        [Required]
        public int QUANTITY { get; set; }
        /// <summary>
        /// NOTE of the DOOR_KEY_TRANSACTION 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the DOOR_KEY_TRANSACTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_TRANSACTION belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the DOOR_KEY_TRANSACTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the DOOR_KEY_TRANSACTION belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the DOOR_KEY_TRANSACTION belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DOOR_KEY_X_USER to which the DOOR_KEY_TRANSACTION belongs 
        /// </summary>
        public Guid? GUID_SUPPLY { get; set; }

        /// <summary>
        /// Navigation property representing the associated DOOR_KEY_X_USER
        /// </summary>
        [ForeignKey("GUID_SUPPLY")]
        public DOOR_KEY_X_USER? GUID_SUPPLY_DOOR_KEY_X_USER { get; set; }
        /// <summary>
        /// UNIQUE_KEY_ID of the DOOR_KEY_TRANSACTION 
        /// </summary>
        public string? UNIQUE_KEY_ID { get; set; }

        /// <summary>
        /// SUPPLY_DATE of the DOOR_KEY_TRANSACTION 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? SUPPLY_DATE { get; set; }
    }
}