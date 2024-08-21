using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a follow_up entity with essential details
    /// </summary>
    [Table("FOLLOW_UP", Schema = "dbo")]
    public class FOLLOW_UP
    {
        /// <summary>
        /// Initializes a new instance of the FOLLOW_UP class.
        /// </summary>
        public FOLLOW_UP()
        {
            PERIODICITY_UNIT = -1;
            STATUS = -1;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the FOLLOW_UP 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field PERIODICITY_NUMBER of the FOLLOW_UP 
        /// </summary>
        [Required]
        public double PERIODICITY_NUMBER { get; set; }

        /// <summary>
        /// Required field PERIODICITY_UNIT of the FOLLOW_UP 
        /// </summary>
        [Required]
        public int PERIODICITY_UNIT { get; set; }

        /// <summary>
        /// Required field STATUS of the FOLLOW_UP 
        /// </summary>
        [Required]
        public int STATUS { get; set; }

        /// <summary>
        /// UPDATED_DATE of the FOLLOW_UP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the FOLLOW_UP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_RESPONSIBLE_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_RESPONSIBLE_PERSON")]
        public PERSON? GUID_RESPONSIBLE_PERSON_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTACT_PERSON to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_CONTACT_PERSON { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTACT_PERSON
        /// </summary>
        [ForeignKey("GUID_CONTACT_PERSON")]
        public CONTACT_PERSON? GUID_CONTACT_PERSON_CONTACT_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_CONTRACT { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT
        /// </summary>
        [ForeignKey("GUID_CONTRACT")]
        public CONTRACT? GUID_CONTRACT_CONTRACT { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_CUSTOMER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_CUSTOMER")]
        public CUSTOMER? GUID_CUSTOMER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the FOLLOW_UP to which the FOLLOW_UP belongs 
        /// </summary>
        public Guid? GUID_PREVIOUS { get; set; }

        /// <summary>
        /// Navigation property representing the associated FOLLOW_UP
        /// </summary>
        [ForeignKey("GUID_PREVIOUS")]
        public FOLLOW_UP? GUID_PREVIOUS_FOLLOW_UP { get; set; }
        /// <summary>
        /// ID of the FOLLOW_UP 
        /// </summary>
        public string? ID { get; set; }

        /// <summary>
        /// END_DATE of the FOLLOW_UP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }

        /// <summary>
        /// NOTIFICATION_DATE of the FOLLOW_UP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? NOTIFICATION_DATE { get; set; }

        /// <summary>
        /// REGISTRATION_DATE of the FOLLOW_UP 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? REGISTRATION_DATE { get; set; }
        /// <summary>
        /// NOTE of the FOLLOW_UP 
        /// </summary>
        public string? NOTE { get; set; }
    }
}