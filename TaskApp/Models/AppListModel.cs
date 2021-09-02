using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Entities;

namespace TaskApp.Models
{
    public class AppListModel
    {
        public IEnumerable<App> Apps { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}