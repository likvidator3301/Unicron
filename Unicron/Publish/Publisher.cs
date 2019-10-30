using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicron.DtoModels;
using Environment = Unicron.Models.Environment;

namespace Unicron.Publish
{
    internal sealed class Publisher
    {
        public Publisher()
        {
            environments = new List<Environment>();
        }
        public void Add(Environment environment)
        {
            environments.Add(environment);
        }

        public void Add(EnvironmentDto environmentDto)
        {
            environments.Add(Environment.FromDto(environmentDto));
        }

        public Environment Get(Guid id)
        {
            return environments.FirstOrDefault(x => x.Id == id);
        }

        public EnvironmentDto GetDto(Guid id)
        {
            return environments.FirstOrDefault(x => x.Id == id)?.ToDto();
        }

        public IEnumerable<Environment> GetAll()
        {
            return environments;
        }

        public IEnumerable<EnvironmentDto> GetAllDto()
        {
            return environments.Select(x => x.ToDto());
        }

        private readonly List<Environment> environments;
    }
}
