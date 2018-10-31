using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dystopia_sharp.Commands
{
    public interface ICommandProvider
    {
        IEnumerable<CmdType> GetCommands();
    }
}
