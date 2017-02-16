using System.Collections.Generic;
using System.Linq;

namespace StringCalculator.Spec
{
    public class GradeManager
    {
        private IGradeRepository _gradeRepository;
        private IEmailManager _emailManager;

        public GradeManager(IGradeRepository gradeRepository, IEmailManager emailManager)
        {
            _gradeRepository = gradeRepository;
            _emailManager = emailManager;
        }

        public double CalculateAverage(string accountNumber)
        {
            var grades = _gradeRepository.GetGrades(accountNumber);
            var UVs = 0;
            var average = 0;

            foreach (var grade in grades)
            {
                UVs += grade.UV;
                average += grade.GradeValue * grade.UV;
            }

            average /= UVs;

            if (average < 60)
            {
                _emailManager.SendEmail("La riata");
            }

            return average;
        }
    }
}