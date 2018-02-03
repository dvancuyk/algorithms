# Graph Definitions

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