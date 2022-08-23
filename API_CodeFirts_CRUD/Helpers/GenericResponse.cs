namespace API_CodeFirts_CRUD.Helpers
{
    public class GenericResponse<T>
    {
        public bool State { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
