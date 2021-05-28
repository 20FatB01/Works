using System;

namespace Works
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GenderCode { get; set; }
        public string PhotoPath { get; set; }

        public string ToSql()
        {
            return $"('{FirstName}', '{LastName}', '{Patronymic}', {Birthday}, {RegistrationDate}, '{Email}', '{Phone}', '{GenderCode}', '{PhotoPath}')";
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Patronymic}";
        }
    }
}