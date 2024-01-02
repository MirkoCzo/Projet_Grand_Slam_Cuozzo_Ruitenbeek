using System;
using System.Configuration;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek.DAO
{
    internal abstract class DAO<T>
    {
        protected string connectionString = null;
        public DAO()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
        }
        public abstract int Create(T obj);
        public abstract bool Delete(T obj);
        public abstract bool Update(T obj);
        public abstract T Find(int id);
        public abstract List<T> FindAll();


    }
}
