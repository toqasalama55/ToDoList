namespace ToDoList.Models
{
    public class ListItems
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
