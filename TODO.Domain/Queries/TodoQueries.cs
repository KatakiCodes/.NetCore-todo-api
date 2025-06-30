using System;
using System.Linq.Expressions;
using TODO.Domain.Entities;

namespace TODO.Domain.Queries;

public static class TodoQueries
{
    public static Expression<Func<TodoItem, bool>> GetAll(Guid user_id)
    {
        return x => x.User_id == user_id;
    }
    public static Expression<Func<TodoItem, bool>> GetById(Guid user_id, Guid id)
    {
        return x => x.User_id == user_id && x.Id == id;
    }
    public static Expression<Func<TodoItem, bool>> GetAllDone(Guid user_id)
    {
        return x => x.User_id == user_id && x.Done == true;
    }

    public static Expression<Func<TodoItem, bool>> GetAllUndone(Guid user_id)
    {
        return x => x.User_id == user_id && x.Done == false;
    }
    public static Expression<Func<TodoItem, bool>> GetByPeriod(Guid user_id, DateTime date, bool done)
    {
        return x => x.User_id == user_id
            && x.Done == done
            && x.Date.Date == date.Date;
    }
}
