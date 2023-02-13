namespace WebApiTutorial.DTO
{
    public class OwnerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gym { get; set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }
}
