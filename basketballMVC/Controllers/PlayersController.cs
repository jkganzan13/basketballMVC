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
    public class PlayersController : Controller
    {
        private IPlayerRepository playerRepository = new PlayerRepository();

        // GET: Players
        public ActionResult Index()
        {
            var players = playerRepository.GetPlayers();
            return View(players);
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = playerRepository.GetPlayerByID(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return PartialView(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.PositionID = playerRepository.GetPositions();
            return PartialView();
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerID,LastName,FirstName,PositionID,Height,BirthDate")] Player player)
        {
            try { 
                if (ModelState.IsValid)
                {
                    playerRepository.InsertPlayer(player);
                    playerRepository.Save();
                    TempData["Success"] = string.Format("{0} {1} has been added to the database", player.FirstName, player.LastName);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Write log here
                TempData["Error"] = "Unable to create player. If the problem persists, contact me.";
            }

            ViewBag.PositionID = playerRepository.GetPlayerPosition(player.PositionID);
            return PartialView(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = playerRepository.GetPlayerByID(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionID = playerRepository.GetPlayerPosition(player.PositionID);
            return PartialView(player);
        }

        // POST: Players/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerID,LastName,FirstName,PositionID,Height,BirthDate")] Player player)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    playerRepository.UpdatePlayer(player);
                    playerRepository.Save();
                    TempData["Success"] = string.Format("{0} {1}'s details have been updated", player.FirstName, player.LastName);
                    return RedirectToAction("Index");
                }
            } catch (DataException)
            {
                TempData["Error"] = "Unable to update player. If the problem persists, contact me.";
            }
            ViewBag.PositionID = playerRepository.GetPlayerPosition(player.PositionID);
            return PartialView(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                Player player = playerRepository.GetPlayerByID(id);
                playerRepository.DeletePlayer(id);
                playerRepository.Save();
                TempData["Success"] = string.Format("{0} {1}'s details have been updated", player.FirstName, player.LastName);
            }
            catch (DataException dex)
            {
                //Write log here 
                //ModelState.AddModelError(string.Empty, "Unable to delete player. If the problem persists, contact me.");
                TempData["Error"] = "Unable to delete player. If the problem persists, contact me.";
            }
            return RedirectToAction("Index");
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                playerRepository.DeletePlayer(id);
                playerRepository.Save();
            } catch (DataException /*dex*/)
            {                
                TempData["Error"] = "Unable to delete player. If the problem persists, contact me.";
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            playerRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
