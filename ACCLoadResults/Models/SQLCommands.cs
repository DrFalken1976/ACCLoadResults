using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCLoadResults.Models
{
    public class SQLCommands
    {

        public const string  InsertSessions = "INSERT INTO Sessions ( [sessionType], [trackName], [LogFileName], [BestLap], [BestSector1], [BestSector2], [BestSector3], [IsWet]) Select '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}";

    }
}
