using Microsoft.AspNetCore.Components;

namespace eBook.Components.Events;

[EventHandler("onanimationend", typeof(EventArgs),
    enableStopPropagation: true, enablePreventDefault: false)]
public static class EventHandlers
{
}
