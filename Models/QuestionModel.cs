using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TrackUPSC.Models
{
    public class QuestionModel
    {
        public int year { get; set; }
        public List<Question> questions;

        public QuestionModel(string filePath)
        {
            this.questions = new List<Question>();
            string[] lines = System.IO.File.ReadAllLines(filePath);

            int currentQuestionIndex = -1;

            foreach (string line in lines)
            {
                if (line.StartsWith("<") && line.EndsWith(">"))
                {
                    year = Convert.ToInt32(Regex.Match(line, @"\d+").Value);
                }else if (line.StartsWith("Q"))
                {
                    currentQuestionIndex++;
                    Question question = new Question();
                    question.question = line.Substring(line.IndexOf('.') + 1).Trim();
                    questions.Add(question);
                }
                else if (line.StartsWith("("))
                {
                    questions[currentQuestionIndex].answers.Add(line.Substring(3).Trim());
                }
                else if (line.StartsWith("ans"))
                {
                    questions[currentQuestionIndex].answer= line.Substring(line.IndexOf(':') + 1).Trim();

                }
            }
        }
    }
}
