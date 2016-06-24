using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using basketballMVC;
using basketballMVC.DAL;

namespace basketballMVC.Controllers
{
    public class TeamsController : Controller
    {
        private ITeamRepository teamRepository = new TeamRepository();

        // GET: Teams
        public ActionResult Index()
        {
            try
            {
                var teams = teamRepository.GetTeams();
                return View(teams);
            } catch (Exception)
            {
                TempData["Error"] = "Unable to create team. If the problem persists, contact me.";
            }
            return View();
        }

        // GET: Teams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = teamRepository.GetTeamByID(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return PartialView(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeamID,TeamName,TeamDesc")] Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    teamRepository.InsertTeam(team);
                    teamRepository.Save();
                    TempData["Success"] = string.Format("{0} has been added to the database", team.TeamName);
                    return RedirectToAction("Index");
                }
            } catch (DataException /*dex*/)
            {
                //ModelState.AddModelError(string.Empty, "Unable to create team. If the problem persists, contact me.");
                TempData["Error"] = "Unable to create team. If the problem persists, contact me.";
            }
            return PartialView(team);
        }

        // GET: Teams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = teamRepository.GetTeamByID(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return PartialView(team);
        }

        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeamID,TeamName,TeamDesc")] Team team)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    teamRepository.UpdateTeam(team);
                    teamRepository.Save();
                    TempData["Success"] = string.Format("{0} has been updated", team.TeamName);
                    return RedirectToAction("Index");
                }
            } catch
            {
                TempData["Error"] = "Unable to update team. If the problem persists, contact me.";
            }
            return PartialView(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                Team team = teamRepository.GetTeamByID(id);
                teamRepository.DeleteTeam(id);
                teamRepository.Save();
                TempData["Success"] = string.Format("{0} has been deleted", team.TeamName);
            } catch (DataException)
            {
                TempData["Error"] = "Unable to delete team. If the problem persists, contact me.";
            }
            
            //return View(team);
            return RedirectToAction("Index");
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                teamRepository.DeleteTeam(id);
                teamRepository.Save();
                TempData["Success"] = "HTTPpost delete try";
            } catch (DataException /*dex*/)
            {
                TempData["Error"] = "Httppost delete error";
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            teamRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
