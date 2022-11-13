using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AdsPublisher.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
