using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public class TeamRepository : ITeamRepository
    {
        private bballtest2Entities db = new bballtest2Entities();
        
        public IEnumerable<Team> GetTeams()
        {
            return db.Teams.ToList();
        }

        public Team GetTeamByID(int? teamId)
        {
            return db.Teams.Find(teamId);
        }

        public void InsertTeam(Team t)
        {
            db.Teams.Add(t);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdateTeam(Team t)
        {
            db.Entry(t).State = EntityState.Modified;
        }

        public void DeleteTeam(int? id)
        {
            var team = db.Teams.Find(id);
            db.Teams.Remove(team);
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
    }
}