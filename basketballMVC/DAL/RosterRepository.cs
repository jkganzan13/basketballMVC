using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public class RosterRepository : IRosterRepository
    {
        private bballtest2Entities db = new bballtest2Entities();

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //Get all players in a specific team
        public IEnumerable<Roster> GetPlayersBySeasonTeam(int? seasonTeamId)
        {
            var rosterList = db.Rosters.Include(r => r.Player).Include(r => r.SeasonTeam)
                .Where(r => r.SeasonTeamID == seasonTeamId)
                .OrderBy(r => r.Player.LastName);

            return rosterList.ToList();
        }
        //Get all players playing in a specific season
        public IEnumerable<Roster> GetPlayersBySeason(int? seasonId)
        {
            var rosterList = db.Rosters.Where(r => r.SeasonTeam.SeasonID == seasonId);

            return rosterList.ToList();
        }
    }
}