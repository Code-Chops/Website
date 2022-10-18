namespace CodeChops.Website.RazorComponents.Navigation.Notifications;

public class NotificationService : INotificationService, IDisposable
{
	private ISnackbar Snackbar { get; }

	public NotificationService(ISnackbar snackbar)
	{
		this.Snackbar = snackbar;
	}

	public void Show(string message, NotificationSeverity notificationSeverity, bool sticky)
	{
		var severity = Enum.Parse<Severity>(notificationSeverity.ToString());

		this.Snackbar.Add(message, severity, config => { config.RequireInteraction = sticky; });
	}

	public void Dispose()
	{
		this.Snackbar.Dispose();
	}
}

public static class NotificationServiceExtensions
{
	public static void ConfigureCustomSettings(this SnackbarConfiguration config)
	{
		config.PositionClass = Defaults.Classes.Position.TopCenter;
		config.PreventDuplicates = false;
		config.NewestOnTop = true;
		config.ShowCloseIcon = true;
		config.VisibleStateDuration = 5000;
		config.HideTransitionDuration = 100;
		config.ShowTransitionDuration = 500;
		config.SnackbarVariant = Variant.Filled;
	}
}