using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public interface IPlayerRepository : IDisposable
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayerByID(int? playerId);
        SelectList GetPositions();
        SelectList GetPlayerPosition(int? positionId);
        void InsertPlayer(Player p);
        void UpdatePlayer(Player p);
        void DeletePlayer(int? playerId);
        void Save();
    }
}