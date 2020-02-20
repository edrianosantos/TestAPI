using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Model;

namespace TestAPI.Repository
{
    public interface ITodoItemsRepository : IDataRepository<TodoItems>
    {
        public IEnumerable<TodoItems> GetAll();
        public TodoItems Get(long id);
        public void Add(TodoItems entity);
        public void Update(TodoItems dbEntity, TodoItems entity);
        public void Delete(TodoItems entity);
    }
}
