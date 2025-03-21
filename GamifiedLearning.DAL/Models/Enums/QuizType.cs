using System.ComponentModel.DataAnnotations;

namespace GamifiedLearning.DAL.Models.Enums
{
    public enum QuizType
    {
        [Display(Name = "Jednokrotny wybór")]
        SingleChoice = 0,

        [Display(Name = "Wielokrotny wybór")]
        MultipleChoice = 1,

        [Display(Name = "Otwarta odpowiedź")]
        OpenAnswer = 2
    }
}