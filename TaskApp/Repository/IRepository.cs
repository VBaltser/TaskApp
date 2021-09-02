using System.Collections.Generic;
using TaskApp.Entities;

namespace TaskApp.Repository
{
    public interface IRepository
    {
        IEnumerable<App> Apps { get; }

        IEnumerable<Correction> Corrections { get; }

        Correction DeleteCorrection(int id);

        void SaveCorrection(Correction correction);
    }
}
