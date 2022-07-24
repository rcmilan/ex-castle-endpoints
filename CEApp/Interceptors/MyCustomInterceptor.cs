using Castle.DynamicProxy;

namespace CEApp.Interceptors
{
    public class MyCustomInterceptor : IInterceptor
    {
        private readonly ILogger<MyCustomInterceptor> logger;

        public MyCustomInterceptor(ILogger<MyCustomInterceptor> logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            logger.LogInformation("Before! {methodName}", methodName);

            invocation.Proceed();

            logger.LogInformation("After! {methodName}", methodName);
        }
    }
}
