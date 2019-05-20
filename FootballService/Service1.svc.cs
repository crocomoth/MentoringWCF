using System.Collections.Generic;
using FootballService.Service;

namespace FootballService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TeamService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TeamService.svc or TeamService.svc.cs at the Solution Explorer and start debugging.
    public class TeamService : ITeamService
    {
        private const string SitePath = "http://fapl.ru/";
        private readonly HttpLoader httpLoader;
        private readonly HttpParser httpParser;

        public TeamService()
        {
            httpLoader = new HttpLoader();
            httpParser = new HttpParser();
        }

        public string GetData(int value)
        {
            string siteData = httpLoader.LoadContent(SitePath);
            List<TeamResults> list = httpParser.GetTable(siteData);
            var team = list.Find(x => x.Position == value);
            if (team == null)
            {
                return "error";
            }

            return team.Name + " " + team.Position + " " + team.Score;
        }

        public string GetTeamResults(string teamName)
        {
            string siteData = httpLoader.LoadContent(SitePath);
            List<TeamResults> list = httpParser.GetTable(siteData);
            var result = list.Find(x => x.Name == teamName);
            return result.Name + " " + result.Position + " " + result.Score;
        }
    }
}
