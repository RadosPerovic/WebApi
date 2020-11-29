using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaskManager.Domain.Persistance.Context;

namespace WebApiTaskManager.Domain.Persistance.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _dataBaseContext;

        public BaseRepository(AppDbContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
    }
}
