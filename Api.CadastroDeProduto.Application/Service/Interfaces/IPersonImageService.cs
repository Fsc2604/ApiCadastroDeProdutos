﻿using Api.CadastroDeProduto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Application.Service.Interfaces
{
    public interface IPersonImageService
    {
        Task<ResultService> CreateImagebase64Async(PersonImageDto personImageDto);
        Task<ResultService> CreateImageAsync(PersonImageDto personImageDto);
    }
}
