﻿namespace aspnetcorewebapisqlclient.Business.Interfaces
{
    public interface IGetEmployeeById
    {
        Task<List<Employees>> GetEmployee(int id);
    }
}