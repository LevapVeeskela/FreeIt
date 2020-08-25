using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using FreeIt.Domain.Common.Enums;
using FreeIt.Domain.Common.Extensions;
using FreeIt.Domain.Common.Helpers;
using FreeIt.Domain.Common.Models.Db;
using FreeIt.Domain.Common.Models.Requests.Millionaire;
using FreeIt.Domain.Interfaces.Services;
using FreeIt.Domain.Interfaces.Services.External;
using static FreeIt.Domain.Common.Constants.Constants;

namespace FreeIt.Domain.Services.LowLevel.FourthWeek
{
    public class GameService : IGameService
    {
        private readonly IMillionaireClient _millionaireClient;

        private List<QuestionDataDbModel> _listQuestions;

        private int TempPrize { get; set; }

        private string Name { get; set; }

        private QuestionDataDbModel CurrentDbModel { get; set; }

        public int FireproofPrize { get; set; }

        public GameService(IMillionaireClient millionaireClients)
            => _millionaireClient = millionaireClients;

        public async Task StartGameAsync()
        {
            await PrepareQuizAsync();

            Name = Quiz.Welcome.GetValueFromConsole();
            string.Format(Templates.FirstWelcomeTemplate, Name).ToConsole();
            string.Format(Templates.SecondWelcomeTemplate, Name).ToConsole();

            AskQuestions();
        }

        private async Task PrepareQuizAsync()
        {
            FireproofPrize = 0;
            _listQuestions = new List<QuestionDataDbModel>();

            foreach (int complexity in Enum.GetValues(typeof(LevelDifficulty)))
            {
                var response = await _millionaireClient.GetAsync(new GetQuestionRequest
                {
                    QType = (LevelDifficulty)complexity,
                    Count = 5 //Количество вопросов(в пределах от 1 до 5), более 5 платно и нужен ключ
                }, new CancellationToken());

                if (response.Ok)
                    _listQuestions.AddRange(response.Data);
            }
        }

        private void AskQuestions()
        {
            for (var currentStep = 0; currentStep < _listQuestions.Count; currentStep++)
            {
                new string('-', 100).ToConsole();⁣
                string.Format(Templates.NumberQuestionTemplate, currentStep + 1).ToConsole();

                CurrentDbModel = _listQuestions[currentStep];

                CurrentDbModel.Question.ToConsole();
                    ⁣
                var questions = CurrentDbModel.Answers.ToList().Mixing();

                UpdateFireproofPrize(currentStep);

                if (int.TryParse(GetAnswer(questions), out var result) && result == Quiz.ExitNumber)
                {
                    FireproofPrize = TempPrize;
                    return;
                }

                if (!CheckAnswer(questions, result, currentStep))
                    return;

                if (currentStep == _listQuestions.Count - 1)
                {
                    FireproofPrize = TempPrize = SwitchHelper.GetPrizeSum(currentStep);
                    Quiz.Winner.ToConsole();
                }
            }
        }

        private void UpdateFireproofPrize(int currentStep)
        {
            if (currentStep == Quiz.FirstFireproofPrize || currentStep == Quiz.SecondFireproofPrize)
            {
                FireproofPrize = SwitchHelper.GetPrizeSum(currentStep);
                string.Format(Templates.FireproofPrizeTemplate, FireproofPrize).ToConsole();
            }
        }

        private string GetAnswer(List<string> questions) => string.Join(", ", questions.Select((_, index) => $"{index + 1}. {_}"))
            .GetValueFromConsole();

        private bool CheckAnswer(List<string> questions, int result, int currentStep)
        {
            var isTruth = CurrentDbModel.Answers.FirstOrDefault()?.Equals(questions.ToArray()[result - 1]);

            if (isTruth != null && (bool)isTruth)
            {
                TempPrize = SwitchHelper.GetPrizeSum(currentStep);
                Quiz.TrueAnswer.ToConsole();
                return true;
            }

            string.Format(Templates.TrueAnswerTemplate, CurrentDbModel.Answers.FirstOrDefault()).ToConsole();
            return false;
        }
    }
}