using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a budget entity with essential details
    /// </summary>
    [Table("BUDGET", Schema = "dbo")]
    public class BUDGET
    {
        /// <summary>
        /// Initializes a new instance of the BUDGET class.
        /// </summary>
        public BUDGET()
        {
            YEAR = 0;
            IS_OPERATIONAL_COST = false;
            SUM_DIRTY_FLAG = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Required field YEAR of the BUDGET 
        /// </summary>
        [Required]
        public int YEAR { get; set; }

        /// <summary>
        /// Required field SUM_BUDGET of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_BUDGET { get; set; }

        /// <summary>
        /// Required field IS_OPERATIONAL_COST of the BUDGET 
        /// </summary>
        [Required]
        public bool IS_OPERATIONAL_COST { get; set; }

        /// <summary>
        /// Required field SUM_SPECIFIED of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_SPECIFIED { get; set; }

        /// <summary>
        /// Required field SUM_NOT_SPECIFIED of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_NOT_SPECIFIED { get; set; }

        /// <summary>
        /// Required field SUM_ALLOCATED of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_ALLOCATED { get; set; }

        /// <summary>
        /// Required field SUM_COST of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_COST { get; set; }

        /// <summary>
        /// Required field SUM_FOR_DISPOSAL of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_FOR_DISPOSAL { get; set; }

        /// <summary>
        /// Required field SUM_REST_SPECIFIED of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_REST_SPECIFIED { get; set; }

        /// <summary>
        /// Required field SUM_REST_NOT_SPECIFIED of the BUDGET 
        /// </summary>
        [Required]
        public double SUM_REST_NOT_SPECIFIED { get; set; }

        /// <summary>
        /// Required field BUDGET_JAN of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_JAN { get; set; }

        /// <summary>
        /// Required field COST_JAN of the BUDGET 
        /// </summary>
        [Required]
        public double COST_JAN { get; set; }

        /// <summary>
        /// Required field ALLOCATED_JAN of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_JAN { get; set; }

        /// <summary>
        /// Required field BUDGET_FEB of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_FEB { get; set; }

        /// <summary>
        /// Required field COST_FEB of the BUDGET 
        /// </summary>
        [Required]
        public double COST_FEB { get; set; }

        /// <summary>
        /// Required field ALLOCATED_FEB of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_FEB { get; set; }

        /// <summary>
        /// Required field BUDGET_MAR of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_MAR { get; set; }

        /// <summary>
        /// Required field COST_MAR of the BUDGET 
        /// </summary>
        [Required]
        public double COST_MAR { get; set; }

        /// <summary>
        /// Required field ALLOCATED_MAR of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_MAR { get; set; }

        /// <summary>
        /// Required field BUDGET_APR of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_APR { get; set; }

        /// <summary>
        /// Required field COST_APR of the BUDGET 
        /// </summary>
        [Required]
        public double COST_APR { get; set; }

        /// <summary>
        /// Required field ALLOCATED_APR of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_APR { get; set; }

        /// <summary>
        /// Required field BUDGET_MAY of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_MAY { get; set; }

        /// <summary>
        /// Required field COST_MAY of the BUDGET 
        /// </summary>
        [Required]
        public double COST_MAY { get; set; }

        /// <summary>
        /// Required field ALLOCATED_MAY of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_MAY { get; set; }

        /// <summary>
        /// Required field BUDGET_JUN of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_JUN { get; set; }

        /// <summary>
        /// Required field COST_JUN of the BUDGET 
        /// </summary>
        [Required]
        public double COST_JUN { get; set; }

        /// <summary>
        /// Required field ALLOCATED_JUN of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_JUN { get; set; }

        /// <summary>
        /// Required field BUDGET_JUL of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_JUL { get; set; }

        /// <summary>
        /// Required field COST_JUL of the BUDGET 
        /// </summary>
        [Required]
        public double COST_JUL { get; set; }

        /// <summary>
        /// Required field ALLOCATED_JUL of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_JUL { get; set; }

        /// <summary>
        /// Required field BUDGET_AUG of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_AUG { get; set; }

        /// <summary>
        /// Required field COST_AUG of the BUDGET 
        /// </summary>
        [Required]
        public double COST_AUG { get; set; }

        /// <summary>
        /// Required field ALLOCATED_AUG of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_AUG { get; set; }

        /// <summary>
        /// Required field BUDGET_SEP of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_SEP { get; set; }

        /// <summary>
        /// Required field COST_SEP of the BUDGET 
        /// </summary>
        [Required]
        public double COST_SEP { get; set; }

        /// <summary>
        /// Required field ALLOCATED_SEP of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_SEP { get; set; }

        /// <summary>
        /// Required field BUDGET_OCT of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_OCT { get; set; }

        /// <summary>
        /// Required field COST_OCT of the BUDGET 
        /// </summary>
        [Required]
        public double COST_OCT { get; set; }

        /// <summary>
        /// Required field ALLOCATED_OCT of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_OCT { get; set; }

        /// <summary>
        /// Required field BUDGET_NOV of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_NOV { get; set; }

        /// <summary>
        /// Required field COST_NOV of the BUDGET 
        /// </summary>
        [Required]
        public double COST_NOV { get; set; }

        /// <summary>
        /// Required field ALLOCATED_NOV of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_NOV { get; set; }

        /// <summary>
        /// Required field BUDGET_DEC of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_DEC { get; set; }

        /// <summary>
        /// Required field COST_DEC of the BUDGET 
        /// </summary>
        [Required]
        public double COST_DEC { get; set; }

        /// <summary>
        /// Required field ALLOCATED_DEC of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_DEC { get; set; }

        /// <summary>
        /// Required field BUDGET_QUARTER_1 of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_QUARTER_1 { get; set; }

        /// <summary>
        /// Required field COST_QUARTER_1 of the BUDGET 
        /// </summary>
        [Required]
        public double COST_QUARTER_1 { get; set; }

        /// <summary>
        /// Required field ALLOCATED_QUARTER_1 of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_QUARTER_1 { get; set; }

        /// <summary>
        /// Required field BUDGET_QUARTER_2 of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_QUARTER_2 { get; set; }

        /// <summary>
        /// Required field COST_QUARTER_2 of the BUDGET 
        /// </summary>
        [Required]
        public double COST_QUARTER_2 { get; set; }

        /// <summary>
        /// Required field ALLOCATED_QUARTER_2 of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_QUARTER_2 { get; set; }

        /// <summary>
        /// Required field BUDGET_QUARTER_3 of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_QUARTER_3 { get; set; }

        /// <summary>
        /// Required field COST_QUARTER_3 of the BUDGET 
        /// </summary>
        [Required]
        public double COST_QUARTER_3 { get; set; }

        /// <summary>
        /// Required field ALLOCATED_QUARTER_3 of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_QUARTER_3 { get; set; }

        /// <summary>
        /// Required field BUDGET_QUARTER_4 of the BUDGET 
        /// </summary>
        [Required]
        public double BUDGET_QUARTER_4 { get; set; }

        /// <summary>
        /// Required field COST_QUARTER_4 of the BUDGET 
        /// </summary>
        [Required]
        public double COST_QUARTER_4 { get; set; }

        /// <summary>
        /// Required field ALLOCATED_QUARTER_4 of the BUDGET 
        /// </summary>
        [Required]
        public double ALLOCATED_QUARTER_4 { get; set; }

        /// <summary>
        /// Required field SUM_DIRTY_FLAG of the BUDGET 
        /// </summary>
        [Required]
        public bool SUM_DIRTY_FLAG { get; set; }

        /// <summary>
        /// Primary key for the BUDGET 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING0 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING0")]
        public ACCOUNTING? GUID_ACCOUNTING0_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING1 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING1")]
        public ACCOUNTING? GUID_ACCOUNTING1_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING2 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING2")]
        public ACCOUNTING? GUID_ACCOUNTING2_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING3 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING3")]
        public ACCOUNTING? GUID_ACCOUNTING3_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNTING to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_ACCOUNTING4 { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNTING
        /// </summary>
        [ForeignKey("GUID_ACCOUNTING4")]
        public ACCOUNTING? GUID_ACCOUNTING4_ACCOUNTING { get; set; }
        /// <summary>
        /// Foreign key referencing the SERVICE to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_SERVICE { get; set; }

        /// <summary>
        /// Navigation property representing the associated SERVICE
        /// </summary>
        [ForeignKey("GUID_SERVICE")]
        public SERVICE? GUID_SERVICE_SERVICE { get; set; }

        /// <summary>
        /// UPDATED_DATE of the BUDGET 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the BUDGET 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the BUDGET belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
    }
}