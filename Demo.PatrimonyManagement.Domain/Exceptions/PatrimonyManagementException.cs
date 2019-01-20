using Demo.PatrimonyManagement.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Demo.PatrimonyManagement.Domain.Exceptions
{
    public class PatrimonyManagementException : Exception
    {
        public Error ErrorType { get; set; }

        public PatrimonyManagementException(string message) : this(Error.BadRequest, message) { }
        public PatrimonyManagementException(Error error) : this(error, ErrorMessages[error]) { }

        public PatrimonyManagementException(Error error, string message) : base(message)
        {
            ErrorType = error;
        }

        public static Dictionary<Error, string> ErrorMessages = new Dictionary<Error, string>()
        {
            { Error.NotAuthorized, "O usuário precisa estar logado para realizar essa operação." },
            { Error.Forbidden, "Usuário não tem permissão para realizar essa operação." },
            { Error.NotFound, "Operação não identificada. Por favor, contate o administrador." }
        };
    }
}
