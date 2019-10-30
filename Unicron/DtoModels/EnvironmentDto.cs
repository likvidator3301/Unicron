using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicron.Models;

namespace Unicron.DtoModels
{
    public sealed class EnvironmentDto
    {
        public string Name;
        public string RemoteUrl;
        public Guid Id;
        public DeployDto Deploy;
    }
}
