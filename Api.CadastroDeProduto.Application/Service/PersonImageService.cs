using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Api.CadastroDeProduto.Application.Validations;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Integrations;
using ApiCadastroDeProduto.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service
{
    public class PersonImageService : IPersonImageService
    {
        private readonly IPersonImageRepository _personImageRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ISavePersonImage _savePersonImage;

        public PersonImageService(IPersonImageRepository personImageRepository,IPersonRepository personRepository, ISavePersonImage  savePersonImage)
        {
            _personImageRepository= personImageRepository;
            _personRepository= personRepository;
            _savePersonImage= savePersonImage;
        }

        public async Task<ResultService> CreateImageAsync(PersonImageDto personImageDto)
        {
            if (personImageDto == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validations = new PersonImageDtoValidator().Validate(personImageDto);
            if (!validations.IsValid)
                return ResultService.RequestError("Problemas de validação", validations);

            var person = await _personRepository.GetByIdAsync(personImageDto.PersonId);
            if (person == null)
                return ResultService.Fail("Id pessoa não encontrado");

            var pathImage = _savePersonImage.Save(personImageDto.Image);
            var personImage = new PersonImage(person.Id, pathImage, null);
            await _personImageRepository.CreateAsync(personImage);
            return ResultService.Ok("Imagem salva com sucesso");
        }

        public async Task<ResultService> CreateImagebase64Async(PersonImageDto personImageDto)
        {
            if (personImageDto == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validations = new PersonImageDtoValidator().Validate(personImageDto);
            if(!validations.IsValid)
                return ResultService.RequestError("Problemas de validação", validations);

            var person = await _personRepository.GetByIdAsync(personImageDto.PersonId);
             if(person == null)
                return ResultService.Fail("Id pessoa não encontrado");

            var personImage = new PersonImage(person.Id, null, personImageDto.Image);
            await _personImageRepository.CreateAsync(personImage);
            return ResultService.Ok("Imagem em base64 salva");
        }
    }
}
