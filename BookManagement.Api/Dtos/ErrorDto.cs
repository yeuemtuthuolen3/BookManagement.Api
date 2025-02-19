using System;
namespace BookManagement.Api.Dtos
{
	public class ErrorDto
	{
        public ErrorDto(string statusCode,string error,string messages)
        {
            StatusCode = statusCode;
            Error = error;
            Messages = messages;
        }
		public string StatusCode { get; set; } = string.Empty;
        public string Error { get; set; } = string.Empty;
        public string Messages { get; set; } = string.Empty;
    }
}

