using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Model;
using TestAPI.Repository;

namespace TestAPI.Services
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly ITodoItemsRepository _todoItemsRepository;
        public TodoItemsService(DataBaseContext dataBaseContext, ITodoItemsRepository todoItemsRepository)
        {
            _dataBaseContext = dataBaseContext;
            _todoItemsRepository = todoItemsRepository;
        }

        public IEnumerable<TodoItems> GetAll()
        {
            return _todoItemsRepository.GetAll();
        }

        public TodoItems Get(long id)
        {
            return _todoItemsRepository.Get(id);
        }

        public void Add(TodoItems entity)
        {
            _todoItemsRepository.Add(entity);
        }

        public void Update(TodoItems dbEntity, TodoItems entity)
        {
            _todoItemsRepository.Update(dbEntity, entity);
        }

        public void Delete(TodoItems entity)
        {
            _todoItemsRepository.Delete(entity);
        }

    }
}
