using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a supplier_agreement entity with essential details
    /// </summary>
    [Table("SUPPLIER_AGREEMENT", Schema = "dbo")]
    public class SUPPLIER_AGREEMENT
    {
        /// <summary>
        /// Initializes a new instance of the SUPPLIER_AGREEMENT class.
        /// </summary>
        public SUPPLIER_AGREEMENT()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the SUPPLIER_AGREEMENT 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field AMOUNT of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Required]
        public double AMOUNT { get; set; }

        /// <summary>
        /// Required field SUM_ALLOCATED of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Required]
        public double SUM_ALLOCATED { get; set; }

        /// <summary>
        /// Required field SUM_ORDERED of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Required]
        public double SUM_ORDERED { get; set; }

        /// <summary>
        /// Required field SUM_INVOICED of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Required]
        public double SUM_INVOICED { get; set; }
        /// <summary>
        /// NOTE of the SUPPLIER_AGREEMENT 
        /// </summary>
        public string? NOTE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SUPPLIER_AGREEMENT belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the SUPPLIER_AGREEMENT belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the SUPPLIER_AGREEMENT belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the SUPPLIER to which the SUPPLIER_AGREEMENT belongs 
        /// </summary>
        public Guid? GUID_SUPPLIER { get; set; }

        /// <summary>
        /// Navigation property representing the associated SUPPLIER
        /// </summary>
        [ForeignKey("GUID_SUPPLIER")]
        public SUPPLIER? GUID_SUPPLIER_SUPPLIER { get; set; }
        /// <summary>
        /// Foreign key referencing the PAYMENT_TERM to which the SUPPLIER_AGREEMENT belongs 
        /// </summary>
        public Guid? GUID_PAYMENT_TERM { get; set; }

        /// <summary>
        /// Navigation property representing the associated PAYMENT_TERM
        /// </summary>
        [ForeignKey("GUID_PAYMENT_TERM")]
        public PAYMENT_TERM? GUID_PAYMENT_TERM_PAYMENT_TERM { get; set; }
        /// <summary>
        /// ID of the SUPPLIER_AGREEMENT 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the SUPPLIER_AGREEMENT 
        /// </summary>
        public string? DESCRIPTION { get; set; }

        /// <summary>
        /// START_DATE of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? START_DATE { get; set; }

        /// <summary>
        /// END_DATE of the SUPPLIER_AGREEMENT 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? END_DATE { get; set; }
    }
}