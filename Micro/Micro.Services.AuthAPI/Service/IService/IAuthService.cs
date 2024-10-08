﻿using Micro.Services.AuthAPI.Models.Dto;

namespace Micro.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        //Task<UserDto> Register(RegistrationRequestDto registrationRequestDto);
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
