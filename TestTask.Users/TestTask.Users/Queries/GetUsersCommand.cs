using AzureFromTheTrenches.Commanding.Abstractions;
using System.Collections.Generic;
using TestTask.Users.BLL.DTOs.Users;

namespace TestTask.Users.Queries
{
    public class GetUsersCommand : ICommand<List<GetUserDTO>>
    {
    }
}