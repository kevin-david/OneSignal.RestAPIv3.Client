using System.Threading.Tasks;

namespace OneSignal.RestAPIv3.Client.Resources.Notifications
{
    /// <summary>
    /// Interface used to unify Notification Resource classes.
    /// </summary>
    public interface INotificationsResource
    {
        /// <summary>
        /// Creates a new notification.
        /// </summary>
        /// <param name="options">This parameter can contai variety of possible options used to create notification.</param>
        /// <returns>Returns result of notification create operation.</returns>
        NotificationCreateResult Create(NotificationCreateOptions options);

        /// <summary>
        /// Creates a new notification. Async version
        /// </summary>
        /// <param name="options">This parameter can contai variety of possible options used to create notification.</param>
        /// <returns>Returns result of notification create operation.</returns>
        Task<NotificationCreateResult> CreateAsync(NotificationCreateOptions options);

        /// <summary>
        /// Cancel notification  Stop a scheduled or currently outgoing notification
        /// </summary>
        /// <param name="options">This parameter contains the information required to cancel a scheduled notification</param>
        /// <returns>Returns result of notification cancel operation.</returns>
        NotificationCancelResult Cancel(NotificationCancelOptions options);

        /// <summary>
        /// Cancel notification  Stop a scheduled or currently outgoing notification. Async version
        /// </summary>
        /// <param name="options">This parameter contains the information required to cancel a scheduled notification</param>
        /// <returns>Returns result of notification cancel operation.</returns>
        Task<NotificationCancelResult> CancelAsync(NotificationCancelOptions options);

        /// <summary>
        /// Get report about notification
        /// </summary>
        /// <param name="options">This parameter can contai variety of possible options used to create notification.</param>
        /// <returns>Returns result of notification create operation.</returns>
        NotificationViewResult View(NotificationViewOptions options);

        /// <summary>
        /// Get report about notification. Async version
        /// </summary>
        /// <param name="options">This parameter can contai variety of possible options used to create notification.</param>
        /// <returns>Returns result of notification create operation.</returns>
        Task<NotificationViewResult> ViewAsync(NotificationViewOptions options);
    }
}
