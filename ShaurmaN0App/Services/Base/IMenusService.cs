using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShaurmaN0App.Repositories.Base;

namespace ShaurmaN0App.Services.Base
{
    public interface IMenusService : IMenusRepository
    {
        Task<bool> NameIsTaken(string name);
        
    }
}