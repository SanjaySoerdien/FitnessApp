using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;
using FitnessWebAppModels;

namespace FitnessWebAppDAL.MemoryContexts
{
    public class CommentMemoryContext : ICommentContext
    {
        private List<Comment> Comments;
        private List<Comment> Comments2;

        public CommentMemoryContext()
        {
            Comments2 = new List<Comment>
            {
                new Comment
                {
                    ID = 21,
                    ForeignID = 211,
                    Kudos = 23,
                    Nickname = "2Johnny",
                    Text = "2wow"


                },
                new Comment
                {
                    ID = 22,
                    ForeignID = 212,
                    Kudos = 212,
                    Nickname = "2Henk",
                    Text = "2Mooie ding"
                },
                new Comment
                {
                    ID = 23,
                    ForeignID = 213,
                    Kudos = 244,
                    Nickname = "2Anna",
                    Text = "2goed hoor"
                },
                new Comment
                {
                    ID = 24,
                    ForeignID = 214,
                    Kudos = 250,
                    Nickname = "2Bart",
                    Text = "2netjes"
                }
            };

            Comments = new List<Comment>
            {
                new Comment
                {
                    ID = 1,
                    ForeignID = 11,
                    Kudos = 3,
                    Nickname = "Johnny",
                    Text = "wow"


                },
                new Comment
                {
                    ID = 2,
                    ForeignID = 12,
                    Kudos = 12,
                    Nickname = "Henk",
                    Text = "Mooie ding"
                },
                new Comment
                {
                    ID = 3,
                    ForeignID = 13,
                    Kudos = 44,
                    Nickname = "Anna",
                    Text = "goed hoor"
                },
                new Comment
                {
                    ID = 4,
                    ForeignID = 14,
                    Kudos = 50,
                    Nickname = "Bart",
                    Text = "netjes"
                }
            };
        }
        public List<Comment> GetCommentsByWorkoutplan(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentsByExercise(int id)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToWorkout(Comment commentToAdd)
        {
            throw new NotImplementedException();
        }

        public void AddCommentToExercise(Comment commentToAdd)
        {
            throw new NotImplementedException();
        }

        public string AddKudoToComment(int commentId, string nickname)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(int commentId)
        {
            throw new NotImplementedException();
        }
    }
}
