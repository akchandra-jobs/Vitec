using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a accounting_x_accounting entity with essential details
    /// </summary>
    [Table("ACCOUNTING_X_ACCOUNTING", Schema = "dbo")]
    public class ACCOUNTING_X_ACCOUNTING
    {
        /// <summary>
        /// Initializes a new instance of the ACCOUNTING_X_ACCOUNTING class.
        /// </summary>
        public ACCOUNTING_X_ACCOUNTING()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the ACCOUNTING_X_ACCOUNTING 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the ACCOUNTING_X_ACCOUNTING belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the ACCOUNTING_X_ACCOUNTING belongs 
        /// </summary>
        public Guid? GUID_PARENT_ACCOUNTING { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_PARENT_ACCOUNTING")]
        public ACCOUNTING? GUID_PARENT_ACCOUNTING_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the ACCOUNTING_X_ACCOUNTING belongs 
        /// </summary>
        public Guid? GUID_CHILD_ACCOUNTING { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_CHILD_ACCOUNTING")]
        public ACCOUNTING? GUID_CHILD_ACCOUNTING_ACCOUNTING { get; set; }

        /// <summary>
        /// UPDATED_DATE of the ACCOUNTING_X_ACCOUNTING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ACCOUNTING_X_ACCOUNTING belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the ACCOUNTING_X_ACCOUNTING 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the ACCOUNTING_X_ACCOUNTING belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}