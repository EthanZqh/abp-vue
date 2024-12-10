export interface OnboardingGetListInput extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface TenantCreateDto extends TenantCreateOrUpdateBase {
  adminEmailAddress: string;
  adminPassword: string;
  useSharedDatabase?: boolean;
  defaultConnectionString?: string;
}

export interface TenantUpdateDto extends TenantCreateOrUpdateBase {
  concurrencyStamp?: string;
}

export interface TenantConnectionStringCreateOrUpdate {
  name: string;
  value: string;
}

export interface OnboardingTaskDto extends ExtensibleAuditedEntityDto<string> {
  name?: string;
  externalId?: string;
  processId?: string;
  employeeName?: string;
  employeeEmail?: string;
  isCompleted?: boolean;
  description?: string;
}

export interface TenantCreateOrUpdateBase extends ExtensibleObject {
  name: string;
  isActive?: boolean;
  editionId?: string;
  enableTime?: string;
  disableTime?: string;
}

export interface TenantConnectionStringDto {
  name?: string;
  value?: string;
}

