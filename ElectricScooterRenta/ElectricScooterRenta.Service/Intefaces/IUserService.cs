using ElectricScooterRenta.Domain.Models;
using ElectricScooterRenta.Service.DTOs.UserDTOs;

namespace ElectricScooterRenta.Service.Intefaces;

public interface IUserService
{
    public Task<bool> Register(UserRegisterRequest request);
    public Task<User?> Login(UserLoginRequest request);
}