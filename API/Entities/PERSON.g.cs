using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a person entity with essential details
    /// </summary>
    [Table("PERSON", Schema = "dbo")]
    public class PERSON
    {
        /// <summary>
        /// Initializes a new instance of the PERSON class.
        /// </summary>
        public PERSON()
        {
            IS_OPERATIONS_MANAGER = false;
            IS_DEACTIVATED = false;
            DOES_CLEANING_TASKS = false;
            DOES_MAINTENANCE_TASKS = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the PERSON 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field IS_OPERATIONS_MANAGER of the PERSON 
        /// </summary>
        [Required]
        public bool IS_OPERATIONS_MANAGER { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the PERSON 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field HOURS of the PERSON 
        /// </summary>
        [Required]
        public double HOURS { get; set; }

        /// <summary>
        /// Required field DOES_CLEANING_TASKS of the PERSON 
        /// </summary>
        [Required]
        public bool DOES_CLEANING_TASKS { get; set; }

        /// <summary>
        /// Required field DOES_MAINTENANCE_TASKS of the PERSON 
        /// </summary>
        [Required]
        public bool DOES_MAINTENANCE_TASKS { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the PERSON 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// WORKING_HOURS_RULES of the PERSON 
        /// </summary>
        public string? WORKING_HOURS_RULES { get; set; }

        /// <summary>
        /// UPDATED_DATE of the PERSON 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the PERSON 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION_SECTION to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION_SECTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION_SECTION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION_SECTION")]
        public ORGANIZATION_SECTION? GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION_UNIT to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION_UNIT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION_UNIT
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION_UNIT")]
        public ORGANIZATION_UNIT? GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT { get; set; }
        /// <summary>
        /// EXTERNAL_ID of the PERSON 
        /// </summary>
        public string? EXTERNAL_ID { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the DEPARTMENT to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_DEPARTMENT { get; set; }

        /// <summary>
        /// Navigation property representing the associated DEPARTMENT
        /// </summary>
        [ForeignKey("GUID_DEPARTMENT")]
        public DEPARTMENT? GUID_DEPARTMENT_DEPARTMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA")]
        public AREA? GUID_AREA_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_RESOURCE_GROUP")]
        public RESOURCE_GROUP? GUID_RESOURCE_GROUP_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION")]
        public ORGANIZATION? GUID_ORGANIZATION_ORGANIZATION { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON_ROLE to which the PERSON belongs 
        /// </summary>
        public Guid? GUID_PERSON_ROLE { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON_ROLE
        /// </summary>
        [ForeignKey("GUID_PERSON_ROLE")]
        public PERSON_ROLE? GUID_PERSON_ROLE_PERSON_ROLE { get; set; }
        /// <summary>
        /// EMPLOYEE_NR of the PERSON 
        /// </summary>
        public string? EMPLOYEE_NR { get; set; }
        /// <summary>
        /// FIRST_NAME of the PERSON 
        /// </summary>
        public string? FIRST_NAME { get; set; }
        /// <summary>
        /// LAST_NAME of the PERSON 
        /// </summary>
        public string? LAST_NAME { get; set; }
        /// <summary>
        /// PARKING of the PERSON 
        /// </summary>
        public string? PARKING { get; set; }
        /// <summary>
        /// TELEPHONE_PRIVATE of the PERSON 
        /// </summary>
        public string? TELEPHONE_PRIVATE { get; set; }
        /// <summary>
        /// TELEPHONE_WORK of the PERSON 
        /// </summary>
        public string? TELEPHONE_WORK { get; set; }
        /// <summary>
        /// CELLPHONE of the PERSON 
        /// </summary>
        public string? CELLPHONE { get; set; }
        /// <summary>
        /// PAGER of the PERSON 
        /// </summary>
        public string? PAGER { get; set; }
        /// <summary>
        /// EMAIL of the PERSON 
        /// </summary>
        public string? EMAIL { get; set; }
        /// <summary>
        /// POSITION of the PERSON 
        /// </summary>
        public string? POSITION { get; set; }
        /// <summary>
        /// ADDRESS of the PERSON 
        /// </summary>
        public string? ADDRESS { get; set; }
        /// <summary>
        /// POSTAL_CODE of the PERSON 
        /// </summary>
        public string? POSTAL_CODE { get; set; }
        /// <summary>
        /// POSTAL_AREA of the PERSON 
        /// </summary>
        public string? POSTAL_AREA { get; set; }
        /// <summary>
        /// COUNTRY of the PERSON 
        /// </summary>
        public string? COUNTRY { get; set; }
    }
}