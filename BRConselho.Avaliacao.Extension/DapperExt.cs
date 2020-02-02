using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using ColumnAttribute = System.ComponentModel.DataAnnotations.Schema.ColumnAttribute;
using NotMappedAttribute = System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute;
using TableAttribute = System.ComponentModel.DataAnnotations.Schema.TableAttribute;

namespace BRConselho.Avaliacao.Extension
{
    public static class DapperExt
    {
        public static int? InsertIgnoreKey<TEntity>(this IDbConnection connection, TEntity entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            return InsertIgnoreKey<int?, TEntity>(connection, entityToInsert, transaction, commandTimeout);
        }

        public static TKey InsertIgnoreKey<TKey, TEntity>(this IDbConnection connection, TEntity entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            Type typeEntity = typeof(TEntity);
            IDictionary<string, string> columnParamNames = new Dictionary<string, string>();

            var tableName = typeEntity.GetCustomAttribute<TableAttribute>()?.Name ?? typeEntity.Name;

            TKey key = default;
            foreach (PropertyInfo item in typeEntity.GetProperties())
            {
                if (item.GetCustomAttribute<KeyAttribute>() != null
                    && item.GetValue(entityToInsert) != null)
                {
                    key = (TKey)item.GetValue(entityToInsert);
                }

                if (item.GetCustomAttribute<NotMappedAttribute>() == null
                    && item.GetCustomAttribute<ForeignKeyAttribute>() == null
                    && item.GetValue(entityToInsert) != null)
                {
                    ColumnAttribute columnAttribute = item.GetCustomAttribute<ColumnAttribute>();
                    var columnName = columnAttribute?.Name ?? item.Name;
                    columnParamNames.Add(columnName, item.Name);
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("insert into {0}", tableName);
            sb.AppendFormat(" ({0}) ", string.Join(", ", columnParamNames.Keys));
            sb.AppendFormat("values (@{0}) ", string.Join(", @", columnParamNames.Values));

            if (0 == connection.Execute(sb.ToString(), entityToInsert, commandType: CommandType.Text))
            {
                throw new InvalidOperationException("Não foi possível salvar o registro");
            }

            return key;
        }
    }
}
