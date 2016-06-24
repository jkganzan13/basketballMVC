using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace basketballMVC.DAL
{
    public interface ISeasonRepository
    {
        int GetRecentSeason();
        IEnumerable<dynamic> GetSeasons();
        Season GetSeasonByID(int? seasonId);
    }
}
