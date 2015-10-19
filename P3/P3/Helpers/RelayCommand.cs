using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Diagnostics;

namespace P3.Helpers
{

     /// <summary>
     /// This is a rather extensive RelayCommand implementation. We will probably make our own at some point.
     /// 
     /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly bool _RunOnBackGroudThread;
        /// <summary>
        /// Predicate that that evaluates if this command can be executed
        /// </summary>
        private readonly Predicate<object> _CanExecutePredicate;
        /// <summary>
        /// Action to be taken when this command is executed
        /// </summary>
        private readonly Action<object> _ExecuteAction;
        /// <summary>
        /// Run when action method is complete and run on a seperate thread
        /// </summary>
        private readonly Action<object> _ExecuteActionComplete;
 
 
 
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="canExecutePredicate">The can execute predicate.</param>
        /// <param name="executeAction">The execute action.</param>
        /// <param name="executeActionComplete">The execute action complete.</param>
        public RelayCommand(Predicate<object> canExecutePredicate, Action<object> executeAction, Action<object> executeActionComplete)
            : this(canExecutePredicate, executeAction, true)
        {
            if (executeActionComplete == null)
            {
                throw new ArgumentNullException("executeActionComplete");
            }
            _ExecuteActionComplete = executeActionComplete;
        }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="canExecutePredicate">The can execute predicate.</param>
        /// <param name="executeAction">The execute action.</param>
        /// <param name="runOnBackGroundTread">if set to <c>true</c> [run on back ground tread].</param>
        public RelayCommand(Predicate<object> canExecutePredicate, Action<object> executeAction, bool runOnBackGroundTread)
            : this(canExecutePredicate, executeAction)
        {
            _RunOnBackGroudThread = runOnBackGroundTread;
        }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="canExecutePredicate">The can execute predicate.</param>
        /// <param name="executeAction">The execute action.</param>
        public RelayCommand(Predicate<object> canExecutePredicate, Action<object> executeAction)
        {
            if (canExecutePredicate == null)
            {
                throw new ArgumentNullException("canExecutePredicate");
            }
 
            if (executeAction == null)
            {
                throw new ArgumentNullException("executeAction");
            }
 
            _CanExecutePredicate = canExecutePredicate;
            _ExecuteAction = executeAction;
        }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The execute action.</param>
        public RelayCommand(Action<object> executeAction)
            : this(n => true, executeAction)
        {
 
        }
 
 
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
 
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return _CanExecutePredicate(parameter);
        }
 
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
                if (!_RunOnBackGroudThread)
                {
                    _ExecuteAction(parameter);
                }
                else
                {
                    if (_ExecuteActionComplete != null)
                    {
                        //Run with continuation
                        var context = TaskScheduler.FromCurrentSynchronizationContext();
                        Task.Factory.StartNew(_ExecuteAction, parameter).ContinueWith(_ExecuteActionComplete, context);
                    }
                    else
                    {
                        //Run as fire and forget
                        Task.Factory.StartNew(_ExecuteAction, parameter);
                    }
                }
        }
    }
}
