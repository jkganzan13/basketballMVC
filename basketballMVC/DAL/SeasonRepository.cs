using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public class SeasonRepository : ISeasonRepository
    {
        private bballtest2Entities db = new bballtest2Entities();

        public int GetRecentSeasonID()
        {
            int recent = db.Seasons.Max(s => s.SeasonID);
            return recent;
        }

        public int GetNextSeasonID()
        {
            int next = GetRecentSeasonID() + 1;
            return next;
        }

        public Season GetSeasonByID(int? seasonId)
        {
            return db.Seasons.Find(seasonId);
        }

        public IEnumerable<dynamic> GetSeasons()
        {
            var seasonList = db.Seasons.OrderByDescending(s => s.SeasonID).ToList()
                .Select(s => new
                {
                    SeasonID = s.SeasonID,
                    Desc = "Season " + s.SeasonID
                });
            return seasonList;
        }

        public void InsertSeason(Season s)
        {
            s.SeasonID = GetNextSeasonID();
            db.Seasons.Add(s);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}