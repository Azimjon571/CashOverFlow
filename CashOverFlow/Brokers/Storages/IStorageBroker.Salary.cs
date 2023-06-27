﻿//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Salary;

namespace CashOverFlow.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Salary> InsertSalaryAsync(Salary salary);
    }
}
