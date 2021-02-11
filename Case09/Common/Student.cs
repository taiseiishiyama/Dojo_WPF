namespace Case09.Common
{
    internal class Student
    {
        public string Name { get; }
        public Gender Gender { get; }
        public int TestScore { get; }
        public Student(string name, Gender gender, int testScore)
        {
            Name = name;
            Gender = gender;
            TestScore = testScore;
        }
    }
}