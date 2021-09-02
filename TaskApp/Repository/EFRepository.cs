using TaskApp.Entities;
using System.Collections.Generic;
using System.Web;

namespace TaskApp.Repository
{
    public class EFRepository : IRepository
    {
    
        EFDbContext context;

        public EFRepository()
        {
            string mdfFilePath = HttpContext.Current.Server.MapPath("~//App_Data//DB.mdf");
            context = new EFDbContext(string.Format(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename={0};", mdfFilePath));
        }

        public IEnumerable<App> Apps
        {
            get { return context.Apps; }
        }

        public IEnumerable<Correction> Corrections

        {
            get { return context.Corrections; }
        }

        public Correction DeleteCorrection(int id)
        {
            Correction dbEntry = context.Corrections.Find(id);
            if (dbEntry != null)
            {
                context.Corrections.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveCorrection(Correction correction)
        {
            if (correction.id == 0)
                context.Corrections.Add(correction);
            else
            {
                Correction dbEntry = context.Corrections.Find(correction.id);
                if (dbEntry != null)
                {
                    dbEntry.Name = correction.Name;
                    dbEntry.Description = correction.Description;
                    dbEntry.Date = correction.Date;
                    dbEntry.AppID = correction.AppID;
                    dbEntry.Email = correction.Email;
                }
            }
            context.SaveChanges();
        }
    }
}