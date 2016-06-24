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

        public int GetRecentSeason()
        {
            int max = db.Seasons.Max(s => s.SeasonID);
            return max;
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

        //public SelectList GetSeasons(int? seasonId)
        //{
        //    var seasonList = db.Seasons.OrderByDescending(s => s.SeasonID).ToList()
        //        .Select(s => new
        //        {
        //            SeasonID = s.SeasonID,
        //            Desc = "Season " + s.SeasonID
        //        });
        //    return new SelectList(seasonList, "SeasonID", "Desc", seasonId);
        //}
    }
}