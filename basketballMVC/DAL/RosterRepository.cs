﻿using System;
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

        public IEnumerable<SeasonTeam> GetTeamsBySeason(int? seasonId)
        {
            var seasonTeamList = db.SeasonTeams.Include(st => st.Team)
                .Where(st => st.SeasonID == seasonId)
                .OrderBy(st => st.Team.TeamName);

            return seasonTeamList.ToList();
        }

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

        public IEnumerable<Roster> GetPlayersBySeasonTeam(int? seasonTeamId)
        {
            var rosterList = db.Rosters.Include(r => r.Player).Include(r => r.SeasonTeam)
                .Where(r => r.SeasonTeamID == seasonTeamId)
                .OrderBy(r => r.Player.LastName);

            return rosterList.ToList();
        }
    }
}