using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace TechnicalAPI.Connection
{
    public class ConnectionDB : IDisposable
    {

        private bool disposedValue;
        public static string? ConnectionString;

        private readonly IDbConnection _connection;
        private IDbTransaction _transaction;

        public ConnectionDB()
        {

            var conn = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            ConnectionString = conn.GetSection("ConnectionStrings:myConnection").Value;

            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IDbConnection connection => _connection;
        public IDbTransaction transaction => _transaction;


        private static SqlParameter[] GetParameters(Hashtable Values)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            foreach (var item in Values.Keys)
            {
                parameter.Add(new SqlParameter()
                {
                    ParameterName = item.ToString(),
                    Value = Values[item],
                });
            }
            return parameter.ToArray();
        }


        internal T Read<T>(string query, Hashtable Parameters) where T : new()
        {
            T? result = default(T);

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();

                    using (var command = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
                    {
                        if (Parameters != null)
                            command.Parameters.AddRange(GetParameters(Parameters));

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = new T();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    var propertyName = reader.GetName(i);
                                    var propertyInfo = typeof(T).GetProperty(propertyName);
                                    if (propertyInfo != null && !reader.IsDBNull(i))
                                    {
                                        var value = reader.GetValue(i);
                                        propertyInfo.SetValue(result, value);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return result!;
        }


        internal List<T> ReadL<T>(string query, Hashtable Parameters) where T : new()
        {
            var resultList = new List<T>();

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();

                    using (var command = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
                    {
                        if (Parameters != null)
                            command.Parameters.AddRange(GetParameters(Parameters));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new T();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    var propertyName = reader.GetName(i);
                                    var propertyInfo = typeof(T).GetProperty(propertyName);
                                    if (propertyInfo != null && !reader.IsDBNull(i))
                                    {
                                        var value = reader.GetValue(i);
                                        propertyInfo.SetValue(item, value);
                                    }
                                }
                                resultList.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    string error = ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return resultList;
        }



        internal bool Write(string query, Hashtable parameters)
        {
            var validate = false;

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    var task = Task.Factory.StartNew(() =>
                    {
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        return con.State == ConnectionState.Open;
                    });

                    if (!(task.Wait(15000) && task.Result))
                        validate = false;

                    using (var command = new SqlCommand(query, con) { CommandType = CommandType.StoredProcedure })
                    {

                        if (parameters != null) command.Parameters.AddRange(GetParameters(parameters));

                        validate = Convert.ToBoolean(command.ExecuteNonQuery());
                    }

                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    return false;

                }
                con.Close();
            }
            return validate;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
