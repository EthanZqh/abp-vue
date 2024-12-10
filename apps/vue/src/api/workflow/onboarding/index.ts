import { defHttp } from '/@/utils/http/axios';
import { OnboardingGetListInput, TenantCreateDto, TenantUpdateDto, TenantConnectionStringDto,TenantConnectionStringCreateOrUpdate, OnboardingTaskDto,  } from './model';

/* export const GetAsyncById = (id: string) => {
  return defHttp.get<TenantDto>({
    url: `/api/saas/tenants/${id}`,
  });
};

export const GetAsyncByName = (name: string) => {
  return defHttp.get<TenantDto>({
    url: `/api/saas/tenants/by-name/${name}`,
  });
}; */

export const GetListAsyncByInput = (input: OnboardingGetListInput) => {
  alert(2);
  console.log(input);
  return defHttp.get<PagedResultDto<OnboardingTaskDto>>({
    url: `/api/workflow/onboarding`,
    params: input,
  }); 
/*   return defHttp.put<OnboardingTaskDto>({
    url: `/api/saas/tenants/${id}`,
  }); */



/*   var taskId='A7D1A956-3B1D-6647-82F1-3A158A2B37BF';
  alert(taskId);
  return defHttp.put<OnboardingTaskDto>({
    url: `/api/onboarding/${taskId}`,
  });
 */

};


export const update = (taskId: string) => {
  return defHttp.put<OnboardingTaskDto>({
    url: `/api/onboarding/${taskId}`,
  });
};

export const DeleteAsyncById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/saas/tenants/${id}`,
  });
};

/* export const CreateAsyncByInput = (input: TenantCreateDto) => {
  return defHttp.post<TenantDto>({
    url: `/api/saas/tenants`,
    data: input,
  });
};

export const UpdateAsyncByIdAndInput = (id: string, input: TenantUpdateDto) => {
  return defHttp.put<TenantDto>({
    url: `/api/saas/tenants/${id}`,
    data: input,
  });
};

export const DeleteAsyncById = (id: string) => {
  return defHttp.delete<void>({
    url: `/api/saas/tenants/${id}`,
  });
};

export const GetConnectionStringAsyncByIdAndName = (id: string, name: string) => {
  return defHttp.get<TenantConnectionStringDto>({
    url: `/api/saas/tenants/${id}/connection-string/${name}`,
  });
};

export const GetConnectionStringAsyncById = (id: string) => {
  return defHttp.get<ListResultDto<TenantConnectionStringDto>>({
    url: `/api/saas/tenants/${id}/connection-string`,
  });
};

export const SetConnectionStringAsyncByIdAndInput = (id: string, input: TenantConnectionStringCreateOrUpdate) => {
  return defHttp.put<TenantConnectionStringDto>({
    url: `/api/saas/tenants/${id}/connection-string`,
    data: input,
  });
};

export const DeleteConnectionStringAsyncByIdAndName = (id: string, name: string) => {
  return defHttp.delete<void>({
    url: `/api/saas/tenants/${id}/connection-string/${name}`,
  });
};
 */