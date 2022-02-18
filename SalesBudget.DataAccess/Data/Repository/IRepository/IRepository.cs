using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SalesBudget.DataAccess.Data.Repository.IRepository
{

    //Metodi di base implementati in tutti i repository (definizioni)
    public interface IRepository<T> where T : class
    {
        //Funzioni generiche
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        //Solo 1 oggetto
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        //Aggiunge o rimuove un entità
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);

    }
}


