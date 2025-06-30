using System;
using Microsoft.EntityFrameworkCore;
using TODO.Domain.Entities;
using TODO.Domain.Queries;
using TODO.Domain.Repositories;
using TODO.Infra.DataContexts;

namespace TODO.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _Context;

    public UserRepository(DataContext context)
    {
        _Context = context;
    }

    public User Create(User user)
    {
        this._Context.Users.Add(user);
        this._Context.SaveChanges();
        return user;
    }

    public User GetByExternalId(string id)
    {
        var user = this._Context.Users.AsNoTracking().FirstOrDefault(UserQueries.GetByExternalId(id));
        return user;
    }

    public User GetById(Guid id)
    {
        var user = this._Context.Users.AsNoTracking().FirstOrDefault(UserQueries.GetById(id));
        return user;
    }

    public User Login(string name, string password)
    {
        var user = this._Context.Users.AsNoTracking().FirstOrDefault(UserQueries.Login(name, password));
        return user;
    }
}
