using Microsoft.AspNetCore.Identity;
using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;
using MoneyFlow.Utilities;


namespace MoneyFlow.Managers
{
    public class UserManager(AppDBContext _dbContext)
    {
        public UserVM Login(LoginVM viewModel)
        {
            var found = _dbContext.User.Where(
                item => item.Email == viewModel.Email &&
                item.Password == Sha256Hasher.ComputeHash(viewModel.Password)
            ).FirstOrDefault();

            if (found == null)
            {
                return null;
            }

            var user = new UserVM
            {
                UserId = found.UserId.ToString(),
                FullName = found.FullName,
                Email = found.Email
            };

            return user;
        }

        public int Register(UserVM viewModel)
        {
            if (viewModel.Password != viewModel.RepeatPassword)
                throw new InvalidOperationException("The passwords are not the same.");

            var foundEmail = _dbContext.User.Any(i => i.Email == viewModel.Email);

            if (foundEmail)
                throw new InvalidOperationException("The email is already registered.");

            var entity = new User
            {
                FullName = viewModel.FullName,
                Email = viewModel.Email,
                Password = Sha256Hasher.ComputeHash(viewModel.Password)
            };

            _dbContext.User.Add(entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;
        }
    }
}