using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public class SeasonTeamRepository : ISeasonTeamRepository
    {
        private bballtest2Entities db = new bballtest2Entities();

        public IEnumerable<SeasonTeam> GetTeamsBySeason(int? seasonId)
        {
            var seasonTeamList = db.SeasonTeams.Include(st => st.Team)
                .Where(st => st.SeasonID == seasonId)
                .OrderBy(st => st.Team.TeamName);

            return seasonTeamList.ToList();
        }

        public void InsertSeasonTeam(int seasonID, int teamID)
        {
            SeasonTeam st = new SeasonTeam();
            st.SeasonID = seasonID;
            st.TeamID = teamID;

            db.SeasonTeams.Add(st);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}