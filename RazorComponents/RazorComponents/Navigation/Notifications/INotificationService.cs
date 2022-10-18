namespace CodeChops.Website.RazorComponents.Navigation.Notifications;

public interface INotificationService
{
	/// <summary>
	/// Shows a notification to the user. Multiple notifications can be added to the screen at once.
	/// By default, a notification will disappear after 5 seconds.
	/// </summary>
	/// <param name="message">Message displayed to the user, may contain HTML.</param>
	/// <param name="notificationSeverity">Severity determines the styling of the notification, e.g. error is red and success is green.</param>
	/// <param name="sticky">If set to true, the notification will not disappear automatically and the user has to dismiss it. The default value is false.</param>
	void Show(string message, NotificationSeverity notificationSeverity, bool sticky = false);
}