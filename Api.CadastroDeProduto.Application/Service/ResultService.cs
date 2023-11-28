using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service
{
    // Classe criada para retorno dos serviços  + tratamento de erros de forma genérica 
    public class ResultService
    {
        public bool IsSucess { get; set; }
        public string Message { get; set; }
        public ICollection<ErrorValidation> Errors { get; set; }

        /// <summary>Trata Erros de requisição</summary>
        public static ResultService RequestError(string message, ValidationResult validationResult)
        {
            return new ResultService
            {
                IsSucess = true,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
            };
        }
        /// <summary>Trata Erros de requisição</summary>
        public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
        {
            return new ResultService<T>
            {
                IsSucess = true,
                Message = message,
                Errors = validationResult.Errors.Select(e => new ErrorValidation { Field = e.PropertyName, Message = e.ErrorMessage }).ToList()
            };
        }

        public static ResultService Fail(string message) => new ResultService { IsSucess = false, Message = message};
        public static ResultService<T> Fail<T>(string message) => new ResultService<T> { IsSucess = false, Message = message };
        public static ResultService Ok(string message, ValidationResult validationResult) => new ResultService { IsSucess = true, Message = message };
        public static ResultService<T> Ok<T>(T data) => new ResultService<T> { IsSucess = true, Data = data };

    }

    // Tipo genérico para passar vários tipos de retorno
    public class ResultService<T> : ResultService
    {
        public T Data { get; set; }
    }
}
