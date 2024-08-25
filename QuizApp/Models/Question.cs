using System.Collections.Generic;

namespace QuizApp.Models
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }

    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public List<int> UserAnswers { get; set; }
        public int CurrentQuestionIndex { get; set; }

        public Quiz()
        {
            Questions = new List<Question>
            {
                new Question { Text = "What is the capital of France?", Options = new List<string> { "Berlin", "Madrid", "Paris", "Rome" }, CorrectAnswerIndex = 2 },
                new Question { Text = "Which planet is known as the Red Planet?", Options = new List<string> { "Earth", "Jupiter", "Mars", "Saturn" }, CorrectAnswerIndex = 2 },
                new Question { Text = "Who wrote 'To Kill a Mockingbird'?", Options = new List<string> { "Harper Lee", "J.K. Rowling", "Mark Twain", "Jane Austen" }, CorrectAnswerIndex = 0 },
                new Question { Text = "What is the hardest natural substance on Earth?", Options = new List<string> { "Gold", "Iron", "Diamond", "Platinum" }, CorrectAnswerIndex = 2 },
                new Question { Text = "What gas do plants primarily use for photosynthesis?", Options = new List<string> { "Oxygen", "Nitrogen", "Carbon Dioxide", "Hydrogen" }, CorrectAnswerIndex = 2 },
                new Question { Text = "What is the smallest unit of life?", Options = new List<string> { "Atom", "Molecule", "Cell", "Tissue" }, CorrectAnswerIndex = 2 },
            };

            UserAnswers = new List<int>(new int[Questions.Count]);
            CurrentQuestionIndex = 0;
        }

        public Question GetCurrentQuestion()
        {
            if (CurrentQuestionIndex < Questions.Count)
            {
                return Questions[CurrentQuestionIndex];
            }
            return null;
        }
    }
}
