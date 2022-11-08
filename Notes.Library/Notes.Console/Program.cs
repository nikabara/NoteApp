using Note.Services;
using Notes.Library;

SqlDataConnector newDataConnector = new SqlDataConnector();

var result = await newDataConnector.GetAllNotesAsync();

Console.ReadLine();