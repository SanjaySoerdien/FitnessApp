using System;
using System.Collections.Generic;
using System.Text;
using FitnessWebAppInterfaces;

namespace FitnessWebAppDAL
{
    public class CommentDAL : ICommentContext
    {
        private readonly string connectionstring =
            "Server=mssql.fhict.local;Database=dbi413271_iller;User Id=dbi413271_iller;Password=sjorsbaktniet;";
    }
}
