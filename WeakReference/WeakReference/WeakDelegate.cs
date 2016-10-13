using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WeakReferences
{
    class WeakDelegate
    {
        WeakReference weakReference;
        MethodInfo methodInfo;
        CreateNewDelegate newDelegate;

        public WeakDelegate(Delegate currentDelegate)
        {
            weakReference = new WeakReference(currentDelegate.Target);
            methodInfo = currentDelegate.Method;
            newDelegate = new CreateNewDelegate();
        }

        public bool IsDelegateAlive 
        { 
            get 
            { 
                return weakReference.IsAlive; 
            } 
        }

        public Delegate Weak 
        { 
            get 
            { 
                return newDelegate.SetNewDelegate(methodInfo, weakReference); 
            } 
        }
        
        private class CreateNewDelegate
        {
            private MethodInfo delegate_MethodInfo;
            private WeakReference delegate_WeakReference;
           
            private Type GetDelegateType()
            {
                var delegateArguments = new List<Type>(delegate_MethodInfo.GetParameters().Select(param => param.ParameterType));
                delegateArguments.Add(delegate_MethodInfo.ReturnType);

                return Expression.GetDelegateType(delegateArguments.ToArray());
            }

            private ParameterExpression[] GetDelegateParameters() 
            {
                return delegate_MethodInfo.GetParameters().Select(parameters => Expression.Parameter(parameters.ParameterType)).ToArray();
            }

            private Delegate DelegateInfo()
            {
                var delegateParameters = GetDelegateParameters();
                return Expression.Lambda(GetDelegateType(), BlockDelegateAction(delegateParameters), delegateParameters).Compile();
            }

            public Delegate SetNewDelegate(MethodInfo methodInfo, WeakReference weakReference)
            {
                this.delegate_MethodInfo = methodInfo;
                this.delegate_WeakReference = weakReference;
                return DelegateInfo();
            }

            private MemberExpression GetDelegateTarget() 
            {
                return Expression.Property(Expression.Convert(Expression.Constant(delegate_WeakReference), typeof(WeakReference)), "Target");
            }

            private MemberExpression GetDelegateIsAlive() 
            {
                return Expression.Property(Expression.Convert(Expression.Constant(delegate_WeakReference), typeof(WeakReference)), "IsAlive");
            }

            private MethodCallExpression CallDelegate(ParameterExpression[] parameters) 
            {
                return Expression.Call(instance: Expression.Convert(GetDelegateTarget(), delegate_MethodInfo.DeclaringType), method: delegate_MethodInfo, arguments: parameters);
            }

            private Expression[] CallDelegateAction(ParameterExpression[] parameters) 
            { 
                return new Expression[] 
                { 
                    CallDelegate(parameters) 
                }; 
            }

            private ConditionalExpression BlockDelegateAction(ParameterExpression[] parameters) 
            {
                return Expression.IfThen(Expression.IsTrue(GetDelegateIsAlive()), Expression.Block(GetArgumentList(parameters), CallDelegateAction(parameters))); 
            }

            private List<ParameterExpression> GetArgumentList(ParameterExpression[] argumentsType) 
            {
                return new List<ParameterExpression>(argumentsType.Select(argument => Expression.Variable(argument.Type)));
            }
        } 
    }
}