import { useLocalization } from '/@/hooks/abp/useLocalization';
import { BasicColumn } from '/@/components/Table';

const { L } = useLocalization('AbpOnboarding');

export function getDataColumns(): BasicColumn[] {
  return [
    {
      title: 'id',
      dataIndex: 'id',
      width: 1,
      ifShow: false,
    },
    {
      title: L('Name'),
      dataIndex: 'name',
      align: 'left',
      width: 200,
      sorter: true,
    },
    {
      title: L('EmployeeName'),
      dataIndex: 'employeeName',
      align: 'left',
      width: 180,
      sorter: true,
    },
    {
      title: L('EmployeeEmail'),
      dataIndex: 'employeeEmail',
      align: 'left',
      width: '180',
      sorter: true,
    },
    {
      title: L('Description'),
      dataIndex: 'description',
      align: 'left',
      width: '180',
      sorter: true,
    },
  ];
}

export function getConnectionStringsColumns(): BasicColumn[] {
  return [
    {
      title: L('DisplayName:Name'),
      dataIndex: 'name',
      align: 'left',
      width: 180,
      sorter: true,
    },
    {
      title: L('DisplayName:Value'),
      dataIndex: 'value',
      align: 'left',
      width: 'auto',
      sorter: true,
    },
  ];
}
