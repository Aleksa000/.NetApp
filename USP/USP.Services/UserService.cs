using USP.Models;

namespace USP.Services;

public interface IUserService
{
    List<UserModel> GetAll();
}

public class UserService : IUserService
{
    public List<UserModel> GetAll()
    {
        var userModel = new UserModel//prepoznaje sam tip podataka o kome se radi
        {
            Id = "1",
            UserName = "Aleksa1",
            FirstName = "Aleksa",
            LastName = "Grbic",
            Email = "aleksa.grbic00@gmail.com",
        };
        var userModel2 = new UserModel//prepoznaje sam tip podataka o kome se radi
        {
            Id = "2",
            UserName = "Aleksa2",
            FirstName = "Aleksa",
            LastName = "Savic",
            Email = "aleksa.savic00@gmail.com",
        };

        var listOfUserModel = new List<UserModel>
        {
            userModel,
            userModel2
        };

        return listOfUserModel;
    }
}