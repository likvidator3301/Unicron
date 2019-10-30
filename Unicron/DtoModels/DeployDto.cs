using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicron.Models;

namespace Unicron.DtoModels
{
    public class DeployDto
    {
        public string Branch;
        public DeployState State;
        public string CommitHash;
    }
}
