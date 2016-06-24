using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basketballMVC.DAL
{
    public interface ISeasonTeamRepository
    {
        IEnumerable<SeasonTeam> GetTeamsBySeason(int? seasonId);
    }
}
