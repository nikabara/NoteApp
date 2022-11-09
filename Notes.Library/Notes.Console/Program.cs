using Note.Services;
using Notes.Library;

SqlDataConnector newDataConnector = new SqlDataConnector();

var result1 = await newDataConnector.GetAllNotesAsync();

var result2 = await newDataConnector.GetAllErrorLogAsync();

Console.ReadLine();