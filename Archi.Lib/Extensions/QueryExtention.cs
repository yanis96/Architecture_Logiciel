using Archi.Lib.Context;
using Archi.Lib.Models.Params;
using Archi.Lib.Models.Partial;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;

namespace Archi.Lib.Extensions
{
    public static class QueryExtention
    {

        public static IQueryable<TModel> Sort<TModel>(this IQueryable<TModel> query, Params param)
        {
            var parameter = Expression.Parameter(typeof(TModel), "x");

            if (param.HasAscOrder())
            {
                string champ = param.Asc;
                var property = Expression.Property(parameter, champ);
                var o = Expression.Convert(property, typeof(object));
                var lambda = Expression.Lambda<Func<TModel, object>>(o, parameter);
                return query.OrderBy(lambda);
            }
            else if (param.HasDescOrder())
            {
                string champ = param.Desc;
                var property = Expression.Property(parameter, champ);
                var o = Expression.Convert(property, typeof(object));
                var lambda = Expression.Lambda<Func<TModel, object>>(o, parameter);
                return query.OrderByDescending(lambda);
            }
            else
                return query;
        }



        public static Expression<Func<TModel,bool>> SearchExpression<TModel>(IQueryCollection test)
        {
            BinaryExpression bin = null;

            var parameter = Expression.Parameter(typeof(TModel), "x");

            foreach (var champ in test)
            {
                var property = Expression.Property(parameter, champ.Key);
                var o = Expression.Equal(property, Expression.Convert(Expression.Constant(champ.Value), typeof(string)));

                if (bin == null)
                    bin = o;
                else
                    bin = Expression.And(bin, o);
            }
            if (bin == null)
                return null;
            var lambda = Expression.Lambda<Func<TModel, bool>>(bin, parameter);

            return lambda;
        }


        public static Expression<Func<TModel, bool>> FilterReserch<TModel>(IQueryCollection test)
        {
            BinaryExpression bin = null;

            var parameter = Expression.Parameter(typeof(TModel), "x");

            foreach (var champ in test)
            {
                if (typeof(TModel).GetProperty(champ.Key, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase) != null)
                {
                    var property = Expression.Property(parameter, champ.Key);
                    var o = Expression.Equal(property, Expression.Convert(Expression.Constant(champ.Value), typeof(string)));

                    if (bin == null)
                        bin = o;
                    else
                        bin = Expression.And(bin, o);
                }
            }

            var lambda = Expression.Lambda<Func<TModel, bool>>(bin, parameter);
            return lambda;
        }

        public static Expression<Func<TModel, dynamic>> PartialReserch<TModel>(Partial champs)
        {
            if (champs.HasFieals())
            {
                var source = Expression.Parameter(typeof(TModel), "o");
                var fields = champs.Fields.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var properties = fields
                        .Select(f => typeof(TModel).GetProperty(f, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase))
                        .Select(p => new DynamicProperty(p.Name, p.PropertyType))
                        .ToList();

                var resultType = DynamicClassFactory.CreateType(properties, false);
                var bindings = properties.Select(p => Expression.Bind(resultType.GetProperty(p.Name), Expression.Property(source, p.Name)));
                var result = Expression.MemberInit(Expression.New(resultType), bindings);
                var lambda = Expression.Lambda<Func<TModel, dynamic>>(result, source);
                return lambda;
            }
            return null;
        }

    }
}
