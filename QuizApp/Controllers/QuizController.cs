using Microsoft.AspNetCore.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private static Quiz _quiz;

        public QuizController()
        {
            if (_quiz == null)
            {
                _quiz = new Quiz();
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_quiz.GetCurrentQuestion());
        }

        [HttpPost]
        public IActionResult Index(int selectedAnswer, string action)
        {
            _quiz.UserAnswers[_quiz.CurrentQuestionIndex] = selectedAnswer;

            if (action == "Next")
            {
                _quiz.CurrentQuestionIndex++;
            }

            if (_quiz.CurrentQuestionIndex >= _quiz.Questions.Count || action == "Finish")
            {
                return RedirectToAction("Result");
            }

            return View(_quiz.GetCurrentQuestion());
        }

        public IActionResult Result()
        {
            int score = 0;

            var results = new List<(Question Question, int UserAnswer, bool IsCorrect)>();
            for (int i = 0; i <= _quiz.CurrentQuestionIndex; i++)
            {
                var isCorrect = _quiz.UserAnswers[i] == _quiz.Questions[i].CorrectAnswerIndex;
                if (isCorrect)
                {
                    score++;
                }
                results.Add((_quiz.Questions[i], _quiz.UserAnswers[i], isCorrect));
            }

            ViewBag.Score = score;
            ViewBag.TotalQuestions = _quiz.Questions.Count;
            ViewBag.Results = results;

            return View();
        }

        [HttpPost]
        public IActionResult Restart()
        {
            _quiz = new Quiz(); // Скидаємо вікторину
            return RedirectToAction("Index");
        }
    }
}
