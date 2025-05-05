namespace UserInterface
{
    public class Presenter<T>
    {
        protected T View { get; }

        protected Presenter(T view)
        {
            View = view;
        }
    }
}