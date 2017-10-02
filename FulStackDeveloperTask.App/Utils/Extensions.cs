using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace FulStackDeveloperTask.App.Utils
{
    public static class Extensions
    {
        public static IQueryable<T> OrderByField<T>(this IQueryable<T> q, string SortField, string SortDirection)
        {
            var param = Expression.Parameter(typeof(T), "p");
            Expression prop = null;
            if (SortField.Contains("."))
            {
                bool inNestedProperty = false;

                List<string> properties = SortField.Split('.').ToList();
                foreach (string property in properties)
                {

                    if (!inNestedProperty)
                    {
                        prop = Expression.Property(param, property);
                        inNestedProperty = true;
                    }
                    else
                        prop = Expression.Property(prop, property);
                }
            }
            else prop = Expression.Property(param, SortField);

            var exp = Expression.Lambda(prop, param);

            string method = "";

            if (SortDirection == "asc")
                method = "OrderBy";
            else
                method = "OrderByDescending";

            Type[] types = new Type[] { q.ElementType, exp.Body.Type };

            var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);

            return q.Provider.CreateQuery<T>(mce);

        }

        public static byte[] ToByteArray(this Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}