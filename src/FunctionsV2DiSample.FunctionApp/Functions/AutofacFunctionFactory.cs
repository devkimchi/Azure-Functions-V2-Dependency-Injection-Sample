//using Autofac;

//using Microsoft.Azure.WebJobs.Host;

//namespace FunctionsV2DiSample.FunctionApp.Functions
//{
//    /// <summary>
//    /// This represents the factory entity for functions.
//    /// </summary>
//    public class AutofacFunctionFactory : IFunctionFactory
//    {
//        private readonly IContainer _container;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="AutofacFunctionFactory"/> class.
//        /// </summary>
//        /// <param name="module"><see cref="Module"/> instance.</param>
//        public AutofacFunctionFactory(Module module = null)
//        {
//            var builder = new ContainerBuilder();
//            builder.RegisterModule(module);

//            this._container = builder.Build();
//        }

//        /// <inheritdoc />
//        public TFunction Create<TFunction>(TraceWriter log, string name = null)
//            where TFunction : IFunction
//        {
//            // Resolve the function instance directly from the container.
//            var function = this._container.ResolveNamed<TFunction>(name);
//            function.Log = log;

//            return function;
//        }
//    }
//}