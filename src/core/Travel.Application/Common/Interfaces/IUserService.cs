using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.Dtos.User;
using Travel.Domain.Entities;

namespace Travel.Application.Common.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int id);
    }
}
