using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Vitec.Entities
{
#pragma warning disable
    /// <summary> 
    /// Represents a area entity with essential details
    /// </summary>
    [Table("AREA", Schema = "dbo")]
    public class AREA
    {
        /// <summary>
        /// Initializes a new instance of the AREA class.
        /// </summary>
        public AREA()
        {
            COMPUTED_NET_AREA = 0M;
            COMPUTED_GROSS_AREA = 0M;
            COMMON_STATUS = -1;
            CAPACITY_BEARING = false;
            FONT_SIZE = 0;
            FONT_ANGLE = 0;
            RENTAL_STATUS = 0;
            POLYGON_STATUS = 0;
            IS_BOOKING = false;
            IS_GROUP = false;
            CAN_BE_SHARED = false;
            CAN_BE_RENTED_OUT = false;
            IS_HOUSING = false;
            AVAILABILITY_CAUSE = -1;
            MUST_CORRECT_DRAWING = false;
            IS_PRICE_PER_SQUARE_METER = false;
            USES_UNDERUTILIZATION = false;
            IS_DEACTIVATED = false;
            IS_VALID_CLASSIFICATION = false;
            UPDATED_DATE = DateTime.UtcNow;
            CREATION_DATE = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary key for the AREA 
        /// </summary>
        [Key]
        [Required]
        public Guid GUID { get; set; }

        /// <summary>
        /// Required field COMPUTED_NET_AREA of the AREA 
        /// </summary>
        [Required]
        public decimal COMPUTED_NET_AREA { get; set; }

        /// <summary>
        /// Required field COMPUTED_GROSS_AREA of the AREA 
        /// </summary>
        [Required]
        public decimal COMPUTED_GROSS_AREA { get; set; }

        /// <summary>
        /// Required field ESTIMATE of the AREA 
        /// </summary>
        [Required]
        public double ESTIMATE { get; set; }

        /// <summary>
        /// Required field PRICE of the AREA 
        /// </summary>
        [Required]
        public double PRICE { get; set; }

        /// <summary>
        /// Required field COMMON_STATUS of the AREA 
        /// </summary>
        [Required]
        public int COMMON_STATUS { get; set; }

        /// <summary>
        /// Required field HIRE_PRICE of the AREA 
        /// </summary>
        [Required]
        public double HIRE_PRICE { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_PRICE { get; set; }

        /// <summary>
        /// Required field CAPACITY_BEARING of the AREA 
        /// </summary>
        [Required]
        public bool CAPACITY_BEARING { get; set; }

        /// <summary>
        /// Required field NUMBER01 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER01 { get; set; }

        /// <summary>
        /// Required field NUMBER02 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER02 { get; set; }

        /// <summary>
        /// Required field NUMBER03 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER03 { get; set; }

        /// <summary>
        /// Required field NUMBER04 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER04 { get; set; }

        /// <summary>
        /// Required field NUMBER05 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER05 { get; set; }

        /// <summary>
        /// Required field NUMBER06 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER06 { get; set; }

        /// <summary>
        /// Required field NUMBER07 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER07 { get; set; }

        /// <summary>
        /// Required field NUMBER08 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER08 { get; set; }

        /// <summary>
        /// Required field NUMBER09 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER09 { get; set; }

        /// <summary>
        /// Required field NUMBER10 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER10 { get; set; }

        /// <summary>
        /// Required field REFERENCE_POINT_X of the AREA 
        /// </summary>
        [Required]
        public double REFERENCE_POINT_X { get; set; }

        /// <summary>
        /// Required field REFERENCE_POINT_Y of the AREA 
        /// </summary>
        [Required]
        public double REFERENCE_POINT_Y { get; set; }

        /// <summary>
        /// Required field RENTAL_AREA of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_AREA { get; set; }

        /// <summary>
        /// Required field FONT_SIZE of the AREA 
        /// </summary>
        [Required]
        public int FONT_SIZE { get; set; }

        /// <summary>
        /// Required field FONT_ANGLE of the AREA 
        /// </summary>
        [Required]
        public int FONT_ANGLE { get; set; }

        /// <summary>
        /// Required field RENTAL_STATUS of the AREA 
        /// </summary>
        [Required]
        public int RENTAL_STATUS { get; set; }

        /// <summary>
        /// Required field POLYGON_STATUS of the AREA 
        /// </summary>
        [Required]
        public int POLYGON_STATUS { get; set; }

        /// <summary>
        /// Required field IS_BOOKING of the AREA 
        /// </summary>
        [Required]
        public bool IS_BOOKING { get; set; }

        /// <summary>
        /// Required field IS_GROUP of the AREA 
        /// </summary>
        [Required]
        public bool IS_GROUP { get; set; }

        /// <summary>
        /// Required field CAN_BE_SHARED of the AREA 
        /// </summary>
        [Required]
        public bool CAN_BE_SHARED { get; set; }

        /// <summary>
        /// Required field CAN_BE_RENTED_OUT of the AREA 
        /// </summary>
        [Required]
        public bool CAN_BE_RENTED_OUT { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_YEAR of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_YEAR { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_MONTH of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_MONTH { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_DAY of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_DAY { get; set; }

        /// <summary>
        /// Required field IS_HOUSING of the AREA 
        /// </summary>
        [Required]
        public bool IS_HOUSING { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_YEAR_TOTAL of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_YEAR_TOTAL { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_MONTH_TOTAL of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_MONTH_TOTAL { get; set; }

        /// <summary>
        /// Required field RENTAL_PRICE_PER_DAY_TOTAL of the AREA 
        /// </summary>
        [Required]
        public double RENTAL_PRICE_PER_DAY_TOTAL { get; set; }

        /// <summary>
        /// Required field AVAILABILITY_CAUSE of the AREA 
        /// </summary>
        [Required]
        public int AVAILABILITY_CAUSE { get; set; }

        /// <summary>
        /// Required field MUST_CORRECT_DRAWING of the AREA 
        /// </summary>
        [Required]
        public bool MUST_CORRECT_DRAWING { get; set; }

        /// <summary>
        /// Required field ESTIMATED_TIME of the AREA 
        /// </summary>
        [Required]
        public double ESTIMATED_TIME { get; set; }

        /// <summary>
        /// Required field ESTIMATED_COST of the AREA 
        /// </summary>
        [Required]
        public double ESTIMATED_COST { get; set; }

        /// <summary>
        /// Required field FULL_TIME_EQUIVALENT of the AREA 
        /// </summary>
        [Required]
        public double FULL_TIME_EQUIVALENT { get; set; }

        /// <summary>
        /// Required field REAL_CAPACITY of the AREA 
        /// </summary>
        [Required]
        public double REAL_CAPACITY { get; set; }

        /// <summary>
        /// Required field CALCULATED_CAPACITY of the AREA 
        /// </summary>
        [Required]
        public double CALCULATED_CAPACITY { get; set; }

        /// <summary>
        /// Required field IS_PRICE_PER_SQUARE_METER of the AREA 
        /// </summary>
        [Required]
        public bool IS_PRICE_PER_SQUARE_METER { get; set; }

        /// <summary>
        /// Required field USES_UNDERUTILIZATION of the AREA 
        /// </summary>
        [Required]
        public bool USES_UNDERUTILIZATION { get; set; }

        /// <summary>
        /// Required field IS_DEACTIVATED of the AREA 
        /// </summary>
        [Required]
        public bool IS_DEACTIVATED { get; set; }

        /// <summary>
        /// Required field NUMBER11 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER11 { get; set; }

        /// <summary>
        /// Required field NUMBER12 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER12 { get; set; }

        /// <summary>
        /// Required field NUMBER13 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER13 { get; set; }

        /// <summary>
        /// Required field NUMBER14 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER14 { get; set; }

        /// <summary>
        /// Required field NUMBER15 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER15 { get; set; }

        /// <summary>
        /// Required field NUMBER16 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER16 { get; set; }

        /// <summary>
        /// Required field NUMBER17 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER17 { get; set; }

        /// <summary>
        /// Required field NUMBER18 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER18 { get; set; }

        /// <summary>
        /// Required field NUMBER19 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER19 { get; set; }

        /// <summary>
        /// Required field NUMBER20 of the AREA 
        /// </summary>
        [Required]
        public double NUMBER20 { get; set; }

        /// <summary>
        /// Required field IS_VALID_CLASSIFICATION of the AREA 
        /// </summary>
        [Required]
        public bool IS_VALID_CLASSIFICATION { get; set; }

        /// <summary>
        /// Required field PROPERTY_REGISTRATION_NUMBER of the AREA 
        /// </summary>
        [Required]
        public string PROPERTY_REGISTRATION_NUMBER { get; set; }
        /// <summary>
        /// MUST_CORRECT_DRAWING_COMMENT of the AREA 
        /// </summary>
        public string? MUST_CORRECT_DRAWING_COMMENT { get; set; }
        /// <summary>
        /// TEXT21 of the AREA 
        /// </summary>
        public string? TEXT21 { get; set; }
        /// <summary>
        /// TEXT22 of the AREA 
        /// </summary>
        public string? TEXT22 { get; set; }
        /// <summary>
        /// TEXT23 of the AREA 
        /// </summary>
        public string? TEXT23 { get; set; }
        /// <summary>
        /// TEXT24 of the AREA 
        /// </summary>
        public string? TEXT24 { get; set; }
        /// <summary>
        /// TEXT25 of the AREA 
        /// </summary>
        public string? TEXT25 { get; set; }
        /// <summary>
        /// TEXT26 of the AREA 
        /// </summary>
        public string? TEXT26 { get; set; }
        /// <summary>
        /// TEXT27 of the AREA 
        /// </summary>
        public string? TEXT27 { get; set; }
        /// <summary>
        /// TEXT28 of the AREA 
        /// </summary>
        public string? TEXT28 { get; set; }
        /// <summary>
        /// TEXT29 of the AREA 
        /// </summary>
        public string? TEXT29 { get; set; }
        /// <summary>
        /// TEXT30 of the AREA 
        /// </summary>
        public string? TEXT30 { get; set; }
        /// <summary>
        /// COMBO31 of the AREA 
        /// </summary>
        public string? COMBO31 { get; set; }
        /// <summary>
        /// COMBO32 of the AREA 
        /// </summary>
        public string? COMBO32 { get; set; }
        /// <summary>
        /// COMBO33 of the AREA 
        /// </summary>
        public string? COMBO33 { get; set; }
        /// <summary>
        /// COMBO34 of the AREA 
        /// </summary>
        public string? COMBO34 { get; set; }
        /// <summary>
        /// COMBO35 of the AREA 
        /// </summary>
        public string? COMBO35 { get; set; }
        /// <summary>
        /// COMBO36 of the AREA 
        /// </summary>
        public string? COMBO36 { get; set; }
        /// <summary>
        /// COMBO37 of the AREA 
        /// </summary>
        public string? COMBO37 { get; set; }
        /// <summary>
        /// COMBO38 of the AREA 
        /// </summary>
        public string? COMBO38 { get; set; }
        /// <summary>
        /// COMBO39 of the AREA 
        /// </summary>
        public string? COMBO39 { get; set; }
        /// <summary>
        /// COMBO40 of the AREA 
        /// </summary>
        public string? COMBO40 { get; set; }
        /// <summary>
        /// COMBO41 of the AREA 
        /// </summary>
        public string? COMBO41 { get; set; }
        /// <summary>
        /// COMBO42 of the AREA 
        /// </summary>
        public string? COMBO42 { get; set; }
        /// <summary>
        /// COMBO43 of the AREA 
        /// </summary>
        public string? COMBO43 { get; set; }
        /// <summary>
        /// COMBO44 of the AREA 
        /// </summary>
        public string? COMBO44 { get; set; }
        /// <summary>
        /// COMBO45 of the AREA 
        /// </summary>
        public string? COMBO45 { get; set; }
        /// <summary>
        /// COMBO46 of the AREA 
        /// </summary>
        public string? COMBO46 { get; set; }
        /// <summary>
        /// COMBO47 of the AREA 
        /// </summary>
        public string? COMBO47 { get; set; }
        /// <summary>
        /// COMBO48 of the AREA 
        /// </summary>
        public string? COMBO48 { get; set; }
        /// <summary>
        /// COMBO49 of the AREA 
        /// </summary>
        public string? COMBO49 { get; set; }
        /// <summary>
        /// COMBO50 of the AREA 
        /// </summary>
        public string? COMBO50 { get; set; }
        /// <summary>
        /// COMBO51 of the AREA 
        /// </summary>
        public string? COMBO51 { get; set; }
        /// <summary>
        /// COMBO52 of the AREA 
        /// </summary>
        public string? COMBO52 { get; set; }
        /// <summary>
        /// COMBO53 of the AREA 
        /// </summary>
        public string? COMBO53 { get; set; }
        /// <summary>
        /// COMBO54 of the AREA 
        /// </summary>
        public string? COMBO54 { get; set; }
        /// <summary>
        /// COMBO55 of the AREA 
        /// </summary>
        public string? COMBO55 { get; set; }
        /// <summary>
        /// COMBO56 of the AREA 
        /// </summary>
        public string? COMBO56 { get; set; }
        /// <summary>
        /// COMBO57 of the AREA 
        /// </summary>
        public string? COMBO57 { get; set; }
        /// <summary>
        /// COMBO58 of the AREA 
        /// </summary>
        public string? COMBO58 { get; set; }
        /// <summary>
        /// COMBO59 of the AREA 
        /// </summary>
        public string? COMBO59 { get; set; }
        /// <summary>
        /// COMBO60 of the AREA 
        /// </summary>
        public string? COMBO60 { get; set; }
        /// <summary>
        /// GLOBAL_LOCATION_NUMBER of the AREA 
        /// </summary>
        public string? GLOBAL_LOCATION_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_CADASTRAL_NUMBER of the AREA 
        /// </summary>
        public string? PROPERTY_CADASTRAL_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_UNIT_NUMBER of the AREA 
        /// </summary>
        public string? PROPERTY_UNIT_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_LEASEHOLD_NUMBER of the AREA 
        /// </summary>
        public string? PROPERTY_LEASEHOLD_NUMBER { get; set; }
        /// <summary>
        /// PROPERTY_UNDER_NUMBER of the AREA 
        /// </summary>
        public string? PROPERTY_UNDER_NUMBER { get; set; }

        /// <summary>
        /// UPDATED_DATE of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UPDATED_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA belongs 
        /// </summary>
        public Guid? GUID_USER_UPDATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_UPDATED_BY")]
        public USR? GUID_USER_UPDATED_BY_USR { get; set; }

        /// <summary>
        /// CREATION_DATE of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CREATION_DATE { get; set; }
        /// <summary>
        /// Foreign key referencing the USR to which the AREA belongs 
        /// </summary>
        public Guid? GUID_USER_CREATED_BY { get; set; }

        /// <summary>
        /// Navigation property representing the associated USR
        /// </summary>
        [ForeignKey("GUID_USER_CREATED_BY")]
        public USR? GUID_USER_CREATED_BY_USR { get; set; }
        /// <summary>
        /// CLEANING_COMMENT of the AREA 
        /// </summary>
        public string? CLEANING_COMMENT { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION to which the AREA belongs 
        /// </summary>
        public Guid? GUID_CONDITION { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION
        /// </summary>
        [ForeignKey("GUID_CONDITION")]
        public CONDITION? GUID_CONDITION_CONDITION { get; set; }
        /// <summary>
        /// GUID_IFC of the AREA 
        /// </summary>
        public string? GUID_IFC { get; set; }

        /// <summary>
        /// UNDERUTILIZATION_INVOICE_DATE of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UNDERUTILIZATION_INVOICE_DATE { get; set; }
        /// <summary>
        /// MAIN_FUNCTION of the AREA 
        /// </summary>
        public string? MAIN_FUNCTION { get; set; }
        /// <summary>
        /// PART_FUNCTION of the AREA 
        /// </summary>
        public string? PART_FUNCTION { get; set; }
        /// <summary>
        /// ROOM_NAME of the AREA 
        /// </summary>
        public string? ROOM_NAME { get; set; }
        /// <summary>
        /// ROOM_SPECIFICATION of the AREA 
        /// </summary>
        public string? ROOM_SPECIFICATION { get; set; }

        /// <summary>
        /// AVAILABILITY_DATE of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? AVAILABILITY_DATE { get; set; }
        /// <summary>
        /// ADDRESS of the AREA 
        /// </summary>
        public string? ADDRESS { get; set; }
        /// <summary>
        /// EXPLANATORY_TEXT of the AREA 
        /// </summary>
        public string? EXPLANATORY_TEXT { get; set; }
        /// <summary>
        /// FONT_NAME of the AREA 
        /// </summary>
        public string? FONT_NAME { get; set; }
        /// <summary>
        /// COMBO01 of the AREA 
        /// </summary>
        public string? COMBO01 { get; set; }
        /// <summary>
        /// COMBO02 of the AREA 
        /// </summary>
        public string? COMBO02 { get; set; }
        /// <summary>
        /// COMBO03 of the AREA 
        /// </summary>
        public string? COMBO03 { get; set; }
        /// <summary>
        /// COMBO04 of the AREA 
        /// </summary>
        public string? COMBO04 { get; set; }
        /// <summary>
        /// COMBO05 of the AREA 
        /// </summary>
        public string? COMBO05 { get; set; }
        /// <summary>
        /// COMBO06 of the AREA 
        /// </summary>
        public string? COMBO06 { get; set; }
        /// <summary>
        /// COMBO07 of the AREA 
        /// </summary>
        public string? COMBO07 { get; set; }
        /// <summary>
        /// COMBO08 of the AREA 
        /// </summary>
        public string? COMBO08 { get; set; }
        /// <summary>
        /// COMBO09 of the AREA 
        /// </summary>
        public string? COMBO09 { get; set; }
        /// <summary>
        /// COMBO10 of the AREA 
        /// </summary>
        public string? COMBO10 { get; set; }
        /// <summary>
        /// COMBO11 of the AREA 
        /// </summary>
        public string? COMBO11 { get; set; }
        /// <summary>
        /// COMBO12 of the AREA 
        /// </summary>
        public string? COMBO12 { get; set; }
        /// <summary>
        /// COMBO13 of the AREA 
        /// </summary>
        public string? COMBO13 { get; set; }
        /// <summary>
        /// COMBO14 of the AREA 
        /// </summary>
        public string? COMBO14 { get; set; }
        /// <summary>
        /// COMBO15 of the AREA 
        /// </summary>
        public string? COMBO15 { get; set; }
        /// <summary>
        /// COMBO16 of the AREA 
        /// </summary>
        public string? COMBO16 { get; set; }
        /// <summary>
        /// COMBO17 of the AREA 
        /// </summary>
        public string? COMBO17 { get; set; }
        /// <summary>
        /// COMBO18 of the AREA 
        /// </summary>
        public string? COMBO18 { get; set; }
        /// <summary>
        /// COMBO19 of the AREA 
        /// </summary>
        public string? COMBO19 { get; set; }
        /// <summary>
        /// COMBO20 of the AREA 
        /// </summary>
        public string? COMBO20 { get; set; }
        /// <summary>
        /// COMBO21 of the AREA 
        /// </summary>
        public string? COMBO21 { get; set; }
        /// <summary>
        /// COMBO22 of the AREA 
        /// </summary>
        public string? COMBO22 { get; set; }
        /// <summary>
        /// COMBO23 of the AREA 
        /// </summary>
        public string? COMBO23 { get; set; }
        /// <summary>
        /// COMBO24 of the AREA 
        /// </summary>
        public string? COMBO24 { get; set; }
        /// <summary>
        /// COMBO25 of the AREA 
        /// </summary>
        public string? COMBO25 { get; set; }
        /// <summary>
        /// COMBO26 of the AREA 
        /// </summary>
        public string? COMBO26 { get; set; }
        /// <summary>
        /// COMBO27 of the AREA 
        /// </summary>
        public string? COMBO27 { get; set; }
        /// <summary>
        /// COMBO28 of the AREA 
        /// </summary>
        public string? COMBO28 { get; set; }
        /// <summary>
        /// COMBO29 of the AREA 
        /// </summary>
        public string? COMBO29 { get; set; }
        /// <summary>
        /// COMBO30 of the AREA 
        /// </summary>
        public string? COMBO30 { get; set; }
        /// <summary>
        /// TEXT01 of the AREA 
        /// </summary>
        public string? TEXT01 { get; set; }
        /// <summary>
        /// TEXT02 of the AREA 
        /// </summary>
        public string? TEXT02 { get; set; }
        /// <summary>
        /// TEXT03 of the AREA 
        /// </summary>
        public string? TEXT03 { get; set; }
        /// <summary>
        /// TEXT04 of the AREA 
        /// </summary>
        public string? TEXT04 { get; set; }
        /// <summary>
        /// TEXT05 of the AREA 
        /// </summary>
        public string? TEXT05 { get; set; }
        /// <summary>
        /// TEXT06 of the AREA 
        /// </summary>
        public string? TEXT06 { get; set; }
        /// <summary>
        /// TEXT07 of the AREA 
        /// </summary>
        public string? TEXT07 { get; set; }
        /// <summary>
        /// TEXT08 of the AREA 
        /// </summary>
        public string? TEXT08 { get; set; }
        /// <summary>
        /// TEXT09 of the AREA 
        /// </summary>
        public string? TEXT09 { get; set; }
        /// <summary>
        /// TEXT10 of the AREA 
        /// </summary>
        public string? TEXT10 { get; set; }
        /// <summary>
        /// TEXT11 of the AREA 
        /// </summary>
        public string? TEXT11 { get; set; }
        /// <summary>
        /// TEXT12 of the AREA 
        /// </summary>
        public string? TEXT12 { get; set; }
        /// <summary>
        /// TEXT13 of the AREA 
        /// </summary>
        public string? TEXT13 { get; set; }
        /// <summary>
        /// TEXT14 of the AREA 
        /// </summary>
        public string? TEXT14 { get; set; }
        /// <summary>
        /// TEXT15 of the AREA 
        /// </summary>
        public string? TEXT15 { get; set; }
        /// <summary>
        /// TEXT16 of the AREA 
        /// </summary>
        public string? TEXT16 { get; set; }
        /// <summary>
        /// TEXT17 of the AREA 
        /// </summary>
        public string? TEXT17 { get; set; }
        /// <summary>
        /// TEXT18 of the AREA 
        /// </summary>
        public string? TEXT18 { get; set; }
        /// <summary>
        /// TEXT19 of the AREA 
        /// </summary>
        public string? TEXT19 { get; set; }
        /// <summary>
        /// TEXT20 of the AREA 
        /// </summary>
        public string? TEXT20 { get; set; }

        /// <summary>
        /// DATE01 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE01 { get; set; }

        /// <summary>
        /// DATE02 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE02 { get; set; }

        /// <summary>
        /// DATE03 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE03 { get; set; }

        /// <summary>
        /// DATE04 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE04 { get; set; }

        /// <summary>
        /// DATE05 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE05 { get; set; }

        /// <summary>
        /// DATE06 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE06 { get; set; }

        /// <summary>
        /// DATE07 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE07 { get; set; }

        /// <summary>
        /// DATE08 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE08 { get; set; }

        /// <summary>
        /// DATE09 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE09 { get; set; }

        /// <summary>
        /// DATE10 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE10 { get; set; }

        /// <summary>
        /// DATE11 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE11 { get; set; }

        /// <summary>
        /// DATE12 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE12 { get; set; }

        /// <summary>
        /// DATE13 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE13 { get; set; }

        /// <summary>
        /// DATE14 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE14 { get; set; }

        /// <summary>
        /// DATE15 of the AREA 
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? DATE15 { get; set; }
        /// <summary>
        /// NET_POLYGON_ID of the AREA 
        /// </summary>
        public string? NET_POLYGON_ID { get; set; }
        /// <summary>
        /// GROSS_POLYGON_ID of the AREA 
        /// </summary>
        public string? GROSS_POLYGON_ID { get; set; }
        /// <summary>
        /// NET_POLYGON of the AREA 
        /// </summary>
        public byte[]? NET_POLYGON { get; set; }
        /// <summary>
        /// GROSS_POLYGON of the AREA 
        /// </summary>
        public byte[]? GROSS_POLYGON { get; set; }
        /// <summary>
        /// DIMENSION1 of the AREA 
        /// </summary>
        public string? DIMENSION1 { get; set; }
        /// <summary>
        /// DIMENSION2 of the AREA 
        /// </summary>
        public string? DIMENSION2 { get; set; }
        /// <summary>
        /// DIMENSION3 of the AREA 
        /// </summary>
        public string? DIMENSION3 { get; set; }
        /// <summary>
        /// DIMENSION4 of the AREA 
        /// </summary>
        public string? DIMENSION4 { get; set; }
        /// <summary>
        /// DIMENSION5 of the AREA 
        /// </summary>
        public string? DIMENSION5 { get; set; }
        /// <summary>
        /// Foreign key referencing the DATA_OWNER to which the AREA belongs 
        /// </summary>
        public Guid? GUID_DATA_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated DATA_OWNER
        /// </summary>
        [ForeignKey("GUID_DATA_OWNER")]
        public DATA_OWNER? GUID_DATA_OWNER_DATA_OWNER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER to which the AREA belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER")]
        public WORK_ORDER? GUID_WORK_ORDER_WORK_ORDER { get; set; }
        /// <summary>
        /// Foreign key referencing the WORK_ORDER_X_AREA to which the AREA belongs 
        /// </summary>
        public Guid? GUID_WORK_ORDER_X_AREA { get; set; }

        /// <summary>
        /// Navigation property representing the associated WORK_ORDER_X_AREA
        /// </summary>
        [ForeignKey("GUID_WORK_ORDER_X_AREA")]
        public WORK_ORDER_X_AREA? GUID_WORK_ORDER_X_AREA_WORK_ORDER_X_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA to which the AREA belongs 
        /// </summary>
        public Guid? GUID_AREA_GROUP { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA
        /// </summary>
        [ForeignKey("GUID_AREA_GROUP")]
        public AREA? GUID_AREA_GROUP_AREA { get; set; }
        /// <summary>
        /// Foreign key referencing the BUILDING to which the AREA belongs 
        /// </summary>
        public Guid? GUID_BUILDING { get; set; }

        /// <summary>
        /// Navigation property representing the associated BUILDING
        /// </summary>
        [ForeignKey("GUID_BUILDING")]
        public BUILDING? GUID_BUILDING_BUILDING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONTRACT_ITEM to which the AREA belongs 
        /// </summary>
        public Guid? GUID_CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONTRACT_ITEM
        /// </summary>
        [ForeignKey("GUID_CONTRACT_ITEM")]
        public CONTRACT_ITEM? GUID_CONTRACT_ITEM_CONTRACT_ITEM { get; set; }
        /// <summary>
        /// Foreign key referencing the COST_CENTER to which the AREA belongs 
        /// </summary>
        public Guid? GUID_COST_CENTER { get; set; }

        /// <summary>
        /// Navigation property representing the associated COST_CENTER
        /// </summary>
        [ForeignKey("GUID_COST_CENTER")]
        public COST_CENTER? GUID_COST_CENTER_COST_CENTER { get; set; }
        /// <summary>
        /// Foreign key referencing the CUSTOMER to which the AREA belongs 
        /// </summary>
        public Guid? GUID_OWNER { get; set; }

        /// <summary>
        /// Navigation property representing the associated CUSTOMER
        /// </summary>
        [ForeignKey("GUID_OWNER")]
        public CUSTOMER? GUID_OWNER_CUSTOMER { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_CATEGORY to which the AREA belongs 
        /// </summary>
        public Guid? GUID_AREA_CATEGORY { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_CATEGORY
        /// </summary>
        [ForeignKey("GUID_AREA_CATEGORY")]
        public AREA_CATEGORY? GUID_AREA_CATEGORY_AREA_CATEGORY { get; set; }
        /// <summary>
        /// Foreign key referencing the ACCOUNT to which the AREA belongs 
        /// </summary>
        public Guid? GUID_ACCOUNT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ACCOUNT
        /// </summary>
        [ForeignKey("GUID_ACCOUNT")]
        public ACCOUNT? GUID_ACCOUNT_ACCOUNT { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION to which the AREA belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION")]
        public ORGANIZATION? GUID_ORGANIZATION_ORGANIZATION { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION_SECTION to which the AREA belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION_SECTION { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION_SECTION
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION_SECTION")]
        public ORGANIZATION_SECTION? GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION { get; set; }
        /// <summary>
        /// Foreign key referencing the ORGANIZATION_UNIT to which the AREA belongs 
        /// </summary>
        public Guid? GUID_ORGANIZATION_UNIT { get; set; }

        /// <summary>
        /// Navigation property representing the associated ORGANIZATION_UNIT
        /// </summary>
        [ForeignKey("GUID_ORGANIZATION_UNIT")]
        public ORGANIZATION_UNIT? GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING to which the AREA belongs 
        /// </summary>
        public Guid? GUID_CLEANING { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING
        /// </summary>
        [ForeignKey("GUID_CLEANING")]
        public CLEANING? GUID_CLEANING_CLEANING { get; set; }
        /// <summary>
        /// Foreign key referencing the PERSON to which the AREA belongs 
        /// </summary>
        public Guid? GUID_CLEANER { get; set; }

        /// <summary>
        /// Navigation property representing the associated PERSON
        /// </summary>
        [ForeignKey("GUID_CLEANER")]
        public PERSON? GUID_CLEANER_PERSON { get; set; }
        /// <summary>
        /// Foreign key referencing the CLEANING_QUALITY to which the AREA belongs 
        /// </summary>
        public Guid? GUID_CLEANING_QUALITY { get; set; }

        /// <summary>
        /// Navigation property representing the associated CLEANING_QUALITY
        /// </summary>
        [ForeignKey("GUID_CLEANING_QUALITY")]
        public CLEANING_QUALITY? GUID_CLEANING_QUALITY_CLEANING_QUALITY { get; set; }
        /// <summary>
        /// Foreign key referencing the DRAWING to which the AREA belongs 
        /// </summary>
        public Guid? GUID_DRAWING { get; set; }

        /// <summary>
        /// Navigation property representing the associated DRAWING
        /// </summary>
        [ForeignKey("GUID_DRAWING")]
        public DRAWING? GUID_DRAWING_DRAWING { get; set; }
        /// <summary>
        /// Foreign key referencing the CONDITION_TYPE to which the AREA belongs 
        /// </summary>
        public Guid? GUID_CONDITION_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated CONDITION_TYPE
        /// </summary>
        [ForeignKey("GUID_CONDITION_TYPE")]
        public CONDITION_TYPE? GUID_CONDITION_TYPE_CONDITION_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the AREA_TYPE to which the AREA belongs 
        /// </summary>
        public Guid? GUID_AREA_TYPE { get; set; }

        /// <summary>
        /// Navigation property representing the associated AREA_TYPE
        /// </summary>
        [ForeignKey("GUID_AREA_TYPE")]
        public AREA_TYPE? GUID_AREA_TYPE_AREA_TYPE { get; set; }
        /// <summary>
        /// Foreign key referencing the RESOURCE_GROUP to which the AREA belongs 
        /// </summary>
        public Guid? GUID_CLEANING_TEAM { get; set; }

        /// <summary>
        /// Navigation property representing the associated RESOURCE_GROUP
        /// </summary>
        [ForeignKey("GUID_CLEANING_TEAM")]
        public RESOURCE_GROUP? GUID_CLEANING_TEAM_RESOURCE_GROUP { get; set; }
        /// <summary>
        /// Foreign key referencing the MEDICAL_OWNERSHIP to which the AREA belongs 
        /// </summary>
        public Guid? GUID_MEDICAL_OWNERSHIP { get; set; }

        /// <summary>
        /// Navigation property representing the associated MEDICAL_OWNERSHIP
        /// </summary>
        [ForeignKey("GUID_MEDICAL_OWNERSHIP")]
        public MEDICAL_OWNERSHIP? GUID_MEDICAL_OWNERSHIP_MEDICAL_OWNERSHIP { get; set; }
        /// <summary>
        /// Foreign key referencing the MEDICAL_REGION to which the AREA belongs 
        /// </summary>
        public Guid? GUID_MEDICAL_REGION { get; set; }

        /// <summary>
        /// Navigation property representing the associated MEDICAL_REGION
        /// </summary>
        [ForeignKey("GUID_MEDICAL_REGION")]
        public MEDICAL_REGION? GUID_MEDICAL_REGION_MEDICAL_REGION { get; set; }
        /// <summary>
        /// ID of the AREA 
        /// </summary>
        public string? ID { get; set; }
        /// <summary>
        /// DESCRIPTION of the AREA 
        /// </summary>
        public string? DESCRIPTION { get; set; }
    }
}