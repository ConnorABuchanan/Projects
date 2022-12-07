using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUtilities
{
    public class Web
    {
        private HashSet<Site> sites;

        public Web()
        {
            sites = new HashSet<Site>();
        }
        public Web(HashSet<Site> sites)
        {
            this.sites = sites;
        }

        public HashSet<Site> getSites()
        {
            return sites;
        }

        public void AddSite(Site s)
        {
            sites.Add(s);
        }

        public override string ToString()
        {
            string toReturn = "";
            foreach(Site s in sites)
            {
                toReturn+=s.ToString()+" ";
            }
            return toReturn;
        }

        /// <summary>
        /// Uses the PageRank algorithm to 
        /// "output a probability distribution used to represent the likelihood that a person randomly
        /// clicking on links will arrive at any particular page"
        /// </summary>
        /// <returns></returns>
        public void pageRank()
        {
            //initialize each site's pagerank to 1/the total number of sites
            foreach (Site s in sites)
            {
                s.PageRank = (1.0 / sites.Count());
            }

            //to deal with sites with no outgoing links (called sinks) we add a link from these sites to all other sites in the system. 
            foreach (Site s in sites)
            {
                if(s.Links.Count()==0)
                {
                    foreach(Site s2 in sites)
                    {
                        s.Links.Add(s2);
                    }
                }
            }

            //initialize a variable to represent the dampening factor
            //and a boolean to represent whether the pageranks have converged
            double dampFactor = .85;
            bool haveConverged = false;
            //now loop until the pageRanks have converged
            while (!haveConverged)
            {
                //set the LastPageRank field of each site to the value of the current PageRank field
                foreach(Site s in sites)
                {
                    s.LastPageRank = s.PageRank;
                }

                //loop through all of the sites and calculate their page ranks.
                foreach (Site s in sites)
                {
                    //declare a temporary variable to represent the page rank of the current site.
                    double pr = 0;

                    //loop through each site in the web and check if they have a link to the current site.
                    //if they do, add their last pagerank, divided by their number of outgoing links to the temporary var.
                    foreach (Site s2 in sites)
                    {
                        foreach (Site s3 in s2.Links)
                        {
                            if (s3.Name.Equals(s.Name))
                            {
                                pr += s2.LastPageRank / s2.Links.Count();
                            }
                        }
                    }
                    //calculate the dampened pagerank using the dampening factor and set the site's pagerank to that.
                    double dampenedPr = ((1.0 - dampFactor) / sites.Count()) + (dampFactor * pr);
                    s.PageRank = dampenedPr;
                }
                //now check if the pageranks have converged, and if so, set the boolean flag to true, otherwise set it to false.
                foreach(Site s in sites)
                {
                    if(Math.Abs(s.LastPageRank - s.PageRank) <= .1)
                    {
                        haveConverged = true;
                    }
                    if(Math.Abs(s.LastPageRank - s.PageRank) >= .1)
                    {
                        haveConverged = false;
                    }
                }
            }
        }

    }

    public class Site
    {
        private List<Site> links;
        private readonly string name;
        private double lastPageRank;
        private double pageRank;

        public Site(string n)
        {
            links = new List<Site>();
            name = n;
            lastPageRank = 0;
        }
        public Site(string n, List<Site> s)
        {
            links = s;
            name = n;
            lastPageRank = 0;
        }

        public string Name
        {
            get { return name; }
        }

        public double PageRank
        {
            get { return pageRank; }
            set { pageRank = value; }
        }
        public double LastPageRank
        {
            get { return lastPageRank; }
            set { lastPageRank = value; }
        }

        public List<Site> Links
        {
            get { return links; }
        }

        public override string ToString()
        {
            string toReturn = name+": ";
            foreach (Site s in links)
            {
                toReturn += s.Name+", ";
            }
            toReturn += "\n";
            return toReturn;
        }
    }
}
