# Graph Definitions

## Types of graphs
### Undirected Graph
An undirected graph is a graph whose edges are bidirectional, meaning that if there is an edge from __v__ to __w__, 
    then you can go from __v__ to __w__ and from __w__ to __v__ along the same edge.

An undirected graph can be classifed as the following types:
* Acyclic - a graph that has no cycles
  * Has the following properties:
    1. If an edge is added between two vertices, a cycle is created.
    2. If an edge is removed between two vertices, it is broken into two connected components.
 * Forest - a graph that has disjointed set of trees
 * Spanning Tree - subgrahp that contains all of that graph's vertices in a single tree
 * A *cut* of a graph is a partition of its vertices into two nonempty disjoint
    sets. A *crossing edge* of a cut is an edge that connects a vertex in one set with a vertex in the other.

### Directional Graph (Digraph)
A direactional grpah is a graph whose edges are defined with a direction, meaning that if there is an edge from __v__ to __w__, 
    then you can only from __v__ to __w__ and not from __w__ to __v__ along the same edge.

### Edge-weighted Graph

An edge-weighted graph is a graph whose edges each have an associated weight or cost.

## Strongly Connected

* *Two vertices are strongly connected if they are mutually reachable: that is, if there is a directed path from v to w and a directed path exists from w to v.*
* *A digraph is strongly connected if all it's vertices are strongly connected to one another*

### Strong Components
Partitions of a graph where each partition is a set of vertices strongly connected to one another.
Each partition has the following properties:
* *Reflexive* - Every vertex is strongly connected to itself.
* *Symmetic* - If __v__ is strongly connected to __w__, then __w__ is strongly connected to __v__
* *Transitive* - If __v__ is strongly connected to __w__ and __w__ is strongly connected to __x__, 
                 then __v__ is strongly connected to __x__.

## Spanning Trees

* A *spanning tree* of a graph is a connected subgraph with no cycles that includes all the vertices.
* A *minimal spanning tree* of a edge-weighted graph is a spanning tree whose 
    weight (the sum of the weight on its edges) is no larger than the weight of any other spanning tree.
* A *minimum spanning forest* is a collection of *minimal spanning trees* in a series of connected components