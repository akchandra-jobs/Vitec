using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a contact_person entity with essential details
    /// </summary>
    [Table("CONTACT_PERSON", Schema = "dbo")]
    public class CONTACT_PERSON
    {
        /// <summary>
        /// Initializes a new instance of the CONTACT_PERSON class.
        /// </summary>
        public CONTACT_PERSON()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the CONTACT_PERSON 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the CONTACT_PERSON belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the CONTACT_PERSON belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the CONTACT_PERSON belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// FIRST_NAME of the CONTACT_PERSON 
        /// </summary>
        public string? FIRST_NAME { get; set; }
        /// <summary>
        /// LAST_NAME of the CONTACT_PERSON 
        /// </summary>
        public string? LAST_NAME { get; set; }
        /// <summary>
        /// ADDRESS of the CONTACT_PERSON 
        /// </summary>
        public string? ADDRESS { get; set; }
        /// <summary>
        /// ADDRESS1 of the CONTACT_PERSON 
        /// </summary>
        public string? ADDRESS1 { get; set; }
        /// <summary>
        /// POSTAL_CODE of the CONTACT_PERSON 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the CONTACT_PERSON 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// COUNTRY of the CONTACT_PERSON 
        /// </summary>
        public string? COUNTRY { get; set; }
        /// <summary>
        /// TELEPHONE of the CONTACT_PERSON 
        /// </summary>
        public string? TELEPHONE { get; set; }
        /// <summary>
        /// TELEFAX of the CONTACT_PERSON 
        /// </summary>
        public string? TELEFAX { get; set; }
        /// <summary>
        /// CELLPHONE of the CONTACT_PERSON 
        /// </summary>
        public string? CELLPHONE { get; set; }
        /// <summary>
        /// PAGER of the CONTACT_PERSON 
        /// </summary>
        public string? PAGER { get; set; }
        /// <summary>
        /// TELEPHONE_PRIVATE of the CONTACT_PERSON 
        /// </summary>
        public string? TELEPHONE_PRIVATE { get; set; }
        /// <summary>
        /// EMAIL of the CONTACT_PERSON 
        /// </summary>
        public string? EMAIL { get; set; }
        /// <summary>
        /// NOTE of the CONTACT_PERSON 
        /// </summary>
        public string? NOTE { get; set; }
        /// <summary>
        /// POSITION of the CONTACT_PERSON 
        /// </summary>
        public string? POSITION { get; set; }

        /// <summary>
        /// UPDATED_DATE of the CONTACT_PERSON 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTACT_PERSON belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the CONTACT_PERSON 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the CONTACT_PERSON belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}