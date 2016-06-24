using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public class PlayerRepository : IPlayerRepository
    {
        private bballtest2Entities db = new bballtest2Entities();

        public IEnumerable<Player> GetPlayers()
        {
            return db.Players.Include(p => p.Position).ToList();
        }

        public Player GetPlayerByID(int? playerId)
        {
            return db.Players.Find(playerId);
        }

        public void InsertPlayer(Player p)
        {
            db.Players.Add(p);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void UpdatePlayer(Player p)
        {
            db.Entry(p).State = EntityState.Modified;
        }

        public void DeletePlayer(int? playerId)
        {
            var player = db.Players.Find(playerId);
            db.Players.Remove(player);
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

        public SelectList GetPositions()
        {
            return new SelectList(db.Positions, "PositionID", "PositionName");
        }

        public SelectList GetPlayerPosition(int? positionId)
        {
            return new SelectList(db.Positions, "PositionID", "PositionName", positionId);
        }
    }
}