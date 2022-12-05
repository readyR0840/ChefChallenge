namespace ChefChallege.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Experience { get; set; }

        public User(){ }
    }
}
