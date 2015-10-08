using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JC.Common
{
    /// <summary>
    /// 分页排序助手类
    /// </summary>
    public static class DataPagingHelper
    {
        public static IQueryable<T> GetQueryable<T>(this IList<T> list, string sidx, string sord, int page, int rows)
        {
            return GetQueryable<T>(list.AsQueryable<T>(), sidx, sord, page, rows);
        }

        public static IQueryable<T> GetQueryable<T>(this IQueryable<T> queriable, string sidx, string sord, int page, int rows)
        {
            var data = ApplyOrder<T>(queriable, sidx, sord.ToLower() == "asc" ? true : false);

            return data.Skip<T>((page - 1) * rows).Take<T>(rows);
        }

        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> queriable, string property, bool isASC)
        {
            PropertyInfo pi = typeof(T).GetProperty(property);
            ParameterExpression arg = Expression.Parameter(typeof(T), "x");
            Expression expr = Expression.Property(arg, pi);

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), pi.PropertyType);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            string methodName = isASC ? "OrderBy" : "OrderByDescending";

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), pi.PropertyType)
                    .Invoke(null, new object[] { queriable, lambda });

            return (IOrderedQueryable<T>)result;
        }
    }

    /// <summary>
    /// jqGrid数据处理助手类
    /// </summary>
    public static class JqGridHelper
    {
        public static JsonResult GetJson<T>(this IList<T> datas, string sidx, string sord, int page, int rows, JsonRequestBehavior behavior, params string[] fields)
        {
            return GetJson<T>(datas.AsQueryable<T>(), sidx, sord, page, rows, behavior, fields);
        }

        public static JsonResult GetJson<T>(this IQueryable<T> queriable, string sidx, string sord, int page, int rows, JsonRequestBehavior behavior, params string[] fields)
        {
            var data = queriable.GetQueryable<T>(sidx, sord, page, rows);

            var json = new JsonResult();
            json.JsonRequestBehavior = behavior;

            if (rows != 0)
            {
                var totalpages = (decimal)queriable.Count<T>() / (decimal)rows;
                totalpages = (totalpages == (int)totalpages) ? totalpages : (int)totalpages + 1;

                var rowsData = GetJsonData<T>(data, fields);

                json.Data = new
                {
                    page,
                    records = rows,
                    total = (int)totalpages,
                    rows = rowsData
                };
            }

            return json;
        }

        private static object[] GetJsonData<T>(IQueryable<T> queriable, params string[] fields)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            T[] datas = queriable.ToArray<T>();

            object[] result = new object[datas.Length];

            if (fields.Length == 0)
            {
                fields = Array.ConvertAll<PropertyInfo, string>(properties.Where<PropertyInfo>
                    (x => x.GetCustomAttributes(typeof(InternalAttribute), false).Length == 0)
                    .ToArray<PropertyInfo>()
                    , delegate(PropertyInfo p)
                    {
                        return p.Name;
                    });
            }

            for (int i = 0; i < datas.Length; i++)
            {
                object[] values = new object[fields.Length];
                for (int j = 0; j < fields.Length; j++)
                {
                    var pi = properties.First<PropertyInfo>(x => x.Name == fields[j]);
                    var value = pi.GetValue(datas[i], null);
                    values[j] = value != null ? value.ToString() : "";
                }

                result[i] = new { id = i, cell = values };
            }

            return result;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class InternalAttribute : Attribute { }
}
