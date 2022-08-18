using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SingletonDBContext
{
    private static DBContext _dbcontext;

    public static DBContext dbContext { get { return getcontext(); } }
    public static void Init()
    {
        _dbcontext = new DBContext();
    }

    private static DBContext getcontext()
    {
        return new DBContext();
    }
}

