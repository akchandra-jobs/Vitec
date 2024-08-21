using Vitec.Data;
using Microsoft.OpenApi.Models;
using System.Reflection;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vitec.Models;
using Vitec.Services;
using Vitec.Logger;
using Newtonsoft.Json;
var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
builder.Host.UseNLog();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vitec", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.ToString());
    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter into field the word 'Bearer' following by space and JWT",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string> ()
                    }
                });
});
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
// Build the configuration object from appsettings.json
var config = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json", optional: false)
  .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
  .Build();
//Set value to appsetting
AppSetting.JwtIssuer = config.GetValue<string>("Jwt:Issuer");
AppSetting.JwtKey = config.GetValue<string>("Jwt:Key");
AppSetting.TokenExpirationtime = config.GetValue<int>("TokenExpirationtime");
// Add NLog as the logging service
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders(); // Remove other logging providers
    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
});
// Add JWT authentication services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = AppSetting.JwtIssuer,
        ValidAudience = AppSetting.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSetting.JwtKey ?? ""))
    };
});
//Service inject
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IJobParameterService, JobParameterService>();
builder.Services.AddScoped<IJobQueueService, JobQueueService>();
builder.Services.AddScoped<IListService, ListService>();
builder.Services.AddScoped<ISchemaService, SchemaService>();
builder.Services.AddScoped<IServer1Service, Server1Service>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IAggregatedCounterService, AggregatedCounterService>();
builder.Services.AddScoped<ICounterService, CounterService>();
builder.Services.AddScoped<INonsReferencesService, NonsReferencesService>();
builder.Services.AddScoped<IProductRelationsService, ProductRelationsService>();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IHOUR_TYPEService, HOUR_TYPEService>();
builder.Services.AddScoped<IREGISTERED_FIELDService, REGISTERED_FIELDService>();
builder.Services.AddScoped<IAREA_TYPEService, AREA_TYPEService>();
builder.Services.AddScoped<IDAILY_UPDATE_LOGService, DAILY_UPDATE_LOGService>();
builder.Services.AddScoped<IHATCHING_X_AREAService, HATCHING_X_AREAService>();
builder.Services.AddScoped<IREGIONService, REGIONService>();
builder.Services.AddScoped<IAREA_PRICEService, AREA_PRICEService>();
builder.Services.AddScoped<ICYLINDER_TYPEService, CYLINDER_TYPEService>();
builder.Services.AddScoped<IHATCHINGService, HATCHINGService>();
builder.Services.AddScoped<IREFERENCE_TYPEService, REFERENCE_TYPEService>();
builder.Services.AddScoped<IAREA_CATEGORY_X_AREA_TYPEService, AREA_CATEGORY_X_AREA_TYPEService>();
builder.Services.AddScoped<ICUSTOMER_LOGService, CUSTOMER_LOGService>();
builder.Services.AddScoped<IGIS_ENTITYService, GIS_ENTITYService>();
builder.Services.AddScoped<IREFERENCE_DATAService, REFERENCE_DATAService>();
builder.Services.AddScoped<IAREA_CATEGORYService, AREA_CATEGORYService>();
builder.Services.AddScoped<ICUSTOMER_LINE_OF_BUSINESSService, CUSTOMER_LINE_OF_BUSINESSService>();
builder.Services.AddScoped<IGENERAL_OPTIONSService, GENERAL_OPTIONSService>();
builder.Services.AddScoped<IPURCHASE_ORDER_ITEMService, PURCHASE_ORDER_ITEMService>();
builder.Services.AddScoped<IAREA_AVAILABILITYService, AREA_AVAILABILITYService>();
builder.Services.AddScoped<ICUSTOMER_GROUPService, CUSTOMER_GROUPService>();
builder.Services.AddScoped<IFOLLOW_UPService, FOLLOW_UPService>();
builder.Services.AddScoped<IPURCHASE_ORDER_FORMService, PURCHASE_ORDER_FORMService>();
builder.Services.AddScoped<IAPI_REQUEST_LOGService, API_REQUEST_LOGService>();
builder.Services.AddScoped<ICUSTOMER_DELIVERY_ADDRESSService, CUSTOMER_DELIVERY_ADDRESSService>();
builder.Services.AddScoped<IEXTERNAL_LOGIN_PROVIDERService, EXTERNAL_LOGIN_PROVIDERService>();
builder.Services.AddScoped<IPURCHASE_ORDERService, PURCHASE_ORDERService>();
builder.Services.AddScoped<IAPI_CLIENTService, API_CLIENTService>();
builder.Services.AddScoped<ICUSTOMER_CATEGORYService, CUSTOMER_CATEGORYService>();
builder.Services.AddScoped<IEVENT_X_ENTITYService, EVENT_X_ENTITYService>();
builder.Services.AddScoped<IPROJECT_TYPEService, PROJECT_TYPEService>();
builder.Services.AddScoped<IANONYMIZATION_FIELD_RULEService, ANONYMIZATION_FIELD_RULEService>();
builder.Services.AddScoped<ICUSTOMERService, CUSTOMERService>();
builder.Services.AddScoped<IEVENTService, EVENTService>();
builder.Services.AddScoped<IPROJECT_STATUSService, PROJECT_STATUSService>();
builder.Services.AddScoped<IALARM_LOGService, ALARM_LOGService>();
builder.Services.AddScoped<ICUSTOM_REPORTService, CUSTOM_REPORTService>();
builder.Services.AddScoped<IESTATE_CATEGORYService, ESTATE_CATEGORYService>();
builder.Services.AddScoped<IPROJECT_PHASEService, PROJECT_PHASEService>();
builder.Services.AddScoped<IALARMService, ALARMService>();
builder.Services.AddScoped<ICUSTOM_FUNCTION_X_DATA_OWNERService, CUSTOM_FUNCTION_X_DATA_OWNERService>();
builder.Services.AddScoped<IESTATEService, ESTATEService>();
builder.Services.AddScoped<IPROJECT_MILESTONEService, PROJECT_MILESTONEService>();
builder.Services.AddScoped<ICONTRACT_WARRANTYService, CONTRACT_WARRANTYService>();
builder.Services.AddScoped<IENTITY_PERMISSION_PROFILEService, ENTITY_PERMISSION_PROFILEService>();
builder.Services.AddScoped<IPLOT_X_BUILDINGService, PLOT_X_BUILDINGService>();
builder.Services.AddScoped<IWEB_PROFILE_X_WEB_MENUService, WEB_PROFILE_X_WEB_MENUService>();
builder.Services.AddScoped<ICONTRACT_TYPEService, CONTRACT_TYPEService>();
builder.Services.AddScoped<IENTITY_PERMISSIONService, ENTITY_PERMISSIONService>();
builder.Services.AddScoped<IPERSON_ROLEService, PERSON_ROLEService>();
builder.Services.AddScoped<IWEB_PROFILEService, WEB_PROFILEService>();
builder.Services.AddScoped<ICONTRACT_PRICE_X_SERVICEService, CONTRACT_PRICE_X_SERVICEService>();
builder.Services.AddScoped<IENTITY_MAIL_LISTService, ENTITY_MAIL_LISTService>();
builder.Services.AddScoped<IPERIODIZATIONService, PERIODIZATIONService>();
builder.Services.AddScoped<IWEB_MENUService, WEB_MENUService>();
builder.Services.AddScoped<ICONTRACT_LEASE_ITEMService, CONTRACT_LEASE_ITEMService>();
builder.Services.AddScoped<IENTITY_LINKService, ENTITY_LINKService>();
builder.Services.AddScoped<IPERIODIC_TASK_X_STANDARD_TEXTService, PERIODIC_TASK_X_STANDARD_TEXTService>();
builder.Services.AddScoped<IWEB_LIST_VIEW_COLUMNService, WEB_LIST_VIEW_COLUMNService>();
builder.Services.AddScoped<ICONTRACT_LEASEService, CONTRACT_LEASEService>();
builder.Services.AddScoped<IBUILDINGService, BUILDINGService>();
builder.Services.AddScoped<IENTITY_HISTORYService, ENTITY_HISTORYService>();
builder.Services.AddScoped<IPERIODIC_TASK_X_SPARE_PARTService, PERIODIC_TASK_X_SPARE_PARTService>();
builder.Services.AddScoped<IWEB_LIST_VIEWService, WEB_LIST_VIEWService>();
builder.Services.AddScoped<ICONTRACT_ITEM_X_SERVICEService, CONTRACT_ITEM_X_SERVICEService>();
builder.Services.AddScoped<IAREA_X_CLEANING_TASKService, AREA_X_CLEANING_TASKService>();
builder.Services.AddScoped<IENTITY_COUNTERService, ENTITY_COUNTERService>();
builder.Services.AddScoped<IPERIODIC_TASK_X_RESOURCE_GROUPService, PERIODIC_TASK_X_RESOURCE_GROUPService>();
builder.Services.AddScoped<IWEB_DASHBOARD_WIDGETService, WEB_DASHBOARD_WIDGETService>();
builder.Services.AddScoped<ICONTRACT_ITEMService, CONTRACT_ITEMService>();
builder.Services.AddScoped<IENTITY_COMMENTService, ENTITY_COMMENTService>();
builder.Services.AddScoped<IPERIODIC_TASK_X_EQUIPMENTService, PERIODIC_TASK_X_EQUIPMENTService>();
builder.Services.AddScoped<IWEB_DASHBOARDService, WEB_DASHBOARDService>();
builder.Services.AddScoped<ICLEANING_COMPLETIONService, CLEANING_COMPLETIONService>();
builder.Services.AddScoped<ICONTRACT_CATEGORYService, CONTRACT_CATEGORYService>();
builder.Services.AddScoped<IENTITY_ATTRIBUTEService, ENTITY_ATTRIBUTEService>();
builder.Services.AddScoped<IPERIODIC_TASK_X_AREAService, PERIODIC_TASK_X_AREAService>();
builder.Services.AddScoped<IVIDEO_X_ENTITYService, VIDEO_X_ENTITYService>();
builder.Services.AddScoped<IPERSONService, PERSONService>();
builder.Services.AddScoped<ICONTRACT_ADJUSTMENTService, CONTRACT_ADJUSTMENTService>();
builder.Services.AddScoped<IADJUSTMENTService, ADJUSTMENTService>();
builder.Services.AddScoped<ICUSTOM_FUNCTIONService, CUSTOM_FUNCTIONService>();
builder.Services.AddScoped<IEQUIPMENT_TEMPLATE_X_CATEGORYService, EQUIPMENT_TEMPLATE_X_CATEGORYService>();
builder.Services.AddScoped<IPROJECT_CATEGORYService, PROJECT_CATEGORYService>();
builder.Services.AddScoped<IWORKING_DAYS_OFFService, WORKING_DAYS_OFFService>();
builder.Services.AddScoped<IACTIVITY_GROUPService, ACTIVITY_GROUPService>();
builder.Services.AddScoped<ICOST_CENTERService, COST_CENTERService>();
builder.Services.AddScoped<IEQUIPMENT_TEMPLATEService, EQUIPMENT_TEMPLATEService>();
builder.Services.AddScoped<IPROJECTService, PROJECTService>();
builder.Services.AddScoped<IWORK_ORDER_X_SPARE_PARTService, WORK_ORDER_X_SPARE_PARTService>();
builder.Services.AddScoped<IACTIVITY_CONSTRAINTService, ACTIVITY_CONSTRAINTService>();
builder.Services.AddScoped<ICOSTService, COSTService>();
builder.Services.AddScoped<IEQUIPMENT_OPERATING_HOURSService, EQUIPMENT_OPERATING_HOURSService>();
builder.Services.AddScoped<IPRIORITYService, PRIORITYService>();
builder.Services.AddScoped<IWORK_ORDER_X_RESOURCE_GROUPService, WORK_ORDER_X_RESOURCE_GROUPService>();
builder.Services.AddScoped<IACTIVITY_CATEGORYService, ACTIVITY_CATEGORYService>();
builder.Services.AddScoped<ICONTROL_LIST_X_ENTITYService, CONTROL_LIST_X_ENTITYService>();
builder.Services.AddScoped<IEQUIPMENT_OPERATING_HOUR_TYPEService, EQUIPMENT_OPERATING_HOUR_TYPEService>();
builder.Services.AddScoped<IPRICE_SHEET_X_BUILDINGService, PRICE_SHEET_X_BUILDINGService>();
builder.Services.AddScoped<IWORK_ORDER_X_EQUIPMENTService, WORK_ORDER_X_EQUIPMENTService>();
builder.Services.AddScoped<IACCOUNTING_X_ACCOUNTINGService, ACCOUNTING_X_ACCOUNTINGService>();
builder.Services.AddScoped<ICONTROL_LIST_RULEService, CONTROL_LIST_RULEService>();
builder.Services.AddScoped<IEQUIPMENT_CATEGORYService, EQUIPMENT_CATEGORYService>();
builder.Services.AddScoped<IPRICE_SHEET_REVISIONService, PRICE_SHEET_REVISIONService>();
builder.Services.AddScoped<IWORK_ORDER_X_AREAService, WORK_ORDER_X_AREAService>();
builder.Services.AddScoped<IACCOUNTINGService, ACCOUNTINGService>();
builder.Services.AddScoped<ICONTROL_LIST_LOG_ITEMService, CONTROL_LIST_LOG_ITEMService>();
builder.Services.AddScoped<IEQUIPMENTService, EQUIPMENTService>();
builder.Services.AddScoped<IPRICE_SHEET_CATEGORY_PRICEService, PRICE_SHEET_CATEGORY_PRICEService>();
builder.Services.AddScoped<IWORK_ORDER_INVOICE_ITEMService, WORK_ORDER_INVOICE_ITEMService>();
builder.Services.AddScoped<IACCOUNT_X_ACCOUNTINGService, ACCOUNT_X_ACCOUNTINGService>();
builder.Services.AddScoped<ICONTROL_LIST_ITEM_ANSWERService, CONTROL_LIST_ITEM_ANSWERService>();
builder.Services.AddScoped<IENTITY_X_ATTRIBUTEService, ENTITY_X_ATTRIBUTEService>();
builder.Services.AddScoped<IPRICE_SHEET_CATEGORYService, PRICE_SHEET_CATEGORYService>();
builder.Services.AddScoped<IWORK_ORDERService, WORK_ORDERService>();
builder.Services.AddScoped<IACCOUNTService, ACCOUNTService>();
builder.Services.AddScoped<ICONTROL_LIST_ITEMService, CONTROL_LIST_ITEMService>();
builder.Services.AddScoped<IENTITY_TYPE_INFOService, ENTITY_TYPE_INFOService>();
builder.Services.AddScoped<IPRICE_SHEETService, PRICE_SHEETService>();
builder.Services.AddScoped<IWEB_USER_TOKENService, WEB_USER_TOKENService>();
builder.Services.AddScoped<ICONTROL_LISTService, CONTROL_LISTService>();
builder.Services.AddScoped<IENTITY_TASKService, ENTITY_TASKService>();
builder.Services.AddScoped<IPOSTAL_CODEService, POSTAL_CODEService>();
builder.Services.AddScoped<IWEB_TEXTService, WEB_TEXTService>();
builder.Services.AddScoped<IENERGY_UNITService, ENERGY_UNITService>();
builder.Services.AddScoped<IPERIODIC_TASKService, PERIODIC_TASKService>();
builder.Services.AddScoped<IVIDEO_BINARYService, VIDEO_BINARYService>();
builder.Services.AddScoped<IAREAService, AREAService>();
builder.Services.AddScoped<ICONTRACTService, CONTRACTService>();
builder.Services.AddScoped<IENERGY_READINGService, ENERGY_READINGService>();
builder.Services.AddScoped<IPERIOD_OF_NOTICEService, PERIOD_OF_NOTICEService>();
builder.Services.AddScoped<IVIDEOService, VIDEOService>();
builder.Services.AddScoped<IRESOURCE_GROUPService, RESOURCE_GROUPService>();
builder.Services.AddScoped<ICONTACT_PERSONService, CONTACT_PERSONService>();
builder.Services.AddScoped<IENERGY_PERIODIC_TASKService, ENERGY_PERIODIC_TASKService>();
builder.Services.AddScoped<IPAYMENT_TERMService, PAYMENT_TERMService>();
builder.Services.AddScoped<IUSRService, USRService>();
builder.Services.AddScoped<ICLEANING_TASKService, CLEANING_TASKService>();
builder.Services.AddScoped<ICONSUMABLEService, CONSUMABLEService>();
builder.Services.AddScoped<IENERGY_METERService, ENERGY_METERService>();
builder.Services.AddScoped<IPAYMENT_ORDER_ITEM_X_SERVICEService, PAYMENT_ORDER_ITEM_X_SERVICEService>();
builder.Services.AddScoped<IUSER_X_WEB_PROFILEService, USER_X_WEB_PROFILEService>();
builder.Services.AddScoped<ICONSTRUCTION_TYPEService, CONSTRUCTION_TYPEService>();
builder.Services.AddScoped<IENERGY_JOB_X_COUNTERService, ENERGY_JOB_X_COUNTERService>();
builder.Services.AddScoped<IPAYMENT_ORDER_ITEMService, PAYMENT_ORDER_ITEMService>();
builder.Services.AddScoped<IUSER_X_WEB_LIST_VIEWService, USER_X_WEB_LIST_VIEWService>();
builder.Services.AddScoped<ICONSEQUENCE_TYPEService, CONSEQUENCE_TYPEService>();
builder.Services.AddScoped<IENERGY_JOBService, ENERGY_JOBService>();
builder.Services.AddScoped<IPAYMENT_ORDER_FORMService, PAYMENT_ORDER_FORMService>();
builder.Services.AddScoped<IUSER_X_USER_NOTIFICATIONService, USER_X_USER_NOTIFICATIONService>();
builder.Services.AddScoped<ICONSEQUENCEService, CONSEQUENCEService>();
builder.Services.AddScoped<IENERGY_DATA_FORMATService, ENERGY_DATA_FORMATService>();
builder.Services.AddScoped<IPAYMENT_ORDERService, PAYMENT_ORDERService>();
builder.Services.AddScoped<IUSER_X_SPARE_PART_COUNTING_LISTService, USER_X_SPARE_PART_COUNTING_LISTService>();
builder.Services.AddScoped<ICONDITION_TYPEService, CONDITION_TYPEService>();
builder.Services.AddScoped<IENERGY_COUNTERService, ENERGY_COUNTERService>();
builder.Services.AddScoped<IPASSWORD_HISTORYService, PASSWORD_HISTORYService>();
builder.Services.AddScoped<IUSER_X_EXTERNAL_LOGINService, USER_X_EXTERNAL_LOGINService>();
builder.Services.AddScoped<ICONDITIONService, CONDITIONService>();
builder.Services.AddScoped<IENERGY_CONSUMPTIONService, ENERGY_CONSUMPTIONService>();
builder.Services.AddScoped<IORGANIZATION_X_AREAService, ORGANIZATION_X_AREAService>();
builder.Services.AddScoped<IUSER_X_CUSTOMERService, USER_X_CUSTOMERService>();
builder.Services.AddScoped<ICOMPONENT_X_SUPPLIERService, COMPONENT_X_SUPPLIERService>();
builder.Services.AddScoped<IENERGY_CATEGORYService, ENERGY_CATEGORYService>();
builder.Services.AddScoped<IORGANIZATION_UNITService, ORGANIZATION_UNITService>();
builder.Services.AddScoped<IUSER_SESSIONService, USER_SESSIONService>();
builder.Services.AddScoped<ICOMPONENT_X_EQUIPMENTService, COMPONENT_X_EQUIPMENTService>();
builder.Services.AddScoped<IENERGY_BLOCKService, ENERGY_BLOCKService>();
builder.Services.AddScoped<IORGANIZATION_SECTIONService, ORGANIZATION_SECTIONService>();
builder.Services.AddScoped<IUSER_PROFILEService, USER_PROFILEService>();
builder.Services.AddScoped<ICOMPONENT_X_AREAService, COMPONENT_X_AREAService>();
builder.Services.AddScoped<IEMAIL_TEMPLATEService, EMAIL_TEMPLATEService>();
builder.Services.AddScoped<IORGANIZATIONService, ORGANIZATIONService>();
builder.Services.AddScoped<IUSER_NOTIFICATIONService, USER_NOTIFICATIONService>();
builder.Services.AddScoped<ICOMPONENT_CATEGORYService, COMPONENT_CATEGORYService>();
builder.Services.AddScoped<IDUTY_LOG_GROUPService, DUTY_LOG_GROUPService>();
builder.Services.AddScoped<IOPERATIONAL_MESSAGEService, OPERATIONAL_MESSAGEService>();
builder.Services.AddScoped<ITWO_FACTOR_TOKENService, TWO_FACTOR_TOKENService>();
builder.Services.AddScoped<ICOMPONENTService, COMPONENTService>();
builder.Services.AddScoped<IDUTY_LOG_EVENTService, DUTY_LOG_EVENTService>();
builder.Services.AddScoped<INONS_REFERENCEService, NONS_REFERENCEService>();
builder.Services.AddScoped<ITRANSFER_X_FUNCTIONService, TRANSFER_X_FUNCTIONService>();
builder.Services.AddScoped<ICLEANING_X_CLEANING_TASKService, CLEANING_X_CLEANING_TASKService>();
builder.Services.AddScoped<IDUTY_LOG_CATEGORY_X_GROUPService, DUTY_LOG_CATEGORY_X_GROUPService>();
builder.Services.AddScoped<INAMED_SELECTION_VALUEService, NAMED_SELECTION_VALUEService>();
builder.Services.AddScoped<ITRANSFERService, TRANSFERService>();
builder.Services.AddScoped<ICLEANING_QUALITY_CONTROL_X_AREAService, CLEANING_QUALITY_CONTROL_X_AREAService>();
builder.Services.AddScoped<IDUTY_LOG_CATEGORYService, DUTY_LOG_CATEGORYService>();
builder.Services.AddScoped<INAMED_SELECTIONService, NAMED_SELECTIONService>();
builder.Services.AddScoped<ITASKService, TASKService>();
builder.Services.AddScoped<ICLEANING_QUALITY_CONTROLService, CLEANING_QUALITY_CONTROLService>();
builder.Services.AddScoped<IDUTY_LOGService, DUTY_LOGService>();
builder.Services.AddScoped<IMOBILE_MENU_PROFILEService, MOBILE_MENU_PROFILEService>();
builder.Services.AddScoped<ISUPPLIER_LINE_OF_BUSINESSService, SUPPLIER_LINE_OF_BUSINESSService>();
builder.Services.AddScoped<ICLEANING_QUALITYService, CLEANING_QUALITYService>();
builder.Services.AddScoped<IDRAWING_X_LAYER_GROUPService, DRAWING_X_LAYER_GROUPService>();
builder.Services.AddScoped<IMEDICAL_REGIONService, MEDICAL_REGIONService>();
builder.Services.AddScoped<ISUPPLIER_AGREEMENTService, SUPPLIER_AGREEMENTService>();
builder.Services.AddScoped<ICLEANING_COMPLETION_HISTORYService, CLEANING_COMPLETION_HISTORYService>();
builder.Services.AddScoped<IDRAWING_TEXTService, DRAWING_TEXTService>();
builder.Services.AddScoped<IMEDICAL_OWNERSHIPService, MEDICAL_OWNERSHIPService>();
builder.Services.AddScoped<ISUPPLIERService, SUPPLIERService>();
builder.Services.AddScoped<ICLEANING_COMPLETION_ATTRIBUTE_VALUEService, CLEANING_COMPLETION_ATTRIBUTE_VALUEService>();
builder.Services.AddScoped<IDRAWINGService, DRAWINGService>();
builder.Services.AddScoped<ILOG_SECURITYService, LOG_SECURITYService>();
builder.Services.AddScoped<ISTART_PAGEService, START_PAGEService>();
builder.Services.AddScoped<ICLEANINGService, CLEANINGService>();
builder.Services.AddScoped<IDOOR_LOCK_X_AREAService, DOOR_LOCK_X_AREAService>();
builder.Services.AddScoped<ILOG_PERFORMANCEService, LOG_PERFORMANCEService>();
builder.Services.AddScoped<ISTANDARD_TEXTService, STANDARD_TEXTService>();
builder.Services.AddScoped<ICHANGE_SETService, CHANGE_SETService>();
builder.Services.AddScoped<IDOOR_LOCKService, DOOR_LOCKService>();
builder.Services.AddScoped<ILOGService, LOGService>();
builder.Services.AddScoped<ISPARE_PART_WITHDRAWALService, SPARE_PART_WITHDRAWALService>();
builder.Services.AddScoped<ICAUSEService, CAUSEService>();
builder.Services.AddScoped<IDOOR_KEY_X_USERService, DOOR_KEY_X_USERService>();
builder.Services.AddScoped<ILIST_LAYOUTService, LIST_LAYOUTService>();
builder.Services.AddScoped<ISPARE_PART_COUNTING_LISTService, SPARE_PART_COUNTING_LISTService>();
builder.Services.AddScoped<IBUILDING_X_SUPPLIERService, BUILDING_X_SUPPLIERService>();
builder.Services.AddScoped<IDOOR_KEY_X_DOOR_LOCKService, DOOR_KEY_X_DOOR_LOCKService>();
builder.Services.AddScoped<ILIST_HIGHLIGHTService, LIST_HIGHLIGHTService>();
builder.Services.AddScoped<ISPARE_PART_COUNTING_ITEMService, SPARE_PART_COUNTING_ITEMService>();
builder.Services.AddScoped<IBUILDING_X_PERSONService, BUILDING_X_PERSONService>();
builder.Services.AddScoped<IDOOR_KEY_TRANSACTIONService, DOOR_KEY_TRANSACTIONService>();
builder.Services.AddScoped<ILEASE_FOLLOW_UPService, LEASE_FOLLOW_UPService>();
builder.Services.AddScoped<ISPARE_PART_COUNTINGService, SPARE_PART_COUNTINGService>();
builder.Services.AddScoped<IBUILDING_X_CONTRACTService, BUILDING_X_CONTRACTService>();
builder.Services.AddScoped<IDOOR_KEY_SYSTEMService, DOOR_KEY_SYSTEMService>();
builder.Services.AddScoped<ILAYER_GROUP_SET_X_LAYER_GROUPService, LAYER_GROUP_SET_X_LAYER_GROUPService>();
builder.Services.AddScoped<ISPARE_PARTService, SPARE_PARTService>();
builder.Services.AddScoped<IBUILDING_X_BUILDING_SELECTIONService, BUILDING_X_BUILDING_SELECTIONService>();
builder.Services.AddScoped<IDOOR_KEYService, DOOR_KEYService>();
builder.Services.AddScoped<ILAYER_GROUP_SETService, LAYER_GROUP_SETService>();
builder.Services.AddScoped<ISETTINGService, SETTINGService>();
builder.Services.AddScoped<IBUILDING_X_BIM_FILEService, BUILDING_X_BIM_FILEService>();
builder.Services.AddScoped<IDOCUMENT_X_ENTITYService, DOCUMENT_X_ENTITYService>();
builder.Services.AddScoped<ILAYER_GROUPService, LAYER_GROUPService>();
builder.Services.AddScoped<ISERVICE_X_AREA_CATEGORYService, SERVICE_X_AREA_CATEGORYService>();
builder.Services.AddScoped<IBUILDING_SELECTIONService, BUILDING_SELECTIONService>();
builder.Services.AddScoped<IDOCUMENT_WEB_ACCESSService, DOCUMENT_WEB_ACCESSService>();
builder.Services.AddScoped<ILANGUAGE_X_WEB_TEXTService, LANGUAGE_X_WEB_TEXTService>();
builder.Services.AddScoped<ISERVICE_PRICEService, SERVICE_PRICEService>();
builder.Services.AddScoped<IBUILDING_CATEGORYService, BUILDING_CATEGORYService>();
builder.Services.AddScoped<IDOCUMENT_TYPEService, DOCUMENT_TYPEService>();
builder.Services.AddScoped<ILANGUAGE_REPORT_ENTRYService, LANGUAGE_REPORT_ENTRYService>();
builder.Services.AddScoped<ISERVICEService, SERVICEService>();
builder.Services.AddScoped<IBUDGETService, BUDGETService>();
builder.Services.AddScoped<IDOCUMENT_REVISIONService, DOCUMENT_REVISIONService>();
builder.Services.AddScoped<ILANGUAGE_FIELD_ENTRYService, LANGUAGE_FIELD_ENTRYService>();
builder.Services.AddScoped<ISERVERService, SERVERService>();
builder.Services.AddScoped<IBOOKING_CATEGORYService, BOOKING_CATEGORYService>();
builder.Services.AddScoped<IDOCUMENT_CATEGORYService, DOCUMENT_CATEGORYService>();
builder.Services.AddScoped<ILANGUAGE_ENTRYService, LANGUAGE_ENTRYService>();
builder.Services.AddScoped<ISCHEDULED_JOB_EXECUTIONService, SCHEDULED_JOB_EXECUTIONService>();
builder.Services.AddScoped<IBINARY_DATAService, BINARY_DATAService>();
builder.Services.AddScoped<IDOCUMENTService, DOCUMENTService>();
builder.Services.AddScoped<ILANGUAGEService, LANGUAGEService>();
builder.Services.AddScoped<ISCHEDULED_JOBService, SCHEDULED_JOBService>();
builder.Services.AddScoped<IBIM_PROJECTService, BIM_PROJECTService>();
builder.Services.AddScoped<IDEVIATION_TYPEService, DEVIATION_TYPEService>();
builder.Services.AddScoped<IINVOICINGService, INVOICINGService>();
builder.Services.AddScoped<IRESOURCE_GROUP_X_CAUSEService, RESOURCE_GROUP_X_CAUSEService>();
builder.Services.AddScoped<IBIM_FILEService, BIM_FILEService>();
builder.Services.AddScoped<IDEVIATIONService, DEVIATIONService>();
builder.Services.AddScoped<IINTERVALService, INTERVALService>();
builder.Services.AddScoped<IREQUESTService, REQUESTService>();
builder.Services.AddScoped<IBCF_PROJECTService, BCF_PROJECTService>();
builder.Services.AddScoped<IDEPARTMENTService, DEPARTMENTService>();
builder.Services.AddScoped<IINTEGRATION_DATAService, INTEGRATION_DATAService>();
builder.Services.AddScoped<IREPORTService, REPORTService>();
builder.Services.AddScoped<IBARCODEService, BARCODEService>();
builder.Services.AddScoped<IDELIVERY_TERMService, DELIVERY_TERMService>();
builder.Services.AddScoped<IIMAGE_X_ENTITYService, IMAGE_X_ENTITYService>();
builder.Services.AddScoped<IRENTAL_GROUPService, RENTAL_GROUPService>();
builder.Services.AddScoped<IARTICLEService, ARTICLEService>();
builder.Services.AddScoped<IIMAGE_BINARYService, IMAGE_BINARYService>();
builder.Services.AddScoped<IRELATIONSHIP_TYPEService, RELATIONSHIP_TYPEService>();
builder.Services.AddScoped<IAREA_X_ENTITYService, AREA_X_ENTITYService>();
builder.Services.AddScoped<IDATA_OWNERService, DATA_OWNERService>();
builder.Services.AddScoped<IIMAGEService, IMAGEService>();
builder.Services.AddScoped<IRELATIONSHIPService, RELATIONSHIPService>();
builder.Services.AddScoped<IAREA_X_CLEANING_TASK_ATTRIBUTE_VALUEService, AREA_X_CLEANING_TASK_ATTRIBUTE_VALUEService>();
builder.Services.AddScoped<IDATA_IMPORTService, DATA_IMPORTService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IEntityService, EntityService>();
builder.Services.AddScoped<IRoleEntitlementService, RoleEntitlementService>();
builder.Services.AddScoped<IUserInRoleService, UserInRoleService>();
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IFieldMapperService, FieldMapperService>();
builder.Services.AddScoped<IJsonMessageService, JsonMessageService>();
builder.Services.AddTransient<ILoggerService, LoggerService>();
//Json handler
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    // Configure Newtonsoft.Json settings here
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});
//Inject context
builder.Services.AddTransient<VitecContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.SetIsOriginAllowed(_ => true)
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vitec API v1");
        c.RoutePrefix = string.Empty;
    });
    app.MapSwagger().RequireAuthorization();
}
app.UseAuthorization();
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();