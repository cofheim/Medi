using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Medi.Core.Abstractions
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
        Expression<Func<TSource, TDestination>> GetMapExpression<TSource, TDestination>();
    }
}
