using System;
using TODO.Domain.Entities;

namespace TODO.Domain.Repositories;

public interface IUserRepository
{
    public User GetById(Guid id);
    public User GetByExternalId(string id);
    public User Create(User user);
    public User Login(string name, string password);
}
