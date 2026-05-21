using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.DataStore.EF.OMSModel
{
    public partial class OMSContext : DbContext
    {
        private ObjectContext objectContext = null;
        public ObjectContext ObjectContext
        {
            get
            {
                if (objectContext == null)
                    objectContext = ((IObjectContextAdapter)this).ObjectContext;
                return objectContext;
            }
        }
    }
    public class OMSBaseModel : DbContext
    {
        #region ExecuteFunction
        //
        // Summary:
        //     Executes a stored procedure or function that is defined in the data source and
        //     expressed in the conceptual model; discards any results returned from the function;
        //     and returns the number of rows affected by the execution.
        //
        // Parameters:
        //   functionName:
        //     The name of the stored procedure or function. The name can include the container
        //     name, such as <Container Name>.<Function Name>. When the default container name
        //     is known, only the function name is required.
        //
        //   parameters:
        //     An array of System.Data.Entity.Core.Objects.ObjectParameter objects. If output
        //     parameters are used, their values will not be available until the results have
        //     been read completely. This is due to the underlying behavior of DbDataReader,
        //     see http://go.microsoft.com/fwlink/?LinkID=398589 for more details.
        //
        // Returns:
        //     The number of rows affected.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     function is null or empty or function is not found.
        //
        //   T:System.InvalidOperationException:
        //     The entity reader does not support this function or there is a type mismatch
        //     on the reader and the function .
        public virtual int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            return 0;
        }
        //
        // Summary:
        //     Executes a stored procedure or function that is defined in the data source and
        //     mapped in the conceptual model, with the specified parameters. Returns a typed
        //     System.Data.Entity.Core.Objects.ObjectResult`1 .
        //
        // Parameters:
        //   functionName:
        //     The name of the stored procedure or function. The name can include the container
        //     name, such as <Container Name>.<Function Name>. When the default container name
        //     is known, only the function name is required.
        //
        //   parameters:
        //     An array of System.Data.Entity.Core.Objects.ObjectParameter objects. If output
        //     parameters are used, their values will not be available until the results have
        //     been read completely. This is due to the underlying behavior of DbDataReader,
        //     see http://go.microsoft.com/fwlink/?LinkID=398589 for more details.
        //
        // Type parameters:
        //   TElement:
        //     The entity type of the System.Data.Entity.Core.Objects.ObjectResult`1 returned
        //     when the function is executed against the data source. This type must implement
        //     System.Data.Entity.Core.Objects.DataClasses.IEntityWithChangeTracker .
        //
        // Returns:
        //     An System.Data.Entity.Core.Objects.ObjectResult`1 for the data that is returned
        //     by the stored procedure.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     function is null or empty or function is not found.
        //
        //   T:System.InvalidOperationException:
        //     The entity reader does not support this function or there is a type mismatch
        //     on the reader and the function .
        public ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters) where TElement : IEntity { return null; }
        //
        // Summary:
        //     Executes the given stored procedure or function that is defined in the data source
        //     and expressed in the conceptual model, with the specified parameters, and merge
        //     option. Returns a typed System.Data.Entity.Core.Objects.ObjectResult`1 .
        //
        // Parameters:
        //   functionName:
        //     The name of the stored procedure or function. The name can include the container
        //     name, such as <Container Name>.<Function Name>. When the default container name
        //     is known, only the function name is required.
        //
        //   mergeOption:
        //     The System.Data.Entity.Core.Objects.MergeOption to use when executing the query.
        //
        //   parameters:
        //     An array of System.Data.Entity.Core.Objects.ObjectParameter objects. If output
        //     parameters are used, their values will not be available until the results have
        //     been read completely. This is due to the underlying behavior of DbDataReader,
        //     see http://go.microsoft.com/fwlink/?LinkID=398589 for more details.
        //
        // Type parameters:
        //   TElement:
        //     The entity type of the System.Data.Entity.Core.Objects.ObjectResult`1 returned
        //     when the function is executed against the data source. This type must implement
        //     System.Data.Entity.Core.Objects.DataClasses.IEntityWithChangeTracker .
        //
        // Returns:
        //     An System.Data.Entity.Core.Objects.ObjectResult`1 for the data that is returned
        //     by the stored procedure.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     function is null or empty or function is not found.
        //
        //   T:System.InvalidOperationException:
        //     The entity reader does not support this function or there is a type mismatch
        //     on the reader and the function .
        public virtual ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, MergeOption mergeOption, params ObjectParameter[] parameters) { return null; }
        //
        // Summary:
        //     Executes the given function on the default container.
        //
        // Parameters:
        //   functionName:
        //     Name of function. May include container (e.g. ContainerName.FunctionName) or
        //     just function name when DefaultContainerName is known.
        //
        //   executionOptions:
        //     The options for executing this function.
        //
        //   parameters:
        //     The parameter values to use for the function. If output parameters are used,
        //     their values will not be available until the results have been read completely.
        //     This is due to the underlying behavior of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589
        //     for more details.
        //
        // Type parameters:
        //   TElement:
        //     Element type for function results.
        //
        // Returns:
        //     An object representing the result of executing this function.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     If function is null or empty
        //
        //   T:System.InvalidOperationException:
        //     If function is invalid (syntax, does not exist, refers to a function with return
        //     type incompatible with T)
        public virtual ObjectResult<TElement> ExecuteFunction<TElement>(string functionName, ExecutionOptions executionOptions, params ObjectParameter[] parameters)
        {
            return null;
        }

        #endregion ExecuteFunction

        #region ExecuteCommand
        //
        // Summary:
        //     Executes an arbitrary command directly against the data source using the existing
        //     connection. The command is specified using the server's native query language,
        //     such as SQL. As with any API that accepts SQL it is important to parameterize
        //     any user input to protect against a SQL injection attack. You can include parameter
        //     place holders in the SQL query string and then supply parameter values as additional
        //     arguments. Any parameter values you supply will automatically be converted to
        //     a DbParameter. context.ExecuteStoreCommand("UPDATE dbo.Posts SET Rating = 5 WHERE
        //     Author = @p0", userSuppliedAuthor); Alternatively, you can also construct a DbParameter
        //     and supply it to SqlQuery. This allows you to use named parameters in the SQL
        //     query string. context.ExecuteStoreCommand("UPDATE dbo.Posts SET Rating = 5 WHERE
        //     Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        //
        // Parameters:
        //   commandText:
        //     The command specified in the server's native query language.
        //
        //   parameters:
        //     The parameter values to use for the query.
        //
        // Returns:
        //     The number of rows affected.
        //
        // Remarks:
        //     If there isn't an existing local transaction a new transaction will be used to
        //     execute the command.
        public virtual int ExecuteStoreCommand(string commandText, params object[] parameters) { return 0; }

        //
        // Summary:
        //     Executes the given DDL/DML command against the database. As with any API that
        //     accepts SQL it is important to parameterize any user input to protect against
        //     a SQL injection attack. You can include parameter place holders in the SQL query
        //     string and then supply parameter values as additional arguments. Any parameter
        //     values you supply will automatically be converted to a DbParameter. context.Database.ExecuteSqlCommand("UPDATE
        //     dbo.Posts SET Rating = 5 WHERE Author = @p0", userSuppliedAuthor); Alternatively,
        //     you can also construct a DbParameter and supply it to SqlQuery. This allows you
        //     to use named parameters in the SQL query string. context.Database.ExecuteSqlCommand("UPDATE
        //     dbo.Posts SET Rating = 5 WHERE Author = @author", new SqlParameter("@author",
        //     userSuppliedAuthor));
        //
        // Parameters:
        //   sql:
        //     The command string.
        //
        //   parameters:
        //     The parameters to apply to the command string.
        //
        // Returns:
        //     The result returned by the database after executing the command.
        //
        // Remarks:
        //     If there isn't an existing local or ambient transaction a new transaction will
        //     be used to execute the command.
        public int ExecuteSqlCommand(string sql, params object[] parameters) { return 0; }

        #endregion ExecuteCommand

        #region ExecuteStoreQuery
        //
        // Summary:
        //     Executes a query directly against the data source and returns a sequence of typed
        //     results. The query is specified using the server's native query language, such
        //     as SQL. Results are not tracked by the context, use the overload that specifies
        //     an entity set name to track results. As with any API that accepts SQL it is important
        //     to parameterize any user input to protect against a SQL injection attack. You
        //     can include parameter place holders in the SQL query string and then supply parameter
        //     values as additional arguments. Any parameter values you supply will automatically
        //     be converted to a DbParameter. context.ExecuteStoreQuery<Post>("SELECT * FROM
        //     dbo.Posts WHERE Author = @p0", userSuppliedAuthor); Alternatively, you can also
        //     construct a DbParameter and supply it to SqlQuery. This allows you to use named
        //     parameters in the SQL query string. context.ExecuteStoreQuery<Post>("SELECT *
        //     FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        //
        // Parameters:
        //   commandText:
        //     The query specified in the server's native query language.
        //
        //   parameters:
        //     The parameter values to use for the query. If output parameters are used, their
        //     values will not be available until the results have been read completely. This
        //     is due to the underlying behavior of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589
        //     for more details.
        //
        // Type parameters:
        //   TElement:
        //     The element type of the result sequence.
        //
        // Returns:
        //     An enumeration of objects of type TElement .
        public virtual ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters) { return null; }
        //
        // Summary:
        //     Executes a query directly against the data source and returns a sequence of typed
        //     results. The query is specified using the server's native query language, such
        //     as SQL. Results are not tracked by the context, use the overload that specifies
        //     an entity set name to track results. As with any API that accepts SQL it is important
        //     to parameterize any user input to protect against a SQL injection attack. You
        //     can include parameter place holders in the SQL query string and then supply parameter
        //     values as additional arguments. Any parameter values you supply will automatically
        //     be converted to a DbParameter. context.ExecuteStoreQuery<Post>("SELECT * FROM
        //     dbo.Posts WHERE Author = @p0", userSuppliedAuthor); Alternatively, you can also
        //     construct a DbParameter and supply it to SqlQuery. This allows you to use named
        //     parameters in the SQL query string. context.ExecuteStoreQuery<Post>("SELECT *
        //     FROM dbo.Posts WHERE Author = @author", new SqlParameter("@author", userSuppliedAuthor));
        //
        // Parameters:
        //   commandText:
        //     The query specified in the server's native query language.
        //
        //   executionOptions:
        //     The options for executing this query.
        //
        //   parameters:
        //     The parameter values to use for the query. If output parameters are used, their
        //     values will not be available until the results have been read completely. This
        //     is due to the underlying behavior of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589
        //     for more details.
        //
        // Type parameters:
        //   TElement:
        //     The element type of the result sequence.
        //
        // Returns:
        //     An enumeration of objects of type TElement .
        public virtual ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, ExecutionOptions executionOptions, params object[] parameters) { return null; }
        //
        // Summary:
        //     Executes a query directly against the data source and returns a sequence of typed
        //     results. The query is specified using the server's native query language, such
        //     as SQL. If an entity set name is specified, results are tracked by the context.
        //     As with any API that accepts SQL it is important to parameterize any user input
        //     to protect against a SQL injection attack. You can include parameter place holders
        //     in the SQL query string and then supply parameter values as additional arguments.
        //     Any parameter values you supply will automatically be converted to a DbParameter.
        //     context.ExecuteStoreQuery<Post>("SELECT * FROM dbo.Posts WHERE Author = @p0",
        //     userSuppliedAuthor); Alternatively, you can also construct a DbParameter and
        //     supply it to SqlQuery. This allows you to use named parameters in the SQL query
        //     string. context.ExecuteStoreQuery<Post>("SELECT * FROM dbo.Posts WHERE Author
        //     = @author", new SqlParameter("@author", userSuppliedAuthor));
        //
        // Parameters:
        //   commandText:
        //     The query specified in the server's native query language.
        //
        //   entitySetName:
        //     The entity set of the TResult type. If an entity set name is not provided, the
        //     results are not going to be tracked.
        //
        //   mergeOption:
        //     The System.Data.Entity.Core.Objects.MergeOption to use when executing the query.
        //     The default is System.Data.Entity.Core.Objects.MergeOption.AppendOnly.
        //
        //   parameters:
        //     The parameter values to use for the query. If output parameters are used, their
        //     values will not be available until the results have been read completely. This
        //     is due to the underlying behavior of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589
        //     for more details.
        //
        // Type parameters:
        //   TElement:
        //     The element type of the result sequence.
        //
        // Returns:
        //     An enumeration of objects of type TElement .
        public virtual ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, string entitySetName, MergeOption mergeOption, params object[] parameters) { return null; }
        //
        // Summary:
        //     Executes a query directly against the data source and returns a sequence of typed
        //     results. The query is specified using the server's native query language, such
        //     as SQL. If an entity set name is specified, results are tracked by the context.
        //     As with any API that accepts SQL it is important to parameterize any user input
        //     to protect against a SQL injection attack. You can include parameter place holders
        //     in the SQL query string and then supply parameter values as additional arguments.
        //     Any parameter values you supply will automatically be converted to a DbParameter.
        //     context.ExecuteStoreQuery<Post>("SELECT * FROM dbo.Posts WHERE Author = @p0",
        //     userSuppliedAuthor); Alternatively, you can also construct a DbParameter and
        //     supply it to SqlQuery. This allows you to use named parameters in the SQL query
        //     string. context.ExecuteStoreQuery<Post>("SELECT * FROM dbo.Posts WHERE Author
        //     = @author", new SqlParameter("@author", userSuppliedAuthor));
        //
        // Parameters:
        //   commandText:
        //     The query specified in the server's native query language.
        //
        //   entitySetName:
        //     The entity set of the TResult type. If an entity set name is not provided, the
        //     results are not going to be tracked.
        //
        //   executionOptions:
        //     The options for executing this query.
        //
        //   parameters:
        //     The parameter values to use for the query. If output parameters are used, their
        //     values will not be available until the results have been read completely. This
        //     is due to the underlying behavior of DbDataReader, see http://go.microsoft.com/fwlink/?LinkID=398589
        //     for more details.
        //
        // Type parameters:
        //   TElement:
        //     The element type of the result sequence.
        //
        // Returns:
        //     An enumeration of objects of type TElement .
        public virtual ObjectResult<TElement> ExecuteStoreQuery<TElement>(string commandText, string entitySetName, ExecutionOptions executionOptions, params object[] parameters)
        {
            return null;
        }
        #endregion ExecuteStoreQuery

        #region MultipleResultSet

        #endregion MultipleResultSet

    }
}
