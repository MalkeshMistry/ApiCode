using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interface
{
    /// <summary>
    /// Generic IMapper interface, provides a contract to map
    /// type T1 to T2 and vice-versa.
    /// </summary>
    /// <typeparam name="T1">Generic type 1</typeparam>
    /// <typeparam name="T2">Generic type 2</typeparam>
    public interface IMapper<T1, T2> : IMapper
    {
        /// <summary>
        /// Maps a collection of T2 objects to a collection of T1 objects.
        /// </summary>
        /// <param name="source">Collection of T2 objects</param>
        /// <returns>IList of T1 objects</returns>
        IList<T1> Map(IEnumerable<T2> source);

        /// <summary>
        /// Maps a collection of T2 objects to a collection of T1 objects otherwise it returns an empty list.
        /// </summary>
        /// <param name="source">Collection of T2 objects</param>
        /// <returns>IList of T1 objects</returns>
        IList<T1> MapOrEmptyList(IEnumerable<T2> source);

        /// <summary>
        /// Maps a collection of T1 objects to a collection of T2 objects.
        /// </summary>
        /// <param name="source">Collection of T1 objects</param>
        /// <returns>IList of T2 objects</returns>
        IList<T2> Map(IEnumerable<T1> source);

        /// <summary>
        /// Maps a collection of T1 objects to a collection of T2 objects otherwise it returns an empty list.
        /// </summary>
        /// <param name="source">Collection of T2 objects</param>
        /// <returns>IList of T2 objects</returns>
        IList<T2> MapOrEmptyList(IEnumerable<T1> source);

        /// <summary>
        /// Maps T2 to T1
        /// </summary>
        /// <param name="t">T2 object</param>
        /// <returns>T1 object</returns>
        T1 Map(T2 t);

        /// <summary>
        /// Maps T1 to T2
        /// </summary>
        /// <param name="t">T1 object</param>
        /// <returns>T2 object</returns>
        T2 Map(T1 t);
    }

    /// <summary>
    /// Marker interface
    /// </summary>
    public interface IMapper
    {
    }
}
