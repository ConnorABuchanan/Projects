using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUtilities;

namespace ConsoleController
{
    internal class PageRankRunner
    {
        public static void Main(String[] args)
        {
            HashSet<Site> sites = new HashSet<Site>();

            //flag for testing multiple lists
            bool doPresetList = true;

            //create a web of sites with a specified number of sites and a specified number of links per site
            int numSites = 50;
            int numLinks = 3;
            if (!doPresetList)
            {
                for (int i = 0; i < numSites; i++)
                {
                    List<Site> temp = new List<Site>();
                    for (int j = 0; i < numLinks; j++)
                    {
                        temp.Add(new Site("A" + (i + j)));
                    }
                    sites.Add(new Site("A" + i, temp));
                }
            }


            if (doPresetList)
            {
                sites.Clear();
                Site A=new Site("A");
                Site B=new Site("B");
                Site C=new Site("C");
                Site D=new Site("D");
                B.Links.Add(A);
                B.Links.Add(C);
                C.Links.Add(A);
                D.Links.Add(A);
                D.Links.Add(B);
                D.Links.Add(C);
                sites.Add(A);
                sites.Add(B);
                sites.Add(C);
                sites.Add(D);
            }
            Web web =new Web(sites);
            
            //call the pagerank method to calculate the pagerank of each site.
            web.pageRank();

            //now we can print the pageranks
            double sum = 0;
            foreach(Site site in web.getSites())
            {
                sum += site.PageRank;
                Console.WriteLine(site.PageRank);
            }
            //and print the sum of the pageranks (should be near one)
            Console.WriteLine(sum);
            //and all of the sites and their links
            Console.WriteLine(web);
        }
    }


}
