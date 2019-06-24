using System;
using System.Collections.Generic;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppMemContexts
{
    public class AdminMemoryContext : IAdminContext
    {
        List<Change> changes = new List<Change>();

        public AdminMemoryContext()
        {
            changes.Add(new Change
            {
                changeText = "Added mock data",
                time = new DateTime(2000, 1, 1, 12, 3, 1)
            });
            changes.Add(new Change
            {
                changeText = "Added mock data",
                time = new DateTime(2000, 4, 12, 4, 2, 1)
            });
            changes.Add(new Change
            {
                changeText = "Added mock data",
                time = new DateTime(2011, 1, 1, 12, 1, 32)
            });
            changes.Add(new Change
            {
                changeText = "Added mock data",
                time = new DateTime(2012, 4, 4, 6, 1, 4)
            });

        }
        public int AddCategory(string category)
        {
            throw new NotImplementedException();
        }

        public int ChangeCategory(string categoryNew, string categoryOld)
        {
            throw new NotImplementedException();
        }

        public int DeleteCategory(string category)
        {
            throw new NotImplementedException();
        }

        public void AddExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public void DeleteExercise(int id)
        {
            throw new NotImplementedException();
        }

        public List<Change> GetRecentChanges()
        {
            var result = new List<Change>();
            result.Add(changes[0]);
            result.Add(changes[1]);
            return result;
        }

        public List<Change> GetMoreChanges()
        {
            return changes;
        }
    }
}
