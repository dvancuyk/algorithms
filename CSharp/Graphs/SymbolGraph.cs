using System;
using System.Collections.Generic;
using System.Linq;

namespace Kayllian.Algorithms.Graphs
{
    public class SymbolGraph
    {
        private readonly IDictionary<string, int> _symbols = new Dictionary<string, int>();
        private readonly string[] _keys;

        public SymbolGraph(IReadOnlyCollection<string> records, string delimiter)
            : this(records, delimiter, (count) => new Graph(count))
        {

        }

        public SymbolGraph(IReadOnlyCollection<string> records, string delimiter, Func<int, IGraph> createGraph)
        {
            foreach (var record in records)
            {
                foreach (var name in record.Split(delimiter))
                {
                    if (!_symbols.ContainsKey(name))
                    {
                        _symbols.Add(name, _symbols.Count);
                    }
                }
            }

            Graph = createGraph(_symbols.Count);
            _keys = new string[_symbols.Count];

            foreach (var record in records)
            {
                var names = record.Split(delimiter);
                var root = _symbols[names[0]];

                _keys[root] = names[0];
                
                foreach (var name in names.Skip(1))
                {
                    var index = _symbols[name];
                    _keys[index] = name;
                    Graph.AddEdge(root, index);
                }
            }
        }

        /// <summary>
        /// Gets the underlying graph.
        /// </summary>
        public IGraph Graph { get; }

        public bool Contains(string key)
        {
            return _symbols.ContainsKey(key);
        }

        /// <summary>
        /// Returns the internally maintained index for the given symbol key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Index(string key)
        {
            return _symbols[key];
        }

        /// <summary>
        /// Returns the symbol key maintained at the provided index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Name(int index)
        {
            return _keys[index];
        }
        
    }
}
