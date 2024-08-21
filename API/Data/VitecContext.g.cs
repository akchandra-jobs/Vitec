using Microsoft.EntityFrameworkCore;
using Vitec.Entities;

namespace Vitec.Data
{
    /// <summary>
    /// Represents the database context for the application.
    /// </summary>
    public class VitecContext : DbContext
    {
        /// <summary>
        /// Configures the database connection options.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the database connection.</param>
        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=codezen.database.windows.net;Initial Catalog=codezen;Persist Security Info=True;user id=Lowcodeadmin;password=NtLowCode^123*;Integrated Security=false;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=true;");
        }

        /// <summary>
        /// Configures the model relationships and entity mappings.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the database model.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInRole>().HasKey(a => a.Id);
            modelBuilder.Entity<UserToken>().HasKey(a => a.Id);
            modelBuilder.Entity<RoleEntitlement>().HasKey(a => a.Id);
            modelBuilder.Entity<Entity>().HasKey(a => a.Id);
            modelBuilder.Entity<Tenant>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<DATA_IMPORT>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE>().HasKey(a => a.GUID);
            modelBuilder.Entity<RELATIONSHIP>().HasKey(a => a.GUID);
            modelBuilder.Entity<IMAGE>().HasKey(a => a.GUID);
            modelBuilder.Entity<DATA_OWNER>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA_X_ENTITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<RELATIONSHIP_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<IMAGE_BINARY>().HasKey(a => a.GUID);
            modelBuilder.Entity<ARTICLE>().HasKey(a => a.GUID);
            modelBuilder.Entity<RENTAL_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<DELIVERY_TERM>().HasKey(a => a.GUID);
            modelBuilder.Entity<BARCODE>().HasKey(a => a.GUID);
            modelBuilder.Entity<REPORT>().HasKey(a => a.GUID);
            modelBuilder.Entity<INTEGRATION_DATA>().HasKey(a => a.GUID);
            modelBuilder.Entity<DEPARTMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<BCF_PROJECT>().HasKey(a => a.GUID);
            modelBuilder.Entity<REQUEST>().HasKey(a => a.GUID);
            modelBuilder.Entity<INTERVAL>().HasKey(a => a.GUID);
            modelBuilder.Entity<DEVIATION>().HasKey(a => a.GUID);
            modelBuilder.Entity<BIM_FILE>().HasKey(a => a.GUID);
            modelBuilder.Entity<RESOURCE_GROUP_X_CAUSE>().HasKey(a => a.GUID);
            modelBuilder.Entity<INVOICING>().HasKey(a => a.GUID);
            modelBuilder.Entity<DEVIATION_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<BIM_PROJECT>().HasKey(a => a.GUID);
            modelBuilder.Entity<SCHEDULED_JOB>().HasKey(a => a.GUID);
            modelBuilder.Entity<LANGUAGE>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOCUMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<BINARY_DATA>().HasKey(a => a.GUID);
            modelBuilder.Entity<SCHEDULED_JOB_EXECUTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<LANGUAGE_ENTRY>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOCUMENT_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<BOOKING_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<SERVER>().HasKey(a => a.GUID);
            modelBuilder.Entity<LANGUAGE_FIELD_ENTRY>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOCUMENT_REVISION>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUDGET>().HasKey(a => a.GUID);
            modelBuilder.Entity<SERVICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<LANGUAGE_REPORT_ENTRY>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOCUMENT_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<SERVICE_PRICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<LANGUAGE_X_WEB_TEXT>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOCUMENT_WEB_ACCESS>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING_SELECTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<SERVICE_X_AREA_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<LAYER_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING_X_BIM_FILE>().HasKey(a => a.GUID);
            modelBuilder.Entity<SETTING>().HasKey(a => a.GUID);
            modelBuilder.Entity<LAYER_GROUP_SET>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOOR_KEY>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING_X_BUILDING_SELECTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<SPARE_PART>().HasKey(a => a.GUID);
            modelBuilder.Entity<LAYER_GROUP_SET_X_LAYER_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOOR_KEY_SYSTEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING_X_CONTRACT>().HasKey(a => a.GUID);
            modelBuilder.Entity<SPARE_PART_COUNTING>().HasKey(a => a.GUID);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOOR_KEY_TRANSACTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING_X_PERSON>().HasKey(a => a.GUID);
            modelBuilder.Entity<SPARE_PART_COUNTING_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<LIST_HIGHLIGHT>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOOR_KEY_X_DOOR_LOCK>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING_X_SUPPLIER>().HasKey(a => a.GUID);
            modelBuilder.Entity<SPARE_PART_COUNTING_LIST>().HasKey(a => a.GUID);
            modelBuilder.Entity<LIST_LAYOUT>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOOR_KEY_X_USER>().HasKey(a => a.GUID);
            modelBuilder.Entity<CAUSE>().HasKey(a => a.GUID);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasKey(a => a.GUID);
            modelBuilder.Entity<LOG>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOOR_LOCK>().HasKey(a => a.GUID);
            modelBuilder.Entity<CHANGE_SET>().HasKey(a => a.GUID);
            modelBuilder.Entity<STANDARD_TEXT>().HasKey(a => a.GUID);
            modelBuilder.Entity<LOG_PERFORMANCE>().HasKey(a => a.GUID);
            modelBuilder.Entity<DOOR_LOCK_X_AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING>().HasKey(a => a.GUID);
            modelBuilder.Entity<START_PAGE>().HasKey(a => a.GUID);
            modelBuilder.Entity<LOG_SECURITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<DRAWING>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_COMPLETION_ATTRIBUTE_VALUE>().HasKey(a => a.GUID);
            modelBuilder.Entity<SUPPLIER>().HasKey(a => a.GUID);
            modelBuilder.Entity<MEDICAL_OWNERSHIP>().HasKey(a => a.GUID);
            modelBuilder.Entity<DRAWING_TEXT>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_COMPLETION_HISTORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<SUPPLIER_AGREEMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<MEDICAL_REGION>().HasKey(a => a.GUID);
            modelBuilder.Entity<DRAWING_X_LAYER_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_QUALITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<SUPPLIER_LINE_OF_BUSINESS>().HasKey(a => a.GUID);
            modelBuilder.Entity<MOBILE_MENU_PROFILE>().HasKey(a => a.GUID);
            modelBuilder.Entity<DUTY_LOG>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL>().HasKey(a => a.GUID);
            modelBuilder.Entity<Entities.TASK>().HasKey(a => a.GUID);
            modelBuilder.Entity<NAMED_SELECTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<DUTY_LOG_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL_X_AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<TRANSFER>().HasKey(a => a.GUID);
            modelBuilder.Entity<NAMED_SELECTION_VALUE>().HasKey(a => a.GUID);
            modelBuilder.Entity<DUTY_LOG_CATEGORY_X_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_X_CLEANING_TASK>().HasKey(a => a.GUID);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<NONS_REFERENCE>().HasKey(a => a.GUID);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<COMPONENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<TWO_FACTOR_TOKEN>().HasKey(a => a.GUID);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasKey(a => a.GUID);
            modelBuilder.Entity<DUTY_LOG_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<COMPONENT_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_NOTIFICATION>().HasKey(a => a.GUID);
            modelBuilder.Entity<ORGANIZATION>().HasKey(a => a.GUID);
            modelBuilder.Entity<EMAIL_TEMPLATE>().HasKey(a => a.GUID);
            modelBuilder.Entity<COMPONENT_X_AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_PROFILE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ORGANIZATION_SECTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_BLOCK>().HasKey(a => a.GUID);
            modelBuilder.Entity<COMPONENT_X_EQUIPMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_SESSION>().HasKey(a => a.GUID);
            modelBuilder.Entity<ORGANIZATION_UNIT>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_X_CUSTOMER>().HasKey(a => a.GUID);
            modelBuilder.Entity<ORGANIZATION_X_AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_CONSUMPTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONDITION>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_X_EXTERNAL_LOGIN>().HasKey(a => a.GUID);
            modelBuilder.Entity<PASSWORD_HISTORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_COUNTER>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONDITION_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_X_SPARE_PART_COUNTING_LIST>().HasKey(a => a.GUID);
            modelBuilder.Entity<PAYMENT_ORDER>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_DATA_FORMAT>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONSEQUENCE>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_X_USER_NOTIFICATION>().HasKey(a => a.GUID);
            modelBuilder.Entity<PAYMENT_ORDER_FORM>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_JOB>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONSEQUENCE_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_X_WEB_LIST_VIEW>().HasKey(a => a.GUID);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_JOB_X_COUNTER>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONSTRUCTION_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<USER_X_WEB_PROFILE>().HasKey(a => a.GUID);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM_X_SERVICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_METER>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONSUMABLE>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_TASK>().HasKey(a => a.GUID);
            modelBuilder.Entity<USR>().HasKey(a => a.GUID);
            modelBuilder.Entity<PAYMENT_TERM>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_PERIODIC_TASK>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTACT_PERSON>().HasKey(a => a.GUID);
            modelBuilder.Entity<RESOURCE_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<VIDEO>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIOD_OF_NOTICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_READING>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<VIDEO_BINARY>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIODIC_TASK>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENERGY_UNIT>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_TEXT>().HasKey(a => a.GUID);
            modelBuilder.Entity<POSTAL_CODE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_TASK>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTROL_LIST>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_USER_TOKEN>().HasKey(a => a.GUID);
            modelBuilder.Entity<PRICE_SHEET>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_TYPE_INFO>().HasKey(a => a.MODULE);
            modelBuilder.Entity<CONTROL_LIST_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<ACCOUNT>().HasKey(a => a.GUID);
            modelBuilder.Entity<WORK_ORDER>().HasKey(a => a.GUID);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_X_ATTRIBUTE>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTROL_LIST_ITEM_ANSWER>().HasKey(a => a.GUID);
            modelBuilder.Entity<ACCOUNT_X_ACCOUNTING>().HasKey(a => a.GUID);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY_PRICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<EQUIPMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTROL_LIST_LOG_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<ACCOUNTING>().HasKey(a => a.GUID);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<PRICE_SHEET_REVISION>().HasKey(a => a.GUID);
            modelBuilder.Entity<EQUIPMENT_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTROL_LIST_RULE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ACCOUNTING_X_ACCOUNTING>().HasKey(a => a.GUID);
            modelBuilder.Entity<WORK_ORDER_X_EQUIPMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<PRICE_SHEET_X_BUILDING>().HasKey(a => a.GUID);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOUR_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<ACTIVITY_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<PRIORITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOURS>().HasKey(a => a.GUID);
            modelBuilder.Entity<COST>().HasKey(a => a.GUID);
            modelBuilder.Entity<ACTIVITY_CONSTRAINT>().HasKey(a => a.GUID);
            modelBuilder.Entity<WORK_ORDER_X_SPARE_PART>().HasKey(a => a.GUID);
            modelBuilder.Entity<PROJECT>().HasKey(a => a.GUID);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE>().HasKey(a => a.GUID);
            modelBuilder.Entity<COST_CENTER>().HasKey(a => a.GUID);
            modelBuilder.Entity<ACTIVITY_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<WORKING_DAYS_OFF>().HasKey(a => a.GUID);
            modelBuilder.Entity<PROJECT_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE_X_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOM_FUNCTION>().HasKey(a => a.GUID);
            modelBuilder.Entity<ADJUSTMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERSON>().HasKey(a => a.GUID);
            modelBuilder.Entity<VIDEO_X_ENTITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIODIC_TASK_X_AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_ATTRIBUTE>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_DASHBOARD>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIODIC_TASK_X_EQUIPMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_COMMENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_DASHBOARD_WIDGET>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_COUNTER>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_ITEM_X_SERVICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_LIST_VIEW>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIODIC_TASK_X_SPARE_PART>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_HISTORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<BUILDING>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_LEASE>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_LIST_VIEW_COLUMN>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIODIC_TASK_X_STANDARD_TEXT>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_LINK>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_MENU>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERIODIZATION>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_PROFILE>().HasKey(a => a.GUID);
            modelBuilder.Entity<PERSON_ROLE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_PERMISSION>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<WEB_PROFILE_X_WEB_MENU>().HasKey(a => a.GUID);
            modelBuilder.Entity<PLOT_X_BUILDING>().HasKey(a => a.GUID);
            modelBuilder.Entity<ENTITY_PERMISSION_PROFILE>().HasKey(a => a.GUID);
            modelBuilder.Entity<CONTRACT_WARRANTY>().HasKey(a => a.GUID);
            modelBuilder.Entity<PROJECT_MILESTONE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ESTATE>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOM_FUNCTION_X_DATA_OWNER>().HasKey(a => a.GUID);
            modelBuilder.Entity<ALARM>().HasKey(a => a.GUID);
            modelBuilder.Entity<PROJECT_PHASE>().HasKey(a => a.GUID);
            modelBuilder.Entity<ESTATE_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOM_REPORT>().HasKey(a => a.GUID);
            modelBuilder.Entity<ALARM_LOG>().HasKey(a => a.GUID);
            modelBuilder.Entity<PROJECT_STATUS>().HasKey(a => a.GUID);
            modelBuilder.Entity<Entities.EVENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOMER>().HasKey(a => a.GUID);
            modelBuilder.Entity<ANONYMIZATION_FIELD_RULE>().HasKey(a => a.GUID);
            modelBuilder.Entity<PROJECT_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<EVENT_X_ENTITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOMER_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<API_CLIENT>().HasKey(a => a.GUID);
            modelBuilder.Entity<PURCHASE_ORDER>().HasKey(a => a.GUID);
            modelBuilder.Entity<EXTERNAL_LOGIN_PROVIDER>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOMER_DELIVERY_ADDRESS>().HasKey(a => a.GUID);
            modelBuilder.Entity<API_REQUEST_LOG>().HasKey(a => a.GUID);
            modelBuilder.Entity<PURCHASE_ORDER_FORM>().HasKey(a => a.GUID);
            modelBuilder.Entity<FOLLOW_UP>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOMER_GROUP>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasKey(a => a.GUID);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOMER_LINE_OF_BUSINESS>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA_CATEGORY>().HasKey(a => a.GUID);
            modelBuilder.Entity<REFERENCE_DATA>().HasKey(a => a.GUID);
            modelBuilder.Entity<GIS_ENTITY>().HasKey(a => a.GUID);
            modelBuilder.Entity<CUSTOMER_LOG>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA_CATEGORY_X_AREA_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<REFERENCE_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<HATCHING>().HasKey(a => a.GUID);
            modelBuilder.Entity<CYLINDER_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<AREA_PRICE>().HasKey(a => a.GUID);
            modelBuilder.Entity<REGION>().HasKey(a => a.GUID);
            modelBuilder.Entity<HATCHING_X_AREA>().HasKey(a => a.GUID);
            modelBuilder.Entity<DAILY_UPDATE_LOG>().HasKey(a => a.ID);
            modelBuilder.Entity<AREA_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<REGISTERED_FIELD>().HasKey(a => a.GUID);
            modelBuilder.Entity<HOUR_TYPE>().HasKey(a => a.GUID);
            modelBuilder.Entity<Products>().HasKey(a => a.Id);
            modelBuilder.Entity<ProductRelations>().HasKey(a => a.Id);
            modelBuilder.Entity<NonsReferences>().HasKey(a => a.Id);
            modelBuilder.Entity<Counter>().HasKey(a => a.Id);
            modelBuilder.Entity<AggregatedCounter>().HasKey(a => a.Id);
            modelBuilder.Entity<State>().HasKey(a => a.Id);
            modelBuilder.Entity<Entities.Set>().HasKey(a => a.Id);
            modelBuilder.Entity<Server1>().HasKey(a => a.Id);
            modelBuilder.Entity<Schema>().HasKey(a => a.Version);
            modelBuilder.Entity<List>().HasKey(a => a.Id);
            modelBuilder.Entity<JobQueue>().HasKey(a => a.Id);
            modelBuilder.Entity<JobParameter>().HasKey(a => a.Id);
            modelBuilder.Entity<Job>().HasKey(a => a.Id);
            modelBuilder.Entity<Hash>().HasKey(a => a.Id);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.RoleId_Role).WithMany().HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<UserInRole>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<UserToken>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<UserToken>().HasOne(a => a.UserId_User).WithMany().HasForeignKey(c => c.UserId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.RoleId_Role).WithMany().HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.EntityId_Entity).WithMany().HasForeignKey(c => c.EntityId);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<RoleEntitlement>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<Entity>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Entity>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Entity>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<User>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.TenantId_Tenant).WithMany().HasForeignKey(c => c.TenantId);
            modelBuilder.Entity<Role>().HasOne(a => a.CreatedBy_User).WithMany().HasForeignKey(c => c.CreatedBy);
            modelBuilder.Entity<Role>().HasOne(a => a.UpdatedBy_User).WithMany().HasForeignKey(c => c.UpdatedBy);
            modelBuilder.Entity<DATA_IMPORT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DATA_IMPORT>().HasOne(a => a.GUID_BINARY_DATA_BINARY_DATA).WithMany().HasForeignKey(c => c.GUID_BINARY_DATA);
            modelBuilder.Entity<DATA_IMPORT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DATA_IMPORT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_ENTITY_X_ATTRIBUTE_ENTITY_X_ATTRIBUTE).WithMany().HasForeignKey(c => c.GUID_ENTITY_X_ATTRIBUTE);
            modelBuilder.Entity<AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_AREA_X_CLEANING_TASK_AREA_X_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_AREA_X_CLEANING_TASK);
            modelBuilder.Entity<RELATIONSHIP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<RELATIONSHIP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<RELATIONSHIP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<RELATIONSHIP>().HasOne(a => a.GUID_RELATIONSHIP_TYPE_RELATIONSHIP_TYPE).WithMany().HasForeignKey(c => c.GUID_RELATIONSHIP_TYPE);
            modelBuilder.Entity<IMAGE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<IMAGE>().HasOne(a => a.GUID_IMAGE_BINARY_IMAGE_BINARY).WithMany().HasForeignKey(c => c.GUID_IMAGE_BINARY);
            modelBuilder.Entity<IMAGE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<IMAGE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<IMAGE>().HasOne(a => a.GUID_ORIGINAL_IMAGE_BINARY_IMAGE_BINARY).WithMany().HasForeignKey(c => c.GUID_ORIGINAL_IMAGE_BINARY);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_WORK_ORDER_EMAIL_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER_EMAIL_DOCUMENT_CATEGORY);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_DEFAULT_EMAIL_DOCUMENT_TYPE_DOCUMENT_TYPE).WithMany().HasForeignKey(c => c.GUID_DEFAULT_EMAIL_DOCUMENT_TYPE);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_PURCHASE_ORDER_EMAIL_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER_EMAIL_DOCUMENT_CATEGORY);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_WO_X_EQ_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_WO_X_EQ_DOCUMENT_CATEGORY);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_IMAGE_LOGO_IMAGE).WithMany().HasForeignKey(c => c.GUID_IMAGE_LOGO);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_DEFAULT_DOCUMENT_TYPE_DOCUMENT_TYPE).WithMany().HasForeignKey(c => c.GUID_DEFAULT_DOCUMENT_TYPE);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DATA_OWNER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_X_ENTITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_X_ENTITY>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<AREA_X_ENTITY>().HasOne(a => a.GUID_ROOM_AREA).WithMany().HasForeignKey(c => c.GUID_ROOM);
            modelBuilder.Entity<AREA_X_ENTITY>().HasOne(a => a.GUID_ARTICLE_ARTICLE).WithMany().HasForeignKey(c => c.GUID_ARTICLE);
            modelBuilder.Entity<AREA_X_ENTITY>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<AREA_X_ENTITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_X_ENTITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<RELATIONSHIP_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<RELATIONSHIP_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<IMAGE_BINARY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<IMAGE_BINARY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<IMAGE_BINARY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<ARTICLE>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<RENTAL_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<RENTAL_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<RENTAL_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_IMAGE_IMAGE).WithMany().HasForeignKey(c => c.GUID_IMAGE);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_CLEANING_TASK_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_CLEANING_TASK);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_CONDITION_CONDITION).WithMany().HasForeignKey(c => c.GUID_CONDITION);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_CONTRACT_LEASE_CONTRACT_LEASE).WithMany().HasForeignKey(c => c.GUID_CONTRACT_LEASE);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_DOOR_KEY_DOOR_KEY).WithMany().HasForeignKey(c => c.GUID_DOOR_KEY);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_DOOR_LOCK_DOOR_LOCK).WithMany().HasForeignKey(c => c.GUID_DOOR_LOCK);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_PURCHASE_ORDER_PURCHASE_ORDER).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_REQUEST_REQUEST).WithMany().HasForeignKey(c => c.GUID_REQUEST);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_DEVIATION_DEVIATION).WithMany().HasForeignKey(c => c.GUID_DEVIATION);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_CONTROL_LIST_X_ENTITY_CONTROL_LIST_X_ENTITY).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_X_ENTITY);
            modelBuilder.Entity<IMAGE_X_ENTITY>().HasOne(a => a.GUID_CONTROL_LIST_ITEM_ANSWER_CONTROL_LIST_ITEM_ANSWER).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_ITEM_ANSWER);
            modelBuilder.Entity<DELIVERY_TERM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DELIVERY_TERM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DELIVERY_TERM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BARCODE>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<BARCODE>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<BARCODE>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<BARCODE>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<BARCODE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BARCODE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BARCODE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<REPORT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<REPORT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<REPORT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<INTEGRATION_DATA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<INTEGRATION_DATA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<INTEGRATION_DATA>().HasOne(a => a.GUID_CUSTOM_FUNCTION_CUSTOM_FUNCTION).WithMany().HasForeignKey(c => c.GUID_CUSTOM_FUNCTION);
            modelBuilder.Entity<INTEGRATION_DATA>().HasOne(a => a.GUID_SCHEDULED_JOB_SCHEDULED_JOB).WithMany().HasForeignKey(c => c.GUID_SCHEDULED_JOB);
            modelBuilder.Entity<DEPARTMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DEPARTMENT>().HasOne(a => a.GUID_PURCHASE_ORDER_FORM_PURCHASE_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER_FORM);
            modelBuilder.Entity<DEPARTMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DEPARTMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BCF_PROJECT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BCF_PROJECT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BCF_PROJECT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BCF_PROJECT>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<BCF_PROJECT>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<BCF_PROJECT>().HasOne(a => a.GUID_EXPORTED_BY_USER_USR).WithMany().HasForeignKey(c => c.GUID_EXPORTED_BY_USER);
            modelBuilder.Entity<BCF_PROJECT>().HasOne(a => a.GUID_CLOSED_BY_USER_USR).WithMany().HasForeignKey(c => c.GUID_CLOSED_BY_USER);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_CONTROL_LIST_ITEM_ANSWER_CONTROL_LIST_ITEM_ANSWER).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_ITEM_ANSWER);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_GIS_ENTITY_GIS_ENTITY).WithMany().HasForeignKey(c => c.GUID_GIS_ENTITY);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_BCF_PROJECT_BCF_PROJECT).WithMany().HasForeignKey(c => c.GUID_BCF_PROJECT);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_CAUSE_CAUSE).WithMany().HasForeignKey(c => c.GUID_CAUSE);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY).WithMany().HasForeignKey(c => c.GUID_ACTIVITY_CATEGORY);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_PRIORITY_PRIORITY).WithMany().HasForeignKey(c => c.GUID_PRIORITY);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_RESPONSIBLE_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_DRAWING_DRAWING).WithMany().HasForeignKey(c => c.GUID_DRAWING);
            modelBuilder.Entity<REQUEST>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<INTERVAL>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<INTERVAL>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<INTERVAL>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_PRIORITY_PRIORITY).WithMany().HasForeignKey(c => c.GUID_PRIORITY);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_USER_CLOSED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CLOSED_BY);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_CONTROL_LIST_ITEM_ANSWER_CONTROL_LIST_ITEM_ANSWER).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_ITEM_ANSWER);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_CORRECTIVE_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_CORRECTIVE_WORK_ORDER);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_DEVIATION_TYPE_DEVIATION_TYPE).WithMany().HasForeignKey(c => c.GUID_DEVIATION_TYPE);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_INSPECTION_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_INSPECTION_WORK_ORDER);
            modelBuilder.Entity<DEVIATION>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<BIM_FILE>().HasOne(a => a.GUID_BIM_PROJECT_BIM_PROJECT).WithMany().HasForeignKey(c => c.GUID_BIM_PROJECT);
            modelBuilder.Entity<BIM_FILE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BIM_FILE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BIM_FILE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<RESOURCE_GROUP_X_CAUSE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<RESOURCE_GROUP_X_CAUSE>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<RESOURCE_GROUP_X_CAUSE>().HasOne(a => a.GUID_CAUSE_CAUSE).WithMany().HasForeignKey(c => c.GUID_CAUSE);
            modelBuilder.Entity<RESOURCE_GROUP_X_CAUSE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<RESOURCE_GROUP_X_CAUSE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<INVOICING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<INVOICING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<INVOICING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DEVIATION_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DEVIATION_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DEVIATION_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BIM_PROJECT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BIM_PROJECT>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<BIM_PROJECT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BIM_PROJECT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SCHEDULED_JOB>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SCHEDULED_JOB>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LANGUAGE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LANGUAGE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_DOCUMENT_CATEGORY_DOCUMENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_DOCUMENT_CATEGORY);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_DOCUMENT_TYPE_DOCUMENT_TYPE).WithMany().HasForeignKey(c => c.GUID_DOCUMENT_TYPE);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_DOCUMENT_TEMPLATE_DOCUMENT).WithMany().HasForeignKey(c => c.GUID_DOCUMENT_TEMPLATE);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BINARY_DATA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BINARY_DATA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BINARY_DATA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SCHEDULED_JOB_EXECUTION>().HasOne(a => a.GUID_SCHEDULED_JOB_SCHEDULED_JOB).WithMany().HasForeignKey(c => c.GUID_SCHEDULED_JOB);
            modelBuilder.Entity<SCHEDULED_JOB_EXECUTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SCHEDULED_JOB_EXECUTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LANGUAGE_ENTRY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LANGUAGE_ENTRY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOCUMENT_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOCUMENT_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BOOKING_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BOOKING_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BOOKING_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LANGUAGE_FIELD_ENTRY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LANGUAGE_FIELD_ENTRY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOCUMENT_REVISION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOCUMENT_REVISION>().HasOne(a => a.GUID_DOCUMENT_DOCUMENT).WithMany().HasForeignKey(c => c.GUID_DOCUMENT);
            modelBuilder.Entity<DOCUMENT_REVISION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT_REVISION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUDGET>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<SERVICE>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<DOCUMENT_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOCUMENT_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUILDING_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUILDING_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SERVICE_PRICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SERVICE_PRICE>().HasOne(a => a.GUID_AREA_CATEGORY_AREA_CATEGORY).WithMany().HasForeignKey(c => c.GUID_AREA_CATEGORY);
            modelBuilder.Entity<SERVICE_PRICE>().HasOne(a => a.GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION).WithMany().HasForeignKey(c => c.GUID_PRICE_SHEET_REVISION);
            modelBuilder.Entity<SERVICE_PRICE>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<SERVICE_PRICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SERVICE_PRICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LANGUAGE_X_WEB_TEXT>().HasOne(a => a.GUID_LANGUAGE_LANGUAGE).WithMany().HasForeignKey(c => c.GUID_LANGUAGE);
            modelBuilder.Entity<LANGUAGE_X_WEB_TEXT>().HasOne(a => a.GUID_WEB_TEXT_WEB_TEXT).WithMany().HasForeignKey(c => c.GUID_WEB_TEXT);
            modelBuilder.Entity<LANGUAGE_X_WEB_TEXT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LANGUAGE_X_WEB_TEXT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT_WEB_ACCESS>().HasOne(a => a.GUID_DOCUMENT_DOCUMENT).WithMany().HasForeignKey(c => c.GUID_DOCUMENT);
            modelBuilder.Entity<DOCUMENT_WEB_ACCESS>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT_WEB_ACCESS>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOCUMENT_WEB_ACCESS>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING_SELECTION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING_SELECTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING_SELECTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SERVICE_X_AREA_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SERVICE_X_AREA_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SERVICE_X_AREA_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SERVICE_X_AREA_CATEGORY>().HasOne(a => a.GUID_AREA_CATEGORY_AREA_CATEGORY).WithMany().HasForeignKey(c => c.GUID_AREA_CATEGORY);
            modelBuilder.Entity<SERVICE_X_AREA_CATEGORY>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<LAYER_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<LAYER_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LAYER_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_DOCUMENT_DOCUMENT).WithMany().HasForeignKey(c => c.GUID_DOCUMENT);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_PURCHASE_ORDER_PURCHASE_ORDER).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_CONDITION_CONDITION).WithMany().HasForeignKey(c => c.GUID_CONDITION);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_REQUEST_REQUEST).WithMany().HasForeignKey(c => c.GUID_REQUEST);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_CONTRACT_LEASE_CONTRACT_LEASE).WithMany().HasForeignKey(c => c.GUID_CONTRACT_LEASE);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_DOOR_LOCK_DOOR_LOCK).WithMany().HasForeignKey(c => c.GUID_DOOR_LOCK);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_DOOR_KEY_DOOR_KEY).WithMany().HasForeignKey(c => c.GUID_DOOR_KEY);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_CLEANING_TASK_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_CLEANING_TASK);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_DEVIATION_DEVIATION).WithMany().HasForeignKey(c => c.GUID_DEVIATION);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_COST_COST).WithMany().HasForeignKey(c => c.GUID_COST);
            modelBuilder.Entity<DOCUMENT_X_ENTITY>().HasOne(a => a.GUID_PAYMENT_ORDER_PAYMENT_ORDER).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER);
            modelBuilder.Entity<BUILDING_X_BIM_FILE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING_X_BIM_FILE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUILDING_X_BIM_FILE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING_X_BIM_FILE>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<BUILDING_X_BIM_FILE>().HasOne(a => a.GUID_BIM_FILE_BIM_FILE).WithMany().HasForeignKey(c => c.GUID_BIM_FILE);
            modelBuilder.Entity<SETTING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SETTING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LAYER_GROUP_SET>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<LAYER_GROUP_SET>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LAYER_GROUP_SET>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOOR_KEY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOOR_KEY>().HasOne(a => a.GUID_DOOR_KEY_SYSTEM_DOOR_KEY_SYSTEM).WithMany().HasForeignKey(c => c.GUID_DOOR_KEY_SYSTEM);
            modelBuilder.Entity<BUILDING_X_BUILDING_SELECTION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING_X_BUILDING_SELECTION>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<BUILDING_X_BUILDING_SELECTION>().HasOne(a => a.GUID_BUILDING_SELECTION_BUILDING_SELECTION).WithMany().HasForeignKey(c => c.GUID_BUILDING_SELECTION);
            modelBuilder.Entity<BUILDING_X_BUILDING_SELECTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING_X_BUILDING_SELECTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_COMPONENT_X_SUPPLIER_COMPONENT_X_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_COMPONENT_X_SUPPLIER);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER_ITEM);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_ACCOUNTING_DIMENSION0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING_DIMENSION0);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_ACCOUNTING_DIMENSION1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING_DIMENSION1);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_ACCOUNTING_DIMENSION2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING_DIMENSION2);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_ACCOUNTING_DIMENSION3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING_DIMENSION3);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_ACCOUNTING_DIMENSION4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING_DIMENSION4);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<SPARE_PART>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<LAYER_GROUP_SET_X_LAYER_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<LAYER_GROUP_SET_X_LAYER_GROUP>().HasOne(a => a.GUID_LAYER_GROUP_SET_LAYER_GROUP_SET).WithMany().HasForeignKey(c => c.GUID_LAYER_GROUP_SET);
            modelBuilder.Entity<LAYER_GROUP_SET_X_LAYER_GROUP>().HasOne(a => a.GUID_LAYER_GROUP_LAYER_GROUP).WithMany().HasForeignKey(c => c.GUID_LAYER_GROUP);
            modelBuilder.Entity<LAYER_GROUP_SET_X_LAYER_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LAYER_GROUP_SET_X_LAYER_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY_SYSTEM>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<DOOR_KEY_SYSTEM>().HasOne(a => a.GUID_RESPONSIBLE_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON);
            modelBuilder.Entity<DOOR_KEY_SYSTEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOOR_KEY_SYSTEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY_SYSTEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOOR_KEY_SYSTEM>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<BUILDING_X_CONTRACT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING_X_CONTRACT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUILDING_X_CONTRACT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING_X_CONTRACT>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<BUILDING_X_CONTRACT>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<BUILDING_X_CONTRACT>().HasOne(a => a.GUID_PRICE_SHEET_PRICE_SHEET).WithMany().HasForeignKey(c => c.GUID_PRICE_SHEET);
            modelBuilder.Entity<SPARE_PART_COUNTING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SPARE_PART_COUNTING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SPARE_PART_COUNTING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_RESPONSIBLE_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_CONTRACT_LEASE_CONTRACT_LEASE).WithMany().HasForeignKey(c => c.GUID_CONTRACT_LEASE);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<LEASE_FOLLOW_UP>().HasOne(a => a.GUID_PREVIOUS_LEASE_FOLLOW_UP).WithMany().HasForeignKey(c => c.GUID_PREVIOUS);
            modelBuilder.Entity<DOOR_KEY_TRANSACTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOOR_KEY_TRANSACTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY_TRANSACTION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOOR_KEY_TRANSACTION>().HasOne(a => a.GUID_SUPPLY_DOOR_KEY_X_USER).WithMany().HasForeignKey(c => c.GUID_SUPPLY);
            modelBuilder.Entity<BUILDING_X_PERSON>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING_X_PERSON>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<BUILDING_X_PERSON>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<BUILDING_X_PERSON>().HasOne(a => a.GUID_PERSON_ROLE_PERSON_ROLE).WithMany().HasForeignKey(c => c.GUID_PERSON_ROLE);
            modelBuilder.Entity<BUILDING_X_PERSON>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING_X_PERSON>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SPARE_PART_COUNTING_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SPARE_PART_COUNTING_ITEM>().HasOne(a => a.GUID_SPARE_PART_SPARE_PART).WithMany().HasForeignKey(c => c.GUID_SPARE_PART);
            modelBuilder.Entity<SPARE_PART_COUNTING_ITEM>().HasOne(a => a.GUID_SPARE_PART_COUNTING_LIST_SPARE_PART_COUNTING_LIST).WithMany().HasForeignKey(c => c.GUID_SPARE_PART_COUNTING_LIST);
            modelBuilder.Entity<SPARE_PART_COUNTING_ITEM>().HasOne(a => a.GUID_USER_COUNTED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_COUNTED_BY);
            modelBuilder.Entity<SPARE_PART_COUNTING_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SPARE_PART_COUNTING_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LIST_HIGHLIGHT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<LIST_HIGHLIGHT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LIST_HIGHLIGHT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY_X_DOOR_LOCK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOOR_KEY_X_DOOR_LOCK>().HasOne(a => a.GUID_DOOR_LOCK_DOOR_LOCK).WithMany().HasForeignKey(c => c.GUID_DOOR_LOCK);
            modelBuilder.Entity<DOOR_KEY_X_DOOR_LOCK>().HasOne(a => a.GUID_DOOR_KEY_DOOR_KEY).WithMany().HasForeignKey(c => c.GUID_DOOR_KEY);
            modelBuilder.Entity<DOOR_KEY_X_DOOR_LOCK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOOR_KEY_X_DOOR_LOCK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUILDING_X_SUPPLIER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING_X_SUPPLIER>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<BUILDING_X_SUPPLIER>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<BUILDING_X_SUPPLIER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING_X_SUPPLIER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_SPARE_PART_COUNTING_SPARE_PART_COUNTING).WithMany().HasForeignKey(c => c.GUID_SPARE_PART_COUNTING);
            modelBuilder.Entity<SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LIST_LAYOUT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<LIST_LAYOUT>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<LIST_LAYOUT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<LIST_LAYOUT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY_X_USER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOOR_KEY_X_USER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_KEY_X_USER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOOR_KEY_X_USER>().HasOne(a => a.GUID_DOOR_KEY_DOOR_KEY).WithMany().HasForeignKey(c => c.GUID_DOOR_KEY);
            modelBuilder.Entity<DOOR_KEY_X_USER>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<DOOR_KEY_X_USER>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<CAUSE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CAUSE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CAUSE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_ITEM);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_WORK_ORDER_X_SPARE_PART_WORK_ORDER_X_SPARE_PART).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER_X_SPARE_PART);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_SPARE_PART_SPARE_PART).WithMany().HasForeignKey(c => c.GUID_SPARE_PART);
            modelBuilder.Entity<SPARE_PART_WITHDRAWAL>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<LOG>().HasOne(a => a.GUID_PARENT_LOG).WithMany().HasForeignKey(c => c.GUID_PARENT);
            modelBuilder.Entity<LOG>().HasOne(a => a.GUID_USER_SESSION_USER_SESSION).WithMany().HasForeignKey(c => c.GUID_USER_SESSION);
            modelBuilder.Entity<LOG>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_LOCK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOOR_LOCK>().HasOne(a => a.GUID_DOOR_KEY_SYSTEM_DOOR_KEY_SYSTEM).WithMany().HasForeignKey(c => c.GUID_DOOR_KEY_SYSTEM);
            modelBuilder.Entity<DOOR_LOCK>().HasOne(a => a.GUID_CYLINDER_TYPE_CYLINDER_TYPE).WithMany().HasForeignKey(c => c.GUID_CYLINDER_TYPE);
            modelBuilder.Entity<DOOR_LOCK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOOR_LOCK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CHANGE_SET>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CHANGE_SET>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CHANGE_SET>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<STANDARD_TEXT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<STANDARD_TEXT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<STANDARD_TEXT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DOOR_LOCK_X_AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DOOR_LOCK_X_AREA>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<DOOR_LOCK_X_AREA>().HasOne(a => a.GUID_DOOR_LOCK_DOOR_LOCK).WithMany().HasForeignKey(c => c.GUID_DOOR_LOCK);
            modelBuilder.Entity<DOOR_LOCK_X_AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DOOR_LOCK_X_AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CLEANING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING>().HasOne(a => a.GUID_INTERVAL_INTERVAL).WithMany().HasForeignKey(c => c.GUID_INTERVAL);
            modelBuilder.Entity<CLEANING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<START_PAGE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<START_PAGE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<LOG_SECURITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DRAWING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DRAWING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DRAWING>().HasOne(a => a.GUID_USER_CAF_COMPUTED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CAF_COMPUTED_BY);
            modelBuilder.Entity<DRAWING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DRAWING>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<DRAWING>().HasOne(a => a.GUID_LAYER_GROUP_SET_LAYER_GROUP_SET).WithMany().HasForeignKey(c => c.GUID_LAYER_GROUP_SET);
            modelBuilder.Entity<CLEANING_COMPLETION_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_COMPLETION_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CLEANING_COMPLETION_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_COMPLETION_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_ENTITY_X_ATTRIBUTE_ENTITY_X_ATTRIBUTE).WithMany().HasForeignKey(c => c.GUID_ENTITY_X_ATTRIBUTE);
            modelBuilder.Entity<CLEANING_COMPLETION_ATTRIBUTE_VALUE>().HasOne(a => a.GUID_CLEANING_COMPLETION_CLEANING_COMPLETION).WithMany().HasForeignKey(c => c.GUID_CLEANING_COMPLETION);
            modelBuilder.Entity<SUPPLIER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SUPPLIER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SUPPLIER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SUPPLIER>().HasOne(a => a.GUID_SUPPLIER_LINE_OF_BUSINESS_SUPPLIER_LINE_OF_BUSINESS).WithMany().HasForeignKey(c => c.GUID_SUPPLIER_LINE_OF_BUSINESS);
            modelBuilder.Entity<SUPPLIER>().HasOne(a => a.GUID_MAIN_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_MAIN_SUPPLIER);
            modelBuilder.Entity<MEDICAL_OWNERSHIP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<MEDICAL_OWNERSHIP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<MEDICAL_OWNERSHIP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DRAWING_TEXT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DRAWING_TEXT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DRAWING_TEXT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DRAWING_TEXT>().HasOne(a => a.GUID_DRAWING_DRAWING).WithMany().HasForeignKey(c => c.GUID_DRAWING);
            modelBuilder.Entity<CLEANING_COMPLETION_HISTORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_COMPLETION_HISTORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SUPPLIER_AGREEMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SUPPLIER_AGREEMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SUPPLIER_AGREEMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SUPPLIER_AGREEMENT>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<SUPPLIER_AGREEMENT>().HasOne(a => a.GUID_PAYMENT_TERM_PAYMENT_TERM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_TERM);
            modelBuilder.Entity<MEDICAL_REGION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<MEDICAL_REGION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<MEDICAL_REGION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DRAWING_X_LAYER_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DRAWING_X_LAYER_GROUP>().HasOne(a => a.GUID_LAYER_GROUP_LAYER_GROUP).WithMany().HasForeignKey(c => c.GUID_LAYER_GROUP);
            modelBuilder.Entity<DRAWING_X_LAYER_GROUP>().HasOne(a => a.GUID_DRAWING_DRAWING).WithMany().HasForeignKey(c => c.GUID_DRAWING);
            modelBuilder.Entity<DRAWING_X_LAYER_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DRAWING_X_LAYER_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CLEANING_QUALITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_QUALITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_QUALITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<SUPPLIER_LINE_OF_BUSINESS>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<SUPPLIER_LINE_OF_BUSINESS>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<SUPPLIER_LINE_OF_BUSINESS>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<MOBILE_MENU_PROFILE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<MOBILE_MENU_PROFILE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DUTY_LOG>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DUTY_LOG>().HasOne(a => a.GUID_DUTY_LOG_GROUP_DUTY_LOG_GROUP).WithMany().HasForeignKey(c => c.GUID_DUTY_LOG_GROUP);
            modelBuilder.Entity<DUTY_LOG>().HasOne(a => a.GUID_USER_APPROVED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_APPROVED_BY);
            modelBuilder.Entity<DUTY_LOG>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DUTY_LOG>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL>().HasOne(a => a.GUID_DRAWING_DRAWING).WithMany().HasForeignKey(c => c.GUID_DRAWING);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<Entities.TASK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<Entities.TASK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<Entities.TASK>().HasOne(a => a.GUID_PARENT_TASK_TASK).WithMany().HasForeignKey(c => c.GUID_PARENT_TASK);
            modelBuilder.Entity<NAMED_SELECTION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<NAMED_SELECTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<NAMED_SELECTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<NAMED_SELECTION>().HasOne(a => a.GUID_DEFAULT_NAMED_SELECTION_VALUE_NAMED_SELECTION_VALUE).WithMany().HasForeignKey(c => c.GUID_DEFAULT_NAMED_SELECTION_VALUE);
            modelBuilder.Entity<DUTY_LOG_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DUTY_LOG_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DUTY_LOG_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL_X_AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL_X_AREA>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL_X_AREA>().HasOne(a => a.GUID_CLEANING_QUALITY_CONTROL_CLEANING_QUALITY_CONTROL).WithMany().HasForeignKey(c => c.GUID_CLEANING_QUALITY_CONTROL);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL_X_AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_QUALITY_CONTROL_X_AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<TRANSFER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<TRANSFER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<TRANSFER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<TRANSFER>().HasOne(a => a.GUID_USER_GENERATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_GENERATED_BY);
            modelBuilder.Entity<TRANSFER>().HasOne(a => a.GUID_USER_APPROVED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_APPROVED_BY);
            modelBuilder.Entity<NAMED_SELECTION_VALUE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<NAMED_SELECTION_VALUE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<NAMED_SELECTION_VALUE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<NAMED_SELECTION_VALUE>().HasOne(a => a.GUID_NAMED_SELECTION_NAMED_SELECTION).WithMany().HasForeignKey(c => c.GUID_NAMED_SELECTION);
            modelBuilder.Entity<DUTY_LOG_CATEGORY_X_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DUTY_LOG_CATEGORY_X_GROUP>().HasOne(a => a.GUID_DUTY_LOG_CATEGORY_DUTY_LOG_CATEGORY).WithMany().HasForeignKey(c => c.GUID_DUTY_LOG_CATEGORY);
            modelBuilder.Entity<DUTY_LOG_CATEGORY_X_GROUP>().HasOne(a => a.GUID_DUTY_LOG_GROUP_DUTY_LOG_GROUP).WithMany().HasForeignKey(c => c.GUID_DUTY_LOG_GROUP);
            modelBuilder.Entity<DUTY_LOG_CATEGORY_X_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DUTY_LOG_CATEGORY_X_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CLEANING_X_CLEANING_TASK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_X_CLEANING_TASK>().HasOne(a => a.GUID_CLEANING_CLEANING).WithMany().HasForeignKey(c => c.GUID_CLEANING);
            modelBuilder.Entity<CLEANING_X_CLEANING_TASK>().HasOne(a => a.GUID_CLEANING_TASK_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_CLEANING_TASK);
            modelBuilder.Entity<CLEANING_X_CLEANING_TASK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_X_CLEANING_TASK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasOne(a => a.GUID_TRANSFER_TRANSFER).WithMany().HasForeignKey(c => c.GUID_TRANSFER);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasOne(a => a.GUID_USER_GENERATED_USR).WithMany().HasForeignKey(c => c.GUID_USER_GENERATED);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasOne(a => a.GUID_CUSTOM_FUNCTION_CUSTOM_FUNCTION).WithMany().HasForeignKey(c => c.GUID_CUSTOM_FUNCTION);
            modelBuilder.Entity<TRANSFER_X_FUNCTION>().HasOne(a => a.GUID_INTEGRATION_DATA_INTEGRATION_DATA).WithMany().HasForeignKey(c => c.GUID_INTEGRATION_DATA);
            modelBuilder.Entity<NONS_REFERENCE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<NONS_REFERENCE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<NONS_REFERENCE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_DUTY_LOG_CATEGORY_DUTY_LOG_CATEGORY).WithMany().HasForeignKey(c => c.GUID_DUTY_LOG_CATEGORY);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_DUTY_LOG_DUTY_LOG).WithMany().HasForeignKey(c => c.GUID_DUTY_LOG);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DUTY_LOG_EVENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_IMAGE_IMAGE).WithMany().HasForeignKey(c => c.GUID_IMAGE);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_COMPONENT_CATEGORY_COMPONENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_COMPONENT_CATEGORY);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_PARENT_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_PARENT_COMPONENT);
            modelBuilder.Entity<COMPONENT>().HasOne(a => a.GUID_PREFERRED_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_PREFERRED_COMPONENT);
            modelBuilder.Entity<TWO_FACTOR_TOKEN>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<TWO_FACTOR_TOKEN>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<TWO_FACTOR_TOKEN>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_CONTACT_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<OPERATIONAL_MESSAGE>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<DUTY_LOG_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<DUTY_LOG_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<DUTY_LOG_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<COMPONENT_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<USER_NOTIFICATION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_NOTIFICATION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_NOTIFICATION>().HasOne(a => a.GUID_HANDLED_BY_USER_USR).WithMany().HasForeignKey(c => c.GUID_HANDLED_BY_USER);
            modelBuilder.Entity<ORGANIZATION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ORGANIZATION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ORGANIZATION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ORGANIZATION>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<EMAIL_TEMPLATE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EMAIL_TEMPLATE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<EMAIL_TEMPLATE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<COMPONENT_X_AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<COMPONENT_X_AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT_X_AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<COMPONENT_X_AREA>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<COMPONENT_X_AREA>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<USER_PROFILE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_PROFILE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_PROFILE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<USER_PROFILE>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<USER_PROFILE>().HasOne(a => a.GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE).WithMany().HasForeignKey(c => c.GUID_ENTITY_PERMISSION_PROFILE);
            modelBuilder.Entity<ORGANIZATION_SECTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ORGANIZATION_SECTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ORGANIZATION_SECTION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ORGANIZATION_SECTION>().HasOne(a => a.GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION_UNIT);
            modelBuilder.Entity<ENERGY_BLOCK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_BLOCK>().HasOne(a => a.GUID_ENERGY_DATA_FORMAT_ENERGY_DATA_FORMAT).WithMany().HasForeignKey(c => c.GUID_ENERGY_DATA_FORMAT);
            modelBuilder.Entity<ENERGY_BLOCK>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<ENERGY_BLOCK>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<ENERGY_BLOCK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_BLOCK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT_X_EQUIPMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<COMPONENT_X_EQUIPMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT_X_EQUIPMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<COMPONENT_X_EQUIPMENT>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<COMPONENT_X_EQUIPMENT>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<USER_SESSION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_SESSION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_SESSION>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<ORGANIZATION_UNIT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ORGANIZATION_UNIT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ORGANIZATION_UNIT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ORGANIZATION_UNIT>().HasOne(a => a.GUID_ORGANIZATION_ORGANIZATION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION);
            modelBuilder.Entity<ENERGY_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasOne(a => a.GUID_SUPPLIER_AGREEMENT_SUPPLIER_AGREEMENT).WithMany().HasForeignKey(c => c.GUID_SUPPLIER_AGREEMENT);
            modelBuilder.Entity<COMPONENT_X_SUPPLIER>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<USER_X_CUSTOMER>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<USER_X_CUSTOMER>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<USER_X_CUSTOMER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_X_CUSTOMER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ORGANIZATION_X_AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ORGANIZATION_X_AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ORGANIZATION_X_AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ORGANIZATION_X_AREA>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<ORGANIZATION_X_AREA>().HasOne(a => a.GUID_ORGANIZATION_ORGANIZATION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION);
            modelBuilder.Entity<ENERGY_CONSUMPTION>().HasOne(a => a.GUID_ENERGY_COUNTER_ENERGY_COUNTER).WithMany().HasForeignKey(c => c.GUID_ENERGY_COUNTER);
            modelBuilder.Entity<ENERGY_CONSUMPTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_CONSUMPTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_PREVIOUS_VERSION_CONDITION).WithMany().HasForeignKey(c => c.GUID_PREVIOUS_VERSION);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_USER_CONFIRMED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CONFIRMED_BY);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_ADJUSTED_BY_USER_USR).WithMany().HasForeignKey(c => c.GUID_ADJUSTED_BY_USER);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_BASE_RECORD_CONDITION).WithMany().HasForeignKey(c => c.GUID_BASE_RECORD);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_PRIORITY_PRIORITY).WithMany().HasForeignKey(c => c.GUID_PRIORITY);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_CONSTRUCTION_TYPE_CONSTRUCTION_TYPE).WithMany().HasForeignKey(c => c.GUID_CONSTRUCTION_TYPE);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_MASTER_RECORD_CONDITION).WithMany().HasForeignKey(c => c.GUID_MASTER_RECORD);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_CONSEQUENCE_CONSEQUENCE).WithMany().HasForeignKey(c => c.GUID_CONSEQUENCE);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_CONSEQUENCE_TYPE_CONSEQUENCE_TYPE).WithMany().HasForeignKey(c => c.GUID_CONSEQUENCE_TYPE);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_CONDITION_TYPE_CONDITION_TYPE).WithMany().HasForeignKey(c => c.GUID_CONDITION_TYPE);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_INSPECTION_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_INSPECTION_WORK_ORDER);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_CORRECTIVE_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_CORRECTIVE_WORK_ORDER);
            modelBuilder.Entity<CONDITION>().HasOne(a => a.GUID_USER_CHECKED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CHECKED_BY);
            modelBuilder.Entity<USER_X_EXTERNAL_LOGIN>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<USER_X_EXTERNAL_LOGIN>().HasOne(a => a.GUID_EXTERNAL_LOGIN_PROVIDER_EXTERNAL_LOGIN_PROVIDER).WithMany().HasForeignKey(c => c.GUID_EXTERNAL_LOGIN_PROVIDER);
            modelBuilder.Entity<USER_X_EXTERNAL_LOGIN>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_X_EXTERNAL_LOGIN>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PASSWORD_HISTORY>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<PASSWORD_HISTORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PASSWORD_HISTORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_COUNTER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_COUNTER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_COUNTER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_COUNTER>().HasOne(a => a.GUID_LAST_ENERGY_READING_ENERGY_READING).WithMany().HasForeignKey(c => c.GUID_LAST_ENERGY_READING);
            modelBuilder.Entity<ENERGY_COUNTER>().HasOne(a => a.GUID_ENERGY_UNIT_ENERGY_UNIT).WithMany().HasForeignKey(c => c.GUID_ENERGY_UNIT);
            modelBuilder.Entity<ENERGY_COUNTER>().HasOne(a => a.GUID_ENERGY_METER_ENERGY_METER).WithMany().HasForeignKey(c => c.GUID_ENERGY_METER);
            modelBuilder.Entity<CONDITION_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONDITION_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONDITION_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_X_SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<USER_X_SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_SPARE_PART_COUNTING_LIST_SPARE_PART_COUNTING_LIST).WithMany().HasForeignKey(c => c.GUID_SPARE_PART_COUNTING_LIST);
            modelBuilder.Entity<USER_X_SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<USER_X_SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_X_SPARE_PART_COUNTING_LIST>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_USER_BOOKED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_BOOKED_BY);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_PAYMENT_TERM_PAYMENT_TERM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_TERM);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_BOOKING_CATEGORY_BOOKING_CATEGORY).WithMany().HasForeignKey(c => c.GUID_BOOKING_CATEGORY);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_TRANSFER_TRANSFER).WithMany().HasForeignKey(c => c.GUID_TRANSFER);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_CUSTOMER_DELIVERY_ADDRESS_CUSTOMER_DELIVERY_ADDRESS).WithMany().HasForeignKey(c => c.GUID_CUSTOMER_DELIVERY_ADDRESS);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_FORM);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_ORGANIZATION_ORGANIZATION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION);
            modelBuilder.Entity<PAYMENT_ORDER>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<ENERGY_DATA_FORMAT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_DATA_FORMAT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_DATA_FORMAT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_DATA_FORMAT>().HasOne(a => a.GUID_IMPORT_FUNCTION_CUSTOM_FUNCTION).WithMany().HasForeignKey(c => c.GUID_IMPORT_FUNCTION);
            modelBuilder.Entity<ENERGY_DATA_FORMAT>().HasOne(a => a.GUID_EXPORT_FUNCTION_CUSTOM_FUNCTION).WithMany().HasForeignKey(c => c.GUID_EXPORT_FUNCTION);
            modelBuilder.Entity<CONSEQUENCE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONSEQUENCE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONSEQUENCE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_X_USER_NOTIFICATION>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<USER_X_USER_NOTIFICATION>().HasOne(a => a.GUID_USER_NOTIFICATION_USER_NOTIFICATION).WithMany().HasForeignKey(c => c.GUID_USER_NOTIFICATION);
            modelBuilder.Entity<USER_X_USER_NOTIFICATION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_X_USER_NOTIFICATION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER_FORM>().HasOne(a => a.GUID_REPORT_REPORT).WithMany().HasForeignKey(c => c.GUID_REPORT);
            modelBuilder.Entity<PAYMENT_ORDER_FORM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PAYMENT_ORDER_FORM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER_FORM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_JOB>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_JOB>().HasOne(a => a.GUID_ENERGY_BLOCK_ENERGY_BLOCK).WithMany().HasForeignKey(c => c.GUID_ENERGY_BLOCK);
            modelBuilder.Entity<ENERGY_JOB>().HasOne(a => a.GUID_USER_ENDED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_ENDED_BY);
            modelBuilder.Entity<ENERGY_JOB>().HasOne(a => a.GUID_ENERGY_PERIODIC_TASK_ENERGY_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_ENERGY_PERIODIC_TASK);
            modelBuilder.Entity<ENERGY_JOB>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_JOB>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONSEQUENCE_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONSEQUENCE_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONSEQUENCE_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_X_WEB_LIST_VIEW>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_X_WEB_LIST_VIEW>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_X_WEB_LIST_VIEW>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<USER_X_WEB_LIST_VIEW>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<USER_X_WEB_LIST_VIEW>().HasOne(a => a.GUID_WEB_LIST_VIEW_WEB_LIST_VIEW).WithMany().HasForeignKey(c => c.GUID_WEB_LIST_VIEW);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_ARTICLE_ARTICLE).WithMany().HasForeignKey(c => c.GUID_ARTICLE);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_PAYMENT_ORDER_PAYMENT_ORDER).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<ENERGY_JOB_X_COUNTER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_JOB_X_COUNTER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_JOB_X_COUNTER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_JOB_X_COUNTER>().HasOne(a => a.GUID_ENERGY_READING_ENERGY_READING).WithMany().HasForeignKey(c => c.GUID_ENERGY_READING);
            modelBuilder.Entity<ENERGY_JOB_X_COUNTER>().HasOne(a => a.GUID_ENERGY_JOB_ENERGY_JOB).WithMany().HasForeignKey(c => c.GUID_ENERGY_JOB);
            modelBuilder.Entity<ENERGY_JOB_X_COUNTER>().HasOne(a => a.GUID_ENERGY_COUNTER_ENERGY_COUNTER).WithMany().HasForeignKey(c => c.GUID_ENERGY_COUNTER);
            modelBuilder.Entity<CONSTRUCTION_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONSTRUCTION_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONSTRUCTION_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USER_X_WEB_PROFILE>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<USER_X_WEB_PROFILE>().HasOne(a => a.GUID_WEB_PROFILE_WEB_PROFILE).WithMany().HasForeignKey(c => c.GUID_WEB_PROFILE);
            modelBuilder.Entity<USER_X_WEB_PROFILE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USER_X_WEB_PROFILE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM_X_SERVICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM_X_SERVICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM_X_SERVICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM_X_SERVICE>().HasOne(a => a.GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_ITEM);
            modelBuilder.Entity<PAYMENT_ORDER_ITEM_X_SERVICE>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_ENERGY_CATEGORY_ENERGY_CATEGORY).WithMany().HasForeignKey(c => c.GUID_ENERGY_CATEGORY);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_ENERGY_METER_GROUP_ENERGY_METER).WithMany().HasForeignKey(c => c.GUID_ENERGY_METER_GROUP);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_ENERGY_PERIODIC_TASK_ENERGY_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_ENERGY_PERIODIC_TASK);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_SUPPLIER1_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER1);
            modelBuilder.Entity<ENERGY_METER>().HasOne(a => a.GUID_SUPPLIER2_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER2);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<CONSUMABLE>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<CLEANING_TASK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_TASK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_TASK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_IMAGE_IMAGE).WithMany().HasForeignKey(c => c.GUID_IMAGE);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_MOBILE_MENU_PROFILE_MOBILE_MENU_PROFILE).WithMany().HasForeignKey(c => c.GUID_MOBILE_MENU_PROFILE);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_BUILDING_SELECTION_BUILDING_SELECTION).WithMany().HasForeignKey(c => c.GUID_BUILDING_SELECTION);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_USER_GROUP_USR).WithMany().HasForeignKey(c => c.GUID_USER_GROUP);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_WEB_MENU_WEB_MENU).WithMany().HasForeignKey(c => c.GUID_WEB_MENU);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_START_PAGE_START_PAGE).WithMany().HasForeignKey(c => c.GUID_START_PAGE);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE).WithMany().HasForeignKey(c => c.GUID_ENTITY_PERMISSION_PROFILE);
            modelBuilder.Entity<USR>().HasOne(a => a.GUID_LANGUAGE_LANGUAGE).WithMany().HasForeignKey(c => c.GUID_LANGUAGE);
            modelBuilder.Entity<PAYMENT_TERM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PAYMENT_TERM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PAYMENT_TERM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_PERIODIC_TASK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_PERIODIC_TASK>().HasOne(a => a.GUID_USER_ENDED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_ENDED_BY);
            modelBuilder.Entity<ENERGY_PERIODIC_TASK>().HasOne(a => a.GUID_ENERGY_BLOCK_ENERGY_BLOCK).WithMany().HasForeignKey(c => c.GUID_ENERGY_BLOCK);
            modelBuilder.Entity<ENERGY_PERIODIC_TASK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_PERIODIC_TASK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTACT_PERSON>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTACT_PERSON>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<CONTACT_PERSON>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<CONTACT_PERSON>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTACT_PERSON>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<RESOURCE_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<RESOURCE_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<RESOURCE_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<VIDEO>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<VIDEO>().HasOne(a => a.GUID_VIDEO_BINARY_VIDEO_BINARY).WithMany().HasForeignKey(c => c.GUID_VIDEO_BINARY);
            modelBuilder.Entity<VIDEO>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<VIDEO>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIOD_OF_NOTICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIOD_OF_NOTICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIOD_OF_NOTICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_READING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_READING>().HasOne(a => a.GUID_PREVIOUS_ENERGY_READING_ENERGY_READING).WithMany().HasForeignKey(c => c.GUID_PREVIOUS_ENERGY_READING);
            modelBuilder.Entity<ENERGY_READING>().HasOne(a => a.GUID_ENERGY_COUNTER_ENERGY_COUNTER).WithMany().HasForeignKey(c => c.GUID_ENERGY_COUNTER);
            modelBuilder.Entity<ENERGY_READING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_READING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_APPROVAL_STATUS_MODIFIED_BY_USER_USR).WithMany().HasForeignKey(c => c.GUID_APPROVAL_STATUS_MODIFIED_BY_USER);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_LAST_CONTRACT_ADJUSTMENT_CONTRACT_ADJUSTMENT).WithMany().HasForeignKey(c => c.GUID_LAST_CONTRACT_ADJUSTMENT);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_PAYMENT_TERM_PAYMENT_TERM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_TERM);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_USER_CHECKOUT_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CHECKOUT_BY);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_CONTRACT_ADJUSTMENT_CONTRACT_ADJUSTMENT).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ADJUSTMENT);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_INVOICING_INVOICING).WithMany().HasForeignKey(c => c.GUID_INVOICING);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_FORM);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_AREA_CATEGORY_AREA_CATEGORY).WithMany().HasForeignKey(c => c.GUID_AREA_CATEGORY);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_CONTRACT_CATEGORY_CONTRACT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_CONTRACT_CATEGORY);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_CONTRACT_TYPE_CONTRACT_TYPE).WithMany().HasForeignKey(c => c.GUID_CONTRACT_TYPE);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_CUSTOMER_DELIVERY_ADDRESS_CUSTOMER_DELIVERY_ADDRESS).WithMany().HasForeignKey(c => c.GUID_CUSTOMER_DELIVERY_ADDRESS);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_PERIOD_OF_NOTICE_PERIOD_OF_NOTICE).WithMany().HasForeignKey(c => c.GUID_PERIOD_OF_NOTICE);
            modelBuilder.Entity<CONTRACT>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_CONDITION_CONDITION).WithMany().HasForeignKey(c => c.GUID_CONDITION);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_WORK_ORDER_X_AREA_WORK_ORDER_X_AREA).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER_X_AREA);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_AREA_GROUP_AREA).WithMany().HasForeignKey(c => c.GUID_AREA_GROUP);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_OWNER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_OWNER);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_AREA_CATEGORY_AREA_CATEGORY).WithMany().HasForeignKey(c => c.GUID_AREA_CATEGORY);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_ORGANIZATION_ORGANIZATION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION_SECTION);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION_UNIT);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_CLEANING_CLEANING).WithMany().HasForeignKey(c => c.GUID_CLEANING);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_CLEANER_PERSON).WithMany().HasForeignKey(c => c.GUID_CLEANER);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_CLEANING_QUALITY_CLEANING_QUALITY).WithMany().HasForeignKey(c => c.GUID_CLEANING_QUALITY);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_DRAWING_DRAWING).WithMany().HasForeignKey(c => c.GUID_DRAWING);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_CONDITION_TYPE_CONDITION_TYPE).WithMany().HasForeignKey(c => c.GUID_CONDITION_TYPE);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_AREA_TYPE_AREA_TYPE).WithMany().HasForeignKey(c => c.GUID_AREA_TYPE);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_CLEANING_TEAM_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_CLEANING_TEAM);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_MEDICAL_OWNERSHIP_MEDICAL_OWNERSHIP).WithMany().HasForeignKey(c => c.GUID_MEDICAL_OWNERSHIP);
            modelBuilder.Entity<AREA>().HasOne(a => a.GUID_MEDICAL_REGION_MEDICAL_REGION).WithMany().HasForeignKey(c => c.GUID_MEDICAL_REGION);
            modelBuilder.Entity<VIDEO_BINARY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<VIDEO_BINARY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_INVOICE_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_INVOICE_CUSTOMER);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_ACTIVITY_GROUP_ACTIVITY_GROUP).WithMany().HasForeignKey(c => c.GUID_ACTIVITY_GROUP);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_RESOURCE_RESPONSIBLE_PERSON).WithMany().HasForeignKey(c => c.GUID_RESOURCE_RESPONSIBLE);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_EQUIPMENT_HOURS_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_HOURS);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_RESPONSIBLE_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY).WithMany().HasForeignKey(c => c.GUID_ACTIVITY_CATEGORY);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_CAUSE_CAUSE).WithMany().HasForeignKey(c => c.GUID_CAUSE);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_PRIORITY_PRIORITY).WithMany().HasForeignKey(c => c.GUID_PRIORITY);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_PURCHASE_ORDER_FORM_PURCHASE_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER_FORM);
            modelBuilder.Entity<PERIODIC_TASK>().HasOne(a => a.GUID_TEMPLATE_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_TEMPLATE);
            modelBuilder.Entity<ENERGY_UNIT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENERGY_UNIT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENERGY_UNIT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENERGY_UNIT>().HasOne(a => a.GUID_ENERGY_CATEGORY_ENERGY_CATEGORY).WithMany().HasForeignKey(c => c.GUID_ENERGY_CATEGORY);
            modelBuilder.Entity<WEB_TEXT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<WEB_TEXT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<POSTAL_CODE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<POSTAL_CODE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_TASK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_TASK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_TASK>().HasOne(a => a.GUID_ENTITY_LINK_ENTITY_LINK).WithMany().HasForeignKey(c => c.GUID_ENTITY_LINK);
            modelBuilder.Entity<CONTROL_LIST>().HasOne(a => a.GUID_MASTER_RECORD_CONTROL_LIST).WithMany().HasForeignKey(c => c.GUID_MASTER_RECORD);
            modelBuilder.Entity<CONTROL_LIST>().HasOne(a => a.GUID_REFERENCE_TYPE_NOT_EXECUTED_REFERENCE_TYPE).WithMany().HasForeignKey(c => c.GUID_REFERENCE_TYPE_NOT_EXECUTED);
            modelBuilder.Entity<CONTROL_LIST>().HasOne(a => a.GUID_PREVIOUS_VERSION_CONTROL_LIST).WithMany().HasForeignKey(c => c.GUID_PREVIOUS_VERSION);
            modelBuilder.Entity<CONTROL_LIST>().HasOne(a => a.GUID_DRAFT_VERSION_CONTROL_LIST).WithMany().HasForeignKey(c => c.GUID_DRAFT_VERSION);
            modelBuilder.Entity<CONTROL_LIST>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTROL_LIST>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTROL_LIST>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_USER_TOKEN>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<WEB_USER_TOKEN>().HasOne(a => a.GUID_API_CLIENT_API_CLIENT).WithMany().HasForeignKey(c => c.GUID_API_CLIENT);
            modelBuilder.Entity<WEB_USER_TOKEN>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_USER_TOKEN>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PRICE_SHEET>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PRICE_SHEET>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PRICE_SHEET>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PRICE_SHEET>().HasOne(a => a.GUID_PRICE_SHEET_CATEGORY_PRICE_SHEET_CATEGORY).WithMany().HasForeignKey(c => c.GUID_PRICE_SHEET_CATEGORY);
            modelBuilder.Entity<PRICE_SHEET>().HasOne(a => a.GUID_LAST_APPROVED_REVISION_PRICE_SHEET_REVISION).WithMany().HasForeignKey(c => c.GUID_LAST_APPROVED_REVISION);
            modelBuilder.Entity<CONTROL_LIST_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTROL_LIST_ITEM>().HasOne(a => a.GUID_CONTROL_LIST_CONTROL_LIST).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST);
            modelBuilder.Entity<CONTROL_LIST_ITEM>().HasOne(a => a.GUID_PARENT_CONTROL_LIST_ITEM_CONTROL_LIST_ITEM).WithMany().HasForeignKey(c => c.GUID_PARENT_CONTROL_LIST_ITEM);
            modelBuilder.Entity<CONTROL_LIST_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTROL_LIST_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTROL_LIST_ITEM>().HasOne(a => a.GUID_CONTROL_LIST_LOG_ITEM_CONTROL_LIST_LOG_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_LOG_ITEM);
            modelBuilder.Entity<ACCOUNT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ACCOUNT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ACCOUNT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_ALARM_LOG_ALARM_LOG).WithMany().HasForeignKey(c => c.GUID_ALARM_LOG);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_INVOICE_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_INVOICE_CUSTOMER);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_ACTIVITY_GROUP_ACTIVITY_GROUP).WithMany().HasForeignKey(c => c.GUID_ACTIVITY_GROUP);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_RESOURCE_RESPONSIBLE_PERSON).WithMany().HasForeignKey(c => c.GUID_RESOURCE_RESPONSIBLE);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_PROJECT_MILESTONE_PROJECT_MILESTONE).WithMany().HasForeignKey(c => c.GUID_PROJECT_MILESTONE);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_USER_CLOSED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CLOSED_BY);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_GIS_ENTITY_GIS_ENTITY).WithMany().HasForeignKey(c => c.GUID_GIS_ENTITY);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_CAUSE_CAUSE).WithMany().HasForeignKey(c => c.GUID_CAUSE);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_ACTIVITY_CATEGORY_ACTIVITY_CATEGORY).WithMany().HasForeignKey(c => c.GUID_ACTIVITY_CATEGORY);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_PRIORITY_PRIORITY).WithMany().HasForeignKey(c => c.GUID_PRIORITY);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_RESPONSIBLE_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_USER_PRINTED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_PRINTED_BY);
            modelBuilder.Entity<WORK_ORDER>().HasOne(a => a.GUID_REQUEST_REQUEST).WithMany().HasForeignKey(c => c.GUID_REQUEST);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_X_ATTRIBUTE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENTITY_X_ATTRIBUTE>().HasOne(a => a.GUID_ENTITY_ATTRIBUTE_ENTITY_ATTRIBUTE).WithMany().HasForeignKey(c => c.GUID_ENTITY_ATTRIBUTE);
            modelBuilder.Entity<ENTITY_X_ATTRIBUTE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_X_ATTRIBUTE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_X_ATTRIBUTE>().HasOne(a => a.GUID_CLEANING_TASK_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_CLEANING_TASK);
            modelBuilder.Entity<CONTROL_LIST_ITEM_ANSWER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTROL_LIST_ITEM_ANSWER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTROL_LIST_ITEM_ANSWER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTROL_LIST_ITEM_ANSWER>().HasOne(a => a.GUID_CONTROL_LIST_ITEM_CONTROL_LIST_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_ITEM);
            modelBuilder.Entity<CONTROL_LIST_ITEM_ANSWER>().HasOne(a => a.GUID_CONTROL_LIST_X_ENTITY_CONTROL_LIST_X_ENTITY).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_X_ENTITY);
            modelBuilder.Entity<ACCOUNT_X_ACCOUNTING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ACCOUNT_X_ACCOUNTING>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<ACCOUNT_X_ACCOUNTING>().HasOne(a => a.GUID_ACCOUNTING_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING);
            modelBuilder.Entity<ACCOUNT_X_ACCOUNTING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ACCOUNT_X_ACCOUNTING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_ITEM);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_PAYMENT_ORDER_ITEM_ADJUSTMENT_PAYMENT_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_ITEM_ADJUSTMENT);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER_ITEM);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_WORK_ORDER_X_EQUIPMENT_WORK_ORDER_X_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER_X_EQUIPMENT);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_WORK_ORDER_X_RESOURCE_GROUP_WORK_ORDER_X_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER_X_RESOURCE_GROUP);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_WORK_ORDER_X_SPARE_PART_WORK_ORDER_X_SPARE_PART).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER_X_SPARE_PART);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_COST_COST).WithMany().HasForeignKey(c => c.GUID_COST);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_ARTICLE_ARTICLE).WithMany().HasForeignKey(c => c.GUID_ARTICLE);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WORK_ORDER_INVOICE_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY_PRICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY_PRICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY_PRICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY_PRICE>().HasOne(a => a.GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION).WithMany().HasForeignKey(c => c.GUID_PRICE_SHEET_REVISION);
            modelBuilder.Entity<PRICE_SHEET_CATEGORY_PRICE>().HasOne(a => a.GUID_AREA_CATEGORY_AREA_CATEGORY).WithMany().HasForeignKey(c => c.GUID_AREA_CATEGORY);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_TEMPLATE_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_TEMPLATE);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_CONTRACTOR_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_CONTRACTOR);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_INSTALLER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_INSTALLER);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_SERVICE_PROVIDER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SERVICE_PROVIDER);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_NONS_REFERENCE_NONS_REFERENCE).WithMany().HasForeignKey(c => c.GUID_NONS_REFERENCE);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_GIS_ENTITY_GIS_ENTITY).WithMany().HasForeignKey(c => c.GUID_GIS_ENTITY);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_OPERATIONS_MANAGER_PERSON).WithMany().HasForeignKey(c => c.GUID_OPERATIONS_MANAGER);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_EQUIPMENT_TEMPLATE_EQUIPMENT_TEMPLATE).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_TEMPLATE);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_EQUIPMENT_GROUP_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_GROUP);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_EQUIPMENT_CATEGORY_EQUIPMENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_CATEGORY);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_ORGANIZATION_ORGANIZATION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION_SECTION);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION_UNIT);
            modelBuilder.Entity<EQUIPMENT>().HasOne(a => a.GUID_DRAWING_DRAWING).WithMany().HasForeignKey(c => c.GUID_DRAWING);
            modelBuilder.Entity<CONTROL_LIST_LOG_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTROL_LIST_LOG_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTROL_LIST_LOG_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ACCOUNTING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ACCOUNTING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ACCOUNTING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_DOCUMENT_DOCUMENT).WithMany().HasForeignKey(c => c.GUID_DOCUMENT);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_CONSEQUENCE_CONSEQUENCE).WithMany().HasForeignKey(c => c.GUID_CONSEQUENCE);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_CONSEQUENCE_TYPE_CONSEQUENCE_TYPE).WithMany().HasForeignKey(c => c.GUID_CONSEQUENCE_TYPE);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_CONDITION_TYPE_CONDITION_TYPE).WithMany().HasForeignKey(c => c.GUID_CONDITION_TYPE);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_INSPECTION_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_INSPECTION_WORK_ORDER);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_CORRECTIVE_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_CORRECTIVE_WORK_ORDER);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_USER_CHECKED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CHECKED_BY);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WORK_ORDER_X_AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PRICE_SHEET_REVISION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PRICE_SHEET_REVISION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PRICE_SHEET_REVISION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PRICE_SHEET_REVISION>().HasOne(a => a.GUID_USER_APPROVED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_APPROVED_BY);
            modelBuilder.Entity<PRICE_SHEET_REVISION>().HasOne(a => a.GUID_PRICE_SHEET_PRICE_SHEET).WithMany().HasForeignKey(c => c.GUID_PRICE_SHEET);
            modelBuilder.Entity<EQUIPMENT_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EQUIPMENT_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<EQUIPMENT_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTROL_LIST_RULE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTROL_LIST_RULE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTROL_LIST_RULE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTROL_LIST_RULE>().HasOne(a => a.GUID_CONTROL_LIST_CONTROL_LIST).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST);
            modelBuilder.Entity<CONTROL_LIST_RULE>().HasOne(a => a.GUID_CONTROL_LIST_ITEM_CONTROL_LIST_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST_ITEM);
            modelBuilder.Entity<ACCOUNTING_X_ACCOUNTING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ACCOUNTING_X_ACCOUNTING>().HasOne(a => a.GUID_PARENT_ACCOUNTING_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_PARENT_ACCOUNTING);
            modelBuilder.Entity<ACCOUNTING_X_ACCOUNTING>().HasOne(a => a.GUID_CHILD_ACCOUNTING_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_CHILD_ACCOUNTING);
            modelBuilder.Entity<ACCOUNTING_X_ACCOUNTING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ACCOUNTING_X_ACCOUNTING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<WORK_ORDER_X_EQUIPMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER_X_EQUIPMENT>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<WORK_ORDER_X_EQUIPMENT>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<WORK_ORDER_X_EQUIPMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WORK_ORDER_X_EQUIPMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PRICE_SHEET_X_BUILDING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PRICE_SHEET_X_BUILDING>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<PRICE_SHEET_X_BUILDING>().HasOne(a => a.GUID_PRICE_SHEET_PRICE_SHEET).WithMany().HasForeignKey(c => c.GUID_PRICE_SHEET);
            modelBuilder.Entity<PRICE_SHEET_X_BUILDING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PRICE_SHEET_X_BUILDING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOUR_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOUR_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOUR_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_REFERENCE_DATA_NOT_EXECUTED_REFERENCE_DATA).WithMany().HasForeignKey(c => c.GUID_REFERENCE_DATA_NOT_EXECUTED);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_CONTROL_LIST_CONTROL_LIST).WithMany().HasForeignKey(c => c.GUID_CONTROL_LIST);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_USER_CLOSED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CLOSED_BY);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTROL_LIST_X_ENTITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ACTIVITY_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ACTIVITY_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ACTIVITY_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<WORK_ORDER_X_RESOURCE_GROUP>().HasOne(a => a.GUID_HOUR_TYPE_HOUR_TYPE).WithMany().HasForeignKey(c => c.GUID_HOUR_TYPE);
            modelBuilder.Entity<PRIORITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PRIORITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PRIORITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOURS>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOURS>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOURS>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOURS>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<EQUIPMENT_OPERATING_HOURS>().HasOne(a => a.GUID_EQUIPMENT_OPERATING_HOUR_TYPE_EQUIPMENT_OPERATING_HOUR_TYPE).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_OPERATING_HOUR_TYPE);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_PURCHASE_ORDER_PURCHASE_ORDER).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_CONSUMABLE_CONSUMABLE).WithMany().HasForeignKey(c => c.GUID_CONSUMABLE);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<COST>().HasOne(a => a.GUID_PURCHASE_ORDER_ITEM_PURCHASE_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER_ITEM);
            modelBuilder.Entity<ACTIVITY_CONSTRAINT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ACTIVITY_CONSTRAINT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ACTIVITY_CONSTRAINT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ACTIVITY_CONSTRAINT>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<ACTIVITY_CONSTRAINT>().HasOne(a => a.GUID_PERIODIC_TASK_MASTER_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK_MASTER);
            modelBuilder.Entity<WORK_ORDER_X_SPARE_PART>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WORK_ORDER_X_SPARE_PART>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<WORK_ORDER_X_SPARE_PART>().HasOne(a => a.GUID_SPARE_PART_SPARE_PART).WithMany().HasForeignKey(c => c.GUID_SPARE_PART);
            modelBuilder.Entity<WORK_ORDER_X_SPARE_PART>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WORK_ORDER_X_SPARE_PART>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_PROJECT_CATEGORY_PROJECT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_PROJECT_CATEGORY);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_MANAGER_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_MANAGER_PERSON);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_OWNER_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_OWNER_PERSON);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_PROJECT_STATUS_PROJECT_STATUS).WithMany().HasForeignKey(c => c.GUID_PROJECT_STATUS);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_RESPONSIBLE_PERSON2_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON2);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_RESPONSIBLE_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_PROJECT_TYPE_PROJECT_TYPE).WithMany().HasForeignKey(c => c.GUID_PROJECT_TYPE);
            modelBuilder.Entity<PROJECT>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE>().HasOne(a => a.GUID_PARENT_EQUIPMENT_TEMPLATE_EQUIPMENT_TEMPLATE).WithMany().HasForeignKey(c => c.GUID_PARENT_EQUIPMENT_TEMPLATE);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE>().HasOne(a => a.GUID_EQUIPMENT_CATEGORY_EQUIPMENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_CATEGORY);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<COST_CENTER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<COST_CENTER>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<COST_CENTER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<COST_CENTER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ACTIVITY_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ACTIVITY_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ACTIVITY_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<WORKING_DAYS_OFF>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WORKING_DAYS_OFF>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PROJECT_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE_X_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE_X_CATEGORY>().HasOne(a => a.GUID_EQUIPMENT_TEMPLATE_EQUIPMENT_TEMPLATE).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_TEMPLATE);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE_X_CATEGORY>().HasOne(a => a.GUID_EQUIPMENT_CATEGORY_EQUIPMENT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT_CATEGORY);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE_X_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EQUIPMENT_TEMPLATE_X_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CUSTOM_FUNCTION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOM_FUNCTION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ADJUSTMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ADJUSTMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ADJUSTMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasOne(a => a.GUID_PREVIOUS_CONTRACT_ADJUSTMENT_CONTRACT_ADJUSTMENT).WithMany().HasForeignKey(c => c.GUID_PREVIOUS_CONTRACT_ADJUSTMENT);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasOne(a => a.GUID_ADJUSTMENT_ADJUSTMENT).WithMany().HasForeignKey(c => c.GUID_ADJUSTMENT);
            modelBuilder.Entity<CONTRACT_ADJUSTMENT>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_ORGANIZATION_SECTION_ORGANIZATION_SECTION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION_SECTION);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_ORGANIZATION_UNIT_ORGANIZATION_UNIT).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION_UNIT);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_ORGANIZATION_ORGANIZATION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION);
            modelBuilder.Entity<PERSON>().HasOne(a => a.GUID_PERSON_ROLE_PERSON_ROLE).WithMany().HasForeignKey(c => c.GUID_PERSON_ROLE);
            modelBuilder.Entity<VIDEO_X_ENTITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<VIDEO_X_ENTITY>().HasOne(a => a.GUID_VIDEO_VIDEO).WithMany().HasForeignKey(c => c.GUID_VIDEO);
            modelBuilder.Entity<VIDEO_X_ENTITY>().HasOne(a => a.GUID_CLEANING_TASK_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_CLEANING_TASK);
            modelBuilder.Entity<VIDEO_X_ENTITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<VIDEO_X_ENTITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIODIC_TASK_X_AREA>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<PERIODIC_TASK_X_AREA>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<PERIODIC_TASK_X_AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_ATTRIBUTE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_ATTRIBUTE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_ATTRIBUTE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENTITY_ATTRIBUTE>().HasOne(a => a.GUID_NAMED_SELECTION_NAMED_SELECTION).WithMany().HasForeignKey(c => c.GUID_NAMED_SELECTION);
            modelBuilder.Entity<CONTRACT_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasOne(a => a.GUID_CLEANING_TASK_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_CLEANING_TASK);
            modelBuilder.Entity<CLEANING_COMPLETION>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<WEB_DASHBOARD>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WEB_DASHBOARD>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_DASHBOARD>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_EQUIPMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIODIC_TASK_X_EQUIPMENT>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<PERIODIC_TASK_X_EQUIPMENT>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<PERIODIC_TASK_X_EQUIPMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_EQUIPMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_REQUEST_REQUEST).WithMany().HasForeignKey(c => c.GUID_REQUEST);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<ENTITY_COMMENT>().HasOne(a => a.GUID_DEVIATION_DEVIATION).WithMany().HasForeignKey(c => c.GUID_DEVIATION);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_PREVIOUS_VERSION_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_PREVIOUS_VERSION);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_MASTER_RECORD_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_MASTER_RECORD);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_AREA_CATEGORY_AREA_CATEGORY).WithMany().HasForeignKey(c => c.GUID_AREA_CATEGORY);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ARTICLE_ARTICLE).WithMany().HasForeignKey(c => c.GUID_ARTICLE);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_ORGANIZATION_ORGANIZATION).WithMany().HasForeignKey(c => c.GUID_ORGANIZATION);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_PRICE_SHEET_REVISION_PRICE_SHEET_REVISION).WithMany().HasForeignKey(c => c.GUID_PRICE_SHEET_REVISION);
            modelBuilder.Entity<CONTRACT_ITEM>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<WEB_DASHBOARD_WIDGET>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WEB_DASHBOARD_WIDGET>().HasOne(a => a.GUID_WEB_DASHBOARD_WEB_DASHBOARD).WithMany().HasForeignKey(c => c.GUID_WEB_DASHBOARD);
            modelBuilder.Entity<WEB_DASHBOARD_WIDGET>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_DASHBOARD_WIDGET>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasOne(a => a.GUID_HOUR_TYPE_HOUR_TYPE).WithMany().HasForeignKey(c => c.GUID_HOUR_TYPE);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasOne(a => a.GUID_RESOURCE_GROUP_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_RESOURCE_GROUP);
            modelBuilder.Entity<PERIODIC_TASK_X_RESOURCE_GROUP>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<ENTITY_COUNTER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_COUNTER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_COUNTER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasOne(a => a.GUID_CLEANING_TASK_CLEANING_TASK).WithMany().HasForeignKey(c => c.GUID_CLEANING_TASK);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasOne(a => a.GUID_CLEANER_PERSON).WithMany().HasForeignKey(c => c.GUID_CLEANER);
            modelBuilder.Entity<AREA_X_CLEANING_TASK>().HasOne(a => a.GUID_CLEANING_TEAM_RESOURCE_GROUP).WithMany().HasForeignKey(c => c.GUID_CLEANING_TEAM);
            modelBuilder.Entity<CONTRACT_ITEM_X_SERVICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_ITEM_X_SERVICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_ITEM_X_SERVICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_ITEM_X_SERVICE>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<CONTRACT_ITEM_X_SERVICE>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<WEB_LIST_VIEW>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WEB_LIST_VIEW>().HasOne(a => a.GUID_USER_USR).WithMany().HasForeignKey(c => c.GUID_USER);
            modelBuilder.Entity<WEB_LIST_VIEW>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_LIST_VIEW>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_SPARE_PART>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_SPARE_PART>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_SPARE_PART>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIODIC_TASK_X_SPARE_PART>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<PERIODIC_TASK_X_SPARE_PART>().HasOne(a => a.GUID_SPARE_PART_SPARE_PART).WithMany().HasForeignKey(c => c.GUID_SPARE_PART);
            modelBuilder.Entity<ENTITY_HISTORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_HISTORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_MANAGER_PERSON1_PERSON).WithMany().HasForeignKey(c => c.GUID_MANAGER_PERSON1);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_MANAGER_PERSON2_PERSON).WithMany().HasForeignKey(c => c.GUID_MANAGER_PERSON2);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_OPERATIONS_MANAGER_PERSON).WithMany().HasForeignKey(c => c.GUID_OPERATIONS_MANAGER);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_ESTATE_ESTATE).WithMany().HasForeignKey(c => c.GUID_ESTATE);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_RENTAL_GROUP_RENTAL_GROUP).WithMany().HasForeignKey(c => c.GUID_RENTAL_GROUP);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_BUILDING_CATEGORY_BUILDING_CATEGORY).WithMany().HasForeignKey(c => c.GUID_BUILDING_CATEGORY);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_REGION_REGION).WithMany().HasForeignKey(c => c.GUID_REGION);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_POST_POSTAL_CODE).WithMany().HasForeignKey(c => c.GUID_POST);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_USER_AREA_COMPUTED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_AREA_COMPUTED_BY);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_USER_CAF_COMPUTED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CAF_COMPUTED_BY);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_CONDITION_CONDITION).WithMany().HasForeignKey(c => c.GUID_CONDITION);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_BUILDING_TYPE_REFERENCE_DATA).WithMany().HasForeignKey(c => c.GUID_BUILDING_TYPE);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_GIS_ENTITY_GIS_ENTITY).WithMany().HasForeignKey(c => c.GUID_GIS_ENTITY);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_BUSINESS_UNIT_REFERENCE_DATA).WithMany().HasForeignKey(c => c.GUID_BUSINESS_UNIT);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_OWNER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_OWNER);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_EXTERNAL_FACILITY_MANAGER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_EXTERNAL_FACILITY_MANAGER);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_FACILITY_MANAGER_PERSON).WithMany().HasForeignKey(c => c.GUID_FACILITY_MANAGER);
            modelBuilder.Entity<BUILDING>().HasOne(a => a.GUID_TEMPLATE_BUILDING).WithMany().HasForeignKey(c => c.GUID_TEMPLATE);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_FORM);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_PAYMENT_TERM_PAYMENT_TERM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_TERM);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_INVOICING_INVOICING).WithMany().HasForeignKey(c => c.GUID_INVOICING);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_CONTRACT_CATEGORY_CONTRACT_CATEGORY).WithMany().HasForeignKey(c => c.GUID_CONTRACT_CATEGORY);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_PERIOD_OF_NOTICE_PERIOD_OF_NOTICE).WithMany().HasForeignKey(c => c.GUID_PERIOD_OF_NOTICE);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<CONTRACT_LEASE>().HasOne(a => a.GUID_CONTRACT_TYPE_CONTRACT_TYPE).WithMany().HasForeignKey(c => c.GUID_CONTRACT_TYPE);
            modelBuilder.Entity<WEB_LIST_VIEW_COLUMN>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<WEB_LIST_VIEW_COLUMN>().HasOne(a => a.GUID_WEB_LIST_VIEW_WEB_LIST_VIEW).WithMany().HasForeignKey(c => c.GUID_WEB_LIST_VIEW);
            modelBuilder.Entity<WEB_LIST_VIEW_COLUMN>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_LIST_VIEW_COLUMN>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_STANDARD_TEXT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIODIC_TASK_X_STANDARD_TEXT>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<PERIODIC_TASK_X_STANDARD_TEXT>().HasOne(a => a.GUID_STANDARD_TEXT_STANDARD_TEXT).WithMany().HasForeignKey(c => c.GUID_STANDARD_TEXT);
            modelBuilder.Entity<PERIODIC_TASK_X_STANDARD_TEXT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIODIC_TASK_X_STANDARD_TEXT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_LINK>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_LINK>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_LINK>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_ARTICLE_ARTICLE).WithMany().HasForeignKey(c => c.GUID_ARTICLE);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_CONTRACT_LEASE_CONTRACT_LEASE).WithMany().HasForeignKey(c => c.GUID_CONTRACT_LEASE);
            modelBuilder.Entity<CONTRACT_LEASE_ITEM>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<WEB_MENU>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_MENU>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERIODIZATION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERIODIZATION>().HasOne(a => a.GUID_PAYMENT_ORDER_ITEM_PAYMENT_ORDER_ITEM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER_ITEM);
            modelBuilder.Entity<PERIODIZATION>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<PERIODIZATION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERIODIZATION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_PAYMENT_ORDER_PAYMENT_ORDER).WithMany().HasForeignKey(c => c.GUID_PAYMENT_ORDER);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_PURCHASE_ORDER_PURCHASE_ORDER).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<ENTITY_MAIL_LIST>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasOne(a => a.GUID_SERVICE_SERVICE).WithMany().HasForeignKey(c => c.GUID_SERVICE);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<CONTRACT_PRICE_X_SERVICE>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<WEB_PROFILE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_PROFILE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PERSON_ROLE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PERSON_ROLE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PERSON_ROLE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_PERMISSION>().HasOne(a => a.GUID_ENTITY_PERMISSION_PROFILE_ENTITY_PERMISSION_PROFILE).WithMany().HasForeignKey(c => c.GUID_ENTITY_PERMISSION_PROFILE);
            modelBuilder.Entity<ENTITY_PERMISSION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_PERMISSION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<WEB_PROFILE_X_WEB_MENU>().HasOne(a => a.GUID_WEB_MENU_WEB_MENU).WithMany().HasForeignKey(c => c.GUID_WEB_MENU);
            modelBuilder.Entity<WEB_PROFILE_X_WEB_MENU>().HasOne(a => a.GUID_WEB_PROFILE_WEB_PROFILE).WithMany().HasForeignKey(c => c.GUID_WEB_PROFILE);
            modelBuilder.Entity<WEB_PROFILE_X_WEB_MENU>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<WEB_PROFILE_X_WEB_MENU>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PLOT_X_BUILDING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PLOT_X_BUILDING>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<PLOT_X_BUILDING>().HasOne(a => a.GUID_PLOT_BUILDING).WithMany().HasForeignKey(c => c.GUID_PLOT);
            modelBuilder.Entity<PLOT_X_BUILDING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PLOT_X_BUILDING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ENTITY_PERMISSION_PROFILE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ENTITY_PERMISSION_PROFILE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_WARRANTY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CONTRACT_WARRANTY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CONTRACT_WARRANTY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CONTRACT_WARRANTY>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<CONTRACT_WARRANTY>().HasOne(a => a.GUID_DOCUMENT_DOCUMENT).WithMany().HasForeignKey(c => c.GUID_DOCUMENT);
            modelBuilder.Entity<PROJECT_MILESTONE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PROJECT_MILESTONE>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<PROJECT_MILESTONE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PROJECT_MILESTONE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_MANAGER_PERSON1_PERSON).WithMany().HasForeignKey(c => c.GUID_MANAGER_PERSON1);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_MANAGER_PERSON2_PERSON).WithMany().HasForeignKey(c => c.GUID_MANAGER_PERSON2);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_CONDITION_CONDITION).WithMany().HasForeignKey(c => c.GUID_CONDITION);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_GIS_ENTITY_GIS_ENTITY).WithMany().HasForeignKey(c => c.GUID_GIS_ENTITY);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_BUSINESS_UNIT_REFERENCE_DATA).WithMany().HasForeignKey(c => c.GUID_BUSINESS_UNIT);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_OWNER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_OWNER);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_EXTERNAL_FACILITY_MANAGER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_EXTERNAL_FACILITY_MANAGER);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_FACILITY_MANAGER_PERSON).WithMany().HasForeignKey(c => c.GUID_FACILITY_MANAGER);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_BIM_PROJECT_BIM_PROJECT).WithMany().HasForeignKey(c => c.GUID_BIM_PROJECT);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_OPERATIONS_MANAGER_PERSON).WithMany().HasForeignKey(c => c.GUID_OPERATIONS_MANAGER);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_RENTAL_GROUP_RENTAL_GROUP).WithMany().HasForeignKey(c => c.GUID_RENTAL_GROUP);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_ESTATE_CATEGORY_ESTATE_CATEGORY).WithMany().HasForeignKey(c => c.GUID_ESTATE_CATEGORY);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_REGION_REGION).WithMany().HasForeignKey(c => c.GUID_REGION);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_POST_POSTAL_CODE).WithMany().HasForeignKey(c => c.GUID_POST);
            modelBuilder.Entity<ESTATE>().HasOne(a => a.GUID_USER_CAF_COMPUTED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CAF_COMPUTED_BY);
            modelBuilder.Entity<CUSTOM_FUNCTION_X_DATA_OWNER>().HasOne(a => a.GUID_CUSTOM_FUNCTION_CUSTOM_FUNCTION).WithMany().HasForeignKey(c => c.GUID_CUSTOM_FUNCTION);
            modelBuilder.Entity<CUSTOM_FUNCTION_X_DATA_OWNER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOM_FUNCTION_X_DATA_OWNER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOM_FUNCTION_X_DATA_OWNER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ALARM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ALARM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ALARM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT_PHASE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PROJECT_PHASE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT_PHASE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PROJECT_PHASE>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<ESTATE_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ESTATE_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ESTATE_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOM_REPORT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOM_REPORT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOM_REPORT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ALARM_LOG>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ALARM_LOG>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<ALARM_LOG>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<ALARM_LOG>().HasOne(a => a.GUID_ALARM_ALARM).WithMany().HasForeignKey(c => c.GUID_ALARM);
            modelBuilder.Entity<ALARM_LOG>().HasOne(a => a.GUID_ENTITY_HISTORY_ENTITY_HISTORY).WithMany().HasForeignKey(c => c.GUID_ENTITY_HISTORY);
            modelBuilder.Entity<PROJECT_STATUS>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PROJECT_STATUS>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT_STATUS>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PROJECT_STATUS>().HasOne(a => a.GUID_PROJECT_PHASE_PROJECT_PHASE).WithMany().HasForeignKey(c => c.GUID_PROJECT_PHASE);
            modelBuilder.Entity<Entities.EVENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<Entities.EVENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<Entities.EVENT>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_CUSTOMER_DELIVERY_ADDRESS_CUSTOMER_DELIVERY_ADDRESS).WithMany().HasForeignKey(c => c.GUID_CUSTOMER_DELIVERY_ADDRESS);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_LINE_OF_BUSINESS_CUSTOMER_LINE_OF_BUSINESS).WithMany().HasForeignKey(c => c.GUID_LINE_OF_BUSINESS);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_CUSTOMER_CATEGORY_CUSTOMER_CATEGORY).WithMany().HasForeignKey(c => c.GUID_CUSTOMER_CATEGORY);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_CUSTOMER_GROUP_CUSTOMER_GROUP).WithMany().HasForeignKey(c => c.GUID_CUSTOMER_GROUP);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_INVOICE_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_INVOICE_CUSTOMER);
            modelBuilder.Entity<CUSTOMER>().HasOne(a => a.GUID_POST_POSTAL_CODE).WithMany().HasForeignKey(c => c.GUID_POST);
            modelBuilder.Entity<ANONYMIZATION_FIELD_RULE>().HasOne(a => a.GUID_REGISTERED_FIELD_REGISTERED_FIELD).WithMany().HasForeignKey(c => c.GUID_REGISTERED_FIELD);
            modelBuilder.Entity<ANONYMIZATION_FIELD_RULE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<ANONYMIZATION_FIELD_RULE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PROJECT_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PROJECT_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PROJECT_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<EVENT_X_ENTITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<EVENT_X_ENTITY>().HasOne(a => a.GUID_EVENT_EVENT).WithMany().HasForeignKey(c => c.GUID_EVENT);
            modelBuilder.Entity<EVENT_X_ENTITY>().HasOne(a => a.GUID_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_PERSON);
            modelBuilder.Entity<EVENT_X_ENTITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EVENT_X_ENTITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CUSTOMER_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOMER_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOMER_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<API_CLIENT>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<API_CLIENT>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_ALARM_LOG_ALARM_LOG).WithMany().HasForeignKey(c => c.GUID_ALARM_LOG);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_PAYMENT_TERM_PAYMENT_TERM).WithMany().HasForeignKey(c => c.GUID_PAYMENT_TERM);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_USER_PRINTED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_PRINTED_BY);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_USER_RECEIVED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_RECEIVED_BY);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_SUPPLIER_AGREEMENT_SUPPLIER_AGREEMENT).WithMany().HasForeignKey(c => c.GUID_SUPPLIER_AGREEMENT);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_DELIVERY_TERM_DELIVERY_TERM).WithMany().HasForeignKey(c => c.GUID_DELIVERY_TERM);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<PURCHASE_ORDER>().HasOne(a => a.GUID_PURCHASE_ORDER_FORM_PURCHASE_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER_FORM);
            modelBuilder.Entity<EXTERNAL_LOGIN_PROVIDER>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<EXTERNAL_LOGIN_PROVIDER>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CUSTOMER_DELIVERY_ADDRESS>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOMER_DELIVERY_ADDRESS>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<CUSTOMER_DELIVERY_ADDRESS>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOMER_DELIVERY_ADDRESS>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<API_REQUEST_LOG>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<API_REQUEST_LOG>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<API_REQUEST_LOG>().HasOne(a => a.GUID_ENTITY_TASK_ENTITY_TASK).WithMany().HasForeignKey(c => c.GUID_ENTITY_TASK);
            modelBuilder.Entity<API_REQUEST_LOG>().HasOne(a => a.GUID_SCHEDULED_JOB_SCHEDULED_JOB).WithMany().HasForeignKey(c => c.GUID_SCHEDULED_JOB);
            modelBuilder.Entity<PURCHASE_ORDER_FORM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PURCHASE_ORDER_FORM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER_FORM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER_FORM>().HasOne(a => a.GUID_REPORT_REPORT).WithMany().HasForeignKey(c => c.GUID_REPORT);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_RESPONSIBLE_PERSON_PERSON).WithMany().HasForeignKey(c => c.GUID_RESPONSIBLE_PERSON);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_CONTACT_PERSON_CONTACT_PERSON).WithMany().HasForeignKey(c => c.GUID_CONTACT_PERSON);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_CONTRACT_CONTRACT).WithMany().HasForeignKey(c => c.GUID_CONTRACT);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<FOLLOW_UP>().HasOne(a => a.GUID_PREVIOUS_FOLLOW_UP).WithMany().HasForeignKey(c => c.GUID_PREVIOUS);
            modelBuilder.Entity<CUSTOMER_GROUP>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOMER_GROUP>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOMER_GROUP>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasOne(a => a.GUID_CONTRACT_ITEM_CONTRACT_ITEM).WithMany().HasForeignKey(c => c.GUID_CONTRACT_ITEM);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasOne(a => a.GUID_PREVIOUS_AREA_AVAILABILITY).WithMany().HasForeignKey(c => c.GUID_PREVIOUS);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_AVAILABILITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_EQUIPMENT_EQUIPMENT).WithMany().HasForeignKey(c => c.GUID_EQUIPMENT);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_WORK_ORDER_WORK_ORDER).WithMany().HasForeignKey(c => c.GUID_WORK_ORDER);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_ARTICLE_ARTICLE).WithMany().HasForeignKey(c => c.GUID_ARTICLE);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_DEPARTMENT_DEPARTMENT).WithMany().HasForeignKey(c => c.GUID_DEPARTMENT);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_PURCHASE_ORDER_PURCHASE_ORDER).WithMany().HasForeignKey(c => c.GUID_PURCHASE_ORDER);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_BUILDING_BUILDING).WithMany().HasForeignKey(c => c.GUID_BUILDING);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING0_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING0);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING1_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING1);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING2_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING2);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING3_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING3);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNTING4_ACCOUNTING).WithMany().HasForeignKey(c => c.GUID_ACCOUNTING4);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_COMPONENT_COMPONENT).WithMany().HasForeignKey(c => c.GUID_COMPONENT);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_ACCOUNT_ACCOUNT).WithMany().HasForeignKey(c => c.GUID_ACCOUNT);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_COST_CENTER_COST_CENTER).WithMany().HasForeignKey(c => c.GUID_COST_CENTER);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_SUPPLIER_SUPPLIER).WithMany().HasForeignKey(c => c.GUID_SUPPLIER);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_PERIODIC_TASK_PERIODIC_TASK).WithMany().HasForeignKey(c => c.GUID_PERIODIC_TASK);
            modelBuilder.Entity<PURCHASE_ORDER_ITEM>().HasOne(a => a.GUID_SPARE_PART_SPARE_PART).WithMany().HasForeignKey(c => c.GUID_SPARE_PART);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_IMAGE_BACKGROUND_IMAGE).WithMany().HasForeignKey(c => c.GUID_IMAGE_BACKGROUND);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_IMAGE_LOGO_IMAGE).WithMany().HasForeignKey(c => c.GUID_IMAGE_LOGO);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_DOCUMENT_TERMS_OF_USE_DOCUMENT).WithMany().HasForeignKey(c => c.GUID_DOCUMENT_TERMS_OF_USE);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_SYSTEM_OWNER_USR).WithMany().HasForeignKey(c => c.GUID_SYSTEM_OWNER);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_DEFAULT_INVOICING_INVOICING).WithMany().HasForeignKey(c => c.GUID_DEFAULT_INVOICING);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_DEFAULT_PAYMENT_TERM_PAYMENT_TERM).WithMany().HasForeignKey(c => c.GUID_DEFAULT_PAYMENT_TERM);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_DEFAULT_PAYMENT_ORDER_FORM_PAYMENT_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_DEFAULT_PAYMENT_ORDER_FORM);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_USER_GROUP_FOR_NEW_USERS_USR).WithMany().HasForeignKey(c => c.GUID_USER_GROUP_FOR_NEW_USERS);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_COMMON_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_COMMON_DATA_OWNER);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_CAUSE_NOT_EXECUTED_CAUSE).WithMany().HasForeignKey(c => c.GUID_CAUSE_NOT_EXECUTED);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_DEFAULT_ORDER_FORM_PURCHASE_ORDER_FORM).WithMany().HasForeignKey(c => c.GUID_DEFAULT_ORDER_FORM);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<GENERAL_OPTIONS>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CUSTOMER_LINE_OF_BUSINESS>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOMER_LINE_OF_BUSINESS>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOMER_LINE_OF_BUSINESS>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_CATEGORY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_CATEGORY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_CATEGORY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<REFERENCE_DATA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<REFERENCE_DATA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<REFERENCE_DATA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<REFERENCE_DATA>().HasOne(a => a.GUID_REFERENCE_TYPE_REFERENCE_TYPE).WithMany().HasForeignKey(c => c.GUID_REFERENCE_TYPE);
            modelBuilder.Entity<REFERENCE_DATA>().HasOne(a => a.GUID_PARENT_REFERENCE_DATA).WithMany().HasForeignKey(c => c.GUID_PARENT);
            modelBuilder.Entity<GIS_ENTITY>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<GIS_ENTITY>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<GIS_ENTITY>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<CUSTOMER_LOG>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CUSTOMER_LOG>().HasOne(a => a.GUID_CUSTOMER_CUSTOMER).WithMany().HasForeignKey(c => c.GUID_CUSTOMER);
            modelBuilder.Entity<CUSTOMER_LOG>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CUSTOMER_LOG>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_CATEGORY_X_AREA_TYPE>().HasOne(a => a.GUID_AREA_CATEGORY_AREA_CATEGORY).WithMany().HasForeignKey(c => c.GUID_AREA_CATEGORY);
            modelBuilder.Entity<AREA_CATEGORY_X_AREA_TYPE>().HasOne(a => a.GUID_AREA_TYPE_AREA_TYPE).WithMany().HasForeignKey(c => c.GUID_AREA_TYPE);
            modelBuilder.Entity<AREA_CATEGORY_X_AREA_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_CATEGORY_X_AREA_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<REFERENCE_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<REFERENCE_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<REFERENCE_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<HATCHING>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<HATCHING>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<HATCHING>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<HATCHING>().HasOne(a => a.GUID_DRAWING_DRAWING).WithMany().HasForeignKey(c => c.GUID_DRAWING);
            modelBuilder.Entity<CYLINDER_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<CYLINDER_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<CYLINDER_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_PRICE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_PRICE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<AREA_PRICE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_PRICE>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<REGION>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<REGION>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<REGION>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<HATCHING_X_AREA>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<HATCHING_X_AREA>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<HATCHING_X_AREA>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<HATCHING_X_AREA>().HasOne(a => a.GUID_AREA_AREA).WithMany().HasForeignKey(c => c.GUID_AREA);
            modelBuilder.Entity<HATCHING_X_AREA>().HasOne(a => a.GUID_HATCHING_HATCHING).WithMany().HasForeignKey(c => c.GUID_HATCHING);
            modelBuilder.Entity<AREA_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<AREA_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<AREA_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<REGISTERED_FIELD>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<REGISTERED_FIELD>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<HOUR_TYPE>().HasOne(a => a.GUID_USER_UPDATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_UPDATED_BY);
            modelBuilder.Entity<HOUR_TYPE>().HasOne(a => a.GUID_USER_CREATED_BY_USR).WithMany().HasForeignKey(c => c.GUID_USER_CREATED_BY);
            modelBuilder.Entity<HOUR_TYPE>().HasOne(a => a.GUID_DATA_OWNER_DATA_OWNER).WithMany().HasForeignKey(c => c.GUID_DATA_OWNER);
            modelBuilder.Entity<HOUR_TYPE>().HasOne(a => a.GUID_PROJECT_PROJECT).WithMany().HasForeignKey(c => c.GUID_PROJECT);
            modelBuilder.Entity<NonsReferences>().HasOne(a => a.Id_Products).WithMany().HasForeignKey(c => c.Id);
            modelBuilder.Entity<State>().HasOne(a => a.JobId_Job).WithMany().HasForeignKey(c => c.JobId);
            modelBuilder.Entity<JobParameter>().HasOne(a => a.JobId_Job).WithMany().HasForeignKey(c => c.JobId);
        }

        /// <summary>
        /// Represents the database set for the UserInRole entity.
        /// </summary>
        public DbSet<UserInRole> UserInRole { get; set; }

        /// <summary>
        /// Represents the database set for the UserToken entity.
        /// </summary>
        public DbSet<UserToken> UserToken { get; set; }

        /// <summary>
        /// Represents the database set for the RoleEntitlement entity.
        /// </summary>
        public DbSet<RoleEntitlement> RoleEntitlement { get; set; }

        /// <summary>
        /// Represents the database set for the Entity entity.
        /// </summary>
        public DbSet<Entity> Entity { get; set; }

        /// <summary>
        /// Represents the database set for the Tenant entity.
        /// </summary>
        public DbSet<Tenant> Tenant { get; set; }

        /// <summary>
        /// Represents the database set for the User entity.
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Represents the database set for the Role entity.
        /// </summary>
        public DbSet<Role> Role { get; set; }

        /// <summary>
        /// Represents the database set for the DATA_IMPORT entity.
        /// </summary>
        public DbSet<DATA_IMPORT> DATA_IMPORT { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE entity.
        /// </summary>
        public DbSet<AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE> AREA_X_CLEANING_TASK_ATTRIBUTE_VALUE { get; set; }

        /// <summary>
        /// Represents the database set for the RELATIONSHIP entity.
        /// </summary>
        public DbSet<RELATIONSHIP> RELATIONSHIP { get; set; }

        /// <summary>
        /// Represents the database set for the IMAGE entity.
        /// </summary>
        public DbSet<IMAGE> IMAGE { get; set; }

        /// <summary>
        /// Represents the database set for the DATA_OWNER entity.
        /// </summary>
        public DbSet<DATA_OWNER> DATA_OWNER { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_X_ENTITY entity.
        /// </summary>
        public DbSet<AREA_X_ENTITY> AREA_X_ENTITY { get; set; }

        /// <summary>
        /// Represents the database set for the RELATIONSHIP_TYPE entity.
        /// </summary>
        public DbSet<RELATIONSHIP_TYPE> RELATIONSHIP_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the IMAGE_BINARY entity.
        /// </summary>
        public DbSet<IMAGE_BINARY> IMAGE_BINARY { get; set; }

        /// <summary>
        /// Represents the database set for the ARTICLE entity.
        /// </summary>
        public DbSet<ARTICLE> ARTICLE { get; set; }

        /// <summary>
        /// Represents the database set for the RENTAL_GROUP entity.
        /// </summary>
        public DbSet<RENTAL_GROUP> RENTAL_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the IMAGE_X_ENTITY entity.
        /// </summary>
        public DbSet<IMAGE_X_ENTITY> IMAGE_X_ENTITY { get; set; }

        /// <summary>
        /// Represents the database set for the DELIVERY_TERM entity.
        /// </summary>
        public DbSet<DELIVERY_TERM> DELIVERY_TERM { get; set; }

        /// <summary>
        /// Represents the database set for the BARCODE entity.
        /// </summary>
        public DbSet<BARCODE> BARCODE { get; set; }

        /// <summary>
        /// Represents the database set for the REPORT entity.
        /// </summary>
        public DbSet<REPORT> REPORT { get; set; }

        /// <summary>
        /// Represents the database set for the INTEGRATION_DATA entity.
        /// </summary>
        public DbSet<INTEGRATION_DATA> INTEGRATION_DATA { get; set; }

        /// <summary>
        /// Represents the database set for the DEPARTMENT entity.
        /// </summary>
        public DbSet<DEPARTMENT> DEPARTMENT { get; set; }

        /// <summary>
        /// Represents the database set for the BCF_PROJECT entity.
        /// </summary>
        public DbSet<BCF_PROJECT> BCF_PROJECT { get; set; }

        /// <summary>
        /// Represents the database set for the REQUEST entity.
        /// </summary>
        public DbSet<REQUEST> REQUEST { get; set; }

        /// <summary>
        /// Represents the database set for the INTERVAL entity.
        /// </summary>
        public DbSet<INTERVAL> INTERVAL { get; set; }

        /// <summary>
        /// Represents the database set for the DEVIATION entity.
        /// </summary>
        public DbSet<DEVIATION> DEVIATION { get; set; }

        /// <summary>
        /// Represents the database set for the BIM_FILE entity.
        /// </summary>
        public DbSet<BIM_FILE> BIM_FILE { get; set; }

        /// <summary>
        /// Represents the database set for the RESOURCE_GROUP_X_CAUSE entity.
        /// </summary>
        public DbSet<RESOURCE_GROUP_X_CAUSE> RESOURCE_GROUP_X_CAUSE { get; set; }

        /// <summary>
        /// Represents the database set for the INVOICING entity.
        /// </summary>
        public DbSet<INVOICING> INVOICING { get; set; }

        /// <summary>
        /// Represents the database set for the DEVIATION_TYPE entity.
        /// </summary>
        public DbSet<DEVIATION_TYPE> DEVIATION_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the BIM_PROJECT entity.
        /// </summary>
        public DbSet<BIM_PROJECT> BIM_PROJECT { get; set; }

        /// <summary>
        /// Represents the database set for the SCHEDULED_JOB entity.
        /// </summary>
        public DbSet<SCHEDULED_JOB> SCHEDULED_JOB { get; set; }

        /// <summary>
        /// Represents the database set for the LANGUAGE entity.
        /// </summary>
        public DbSet<LANGUAGE> LANGUAGE { get; set; }

        /// <summary>
        /// Represents the database set for the DOCUMENT entity.
        /// </summary>
        public DbSet<DOCUMENT> DOCUMENT { get; set; }

        /// <summary>
        /// Represents the database set for the BINARY_DATA entity.
        /// </summary>
        public DbSet<BINARY_DATA> BINARY_DATA { get; set; }

        /// <summary>
        /// Represents the database set for the SCHEDULED_JOB_EXECUTION entity.
        /// </summary>
        public DbSet<SCHEDULED_JOB_EXECUTION> SCHEDULED_JOB_EXECUTION { get; set; }

        /// <summary>
        /// Represents the database set for the LANGUAGE_ENTRY entity.
        /// </summary>
        public DbSet<LANGUAGE_ENTRY> LANGUAGE_ENTRY { get; set; }

        /// <summary>
        /// Represents the database set for the DOCUMENT_CATEGORY entity.
        /// </summary>
        public DbSet<DOCUMENT_CATEGORY> DOCUMENT_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the BOOKING_CATEGORY entity.
        /// </summary>
        public DbSet<BOOKING_CATEGORY> BOOKING_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the SERVER entity.
        /// </summary>
        public DbSet<SERVER> SERVER { get; set; }

        /// <summary>
        /// Represents the database set for the LANGUAGE_FIELD_ENTRY entity.
        /// </summary>
        public DbSet<LANGUAGE_FIELD_ENTRY> LANGUAGE_FIELD_ENTRY { get; set; }

        /// <summary>
        /// Represents the database set for the DOCUMENT_REVISION entity.
        /// </summary>
        public DbSet<DOCUMENT_REVISION> DOCUMENT_REVISION { get; set; }

        /// <summary>
        /// Represents the database set for the BUDGET entity.
        /// </summary>
        public DbSet<BUDGET> BUDGET { get; set; }

        /// <summary>
        /// Represents the database set for the SERVICE entity.
        /// </summary>
        public DbSet<SERVICE> SERVICE { get; set; }

        /// <summary>
        /// Represents the database set for the LANGUAGE_REPORT_ENTRY entity.
        /// </summary>
        public DbSet<LANGUAGE_REPORT_ENTRY> LANGUAGE_REPORT_ENTRY { get; set; }

        /// <summary>
        /// Represents the database set for the DOCUMENT_TYPE entity.
        /// </summary>
        public DbSet<DOCUMENT_TYPE> DOCUMENT_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING_CATEGORY entity.
        /// </summary>
        public DbSet<BUILDING_CATEGORY> BUILDING_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the SERVICE_PRICE entity.
        /// </summary>
        public DbSet<SERVICE_PRICE> SERVICE_PRICE { get; set; }

        /// <summary>
        /// Represents the database set for the LANGUAGE_X_WEB_TEXT entity.
        /// </summary>
        public DbSet<LANGUAGE_X_WEB_TEXT> LANGUAGE_X_WEB_TEXT { get; set; }

        /// <summary>
        /// Represents the database set for the DOCUMENT_WEB_ACCESS entity.
        /// </summary>
        public DbSet<DOCUMENT_WEB_ACCESS> DOCUMENT_WEB_ACCESS { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING_SELECTION entity.
        /// </summary>
        public DbSet<BUILDING_SELECTION> BUILDING_SELECTION { get; set; }

        /// <summary>
        /// Represents the database set for the SERVICE_X_AREA_CATEGORY entity.
        /// </summary>
        public DbSet<SERVICE_X_AREA_CATEGORY> SERVICE_X_AREA_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the LAYER_GROUP entity.
        /// </summary>
        public DbSet<LAYER_GROUP> LAYER_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the DOCUMENT_X_ENTITY entity.
        /// </summary>
        public DbSet<DOCUMENT_X_ENTITY> DOCUMENT_X_ENTITY { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING_X_BIM_FILE entity.
        /// </summary>
        public DbSet<BUILDING_X_BIM_FILE> BUILDING_X_BIM_FILE { get; set; }

        /// <summary>
        /// Represents the database set for the SETTING entity.
        /// </summary>
        public DbSet<SETTING> SETTING { get; set; }

        /// <summary>
        /// Represents the database set for the LAYER_GROUP_SET entity.
        /// </summary>
        public DbSet<LAYER_GROUP_SET> LAYER_GROUP_SET { get; set; }

        /// <summary>
        /// Represents the database set for the DOOR_KEY entity.
        /// </summary>
        public DbSet<DOOR_KEY> DOOR_KEY { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING_X_BUILDING_SELECTION entity.
        /// </summary>
        public DbSet<BUILDING_X_BUILDING_SELECTION> BUILDING_X_BUILDING_SELECTION { get; set; }

        /// <summary>
        /// Represents the database set for the SPARE_PART entity.
        /// </summary>
        public DbSet<SPARE_PART> SPARE_PART { get; set; }

        /// <summary>
        /// Represents the database set for the LAYER_GROUP_SET_X_LAYER_GROUP entity.
        /// </summary>
        public DbSet<LAYER_GROUP_SET_X_LAYER_GROUP> LAYER_GROUP_SET_X_LAYER_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the DOOR_KEY_SYSTEM entity.
        /// </summary>
        public DbSet<DOOR_KEY_SYSTEM> DOOR_KEY_SYSTEM { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING_X_CONTRACT entity.
        /// </summary>
        public DbSet<BUILDING_X_CONTRACT> BUILDING_X_CONTRACT { get; set; }

        /// <summary>
        /// Represents the database set for the SPARE_PART_COUNTING entity.
        /// </summary>
        public DbSet<SPARE_PART_COUNTING> SPARE_PART_COUNTING { get; set; }

        /// <summary>
        /// Represents the database set for the LEASE_FOLLOW_UP entity.
        /// </summary>
        public DbSet<LEASE_FOLLOW_UP> LEASE_FOLLOW_UP { get; set; }

        /// <summary>
        /// Represents the database set for the DOOR_KEY_TRANSACTION entity.
        /// </summary>
        public DbSet<DOOR_KEY_TRANSACTION> DOOR_KEY_TRANSACTION { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING_X_PERSON entity.
        /// </summary>
        public DbSet<BUILDING_X_PERSON> BUILDING_X_PERSON { get; set; }

        /// <summary>
        /// Represents the database set for the SPARE_PART_COUNTING_ITEM entity.
        /// </summary>
        public DbSet<SPARE_PART_COUNTING_ITEM> SPARE_PART_COUNTING_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the LIST_HIGHLIGHT entity.
        /// </summary>
        public DbSet<LIST_HIGHLIGHT> LIST_HIGHLIGHT { get; set; }

        /// <summary>
        /// Represents the database set for the DOOR_KEY_X_DOOR_LOCK entity.
        /// </summary>
        public DbSet<DOOR_KEY_X_DOOR_LOCK> DOOR_KEY_X_DOOR_LOCK { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING_X_SUPPLIER entity.
        /// </summary>
        public DbSet<BUILDING_X_SUPPLIER> BUILDING_X_SUPPLIER { get; set; }

        /// <summary>
        /// Represents the database set for the SPARE_PART_COUNTING_LIST entity.
        /// </summary>
        public DbSet<SPARE_PART_COUNTING_LIST> SPARE_PART_COUNTING_LIST { get; set; }

        /// <summary>
        /// Represents the database set for the LIST_LAYOUT entity.
        /// </summary>
        public DbSet<LIST_LAYOUT> LIST_LAYOUT { get; set; }

        /// <summary>
        /// Represents the database set for the DOOR_KEY_X_USER entity.
        /// </summary>
        public DbSet<DOOR_KEY_X_USER> DOOR_KEY_X_USER { get; set; }

        /// <summary>
        /// Represents the database set for the CAUSE entity.
        /// </summary>
        public DbSet<CAUSE> CAUSE { get; set; }

        /// <summary>
        /// Represents the database set for the SPARE_PART_WITHDRAWAL entity.
        /// </summary>
        public DbSet<SPARE_PART_WITHDRAWAL> SPARE_PART_WITHDRAWAL { get; set; }

        /// <summary>
        /// Represents the database set for the LOG entity.
        /// </summary>
        public DbSet<LOG> LOG { get; set; }

        /// <summary>
        /// Represents the database set for the DOOR_LOCK entity.
        /// </summary>
        public DbSet<DOOR_LOCK> DOOR_LOCK { get; set; }

        /// <summary>
        /// Represents the database set for the CHANGE_SET entity.
        /// </summary>
        public DbSet<CHANGE_SET> CHANGE_SET { get; set; }

        /// <summary>
        /// Represents the database set for the STANDARD_TEXT entity.
        /// </summary>
        public DbSet<STANDARD_TEXT> STANDARD_TEXT { get; set; }

        /// <summary>
        /// Represents the database set for the LOG_PERFORMANCE entity.
        /// </summary>
        public DbSet<LOG_PERFORMANCE> LOG_PERFORMANCE { get; set; }

        /// <summary>
        /// Represents the database set for the DOOR_LOCK_X_AREA entity.
        /// </summary>
        public DbSet<DOOR_LOCK_X_AREA> DOOR_LOCK_X_AREA { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING entity.
        /// </summary>
        public DbSet<CLEANING> CLEANING { get; set; }

        /// <summary>
        /// Represents the database set for the START_PAGE entity.
        /// </summary>
        public DbSet<START_PAGE> START_PAGE { get; set; }

        /// <summary>
        /// Represents the database set for the LOG_SECURITY entity.
        /// </summary>
        public DbSet<LOG_SECURITY> LOG_SECURITY { get; set; }

        /// <summary>
        /// Represents the database set for the DRAWING entity.
        /// </summary>
        public DbSet<DRAWING> DRAWING { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_COMPLETION_ATTRIBUTE_VALUE entity.
        /// </summary>
        public DbSet<CLEANING_COMPLETION_ATTRIBUTE_VALUE> CLEANING_COMPLETION_ATTRIBUTE_VALUE { get; set; }

        /// <summary>
        /// Represents the database set for the SUPPLIER entity.
        /// </summary>
        public DbSet<SUPPLIER> SUPPLIER { get; set; }

        /// <summary>
        /// Represents the database set for the MEDICAL_OWNERSHIP entity.
        /// </summary>
        public DbSet<MEDICAL_OWNERSHIP> MEDICAL_OWNERSHIP { get; set; }

        /// <summary>
        /// Represents the database set for the DRAWING_TEXT entity.
        /// </summary>
        public DbSet<DRAWING_TEXT> DRAWING_TEXT { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_COMPLETION_HISTORY entity.
        /// </summary>
        public DbSet<CLEANING_COMPLETION_HISTORY> CLEANING_COMPLETION_HISTORY { get; set; }

        /// <summary>
        /// Represents the database set for the SUPPLIER_AGREEMENT entity.
        /// </summary>
        public DbSet<SUPPLIER_AGREEMENT> SUPPLIER_AGREEMENT { get; set; }

        /// <summary>
        /// Represents the database set for the MEDICAL_REGION entity.
        /// </summary>
        public DbSet<MEDICAL_REGION> MEDICAL_REGION { get; set; }

        /// <summary>
        /// Represents the database set for the DRAWING_X_LAYER_GROUP entity.
        /// </summary>
        public DbSet<DRAWING_X_LAYER_GROUP> DRAWING_X_LAYER_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_QUALITY entity.
        /// </summary>
        public DbSet<CLEANING_QUALITY> CLEANING_QUALITY { get; set; }

        /// <summary>
        /// Represents the database set for the SUPPLIER_LINE_OF_BUSINESS entity.
        /// </summary>
        public DbSet<SUPPLIER_LINE_OF_BUSINESS> SUPPLIER_LINE_OF_BUSINESS { get; set; }

        /// <summary>
        /// Represents the database set for the MOBILE_MENU_PROFILE entity.
        /// </summary>
        public DbSet<MOBILE_MENU_PROFILE> MOBILE_MENU_PROFILE { get; set; }

        /// <summary>
        /// Represents the database set for the DUTY_LOG entity.
        /// </summary>
        public DbSet<DUTY_LOG> DUTY_LOG { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_QUALITY_CONTROL entity.
        /// </summary>
        public DbSet<CLEANING_QUALITY_CONTROL> CLEANING_QUALITY_CONTROL { get; set; }

        /// <summary>
        /// Represents the database set for the TASK entity.
        /// </summary>
        public DbSet<Entities.TASK> TASK { get; set; }

        /// <summary>
        /// Represents the database set for the NAMED_SELECTION entity.
        /// </summary>
        public DbSet<NAMED_SELECTION> NAMED_SELECTION { get; set; }

        /// <summary>
        /// Represents the database set for the DUTY_LOG_CATEGORY entity.
        /// </summary>
        public DbSet<DUTY_LOG_CATEGORY> DUTY_LOG_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_QUALITY_CONTROL_X_AREA entity.
        /// </summary>
        public DbSet<CLEANING_QUALITY_CONTROL_X_AREA> CLEANING_QUALITY_CONTROL_X_AREA { get; set; }

        /// <summary>
        /// Represents the database set for the TRANSFER entity.
        /// </summary>
        public DbSet<TRANSFER> TRANSFER { get; set; }

        /// <summary>
        /// Represents the database set for the NAMED_SELECTION_VALUE entity.
        /// </summary>
        public DbSet<NAMED_SELECTION_VALUE> NAMED_SELECTION_VALUE { get; set; }

        /// <summary>
        /// Represents the database set for the DUTY_LOG_CATEGORY_X_GROUP entity.
        /// </summary>
        public DbSet<DUTY_LOG_CATEGORY_X_GROUP> DUTY_LOG_CATEGORY_X_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_X_CLEANING_TASK entity.
        /// </summary>
        public DbSet<CLEANING_X_CLEANING_TASK> CLEANING_X_CLEANING_TASK { get; set; }

        /// <summary>
        /// Represents the database set for the TRANSFER_X_FUNCTION entity.
        /// </summary>
        public DbSet<TRANSFER_X_FUNCTION> TRANSFER_X_FUNCTION { get; set; }

        /// <summary>
        /// Represents the database set for the NONS_REFERENCE entity.
        /// </summary>
        public DbSet<NONS_REFERENCE> NONS_REFERENCE { get; set; }

        /// <summary>
        /// Represents the database set for the DUTY_LOG_EVENT entity.
        /// </summary>
        public DbSet<DUTY_LOG_EVENT> DUTY_LOG_EVENT { get; set; }

        /// <summary>
        /// Represents the database set for the COMPONENT entity.
        /// </summary>
        public DbSet<COMPONENT> COMPONENT { get; set; }

        /// <summary>
        /// Represents the database set for the TWO_FACTOR_TOKEN entity.
        /// </summary>
        public DbSet<TWO_FACTOR_TOKEN> TWO_FACTOR_TOKEN { get; set; }

        /// <summary>
        /// Represents the database set for the OPERATIONAL_MESSAGE entity.
        /// </summary>
        public DbSet<OPERATIONAL_MESSAGE> OPERATIONAL_MESSAGE { get; set; }

        /// <summary>
        /// Represents the database set for the DUTY_LOG_GROUP entity.
        /// </summary>
        public DbSet<DUTY_LOG_GROUP> DUTY_LOG_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the COMPONENT_CATEGORY entity.
        /// </summary>
        public DbSet<COMPONENT_CATEGORY> COMPONENT_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the USER_NOTIFICATION entity.
        /// </summary>
        public DbSet<USER_NOTIFICATION> USER_NOTIFICATION { get; set; }

        /// <summary>
        /// Represents the database set for the ORGANIZATION entity.
        /// </summary>
        public DbSet<ORGANIZATION> ORGANIZATION { get; set; }

        /// <summary>
        /// Represents the database set for the EMAIL_TEMPLATE entity.
        /// </summary>
        public DbSet<EMAIL_TEMPLATE> EMAIL_TEMPLATE { get; set; }

        /// <summary>
        /// Represents the database set for the COMPONENT_X_AREA entity.
        /// </summary>
        public DbSet<COMPONENT_X_AREA> COMPONENT_X_AREA { get; set; }

        /// <summary>
        /// Represents the database set for the USER_PROFILE entity.
        /// </summary>
        public DbSet<USER_PROFILE> USER_PROFILE { get; set; }

        /// <summary>
        /// Represents the database set for the ORGANIZATION_SECTION entity.
        /// </summary>
        public DbSet<ORGANIZATION_SECTION> ORGANIZATION_SECTION { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_BLOCK entity.
        /// </summary>
        public DbSet<ENERGY_BLOCK> ENERGY_BLOCK { get; set; }

        /// <summary>
        /// Represents the database set for the COMPONENT_X_EQUIPMENT entity.
        /// </summary>
        public DbSet<COMPONENT_X_EQUIPMENT> COMPONENT_X_EQUIPMENT { get; set; }

        /// <summary>
        /// Represents the database set for the USER_SESSION entity.
        /// </summary>
        public DbSet<USER_SESSION> USER_SESSION { get; set; }

        /// <summary>
        /// Represents the database set for the ORGANIZATION_UNIT entity.
        /// </summary>
        public DbSet<ORGANIZATION_UNIT> ORGANIZATION_UNIT { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_CATEGORY entity.
        /// </summary>
        public DbSet<ENERGY_CATEGORY> ENERGY_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the COMPONENT_X_SUPPLIER entity.
        /// </summary>
        public DbSet<COMPONENT_X_SUPPLIER> COMPONENT_X_SUPPLIER { get; set; }

        /// <summary>
        /// Represents the database set for the USER_X_CUSTOMER entity.
        /// </summary>
        public DbSet<USER_X_CUSTOMER> USER_X_CUSTOMER { get; set; }

        /// <summary>
        /// Represents the database set for the ORGANIZATION_X_AREA entity.
        /// </summary>
        public DbSet<ORGANIZATION_X_AREA> ORGANIZATION_X_AREA { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_CONSUMPTION entity.
        /// </summary>
        public DbSet<ENERGY_CONSUMPTION> ENERGY_CONSUMPTION { get; set; }

        /// <summary>
        /// Represents the database set for the CONDITION entity.
        /// </summary>
        public DbSet<CONDITION> CONDITION { get; set; }

        /// <summary>
        /// Represents the database set for the USER_X_EXTERNAL_LOGIN entity.
        /// </summary>
        public DbSet<USER_X_EXTERNAL_LOGIN> USER_X_EXTERNAL_LOGIN { get; set; }

        /// <summary>
        /// Represents the database set for the PASSWORD_HISTORY entity.
        /// </summary>
        public DbSet<PASSWORD_HISTORY> PASSWORD_HISTORY { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_COUNTER entity.
        /// </summary>
        public DbSet<ENERGY_COUNTER> ENERGY_COUNTER { get; set; }

        /// <summary>
        /// Represents the database set for the CONDITION_TYPE entity.
        /// </summary>
        public DbSet<CONDITION_TYPE> CONDITION_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the USER_X_SPARE_PART_COUNTING_LIST entity.
        /// </summary>
        public DbSet<USER_X_SPARE_PART_COUNTING_LIST> USER_X_SPARE_PART_COUNTING_LIST { get; set; }

        /// <summary>
        /// Represents the database set for the PAYMENT_ORDER entity.
        /// </summary>
        public DbSet<PAYMENT_ORDER> PAYMENT_ORDER { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_DATA_FORMAT entity.
        /// </summary>
        public DbSet<ENERGY_DATA_FORMAT> ENERGY_DATA_FORMAT { get; set; }

        /// <summary>
        /// Represents the database set for the CONSEQUENCE entity.
        /// </summary>
        public DbSet<CONSEQUENCE> CONSEQUENCE { get; set; }

        /// <summary>
        /// Represents the database set for the USER_X_USER_NOTIFICATION entity.
        /// </summary>
        public DbSet<USER_X_USER_NOTIFICATION> USER_X_USER_NOTIFICATION { get; set; }

        /// <summary>
        /// Represents the database set for the PAYMENT_ORDER_FORM entity.
        /// </summary>
        public DbSet<PAYMENT_ORDER_FORM> PAYMENT_ORDER_FORM { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_JOB entity.
        /// </summary>
        public DbSet<ENERGY_JOB> ENERGY_JOB { get; set; }

        /// <summary>
        /// Represents the database set for the CONSEQUENCE_TYPE entity.
        /// </summary>
        public DbSet<CONSEQUENCE_TYPE> CONSEQUENCE_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the USER_X_WEB_LIST_VIEW entity.
        /// </summary>
        public DbSet<USER_X_WEB_LIST_VIEW> USER_X_WEB_LIST_VIEW { get; set; }

        /// <summary>
        /// Represents the database set for the PAYMENT_ORDER_ITEM entity.
        /// </summary>
        public DbSet<PAYMENT_ORDER_ITEM> PAYMENT_ORDER_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_JOB_X_COUNTER entity.
        /// </summary>
        public DbSet<ENERGY_JOB_X_COUNTER> ENERGY_JOB_X_COUNTER { get; set; }

        /// <summary>
        /// Represents the database set for the CONSTRUCTION_TYPE entity.
        /// </summary>
        public DbSet<CONSTRUCTION_TYPE> CONSTRUCTION_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the USER_X_WEB_PROFILE entity.
        /// </summary>
        public DbSet<USER_X_WEB_PROFILE> USER_X_WEB_PROFILE { get; set; }

        /// <summary>
        /// Represents the database set for the PAYMENT_ORDER_ITEM_X_SERVICE entity.
        /// </summary>
        public DbSet<PAYMENT_ORDER_ITEM_X_SERVICE> PAYMENT_ORDER_ITEM_X_SERVICE { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_METER entity.
        /// </summary>
        public DbSet<ENERGY_METER> ENERGY_METER { get; set; }

        /// <summary>
        /// Represents the database set for the CONSUMABLE entity.
        /// </summary>
        public DbSet<CONSUMABLE> CONSUMABLE { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_TASK entity.
        /// </summary>
        public DbSet<CLEANING_TASK> CLEANING_TASK { get; set; }

        /// <summary>
        /// Represents the database set for the USR entity.
        /// </summary>
        public DbSet<USR> USR { get; set; }

        /// <summary>
        /// Represents the database set for the PAYMENT_TERM entity.
        /// </summary>
        public DbSet<PAYMENT_TERM> PAYMENT_TERM { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_PERIODIC_TASK entity.
        /// </summary>
        public DbSet<ENERGY_PERIODIC_TASK> ENERGY_PERIODIC_TASK { get; set; }

        /// <summary>
        /// Represents the database set for the CONTACT_PERSON entity.
        /// </summary>
        public DbSet<CONTACT_PERSON> CONTACT_PERSON { get; set; }

        /// <summary>
        /// Represents the database set for the RESOURCE_GROUP entity.
        /// </summary>
        public DbSet<RESOURCE_GROUP> RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the VIDEO entity.
        /// </summary>
        public DbSet<VIDEO> VIDEO { get; set; }

        /// <summary>
        /// Represents the database set for the PERIOD_OF_NOTICE entity.
        /// </summary>
        public DbSet<PERIOD_OF_NOTICE> PERIOD_OF_NOTICE { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_READING entity.
        /// </summary>
        public DbSet<ENERGY_READING> ENERGY_READING { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT entity.
        /// </summary>
        public DbSet<CONTRACT> CONTRACT { get; set; }

        /// <summary>
        /// Represents the database set for the AREA entity.
        /// </summary>
        public DbSet<AREA> AREA { get; set; }

        /// <summary>
        /// Represents the database set for the VIDEO_BINARY entity.
        /// </summary>
        public DbSet<VIDEO_BINARY> VIDEO_BINARY { get; set; }

        /// <summary>
        /// Represents the database set for the PERIODIC_TASK entity.
        /// </summary>
        public DbSet<PERIODIC_TASK> PERIODIC_TASK { get; set; }

        /// <summary>
        /// Represents the database set for the ENERGY_UNIT entity.
        /// </summary>
        public DbSet<ENERGY_UNIT> ENERGY_UNIT { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_TEXT entity.
        /// </summary>
        public DbSet<WEB_TEXT> WEB_TEXT { get; set; }

        /// <summary>
        /// Represents the database set for the POSTAL_CODE entity.
        /// </summary>
        public DbSet<POSTAL_CODE> POSTAL_CODE { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_TASK entity.
        /// </summary>
        public DbSet<ENTITY_TASK> ENTITY_TASK { get; set; }

        /// <summary>
        /// Represents the database set for the CONTROL_LIST entity.
        /// </summary>
        public DbSet<CONTROL_LIST> CONTROL_LIST { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_USER_TOKEN entity.
        /// </summary>
        public DbSet<WEB_USER_TOKEN> WEB_USER_TOKEN { get; set; }

        /// <summary>
        /// Represents the database set for the PRICE_SHEET entity.
        /// </summary>
        public DbSet<PRICE_SHEET> PRICE_SHEET { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_TYPE_INFO entity.
        /// </summary>
        public DbSet<ENTITY_TYPE_INFO> ENTITY_TYPE_INFO { get; set; }

        /// <summary>
        /// Represents the database set for the CONTROL_LIST_ITEM entity.
        /// </summary>
        public DbSet<CONTROL_LIST_ITEM> CONTROL_LIST_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the ACCOUNT entity.
        /// </summary>
        public DbSet<ACCOUNT> ACCOUNT { get; set; }

        /// <summary>
        /// Represents the database set for the WORK_ORDER entity.
        /// </summary>
        public DbSet<WORK_ORDER> WORK_ORDER { get; set; }

        /// <summary>
        /// Represents the database set for the PRICE_SHEET_CATEGORY entity.
        /// </summary>
        public DbSet<PRICE_SHEET_CATEGORY> PRICE_SHEET_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_X_ATTRIBUTE entity.
        /// </summary>
        public DbSet<ENTITY_X_ATTRIBUTE> ENTITY_X_ATTRIBUTE { get; set; }

        /// <summary>
        /// Represents the database set for the CONTROL_LIST_ITEM_ANSWER entity.
        /// </summary>
        public DbSet<CONTROL_LIST_ITEM_ANSWER> CONTROL_LIST_ITEM_ANSWER { get; set; }

        /// <summary>
        /// Represents the database set for the ACCOUNT_X_ACCOUNTING entity.
        /// </summary>
        public DbSet<ACCOUNT_X_ACCOUNTING> ACCOUNT_X_ACCOUNTING { get; set; }

        /// <summary>
        /// Represents the database set for the WORK_ORDER_INVOICE_ITEM entity.
        /// </summary>
        public DbSet<WORK_ORDER_INVOICE_ITEM> WORK_ORDER_INVOICE_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the PRICE_SHEET_CATEGORY_PRICE entity.
        /// </summary>
        public DbSet<PRICE_SHEET_CATEGORY_PRICE> PRICE_SHEET_CATEGORY_PRICE { get; set; }

        /// <summary>
        /// Represents the database set for the EQUIPMENT entity.
        /// </summary>
        public DbSet<EQUIPMENT> EQUIPMENT { get; set; }

        /// <summary>
        /// Represents the database set for the CONTROL_LIST_LOG_ITEM entity.
        /// </summary>
        public DbSet<CONTROL_LIST_LOG_ITEM> CONTROL_LIST_LOG_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the ACCOUNTING entity.
        /// </summary>
        public DbSet<ACCOUNTING> ACCOUNTING { get; set; }

        /// <summary>
        /// Represents the database set for the WORK_ORDER_X_AREA entity.
        /// </summary>
        public DbSet<WORK_ORDER_X_AREA> WORK_ORDER_X_AREA { get; set; }

        /// <summary>
        /// Represents the database set for the PRICE_SHEET_REVISION entity.
        /// </summary>
        public DbSet<PRICE_SHEET_REVISION> PRICE_SHEET_REVISION { get; set; }

        /// <summary>
        /// Represents the database set for the EQUIPMENT_CATEGORY entity.
        /// </summary>
        public DbSet<EQUIPMENT_CATEGORY> EQUIPMENT_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the CONTROL_LIST_RULE entity.
        /// </summary>
        public DbSet<CONTROL_LIST_RULE> CONTROL_LIST_RULE { get; set; }

        /// <summary>
        /// Represents the database set for the ACCOUNTING_X_ACCOUNTING entity.
        /// </summary>
        public DbSet<ACCOUNTING_X_ACCOUNTING> ACCOUNTING_X_ACCOUNTING { get; set; }

        /// <summary>
        /// Represents the database set for the WORK_ORDER_X_EQUIPMENT entity.
        /// </summary>
        public DbSet<WORK_ORDER_X_EQUIPMENT> WORK_ORDER_X_EQUIPMENT { get; set; }

        /// <summary>
        /// Represents the database set for the PRICE_SHEET_X_BUILDING entity.
        /// </summary>
        public DbSet<PRICE_SHEET_X_BUILDING> PRICE_SHEET_X_BUILDING { get; set; }

        /// <summary>
        /// Represents the database set for the EQUIPMENT_OPERATING_HOUR_TYPE entity.
        /// </summary>
        public DbSet<EQUIPMENT_OPERATING_HOUR_TYPE> EQUIPMENT_OPERATING_HOUR_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the CONTROL_LIST_X_ENTITY entity.
        /// </summary>
        public DbSet<CONTROL_LIST_X_ENTITY> CONTROL_LIST_X_ENTITY { get; set; }

        /// <summary>
        /// Represents the database set for the ACTIVITY_CATEGORY entity.
        /// </summary>
        public DbSet<ACTIVITY_CATEGORY> ACTIVITY_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the WORK_ORDER_X_RESOURCE_GROUP entity.
        /// </summary>
        public DbSet<WORK_ORDER_X_RESOURCE_GROUP> WORK_ORDER_X_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the PRIORITY entity.
        /// </summary>
        public DbSet<PRIORITY> PRIORITY { get; set; }

        /// <summary>
        /// Represents the database set for the EQUIPMENT_OPERATING_HOURS entity.
        /// </summary>
        public DbSet<EQUIPMENT_OPERATING_HOURS> EQUIPMENT_OPERATING_HOURS { get; set; }

        /// <summary>
        /// Represents the database set for the COST entity.
        /// </summary>
        public DbSet<COST> COST { get; set; }

        /// <summary>
        /// Represents the database set for the ACTIVITY_CONSTRAINT entity.
        /// </summary>
        public DbSet<ACTIVITY_CONSTRAINT> ACTIVITY_CONSTRAINT { get; set; }

        /// <summary>
        /// Represents the database set for the WORK_ORDER_X_SPARE_PART entity.
        /// </summary>
        public DbSet<WORK_ORDER_X_SPARE_PART> WORK_ORDER_X_SPARE_PART { get; set; }

        /// <summary>
        /// Represents the database set for the PROJECT entity.
        /// </summary>
        public DbSet<PROJECT> PROJECT { get; set; }

        /// <summary>
        /// Represents the database set for the EQUIPMENT_TEMPLATE entity.
        /// </summary>
        public DbSet<EQUIPMENT_TEMPLATE> EQUIPMENT_TEMPLATE { get; set; }

        /// <summary>
        /// Represents the database set for the COST_CENTER entity.
        /// </summary>
        public DbSet<COST_CENTER> COST_CENTER { get; set; }

        /// <summary>
        /// Represents the database set for the ACTIVITY_GROUP entity.
        /// </summary>
        public DbSet<ACTIVITY_GROUP> ACTIVITY_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the WORKING_DAYS_OFF entity.
        /// </summary>
        public DbSet<WORKING_DAYS_OFF> WORKING_DAYS_OFF { get; set; }

        /// <summary>
        /// Represents the database set for the PROJECT_CATEGORY entity.
        /// </summary>
        public DbSet<PROJECT_CATEGORY> PROJECT_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the EQUIPMENT_TEMPLATE_X_CATEGORY entity.
        /// </summary>
        public DbSet<EQUIPMENT_TEMPLATE_X_CATEGORY> EQUIPMENT_TEMPLATE_X_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOM_FUNCTION entity.
        /// </summary>
        public DbSet<CUSTOM_FUNCTION> CUSTOM_FUNCTION { get; set; }

        /// <summary>
        /// Represents the database set for the ADJUSTMENT entity.
        /// </summary>
        public DbSet<ADJUSTMENT> ADJUSTMENT { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_ADJUSTMENT entity.
        /// </summary>
        public DbSet<CONTRACT_ADJUSTMENT> CONTRACT_ADJUSTMENT { get; set; }

        /// <summary>
        /// Represents the database set for the PERSON entity.
        /// </summary>
        public DbSet<PERSON> PERSON { get; set; }

        /// <summary>
        /// Represents the database set for the VIDEO_X_ENTITY entity.
        /// </summary>
        public DbSet<VIDEO_X_ENTITY> VIDEO_X_ENTITY { get; set; }

        /// <summary>
        /// Represents the database set for the PERIODIC_TASK_X_AREA entity.
        /// </summary>
        public DbSet<PERIODIC_TASK_X_AREA> PERIODIC_TASK_X_AREA { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_ATTRIBUTE entity.
        /// </summary>
        public DbSet<ENTITY_ATTRIBUTE> ENTITY_ATTRIBUTE { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_CATEGORY entity.
        /// </summary>
        public DbSet<CONTRACT_CATEGORY> CONTRACT_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the CLEANING_COMPLETION entity.
        /// </summary>
        public DbSet<CLEANING_COMPLETION> CLEANING_COMPLETION { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_DASHBOARD entity.
        /// </summary>
        public DbSet<WEB_DASHBOARD> WEB_DASHBOARD { get; set; }

        /// <summary>
        /// Represents the database set for the PERIODIC_TASK_X_EQUIPMENT entity.
        /// </summary>
        public DbSet<PERIODIC_TASK_X_EQUIPMENT> PERIODIC_TASK_X_EQUIPMENT { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_COMMENT entity.
        /// </summary>
        public DbSet<ENTITY_COMMENT> ENTITY_COMMENT { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_ITEM entity.
        /// </summary>
        public DbSet<CONTRACT_ITEM> CONTRACT_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_DASHBOARD_WIDGET entity.
        /// </summary>
        public DbSet<WEB_DASHBOARD_WIDGET> WEB_DASHBOARD_WIDGET { get; set; }

        /// <summary>
        /// Represents the database set for the PERIODIC_TASK_X_RESOURCE_GROUP entity.
        /// </summary>
        public DbSet<PERIODIC_TASK_X_RESOURCE_GROUP> PERIODIC_TASK_X_RESOURCE_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_COUNTER entity.
        /// </summary>
        public DbSet<ENTITY_COUNTER> ENTITY_COUNTER { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_X_CLEANING_TASK entity.
        /// </summary>
        public DbSet<AREA_X_CLEANING_TASK> AREA_X_CLEANING_TASK { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_ITEM_X_SERVICE entity.
        /// </summary>
        public DbSet<CONTRACT_ITEM_X_SERVICE> CONTRACT_ITEM_X_SERVICE { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_LIST_VIEW entity.
        /// </summary>
        public DbSet<WEB_LIST_VIEW> WEB_LIST_VIEW { get; set; }

        /// <summary>
        /// Represents the database set for the PERIODIC_TASK_X_SPARE_PART entity.
        /// </summary>
        public DbSet<PERIODIC_TASK_X_SPARE_PART> PERIODIC_TASK_X_SPARE_PART { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_HISTORY entity.
        /// </summary>
        public DbSet<ENTITY_HISTORY> ENTITY_HISTORY { get; set; }

        /// <summary>
        /// Represents the database set for the BUILDING entity.
        /// </summary>
        public DbSet<BUILDING> BUILDING { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_LEASE entity.
        /// </summary>
        public DbSet<CONTRACT_LEASE> CONTRACT_LEASE { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_LIST_VIEW_COLUMN entity.
        /// </summary>
        public DbSet<WEB_LIST_VIEW_COLUMN> WEB_LIST_VIEW_COLUMN { get; set; }

        /// <summary>
        /// Represents the database set for the PERIODIC_TASK_X_STANDARD_TEXT entity.
        /// </summary>
        public DbSet<PERIODIC_TASK_X_STANDARD_TEXT> PERIODIC_TASK_X_STANDARD_TEXT { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_LINK entity.
        /// </summary>
        public DbSet<ENTITY_LINK> ENTITY_LINK { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_LEASE_ITEM entity.
        /// </summary>
        public DbSet<CONTRACT_LEASE_ITEM> CONTRACT_LEASE_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_MENU entity.
        /// </summary>
        public DbSet<WEB_MENU> WEB_MENU { get; set; }

        /// <summary>
        /// Represents the database set for the PERIODIZATION entity.
        /// </summary>
        public DbSet<PERIODIZATION> PERIODIZATION { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_MAIL_LIST entity.
        /// </summary>
        public DbSet<ENTITY_MAIL_LIST> ENTITY_MAIL_LIST { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_PRICE_X_SERVICE entity.
        /// </summary>
        public DbSet<CONTRACT_PRICE_X_SERVICE> CONTRACT_PRICE_X_SERVICE { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_PROFILE entity.
        /// </summary>
        public DbSet<WEB_PROFILE> WEB_PROFILE { get; set; }

        /// <summary>
        /// Represents the database set for the PERSON_ROLE entity.
        /// </summary>
        public DbSet<PERSON_ROLE> PERSON_ROLE { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_PERMISSION entity.
        /// </summary>
        public DbSet<ENTITY_PERMISSION> ENTITY_PERMISSION { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_TYPE entity.
        /// </summary>
        public DbSet<CONTRACT_TYPE> CONTRACT_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the WEB_PROFILE_X_WEB_MENU entity.
        /// </summary>
        public DbSet<WEB_PROFILE_X_WEB_MENU> WEB_PROFILE_X_WEB_MENU { get; set; }

        /// <summary>
        /// Represents the database set for the PLOT_X_BUILDING entity.
        /// </summary>
        public DbSet<PLOT_X_BUILDING> PLOT_X_BUILDING { get; set; }

        /// <summary>
        /// Represents the database set for the ENTITY_PERMISSION_PROFILE entity.
        /// </summary>
        public DbSet<ENTITY_PERMISSION_PROFILE> ENTITY_PERMISSION_PROFILE { get; set; }

        /// <summary>
        /// Represents the database set for the CONTRACT_WARRANTY entity.
        /// </summary>
        public DbSet<CONTRACT_WARRANTY> CONTRACT_WARRANTY { get; set; }

        /// <summary>
        /// Represents the database set for the PROJECT_MILESTONE entity.
        /// </summary>
        public DbSet<PROJECT_MILESTONE> PROJECT_MILESTONE { get; set; }

        /// <summary>
        /// Represents the database set for the ESTATE entity.
        /// </summary>
        public DbSet<ESTATE> ESTATE { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOM_FUNCTION_X_DATA_OWNER entity.
        /// </summary>
        public DbSet<CUSTOM_FUNCTION_X_DATA_OWNER> CUSTOM_FUNCTION_X_DATA_OWNER { get; set; }

        /// <summary>
        /// Represents the database set for the ALARM entity.
        /// </summary>
        public DbSet<ALARM> ALARM { get; set; }

        /// <summary>
        /// Represents the database set for the PROJECT_PHASE entity.
        /// </summary>
        public DbSet<PROJECT_PHASE> PROJECT_PHASE { get; set; }

        /// <summary>
        /// Represents the database set for the ESTATE_CATEGORY entity.
        /// </summary>
        public DbSet<ESTATE_CATEGORY> ESTATE_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOM_REPORT entity.
        /// </summary>
        public DbSet<CUSTOM_REPORT> CUSTOM_REPORT { get; set; }

        /// <summary>
        /// Represents the database set for the ALARM_LOG entity.
        /// </summary>
        public DbSet<ALARM_LOG> ALARM_LOG { get; set; }

        /// <summary>
        /// Represents the database set for the PROJECT_STATUS entity.
        /// </summary>
        public DbSet<PROJECT_STATUS> PROJECT_STATUS { get; set; }

        /// <summary>
        /// Represents the database set for the EVENT entity.
        /// </summary>
        public DbSet<Entities.EVENT> EVENT { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOMER entity.
        /// </summary>
        public DbSet<CUSTOMER> CUSTOMER { get; set; }

        /// <summary>
        /// Represents the database set for the ANONYMIZATION_FIELD_RULE entity.
        /// </summary>
        public DbSet<ANONYMIZATION_FIELD_RULE> ANONYMIZATION_FIELD_RULE { get; set; }

        /// <summary>
        /// Represents the database set for the PROJECT_TYPE entity.
        /// </summary>
        public DbSet<PROJECT_TYPE> PROJECT_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the EVENT_X_ENTITY entity.
        /// </summary>
        public DbSet<EVENT_X_ENTITY> EVENT_X_ENTITY { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOMER_CATEGORY entity.
        /// </summary>
        public DbSet<CUSTOMER_CATEGORY> CUSTOMER_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the API_CLIENT entity.
        /// </summary>
        public DbSet<API_CLIENT> API_CLIENT { get; set; }

        /// <summary>
        /// Represents the database set for the PURCHASE_ORDER entity.
        /// </summary>
        public DbSet<PURCHASE_ORDER> PURCHASE_ORDER { get; set; }

        /// <summary>
        /// Represents the database set for the EXTERNAL_LOGIN_PROVIDER entity.
        /// </summary>
        public DbSet<EXTERNAL_LOGIN_PROVIDER> EXTERNAL_LOGIN_PROVIDER { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOMER_DELIVERY_ADDRESS entity.
        /// </summary>
        public DbSet<CUSTOMER_DELIVERY_ADDRESS> CUSTOMER_DELIVERY_ADDRESS { get; set; }

        /// <summary>
        /// Represents the database set for the API_REQUEST_LOG entity.
        /// </summary>
        public DbSet<API_REQUEST_LOG> API_REQUEST_LOG { get; set; }

        /// <summary>
        /// Represents the database set for the PURCHASE_ORDER_FORM entity.
        /// </summary>
        public DbSet<PURCHASE_ORDER_FORM> PURCHASE_ORDER_FORM { get; set; }

        /// <summary>
        /// Represents the database set for the FOLLOW_UP entity.
        /// </summary>
        public DbSet<FOLLOW_UP> FOLLOW_UP { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOMER_GROUP entity.
        /// </summary>
        public DbSet<CUSTOMER_GROUP> CUSTOMER_GROUP { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_AVAILABILITY entity.
        /// </summary>
        public DbSet<AREA_AVAILABILITY> AREA_AVAILABILITY { get; set; }

        /// <summary>
        /// Represents the database set for the PURCHASE_ORDER_ITEM entity.
        /// </summary>
        public DbSet<PURCHASE_ORDER_ITEM> PURCHASE_ORDER_ITEM { get; set; }

        /// <summary>
        /// Represents the database set for the GENERAL_OPTIONS entity.
        /// </summary>
        public DbSet<GENERAL_OPTIONS> GENERAL_OPTIONS { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOMER_LINE_OF_BUSINESS entity.
        /// </summary>
        public DbSet<CUSTOMER_LINE_OF_BUSINESS> CUSTOMER_LINE_OF_BUSINESS { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_CATEGORY entity.
        /// </summary>
        public DbSet<AREA_CATEGORY> AREA_CATEGORY { get; set; }

        /// <summary>
        /// Represents the database set for the REFERENCE_DATA entity.
        /// </summary>
        public DbSet<REFERENCE_DATA> REFERENCE_DATA { get; set; }

        /// <summary>
        /// Represents the database set for the GIS_ENTITY entity.
        /// </summary>
        public DbSet<GIS_ENTITY> GIS_ENTITY { get; set; }

        /// <summary>
        /// Represents the database set for the CUSTOMER_LOG entity.
        /// </summary>
        public DbSet<CUSTOMER_LOG> CUSTOMER_LOG { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_CATEGORY_X_AREA_TYPE entity.
        /// </summary>
        public DbSet<AREA_CATEGORY_X_AREA_TYPE> AREA_CATEGORY_X_AREA_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the REFERENCE_TYPE entity.
        /// </summary>
        public DbSet<REFERENCE_TYPE> REFERENCE_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the HATCHING entity.
        /// </summary>
        public DbSet<HATCHING> HATCHING { get; set; }

        /// <summary>
        /// Represents the database set for the CYLINDER_TYPE entity.
        /// </summary>
        public DbSet<CYLINDER_TYPE> CYLINDER_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_PRICE entity.
        /// </summary>
        public DbSet<AREA_PRICE> AREA_PRICE { get; set; }

        /// <summary>
        /// Represents the database set for the REGION entity.
        /// </summary>
        public DbSet<REGION> REGION { get; set; }

        /// <summary>
        /// Represents the database set for the HATCHING_X_AREA entity.
        /// </summary>
        public DbSet<HATCHING_X_AREA> HATCHING_X_AREA { get; set; }

        /// <summary>
        /// Represents the database set for the DAILY_UPDATE_LOG entity.
        /// </summary>
        public DbSet<DAILY_UPDATE_LOG> DAILY_UPDATE_LOG { get; set; }

        /// <summary>
        /// Represents the database set for the AREA_TYPE entity.
        /// </summary>
        public DbSet<AREA_TYPE> AREA_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the REGISTERED_FIELD entity.
        /// </summary>
        public DbSet<REGISTERED_FIELD> REGISTERED_FIELD { get; set; }

        /// <summary>
        /// Represents the database set for the HOUR_TYPE entity.
        /// </summary>
        public DbSet<HOUR_TYPE> HOUR_TYPE { get; set; }

        /// <summary>
        /// Represents the database set for the Products entity.
        /// </summary>
        public DbSet<Products> Products { get; set; }

        /// <summary>
        /// Represents the database set for the ProductRelations entity.
        /// </summary>
        public DbSet<ProductRelations> ProductRelations { get; set; }

        /// <summary>
        /// Represents the database set for the NonsReferences entity.
        /// </summary>
        public DbSet<NonsReferences> NonsReferences { get; set; }

        /// <summary>
        /// Represents the database set for the Counter entity.
        /// </summary>
        public DbSet<Counter> Counter { get; set; }

        /// <summary>
        /// Represents the database set for the AggregatedCounter entity.
        /// </summary>
        public DbSet<AggregatedCounter> AggregatedCounter { get; set; }

        /// <summary>
        /// Represents the database set for the State entity.
        /// </summary>
        public DbSet<State> State { get; set; }

        /// <summary>
        /// Represents the database set for the Set entity.
        /// </summary>
        public DbSet<Entities.Set> Set { get; set; }

        /// <summary>
        /// Represents the database set for the Server1 entity.
        /// </summary>
        public DbSet<Server1> Server1 { get; set; }

        /// <summary>
        /// Represents the database set for the Schema entity.
        /// </summary>
        public DbSet<Schema> Schema { get; set; }

        /// <summary>
        /// Represents the database set for the List entity.
        /// </summary>
        public DbSet<List> List { get; set; }

        /// <summary>
        /// Represents the database set for the JobQueue entity.
        /// </summary>
        public DbSet<JobQueue> JobQueue { get; set; }

        /// <summary>
        /// Represents the database set for the JobParameter entity.
        /// </summary>
        public DbSet<JobParameter> JobParameter { get; set; }

        /// <summary>
        /// Represents the database set for the Job entity.
        /// </summary>
        public DbSet<Job> Job { get; set; }

        /// <summary>
        /// Represents the database set for the Hash entity.
        /// </summary>
        public DbSet<Hash> Hash { get; set; }
    }
}