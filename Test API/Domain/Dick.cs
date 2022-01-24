using Microsoft.AspNetCore.Mvc;

namespace Test_API.Domain
{
    public class Dick
    {
        int length = 5;
        string name = "Dickie";
        string description = "This is the biggest dick i've even seen";

        int nbCalled = 0;

        public string GetDickString()
        {
            nbCalled++;
            return $@"This dick is {length} cm long and it is named {name}.
                        This is what people say about this dick {description}
                        And this method has been called {nbCalled} times";
        }
    }
}
