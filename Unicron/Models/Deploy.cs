using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicron.DtoModels;

namespace Unicron.Models
{
    public class Deploy
    {
        public string Branch;
        public DeployState State;
        public string CommitHash;

        public static Deploy FromDto(DeployDto deployDto)
        {
            return new Deploy
            {
                Branch = deployDto.Branch,
                CommitHash = deployDto.CommitHash,
                State = deployDto.State
            };
            
        }

        public DeployDto ToDto()
        {
            return new DeployDto
            {
                Branch = Branch,
                CommitHash = CommitHash,
                State = State
            };
        }
    }
}
