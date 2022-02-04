namespace business.Exceptions
{
    public class WrongUrlException : Exception
    {
        public WrongUrlException() : base("Неверный URL. Пример: https://yandex.ru")
        {

        }
    }
}

