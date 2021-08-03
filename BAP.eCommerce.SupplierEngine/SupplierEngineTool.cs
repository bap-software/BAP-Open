using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using BAP.Common.Suppliers;

namespace BAP.eCommerce.SupplierEngine
{
    public static class SupplierEngineTool
    {
        private static IDependencyResolver _dependencyResolver;
        
        public static SupplierExecutionResult TriggerSupplierActions(IBapSupplier supplier, Func<IBapSupplierAction, bool> condition, params BapDynamicVariable[] actionArguments)
        {
            var result = new SupplierExecutionResult();
            
            result.AddInfo($"Start of {nameof(TriggerSupplierActions)}");

            foreach (var actionClass in supplier.SupplierActionClasses)
            {
                result.AddInfo($"Found action class name [{actionClass}]");

                var actionAssembly = Assembly.Load(supplier.SupplierActionAssembly);
                
                var supplierActionType = actionAssembly.GetType(actionClass);
                var requiredInterfaceType = typeof(IBapSupplierAction);
                
                if (supplierActionType == null)
                {
                    result.AddError($"Cannot create type from action class name [{actionClass}]. Continue to next action class...");
                    continue;
                }
            
                if (supplierActionType.GetInterfaces().All(x => x.FullName != requiredInterfaceType.FullName))
                {
                    result.AddError($"Action type [{actionClass}] was created but this action doesn't support {nameof(IBapSupplierAction)}. Continue to next action class...");
                    continue;
                }

                IBapSupplierAction supplierAction = null;

                result.AddInfo($"Try to initialize [{actionClass}] action.");
                
                try
                {
                    if (_dependencyResolver == null)
                    {
                        result.AddInfo($"Dependency resolver is NULL. Using parameterless constructor to create instance of action type [{actionClass}]");
                        supplierAction = Activator.CreateInstance(supplierActionType) as IBapSupplierAction;
                    }
                    else
                        supplierAction = _dependencyResolver.GetService(supplierActionType) as IBapSupplierAction;
                }
                catch (Exception e)
                {
                    result.AddError($"Internal error while creating [{actionClass}]. Exception message: {e.Message}.");
                    result.AddError($"Instance of [{actionClass}] was not created. Continue to next action class...");
                    
                    continue;
                }
                
                if (supplierAction == null)
                {
                    result.AddError($"Instance of [{actionClass}] was not created. Continue to next action class...");
                
                    continue;
                }
                
                result.AddInfo($"Instance of [{actionClass}] action was successfully initialized.");
                
                if (!condition.Invoke(supplierAction))
                {
                    // because action doesn't meet required condition => skip it
                    result.AddInfo($"Action [{actionClass}] doesn't meet passed condition. Skip this action and continue...");
                    continue;
                }
                
                result.AddInfo($"Start execution of [{actionClass}].");

                try
                {
                    var actionResult = supplierAction.ExecuteAction(supplier.ExecutionConfig, actionArguments);
                    result.MergeWith(actionResult);
                }
                catch (Exception e)
                {
                    result.AddError($"Exception while execution action [{actionClass}]");
                    result.AddError($"Exception message: {e.Message}");
                    result.AddError($"Exception stacktrace: {e.StackTrace}");
                }
                finally
                { 
                    result.AddInfo($"Finish execution of [{actionClass}].");
                }
                
            }
            
            result.AddInfo($"End of {nameof(TriggerSupplierActions)}");

            return result;
        }

        
        /// <summary>
        /// Use this to provide correct dependency resolver
        /// </summary>
        /// <param name="dependencyResolver"></param>
        public static void RegisterDependencyResolver(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }
    }
}