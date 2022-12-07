# PageRank

## What is PageRank?
PageRank is an algorithm famously used by Google to determine what 
search results should be placed at the top of the results page.

## The Implementation

### The Data Storage
In this implementation of the PageRank algorithm I created a class
that represents a web of sites that link to each other. The class
keeps track of a list of Site objects that in turn keep track of 
their own links and PageRank.

### The Algorithm
I implemented the algorithm iteratively, using a series of loops to, <br/>
First, I set all of the sites' page rank variables to 1 divided by the total
number of sites in the web. Along with this, I had to check for any sites that
had no links. in this case we treat them as though they have links to all sites in
the web, so we add those links here.<br/>
Next, check if the page ranks had yet converged, using a boolean flag. <br/>
Next, loop through all of the sites held in the web, create a temporary variable,
find the sites that link to the current site, and calculate how much of their page 
rank had to be transfered and add it to the temp variable. <br/>
Next, I used the dampening factor (set to .85 by default) to calculate the final
page rank of the page and set the site's page rank variable. <br/>
Lastly, I checked if the page rank had converged yet by checking the 
current page rank against the last one.

## The Math
The links between the sites in a given web can be represented in an n\*n adjecency
matrix(A), where n is the total number of sites in the system, in which A_i,j represents
the weight of a given link from Site j to Site i. The weight of a given link is
set to 1/l where l is the total number of links site j contains.
We also have a vector x that represents the PageRanks of all of the sites
in the web. On the first iteration, all of the PageRanks will be equal, set to 1/n.
On each iteration, we can calculate the PageRank relative to the last iteration.
To do this we can perform the matrix multiplication, M\*x. The resulting vector 
will contain the updated PageRanks.

## Running The Testing Program
You can run the Main method by setting the "ConsoleController" project as the
startup project, building the project, and then running. As of now, it should
create a web with around 50 sites that all link to each other, aside from the
first ones. It just does this with a simple for loop. You can change both the
total number of sites and the links per site by changing a variable (the names
are self explanitory). If the boolean flag "doPresetWeb" is true, the program 
will skip the loop and move on to a predetermined list.