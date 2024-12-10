﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZQH.Abp.Notifications;

public class UserNotificationGetByNameDto
{
    [Required]
    [StringLength(NotificationConsts.MaxNameLength)]
    [DisplayName("Notifications:Name")]
    public string NotificationName { get; set; }
}