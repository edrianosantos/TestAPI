using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Model;
using TestAPI.Repository;

namespace TestAPI.Services
{
    public interface ITodoItemsService
    {
        public IEnumerable<TodoItems> GetAll();

        public TodoItems Get(long id);

        public void Add(TodoItems entity);

        public void Update(TodoItems dbEntity, TodoItems entity);

        public void Delete(TodoItems entity);
    }
}
