using System.Linq;
using System.Web.Mvc;
using TaskApp.Models;
using TaskApp.Repository;

namespace TaskApp.Controllers
{
    public class AppController : Controller
    {
        private IRepository repository;
        private int pageSize = 10;

        public AppController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            AppListModel model = new AppListModel
            {
                Apps = repository.Apps
                    .OrderBy(app => app.AppId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Apps.Count()
                }
            };
            return View(model);
        }
    }
}