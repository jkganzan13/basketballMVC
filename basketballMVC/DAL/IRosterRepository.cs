using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basketballMVC.DAL
{
    public interface IRosterRepository : IDisposable
    {
        IEnumerable<Roster> GetPlayersBySeasonTeam(int? seasonTeamId);
        IEnumerable<Roster> GetPlayersBySeason(int? seasonId)
    }
}
