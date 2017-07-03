using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamDMS.DaoContracts
{
    public interface IDaoHandler<T> : IDisposable where T : class
    {
        /// <summary>
        /// Возвращает все записи указанной сущности.
        /// </summ3rq   ary>
        IQueryable<T> Get { get; }

        /// <summary>
        /// Создает новую сущность.
        /// </summary>
        /// <param name="entry">Сущность EF.</param>             
        bool Add(T entry);

        /// <summary>
        /// Удаляет указанную сущность из источника данных.
        /// </summary>
        /// <param name="entry">Сущность EF</param>
        bool Delete(T entry);

        /// <summary>
        /// Удаляет сущность из источника данных по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        bool Delete(string id);

        /// <summary>
        /// Обновляет указанную сущность в источнике данных.
        /// </summary>
        /// <param name="entry">Сущность EF.</param>
        bool Update(T entry);

        /// <summary>
        /// Получает сущность по ее идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <returns></returns>
        T GetById(string id);
    }
}