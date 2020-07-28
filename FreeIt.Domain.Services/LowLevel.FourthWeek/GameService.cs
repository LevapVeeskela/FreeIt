using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FreeIt.Domain.Common.Enums;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Common.Helpers;
using FreeIt.Domain.Common.Models.Db;
using FreeIt.Domain.Common.Models.Requests.Millionaire;
using FreeIt.Domain.Common.Models.Responses.Millionaire;
using FreeIt.Domain.Interfaces.Services;
using FreeIt.Domain.Interfaces.Services.External;
using static FreeIt.Domain.Common.Constants.Constants;

namespace FreeIt.Domain.Services.LowLevel.FourthWeek
{
    public class GameService : IGameService
    {
        static object locker = new object();

        /// <summary>
        /// Так как Api отдаёт рандомные вопросы, есть шанс получить предыдущий
        /// </summary>
        private List<string> _listQuestions;

        private readonly IMillionaireClient _millionaireClient;

        private int CurrentStep { get; set; }

        private int TempPrize { get; set; }

        private string Name { get; set; }

        private QuestionDataDbModel CurrentDbModel { get; set; }

        public GameService(IMillionaireClient millionaireClients)
        {
            _millionaireClient = millionaireClients;
            DefaultValue();
        }

        private void DefaultValue()
        {
            FireproofPrize = 0;
            CurrentStep = 1;
            _listQuestions = new List<string>();
        }

        public int FireproofPrize { get; set; }

        public async Task StartGame()
        {
            DefaultValue();

            Name = Quiz.Welcome.GetValueFromConsole();
            string.Format(Templates.FirstWelcomeTemplate, Name).ToConsole();
            string.Format(Templates.SecondWelcomeTemplate, Name).ToConsole();

            await AskQuestions();
        }

        private async Task AskQuestions()
        {
            for (CurrentStep = 1; CurrentStep <= 15; CurrentStep++)
            {
                CurrentDbModel = await GetReadyQuestion(CurrentStep);
                lock (locker)
                {
                    new string('-', 100).ToConsole();
                    string.Format(Templates.NumberQuestionTemplate, CurrentStep).ToConsole();
                    CurrentDbModel.Question.ToConsole();
                    var questions = CurrentDbModel.Answers.ToList().Mixing();
                    var hisAnswer = String.Join(", ", questions.Select((_, index) => $"{index + 1}. {_}"))
                        .GetValueFromConsole();

                    if (CurrentStep == 5 || CurrentStep == 10)
                    {
                        FireproofPrize = SwitchHelper.GetPrizeSum(CurrentStep);
                        string.Format(Templates.FireproofPrizeTemplate, FireproofPrize).ToConsole();
                    }

                    if (int.TryParse(hisAnswer, out var result) && result == 5)
                    {
                        FireproofPrize = TempPrize;
                        return;
                    }

                    var isTruth = CurrentDbModel.Answers.FirstOrDefault().Equals(questions.ToArray()[result - 1]);

                    if (isTruth)
                    {
                        TempPrize = SwitchHelper.GetPrizeSum(CurrentStep);
                        Quiz.TrueAnswer.ToConsole();
                    }
                    else
                    {
                        string.Format(Templates.TrueAnswerTemplate,CurrentDbModel.Answers.FirstOrDefault()).ToConsole();
                        return;
                    }

                    if (isTruth && CurrentStep == 15)
                    {
                        FireproofPrize = TempPrize = SwitchHelper.GetPrizeSum(CurrentStep);
                        Quiz.Winner.ToConsole();
                    }
                   
                }
            }
        }

        private async Task<QuestionDataDbModel> GetReadyQuestion(int step = 1)
        {
            (MillionaireResponse dbModel, string question) result;

            switch (step)
            {
                case int v when v >= 6 && v <= 10:
                    result = await GetTupleQuestion(LevelDifficulty.Middle);
                    break;
                case int v when v >= 11 && v <= 15:
                    result = await GetTupleQuestion(LevelDifficulty.Difficult);
                    break;
                default:
                    result = await GetTupleQuestion(LevelDifficulty.Easy);
                    break;
            }

            _listQuestions.Add(result.question);

            return result.dbModel.Data?.FirstOrDefault();
        }

        private async Task<(MillionaireResponse dbModel, string question)> GetTupleQuestion(LevelDifficulty level)
        {
            var dbModel = await GetQuestion(level);
            var question = dbModel.Data?.FirstOrDefault()?.Question;
            if (_listQuestions.Exists(_ => _.Equals(question)))
                return await GetTupleQuestion(level);

            return (dbModel, question);
        }

        private async Task<MillionaireResponse> GetQuestion(LevelDifficulty level)
            => await _millionaireClient.GetAsync(new GetQuestionRequest
            {
                QType = level,
                Count = 1
            }, new CancellationToken());
    }
}