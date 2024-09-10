

using System.Text;

namespace testing.Application.Utils.StringGenerator
{
    internal static class StringGenerator
    {
        private const string LettersToBuilRandomStrings = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        private const string NumbersToBuildRandomString = "1234567890";
        private static readonly Random Random = new();
        public static string RandomStudentIdGenerator()
        {
            StringBuilder studentId = new();

            int[] posibleYearsToUse = [ DateTime.UtcNow.AddMonths(4).Year , DateTime.UtcNow.Year];

            string yearToBeUse = posibleYearsToUse[0] > posibleYearsToUse[1] ? posibleYearsToUse[0].ToString() : posibleYearsToUse[1].ToString();

            studentId.Append(yearToBeUse + "-");

            for(int i = 0; i < 4; i++)
            {
                studentId.Append(NumbersToBuildRandomString[Random.Next(NumbersToBuildRandomString.Length - 1)]);
            }

            return studentId.ToString();
        }
        public static string RandomSectionGroupGenerator()
        {
            StringBuilder sectionGruop = new();
            sectionGruop.Append("GP");
            int lengthOfNumberToUse = Random.Next(4);
            for(int i =0; i < lengthOfNumberToUse; i++)
            {
                sectionGruop.Append(NumbersToBuildRandomString[Random.Next(NumbersToBuildRandomString.Length - 1)]);
            }
            return sectionGruop.ToString();
        }

        public static string RandomClassroomCodeGenerator()
        {
            StringBuilder classRoomCode = new();
            classRoomCode.Append("CR");
            for(int i = 0; i < 5; i++)
            {
                classRoomCode.Append(LettersToBuilRandomStrings[Random.Next(LettersToBuilRandomStrings.Length - 1)]);
            }
            return classRoomCode.ToString();
        }

    }
}
