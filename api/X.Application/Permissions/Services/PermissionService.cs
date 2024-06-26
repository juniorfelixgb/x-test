﻿using X.Application.Permissions.Requests;
using X.Domain.Employees.Exceptions;
using X.Domain.Permissions;
using X.Domain.Permissions.Exceptions;
using X.Domain.Shared.Interfaces;

namespace X.Application.Permissions.Services;

internal sealed class PermissionService : IPermissionService
{
    private readonly IPermissionRepository permissionRepository;
    private readonly IPermissionTypeRepository permissionTypeRepository;
    private readonly IEmployeeRespository employeeRespository;
    public PermissionService(
        IPermissionRepository permissionRepository,
        IPermissionTypeRepository permissionTypeRepository,
        IEmployeeRespository employeeRespository)
    {
        this.permissionRepository = permissionRepository;
        this.permissionTypeRepository = permissionTypeRepository;
        this.employeeRespository = employeeRespository;
    }

    public async Task<Permission> Create(Permission permission)
    {
        var employee = await this.employeeRespository.Get(e => e.FirstName == permission.Employee.FirstName);
        if (employee is null)
        {
            throw new EmployeeNotExistException(permission.Employee.FirstName);
        }

        var permissionTypeExist = await this.permissionTypeRepository.Exist(e => e.Id == permission.PermissionTypeId);
        if (!permissionTypeExist)
        {
            throw new PermissionTypeNotExistException(permission.PermissionTypeId);
        }

        permission.EmployeeId = employee.Id;
        var permissionCreated = await this.permissionRepository.Create(permission);
        return permissionCreated;
    }

    public async Task<List<Permission>> GetAll()
    {
        return await this.permissionRepository.GetAllAsync();
    }

    public async Task<Permission> GetById(int id)
    {
        return await this.permissionRepository.GetAsync(p => p.Id == id);
    }

    public async Task<List<PermissionType>> GetTypes()
    {
        return await this.permissionTypeRepository.GetTypes();
    }
}
