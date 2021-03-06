﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basketballMVC.DAL
{
    public interface IRosterRepository : IDisposable, ISeasonTeamRepository
    {
        IEnumerable<Roster> GetPlayersBySeasonTeam(int? seasonTeamId);
    }
}
