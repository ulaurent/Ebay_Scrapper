/*This Program is used to scrap info from ebay per particular product using HTML Agility Pack */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace EbayScraperonsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get HTMl Async send the request to server, and you get HTML of said url
            GetHtmlAsync();
            Console.ReadLine();
        }


        private static async void GetHtmlAsync()
        {
            string userValue;
            Console.WriteLine("What do you want to search? \n");
            userValue = Console.ReadLine();

            var url = "https://www.ebay.com/sch/i.html?_nkw="+userValue+"&_in_kw=1&_ex_kw=&_sacat=0&LH_Complete=1&_udlo=&_udhi=&_ftrt=901&_ftrv=1&_sabdlo=&_sabdhi=&_samilow=&_samihi=&_sadis=15&_stpos=02908&_sargn=-1%26saslc%3D1&_salic=1&_sop=12&_dmd=1&_ipg=50";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html.Result);

            //Create New HTML Document
            // Add new packeage 'HTMLAgilityPack'
            var htmlDoc = new HtmlDocument();

            //Now load the html into our html document inorder to parse it out
            htmlDoc.LoadHtml(html);

            // Go in the htmlDoc to the Descendant 'ul' where node of 
            //attribute id (if not return empty string "")is equal to ListViewInner
            var ProductHtml = htmlDoc.DocumentNode.Descendants("ul")
                                     .Where(node => node.GetAttributeValue("id", "")
                                            .Equals("ListViewInner")).ToList();

            var ProductListItem = ProductHtml[0].Descendants("li")
                                                .Where(node => node.GetAttributeValue("id", "")
                                                       .Contains("item")).ToList();


            foreach (var ProductsListItems in ProductListItem)
            {
                // Id
                Console.WriteLine(ProductsListItems.GetAttributeValue("listingid", ""));

                // Product Name
                Console.WriteLine(ProductsListItems.Descendants("h3")
                                  .Where(node => node.GetAttributeValue("class", "")
                                         .Equals("lvtitle")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')
                                 );

                // Product Price
                Console.WriteLine(
                    Regex.Match(
                        ProductsListItems.Descendants("li")
                                      .Where(node => node.GetAttributeValue("class", "")
                                             .Equals("lvprice prc")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')
                        ,@"\d+.\d+")        
                    );
            }
            Console.WriteLine(ProductHtml);

        }
    }
}
