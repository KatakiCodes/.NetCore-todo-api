using System;
using System.Linq.Expressions;
using TODO.Domain.Entities;

namespace TODO.Domain.Queries;

public static class UserQueries
{
    public static Expression<Func<User, bool>> GetById(Guid id)
    {
        return User => User.Id == id;
    }
    public static Expression<Func<User, bool>> GetByExternalId(object external_idid)
    {
        return User => User.IsExternal && User.External_id == external_idid;
    }
    public static Expression<Func<User, bool>> Login(string name, string password)
    {
        return User => User.IsExternal == false && User.Name == name && User.Password == password;
    }
}
