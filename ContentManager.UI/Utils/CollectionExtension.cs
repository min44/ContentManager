using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ContentManager.UI.Utils;

public static class CollectionExtension
{
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
    {
        return new ObservableCollection<T>(collection);
    }
}