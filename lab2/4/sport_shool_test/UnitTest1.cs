using sports_school;

namespace sport_shool_test
{
    public class Tests
    {
        [TestCase("VolleyballSection.txt", new[] { "������� �������� ���������",
                                                   "����� ������ ����������",
                                                   "���������� ���� ���������" })]
        [TestCase("1.txt", new string[] { })]
        public void GetSortedSetFromFileTest(string pathToFile, string[] result)
        {
            SortedSet<string> correctResult = new();

            foreach (var item in result)
                correctResult.Add(item);

            SortedSet<string> actualResult = Program.GetSortedSetFromFile(pathToFile);

            Assert.That(actualResult, Is.EqualTo(correctResult));
        }

        [Test]
        public void GetAllStudentsInSchool()
        {
            SortedSet<string> actualResult = Program.GetAllStudentsInSchool("VolleyballSection.txt SoccerSection.txt TennisSection.txt");

            Assert.That(actualResult, Is.EqualTo(new SortedSet<string> { "������� �������� ���������",
                                                                         "����� ������ ����������",
                                                                         "�������� ����� ����������",
                                                                         "������� ���� �����������",
                                                                         "������� ������ ����������",
                                                                         "���������� ���� ���������"}));
        }
    }
}