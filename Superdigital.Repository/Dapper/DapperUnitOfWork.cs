using Dapper;
using Newtonsoft.Json;
using SuperDigital.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Superdigital.Repository.Dapper
{
    public class DapperUnitOfWork: IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly string _connectionString;
        private SqlConnection _connection { get; set; }
        private int _timeout;
        public const string _dataSettingsFilePath = "appsettings.json";


        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public DapperUnitOfWork()
        {
            var connection = JsonConvert.DeserializeObject<ConnectionStrings>(File.ReadAllText(_dataSettingsFilePath));
            _connectionString = connection.Bank;
            _timeout = 200;
        }

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public void SaveChanges()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public IEnumerable<T> List<T>(string query, params SqlParameter[] parameter) where T : new()
        {
            return ExecuteProc<T>(query, parameter);
        }

        public T Get<T>(string query, params SqlParameter[] parameter) where T : new()
        {
            return List<T>(query, parameter).AsEnumerable().FirstOrDefault();
        }

        private IEnumerable<T> ExecuteProc<T>(string query, params SqlParameter[] parameter) where T : new()
        {
            using (IDbConnection conn = new SqlConnection(this._connectionString))
            {
                return conn.Query<T>(sql: query, param: ConvertTo(parameter), commandTimeout: _timeout, commandType: CommandType.StoredProcedure);
            }
        }

        public int Execute(string query, params SqlParameter[] parameter)
        {
            using (IDbConnection conn = new SqlConnection(this._connectionString))
            {
                return conn.Execute(sql: query, param: ConvertTo(parameter), commandTimeout: _timeout, commandType: CommandType.StoredProcedure);
            }
        }

        private DynamicParameters ConvertTo(SqlParameter[] paramsmysql)
        {
            DynamicParameters paramsdap = null;
            if (paramsmysql != null)
            {
                paramsdap = new DynamicParameters();

                foreach (var item in paramsmysql)
                {
                    if (item.Value.GetType().Name.ToUpper() == typeof(System.DBNull).Name.ToUpper())
                        paramsdap.Add(item.ParameterName, null);
                    else
                        paramsdap.Add(item.ParameterName, item.Value);
                }
            }
            return paramsdap;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        if (_connection.State == ConnectionState.Open)
                        {
                            _connection.Close();
                        }
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~DapperUnitOfWork()
        {
            Dispose(false);
        }
    }
}
