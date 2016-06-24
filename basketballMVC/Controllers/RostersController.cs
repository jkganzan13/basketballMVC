using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using basketballMVC.DAL;
using System.Net;

namespace basketballMVC.Controllers
{
    public class RostersController : Controller
    {
        private IRosterRepository rosterRepository = new RosterRepository();
        private ITeamRepository teamRepository = new TeamRepository();
        private ISeasonRepository seasonRepository = new SeasonRepository();

        // GET: Rosters
        public ActionResult Index()
        {
            int recentSeasonId = seasonRepository.GetRecentSeason();
            ViewBag.SeasonId = recentSeasonId;

            var seasonList = seasonRepository.GetSeasons();
            ViewBag.SeasonDD = new SelectList(seasonList, "SeasonID", "Desc");

            var seasonTeam = rosterRepository.GetTeamsBySeason(recentSeasonId);
            return View(seasonTeam);
        }

        [HttpPost]
        public ActionResult Index(int? seasonId)
        {
            ViewBag.SeasonId = seasonId;
            var seasonList = seasonRepository.GetSeasons();
            ViewBag.SeasonDD = new SelectList(seasonList, "SeasonID", "Desc", seasonId); 

            var seasonTeam = rosterRepository.GetTeamsBySeason(seasonId);
            return View(seasonTeam);
        }

        public ActionResult RosterList(int? id)
        {
            var rosterList = rosterRepository.GetPlayersBySeasonTeam(id);
            return PartialView(rosterList);
        }

        public ActionResult CreateSeason(int? id)
        {
            ViewBag.TeamList = teamRepository.GetTeams();
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSeason([Bind(Include = "SeasonStart,SeasonEnd")] Season season, int[] teams)
        {
            return PartialView();
        }

        public ActionResult SeasonDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Season season = seasonRepository.GetSeasonByID(id);
            if (season == null)
            {
                return HttpNotFound();
            }
            return PartialView(season);
        }
    }
}