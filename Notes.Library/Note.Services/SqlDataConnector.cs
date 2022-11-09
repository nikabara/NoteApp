using Microsoft.Data.SqlClient;
using Note.Services.Interfaces;
using Notes.Library;
using System.Data;

namespace Note.Services
{
    public class SqlDataConnector : IDataConnection
    {
        public async Task<List<NotesCS>> GetAllNotesAsync()
        {
            const string sqlExpression = "sp_SelectedNotes";
            List<NotesCS> result = new();

            using (SqlConnection connection = new(GlobalConfig.ConnectionString()))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlCommand sqlCmd = new(sqlExpression, connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dataReader = await sqlCmd.ExecuteReaderAsync();

                    if (dataReader.HasRows)
                    {
                        while (await dataReader.ReadAsync())
                        {
                            result.Add(new NotesCS
                            {
                                NoteId = dataReader.GetInt32(0),
                                NoteHeader = dataReader.GetString(1),
                                NoteDescr = dataReader.GetString(2),
                                NoteDate = dataReader.GetDateTime(3)
                            });
                        }
                    }
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                   await connection.CloseAsync();
                }
            }
            return result;
        }

        public async Task<List<NotesErrorLog>> GetAllErrorLogAsync()
        {
            const string sqlExpression = "sp_SelectedErrors";
            List<NotesErrorLog> result = new();

            using (SqlConnection connection = new(GlobalConfig.ConnectionString()))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlCommand sqlCmd = new (sqlExpression, connection);
                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = await sqlCmd.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new NotesErrorLog()
                            {
                                ErrorId = reader.GetInt32(0),
                                ErrorNumber = reader.GetInt32(1),
                                ErrorState = reader.GetByte(2),
                                ErrorSeverity = reader.GetByte(3),
                                ErrorMessage = reader.GetString(4),
                                ErrorLine = reader.GetInt32(5)
                            });
                        }
                    }
                }
                catch (SqlException)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
            return result;
        }
    }
}
