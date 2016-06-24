using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public interface ITeamRepository : IDisposable
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamByID(int? teamId);
        void InsertTeam(Team t);
        void UpdateTeam(Team t);
        void DeleteTeam(int? id);
        void Save();
    }
}