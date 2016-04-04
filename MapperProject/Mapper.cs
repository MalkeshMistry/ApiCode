using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using API.Interface;

namespace MapperProject
{
    /// <summary>
    /// Abstract Mapper class that maps T1 to T2 and vice versa.
    /// </summary>
    /// <typeparam name="T1">Type 1</typeparam>
    /// <typeparam name="T2">Type 2</typeparam>
    public abstract class Mapper<T1, T2> : IMapper<T1, T2>
    {
        /// <summary>
        /// Maps a collection of T2 objects to a collection of T1 objects.
        /// </summary>
        /// <param name="source">Collection of T2 objects</param>
        /// <returns>IList of T1 objects</returns>
        public IList<T1> Map(IEnumerable<T2> source)
        {
            return source != null ? source.Select(this.Map).ToList() : null;
        }

        /// <summary>
        /// Maps a collection of T2 objects to a collection of T1 objects otherwise it returns an empty list.
        /// </summary>
        /// <param name="source">Collection of T2 objects</param>
        /// <returns>IList of T1 objects</returns>
        public IList<T1> MapOrEmptyList(IEnumerable<T2> source)
        {
            return source != null ? source.Select(this.Map).ToList() : new List<T1>();
        }

        /// <summary>
        /// Maps a collection of T1 objects to a collection of T2 objects.
        /// </summary>
        /// <param name="source">Collection of T1 objects</param>
        /// <returns>IList of T2 objects</returns>
        public IList<T2> Map(IEnumerable<T1> source)
        {
            return source != null ? source.Select(this.Map).ToList() : null;
        }

        /// <summary>
        /// Maps a collection of T1 objects to a collection of T2 objects otherwise it returns an empty list.
        /// </summary>
        /// <param name="source">Collection of T2 objects</param>
        /// <returns>IList of T2 objects</returns>
        public IList<T2> MapOrEmptyList(IEnumerable<T1> source)
        {
            return source != null ? source.Select(this.Map).ToList() : new List<T2>();
        }

        /// <summary>
        /// Maps T2 to T1
        /// </summary>
        /// <param name="t">T2 object</param>
        /// <returns>T1 object</returns>
        public abstract T1 Map(T2 t);

        /// <summary>
        /// Maps T1 to T2
        /// </summary>
        /// <param name="t">T1 object</param>
        /// <returns>T2 object</returns>
        public abstract T2 Map(T1 t);
    }
}
