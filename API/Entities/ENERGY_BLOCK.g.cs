using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a energy_block entity with essential details
    /// </summary>
    [Table("ENERGY_BLOCK", Schema = "dbo")]
    public class ENERGY_BLOCK
    {
        /// <summary>
        /// Initializes a new instance of the ENERGY_BLOCK class.
        /// </summary>
        public ENERGY_BLOCK()
        {
            ID = 0;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field ID of the ENERGY_BLOCK 
        /// </summary>
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// Primary key for the ENERGY_BLOCK 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ENERGY_BLOCK belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ENERGY_DATA_FORMAT to which the ENERGY_BLOCK belongs 
        /// </summary>
        public Guid? GUID_ENERGY_DATA_FORMAT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ENERGY_DATA_FORMAT
        /// </summary>
        [ForeignKey("GUID_ENERGY_DATA_FORMAT")]
        public ENERGY_DATA_FORMAT? GUID_ENERGY_DATA_FORMAT_ENERGY_DATA_FORMAT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the ENERGY_BLOCK belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the ENERGY_BLOCK belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// DESCRIPTION of the ENERGY_BLOCK 
        /// </summary>
        public string? DESCRIPTION { get; set; }
        /// <summary>
        /// DATA_DIRECTORY_OUT of the ENERGY_BLOCK 
        /// </summary>
        public string? DATA_DIRECTORY_OUT { get; set; }
        /// <summary>
        /// DATA_DIRECTORY_IN of the ENERGY_BLOCK 
        /// </summary>
        public string? DATA_DIRECTORY_IN { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ENERGY_BLOCK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_BLOCK belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ENERGY_BLOCK 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ENERGY_BLOCK belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}