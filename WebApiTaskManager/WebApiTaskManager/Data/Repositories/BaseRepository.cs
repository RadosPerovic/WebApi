using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTaskManager.Data.Context;

namespace WebApiTaskManager.Data.Repositories
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
