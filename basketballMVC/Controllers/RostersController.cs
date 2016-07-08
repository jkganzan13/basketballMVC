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
        private ISeasonTeamRepository seasonTeamRepository = new SeasonTeamRepository();

        // GET: Rosters
        public ActionResult Index()
        {
            int recentSeasonId = seasonRepository.GetRecentSeasonID();
            ViewBag.SeasonId = recentSeasonId;

            var seasonList = seasonRepository.GetSeasons();
            ViewBag.SeasonDD = new SelectList(seasonList, "SeasonID", "Desc");

            var seasonTeam = seasonTeamRepository.GetTeamsBySeason(recentSeasonId);
            return View(seasonTeam);
        }

        [HttpPost]
        public ActionResult Index(int? seasonId)
        {
            ViewBag.SeasonId = seasonId;
            var seasonList = seasonRepository.GetSeasons();
            ViewBag.SeasonDD = new SelectList(seasonList, "SeasonID", "Desc", seasonId); 

            var seasonTeam = seasonTeamRepository.GetTeamsBySeason(seasonId);
            return View(seasonTeam);
        }

        public ActionResult RosterList(int? id)
        {
            var rosterList = rosterRepository.GetPlayersBySeasonTeam(id);
            return PartialView(rosterList);
        }

        public ActionResult CreateSeason(int? id)
        {
            ViewBag.SeasonID = seasonRepository.GetNextSeasonID().ToString();
            var teams = teamRepository.GetTeams();
            ViewBag.Teams = new SelectList(teams, "TeamID", "TeamName");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSeason([Bind(Include = "SeasonStart,SeasonEnd")] Season season, int[] teams)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    seasonRepository.InsertSeason(season);
                    seasonRepository.Save();

                    //Check # of teams selected
                    if (teams == null)
                    {
                        TempData["Error"] = "No Team(s) Selected. Please select teams for the new season.";
                        return PartialView();
                    } else if (teams.Length < 4){
                        TempData["Error"] = "Minimum is 4 or more Teams to start a new season.";
                        return PartialView();
                    }

                    //Insert teams to SeasonTeams                    
                    int nextSeasonID = seasonRepository.GetRecentSeasonID();
                    TempData["Success"] = string.Format("Season {0} has been added with the following participating teams:\n<ul>", nextSeasonID);
                    foreach (int teamID in teams)
                    {
                        seasonTeamRepository.InsertSeasonTeam(nextSeasonID, teamID);
                        var team = teamRepository.GetTeamByID(teamID);
                        TempData["Success"] += string.Format("<li>{0}</li>", team.TeamName);
                    }
                    seasonTeamRepository.Save();

                    TempData["Success"] += "</ul>";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Error"] = "Unable to create new season. If the problem persists, contact me.";
            }
            return RedirectToAction("Index");            
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