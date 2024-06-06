﻿using StarbucksClone.Application;
using StarbucksClone.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StarbuckClone.Implementation
{
    public class UseCaseHandler
    {
        private readonly IUseCaseLogger _logger;
        private readonly IApplicationActor _actor;

        public UseCaseHandler(IUseCaseLogger logger, IApplicationActor actor)
        {
            _logger = logger;
            _actor = actor;
        }

        public void HandleCommand<TData>(ICommand<TData> command,TData data)
        {
            HandleCrossCuttingConcerns(command, data);

            command.Execute(data);
        }

        public TResult HandleQuery<TResult, TSearch>(IQuery<TResult, TSearch> query, TSearch search)
            where TResult : class
        {
            HandleCrossCuttingConcerns(query, search);

            var result = query.Execute(search);

            return result;
        }

        private void HandleCrossCuttingConcerns(IUseCase useCase, object data)
        {
            if (!_actor.AllowedUseCases.Contains(useCase.Id))
            {
                throw new UnauthorizedAccessException();
            }

            var log = new UseCaseLog
            {
                UseCaseData = data,
                UseCaseName = useCase.Name,
                Username = _actor.Username,
            };

            _logger.Log(log);
        }
    }
}
