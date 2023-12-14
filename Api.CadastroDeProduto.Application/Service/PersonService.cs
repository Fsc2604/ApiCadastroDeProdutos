using Api.CadastroDeProduto.Application.DTOs;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Api.CadastroDeProduto.Application.Validations;
using ApiCadastroDeProduto.Domain.Entities;
using ApiCadastroDeProduto.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        /// <summary> Criando Pessoa no repositório e convertendo pra dto</summary>
        public async Task<ResultService<PersonDto>> CreateAsync(PersonDto personDTO)
        {
            if(personDTO == null)            
             return ResultService.Fail<PersonDto>("Objeto deve ser informado");

            var result = new PersonDtoValidator().Validate(personDTO);
            if (!result.IsValid)
             return ResultService.RequestError<PersonDto>("Problemas de validacao", result);

            var person = _mapper.Map<Person>(personDTO);
            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDto>(_mapper.Map<PersonDto>(data));
        }
   
        /// <summary> Buscando Lista de Pessoas no repositório e convertendo pra dto</summary>
        public async Task<ResultService<ICollection<PersonDto>>> GetAsync()
        {
            var people = await _personRepository.GetPeopleAsync();
            return ResultService.Ok<ICollection<PersonDto>>(_mapper.Map<ICollection<PersonDto>>(people));
        }

        /// <summary> Buscando Pessoa no repositório e convertendo pra dto</summary>
        public async Task<ResultService<PersonDto>> GetByIdAsync(int id)
        {
           var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
            return ResultService.Fail<PersonDto>("Pessoaa não encontrada!");

            return ResultService.Ok(_mapper.Map<PersonDto>(person));
        }

        /// <summary> Edita uma Pessoa</summary>
        public async Task<ResultService> UpdateAsync(PersonDto personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail("Objeto deve ser informado");
            
            var validation = new PersonDtoValidator().Validate(personDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com a validação dos campos", validation);
        
            var person = await _personRepository.GetByIdAsync(personDTO.Id);
            if (person == null)
                return ResultService.Fail("Pessoa não encontrada");

            person = _mapper.Map<PersonDto, Person>(personDTO, person);
            await  _personRepository.EditAsync(person);
                return ResultService.Ok("Pessoa Editada");

        }

        /// <summary> Deleta uma Pessoa</summary>
        public async Task<ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if (person == null)
                return ResultService.Fail("Pessoa não encontrada");

            await _personRepository.DeleteAsync(person);
            return ResultService.Ok($"Pessoa do id:{id} foi deletada");
        }
    }
}
