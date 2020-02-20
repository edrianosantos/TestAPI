using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Model;

namespace TestAPI.Repository
{
    public class TodoItemsRepository : ITodoItemsRepository
    {
        readonly DataBaseContext _dataContext;
        public TodoItemsRepository(DataBaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<TodoItems> GetAll()
        {
            return _dataContext.TodoItems.ToList();
        }

        public TodoItems Get(long id)
        {
            return _dataContext.TodoItems.FirstOrDefault(x => Convert.ToInt64(x.Id) == id);
        }

        public void Add(TodoItems entity)
        {
            _dataContext.TodoItems.Add(entity);
            _dataContext.SaveChanges();
        }

        public void Update(TodoItems dbEntity, TodoItems entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.IsComplete = entity.IsComplete;

            _dataContext.SaveChanges();
        }

        public void Delete(TodoItems entity)
        {
            _dataContext.TodoItems.Remove(entity);
            _dataContext.SaveChanges();
        }
    }
}
