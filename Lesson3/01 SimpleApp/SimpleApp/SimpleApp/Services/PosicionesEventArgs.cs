using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.Services
{
    public class PosicionesEventArgs
    {
        public IEnumerable<Equipo> Results { get; private set; }

        public PosicionesEventArgs(IEnumerable<Equipo> results)
        {
            this.Results = results;
        }
    }
}
