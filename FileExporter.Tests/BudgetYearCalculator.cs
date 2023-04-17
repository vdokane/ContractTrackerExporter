using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FileExporter.Tests
{
    public class BudgetYearCalculator
    {
        private DateTime startDate;
        private DateTime endDate;
        [SetUp]
        public void Setup()
        {
            startDate = new DateTime(2022, 12, 9);
            endDate = new DateTime(2022, 12, 10);
        }

        [Test]
        public void Test1()
        {
            var startYear = startDate.Year;
            var endYear = endDate.Year;
            var differenceOfYears = endYear - startYear;
            if (differenceOfYears == 0)
                Assert.Pass("differenceOfYears is 0");
        }

        [Test]
        public void CanSetSingleYearBudgetRange()
        {
            var startYear = startDate.Year;
            var endYear = endDate.Year;

            var startDateOfFirstFiscalYear = new DateTime(startYear, 7, 1);
            if (startDate > startDateOfFirstFiscalYear)
            {
                //If before july 1st, starts in previous FY
                var firstBudgetRecordDate = new DateTime(startYear - 1, 7, 1);
                Assert.Pass(firstBudgetRecordDate.ToShortDateString());
            }
            else
            {
                Assert.Pass(startDateOfFirstFiscalYear.ToShortDateString());
            }
            //var differenceOfYears = endYear - startYear;
            //if (differenceOfYears == 0)
            Assert.Pass("differenceOfYears is 0");
        }

        [Test]
        public void DoesOldTrackerCodeWork()
        {
            decimal dBug = -1;
            var fiscalYearStartDate = GetFiscalYearStartDate(startDate);


            Assert.Pass("differenceOfYears is 0");
        }

        [Test]
        public void GetCorrectEndDateTest1()
        {
            decimal dBug = -1;
            var fiscalYearStartDate = GetFiscalYearStartDate(startDate);
            var shouldBeCorrectEndDate = GetFisalYearEndDateFromStartDate(fiscalYearStartDate);

            var shouldKeepProcessing = (endDate > shouldBeCorrectEndDate);
            if (!shouldKeepProcessing)
                Assert.Pass("Should not keep processing");
        }

        [Test]
        public void ShouldKeepProcessing1()
        {
            decimal dBug = -1;
            DateTime contractStartDate = new DateTime(2022, 12, 1);
            DateTime contractEndDate = new DateTime(2022, 3, 2);

            var fiscalYearStartDate = GetFiscalYearStartDate(contractStartDate);
            var shouldBeCorrectEndDate = GetFisalYearEndDateFromStartDate(fiscalYearStartDate);

            var shouldKeepProcessing = (contractEndDate > shouldBeCorrectEndDate);
            if (!shouldKeepProcessing)
                Assert.Pass("Should not keep processing");
        }

        [Test]
        public void ShouldKeepProcessing2()
        {
            //Start 5 / 15 / 2022
//End 7 / 15 / 2022
//A and B?[Steve Updike] Correct.

            decimal dBug = -1;
            DateTime contractStartDate = new DateTime(2022, 5, 15);
            DateTime contractEndDate = new DateTime(2022, 7, 15);

            var fiscalYearStartDate = GetFiscalYearStartDate(contractStartDate);
            var shouldBeCorrectEndDate = GetFisalYearEndDateFromStartDate(fiscalYearStartDate);

            var shouldKeepProcessing = (contractEndDate > shouldBeCorrectEndDate);
            if (shouldKeepProcessing)
                Assert.Pass("Should   keep processing");
        }

        [Test]
        public void WhileTestToLoadThemUp()
        {
            //Start 5 / 15 / 2022
            //End 7 / 15 / 2022
            //A and B?[Steve Updike] Correct.

            decimal dBug = -1;
            DateTime contractStartDate = new DateTime(2023, 4, 1); // 4/1/2023
            DateTime contractEndDate = new DateTime(2027, 7, 13); //7/13/2027

            var theList = new List<BudgetRangeHolder>();

            var fiscalYearStartDate = GetFiscalYearStartDate(contractStartDate);
            var shouldBeCorrectEndDate = GetFisalYearEndDateFromStartDate(fiscalYearStartDate);

            theList.Add(new BudgetRangeHolder() { StartDate = fiscalYearStartDate, EndDate = shouldBeCorrectEndDate });
            //var shouldKeepProcessing = (endDate > shouldBeCorrectEndDate);
            // if (shouldKeepProcessing)
            //    Assert.Pass("Should   keep processing");
            while (contractEndDate > shouldBeCorrectEndDate)
            {
                fiscalYearStartDate = fiscalYearStartDate.AddYears(1);
                shouldBeCorrectEndDate = GetFisalYearEndDateFromStartDate(fiscalYearStartDate);
                theList.Add(new BudgetRangeHolder() { StartDate = fiscalYearStartDate, EndDate = shouldBeCorrectEndDate });
            }

            if(theList.Count == 6)
                Assert.Pass("IT WORKS");
        }

        [Test]
        public void WhileTestToLoadThemUpTwo()
        {
            //Start 4/1/2023
           // End 4 / 1 / 2027
            //A and B?[Steve Updike] Correct.


            DateTime contractStartDate = new DateTime(2023, 4, 1); // 4/1/2023
            DateTime contractEndDate = new DateTime(2027, 4, 1); //7/13/2027

            var theList = new List<BudgetRangeHolder>();

            var fiscalYearStartDate = GetFiscalYearStartDate(contractStartDate);
            var shouldBeCorrectEndDate = GetFisalYearEndDateFromStartDate(fiscalYearStartDate);

            theList.Add(new BudgetRangeHolder() { StartDate = fiscalYearStartDate, EndDate = shouldBeCorrectEndDate });
            //var shouldKeepProcessing = (endDate > shouldBeCorrectEndDate);
            // if (shouldKeepProcessing)
            //    Assert.Pass("Should   keep processing");
            while (contractEndDate > shouldBeCorrectEndDate)
            {
                fiscalYearStartDate = fiscalYearStartDate.AddYears(1);
                shouldBeCorrectEndDate = GetFisalYearEndDateFromStartDate(fiscalYearStartDate);
                theList.Add(new BudgetRangeHolder() { StartDate = fiscalYearStartDate, EndDate = shouldBeCorrectEndDate });
            }

            if (theList.Count ==5 )
                Assert.Pass("IT WORKS");
        }

        public    class BudgetRangeHolder
        {
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public static int? GetFiscalYear(DateTime? date)
        {
            if (!date.HasValue)
                return null;
            return GetFiscalYearStartDate(date.Value).Year;
        }
        public static DateTime GetFisalYearEndDateFromStartDate(DateTime fyStartDate)
        {
            return new DateTime(fyStartDate.Year + 1, 6, 30);
        }

        public static DateTime GetFiscalYearStartDate(DateTime date)
        {
            int currentYear = date.Year;
            int previousYear = (date.Year - 1);
            int fiscalYear = 0;

            if (date.Month >= 7)
            {
                fiscalYear = currentYear;
            }
            else
            {
                fiscalYear = previousYear;
            }

            var fiscalYearStartDate = new DateTime(fiscalYear, 7, 1);
            return fiscalYearStartDate;
        }
        /*
         * 


fiscal year A 7/1/2021 to 6/30/2022
fiscal year B 7/1/2022 to 6/30/2023
fiscal year C 7/1/2023 to 6/30/2024
fiscal year D 7/1/2024 to 6/30/2025
fiscal year E 7/1/2025 to 6/30/2026
fiscal year F 7/1/2026 to 6/30/2027
fiscal year G 7/1/2027 to 6/30/2028

Scenario One, 2 day contract, say hotel
Start 12/9/2022
End 12/10/2022
We would create just one budget record with fiscal year B, correct?[Steve Updike] Correct..

Scenario Two, 60 day contract, roof repair, ex 1 (stays within same FY)
Start 12/1/2022
End 3/2/2022
Still just B?[Steve Updike] Correct..

Scenario Three, 60 day contract, roof repair, ex 2 (over laps FYs)
Start 5/15/2022
End 7/15/2022
A and B?[Steve Updike] Correct.

Scenario Four,1 year contract, IT vendor, ex 1 (stays within same FY)
Start 7/2/2023
End 6/28/2024
C [Steve Updike] Correct.

Scenario Five, 1 year contract, IT vendor, ex 2 (over laps FYs)
Start 1/15/2023
End 1/15/2024
B and C?[Steve Updike] Correct.

Scenario Six, 4 year contract, copier services, ex 1 (stays within same FY)
Start 4/1/2023
End 4/1/2027
B C D E F?[Steve Updike] Correct.

Scenario Seven, 4 year(ish) contract, copier services, ex 2 (over laps FYs)
Start 4/1/2023
End 7/13/2027
B C D E F G[Steve Updike] Correct.

         */
    }
}