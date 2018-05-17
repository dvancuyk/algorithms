namespace Fundamentals
{
    public interface IUnionFind
    {
        /// <summary>
        /// Returns the number of connected components.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Joins the two points together.
        /// </summary>
        /// <param name="p">The first point</param>
        /// <param name="q">The second point</param>
        void Union(int p, int q);

        /// <summary>
        /// Determines if the two provided points are connected.
        /// </summary>
        /// <param name="p">The first point</param>
        /// <param name="q">The second point</param>
        /// <returns></returns>
        bool Connected(int p, int q);
        
    }
}