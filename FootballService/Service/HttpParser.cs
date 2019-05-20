using System;
using System.Collections.Generic;
using System.Linq;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace FootballService.Service
{
    public class HttpParser
    {
        public List<TeamResults> GetTable(string data)
        {
            var teamResultses = new List<TeamResults>();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(data);

            var node = htmlDocument.DocumentNode.SelectSingleNode("//table[@class='positions']");
            var rows = node.SelectNodes("tr");
            var correctedRows = rows.Skip(1);
            foreach (var elem in correctedRows)
            {
                var innerNodes = elem.SelectNodes("th|td").ToList();
                if (innerNodes.Count > 0)
                {
                    var result = new TeamResults
                    {
                        Position = Convert.ToInt32(innerNodes[0].SelectSingleNode("strong").InnerHtml),
                        Name = innerNodes[1].SelectSingleNode("a").InnerHtml,
                        Score = innerNodes[2].InnerHtml + "-" + innerNodes[3].InnerHtml
                    };
                    teamResultses.Add(result);
                }
            }

            return teamResultses;
        }
    }
}