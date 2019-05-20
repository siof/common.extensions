using System;
using System.Linq.Expressions;

namespace siof.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName(this Expression<Func<object>> extension)
        {
            var memberExpression = extension.Body is UnaryExpression unaryExpression ?
                (MemberExpression)unaryExpression.Operand :
                (MemberExpression)extension.Body;

            return memberExpression.Member.Name;
        }
    }
}
