using ApiProject.Contracts.Models;
using ApiProject.Contracts.Requests;
using ApiProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Services
{
    public interface IBattleshipService
    {
        Battleship CreateBattleship(Battleship battleship);

        BattleshipGrid CreateGrid(BattleshipGrid request);

        BattleshipGrid GetGridById(Guid boardId);

        AttackStatus LaunchAttack(LaunchAttack attack);
    }
}
