﻿using CVBuilderAuth.Models.DTO;

namespace CVBuilderAuth.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {

        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);

        Task LogoutAsync();
    }
}
