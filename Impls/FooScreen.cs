namespace UniPage.Impls
{
    [PageAsset("foo_page")]
    public class FooPage : BasePage<FooPage.Parameter>
    {
        public class Parameter
        {
            public string Bar;
        }

        public class Transition : BasePageTransition<FooPage, Parameter> {}
    }
}