using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicron.DtoModels;

namespace Unicron.Models
{
    public class Environment
    {
        public string Name;
        public Uri RemoteUrl;
        public Guid Id;
        public Deploy Deploy;

        public static Environment FromDto(EnvironmentDto environmentDto)
        {
            return new Environment
            {
                Name = environmentDto.Name,
                RemoteUrl = new Uri(environmentDto.RemoteUrl),
                Id = environmentDto.Id,
                Deploy = Models.Deploy.FromDto(environmentDto.Deploy)
            };
        }

        public EnvironmentDto ToDto()
        {
            return new EnvironmentDto
            {
                Deploy = Deploy.ToDto(),
                Id = Id,
                Name = Name,
                RemoteUrl = RemoteUrl.ToString()
            };
        }
    }
}
