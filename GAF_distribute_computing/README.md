## Distribute Computing Demo: Genetics Algorithm

### The speed limitation step in GA estimates

One of the speed limitation step in GA eastimates is the fitness sorts for selects the best population that can evolved. For calculate the fitness of a parameter set, ODEs will be computed and the Euclidean distance will be calculated between the estimates function and observation data. This calculation operation will takes a long time to run if the data resolution is very high and population is very large.

For a GA estimation that running on a single machine, the only way to boost this operation is using parallel linq, but a single machine is too power limited, so that a server cluster will required for solving this large scale data analysis problem. For solving a system parameter estimates problem using GA, in a server cluster, then we needs distribute computing. 

For running GA on a single machine, makes it run on a server cluster, we just needs devide its population into sevral parts, and then push the fitness calculation task onto each single machine in our server cluster, then we can makes this GA analysis running in distribute method.

![](./Mutation-and-fitness.png)
> A basic calculation in GA
