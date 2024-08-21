using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a work_order_x_spare_part entity with essential details
    /// </summary>
    [Table("WORK_ORDER_X_SPARE_PART", Schema = "dbo")]
    public class WORK_ORDER_X_SPARE_PART
    {
        /// <summary>
        /// Initializes a new instance of the WORK_ORDER_X_SPARE_PART class.
        /// </summary>
        public WORK_ORDER_X_SPARE_PART()
        {
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field QUANTITY of the WORK_ORDER_X_SPARE_PART 
        /// </summary>
        [Required]
        public double QUANTITY { get; set; }

        /// <summary>
        /// Required field PRICE of the WORK_ORDER_X_SPARE_PART 
        /// </summary>
        [Required]
        public double PRICE { get; set; }

        /// <summary>
        /// Required field QUANTITY_WITHDRAWN of the WORK_ORDER_X_SPARE_PART 
        /// </summary>
        [Required]
        public double QUANTITY_WITHDRAWN { get; set; }

        /// <summary>
        /// Primary key for the WORK_ORDER_X_SPARE_PART 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the WORK_ORDER_X_SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the WORK_ORDER_X_SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the SPARE_PART to which the WORK_ORDER_X_SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_SPARE_PART { get; set; }

        /// <summary>
        /// Navigation property representing the associated SPARE_PART
        /// </summary>
        [ForeignKey("GUID_SPARE_PART")]
        public SPARE_PART? GUID_SPARE_PART_SPARE_PART { get; set; }

        /// <summary>
        /// WITHDRAWAL_DATE of the WORK_ORDER_X_SPARE_PART 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? WITHDRAWAL_DATE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the WORK_ORDER_X_SPARE_PART 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_X_SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the WORK_ORDER_X_SPARE_PART 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the WORK_ORDER_X_SPARE_PART belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}