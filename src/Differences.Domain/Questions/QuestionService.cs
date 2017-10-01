﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Differences.Common;
using Differences.Domain.Users;
using Differences.Interaction.Models;
using Differences.Interaction.Repositories;

namespace Differences.Domain.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserService _userService;

        public QuestionService(IQuestionRepository questionRepository,
            IUserService userService)
        {
            _questionRepository = questionRepository;
            _userService = userService;
        }

        public Question AskQuestion(string title, string content, Guid userGuid)
        {
            var user = _userService.GetUserInfo(userGuid);
            if (user == null)
                throw new DefinedException { ErrorCode = ErrorDefinitions.User.CannotFindUser };

            return _questionRepository.Add(new Question
            {
                Title = title,
                Content = content,
                OwnerId = user.Id
            });
        }
    }
}
