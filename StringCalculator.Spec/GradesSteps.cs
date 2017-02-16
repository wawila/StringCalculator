using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace StringCalculator.Spec
{
    [Binding]
    public class GradesSteps
    {
        private GradeManager gradeManager;
        private string accountNumber;
        private Mock<IGradeRepository> _gradeRepositoryMock = new Mock<IGradeRepository>();
        private double average;
        private Mock<IEmailManager> _emailManagerMock = new Mock<IEmailManager>();

        [Given(@"That the student with '(.*)' account number")]
        public void GivenThatTheStudentWithAccountNumber(string p0)
        {
            accountNumber = p0;
        }
        
        [Given(@"These are the following grades")]
        public void GivenTheseAreTheFollowingGrades(Table table)
        {
           var grades = table.CreateSet<Grade>();
            _gradeRepositoryMock.Setup(x => x.GetGrades(accountNumber)).Returns(grades);
        }
        
        [When(@"I calculate the average grade")]
        public void WhenICalculateTheAverageGrade()
        {
            gradeManager = new GradeManager(_gradeRepositoryMock.Object, _emailManagerMock.Object);
            average = gradeManager.CalculateAverage(accountNumber);
        }
        
        [Then(@"the average grade should be (.*) on the screen")]
        public void ThenTheAverageGradeShouldBeOnTheScreen(Decimal p0)
        {

        }

        [Then(@"Send an email to the parents")]
        public void ThenSendAnEmailToTheParents()
        {
            _emailManagerMock.Verify(email => email.SendEmail("La riata"), Times.Once);
        }

        [Then(@"Don't send an email to the parents")]
        public void ThenDonTSendAnEmailToTheParents()
        {
            _emailManagerMock.Verify(email => email.SendEmail(It.IsAny<string>()), Times.Never);
        }


    }
}
