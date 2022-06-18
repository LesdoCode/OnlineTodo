using System.Collections.Generic;

namespace OnlineTodo.DataAccess
{
    public interface IRepository<T> where T : class
    {
        void Add( T entity );
        T GetById( int Id );
        IEnumerable<T> GetAll();
        void Update( int Id, T newEntity );
        void Delete( int Id );
    }
}


