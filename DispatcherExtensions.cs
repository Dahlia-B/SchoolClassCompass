using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ClassCompass.Utilities;

internal static class DispatcherExtensions
{
    public static IDispatcher FindDispatcher(this BindableObject? bindableObject)
    {
        // 1. Try to get the dispatcher for the current thread
        var threadDispatcher = Dispatcher.GetForCurrentThread();
        if (threadDispatcher is not null)
            return threadDispatcher;

        // 2. Try to get dispatcher from Application.Current
        var appDispatcher = Application.Current?.Dispatcher;
        if (appDispatcher is not null)
            return appDispatcher;

        // 3. Try to get the dispatcher from the BindableObject if it's VisualElement
        if (bindableObject is VisualElement ve && ve.Dispatcher is not null)
            return ve.Dispatcher;

        // 4. All attempts failed
        throw new InvalidOperationException(
            "No dispatcher found. BindableObject must be instantiated on a thread with a dispatcher or Application.Current must be set.");
    }

    public static void DispatchIfRequired(this IDispatcher? dispatcher, Action action)
    {
        dispatcher = EnsureDispatcher(dispatcher);
        if (dispatcher.IsDispatchRequired)
            dispatcher.Dispatch(action);
        else
            action();
    }

    public static Task DispatchIfRequiredAsync(this IDispatcher? dispatcher, Action action)
    {
        dispatcher = EnsureDispatcher(dispatcher);
        if (dispatcher.IsDispatchRequired)
            return dispatcher.DispatchAsync(action);

        action();
        return Task.CompletedTask;
    }

    public static Task DispatchIfRequiredAsync(this IDispatcher? dispatcher, Func<Task> action)
    {
        dispatcher = EnsureDispatcher(dispatcher);
        return dispatcher.IsDispatchRequired
            ? dispatcher.DispatchAsync(action)
            : action();
    }

    private static IDispatcher EnsureDispatcher(IDispatcher? dispatcher)
    {
        if (dispatcher is not null)
            return dispatcher;

        var threadDispatcher = Dispatcher.GetForCurrentThread();
        if (threadDispatcher is not null)
            return threadDispatcher;

        var appDispatcher = Application.Current?.Dispatcher;
        if (appDispatcher is not null)
            return appDispatcher;

        throw new InvalidOperationException(
            "No dispatcher found. Ensure this code is running on a UI thread with a dispatcher.");
    }
}
